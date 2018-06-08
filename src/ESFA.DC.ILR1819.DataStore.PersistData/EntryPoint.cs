using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.AttributeFilters;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationErrors.Interface;
using ESFA.DC.ILR.ValidationErrors.Interface.Models;
using ESFA.DC.ILR1819.DataStore.Dto;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    /// <summary>
    /// Entry point to the application. This class contains the job context callback.
    /// </summary>
    public sealed class EntryPoint
    {
        private readonly PersistDataConfiguration _persistDataConfiguration;

        private readonly IKeyValuePersistenceService _storage;

        private readonly IKeyValuePersistenceService _redis;

        private readonly ISerializationService _xmlSerializationService;

        private readonly ISerializationService _jsonSerializationService;

        private readonly IValidationErrorsService _validationErrorsService;

        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntryPoint"/> class.
        /// </summary>
        /// <param name="persistDataConfiguration">The configuration for this class (DB connection string).</param>
        /// <param name="storage">The Azure Storage IO layer.</param>
        /// <param name="redis">The Redis IO layer.</param>
        /// <param name="xmlSerializationService">The XML serialization service.</param>
        /// <param name="jsonSerializationService">The JSON serialization service,</param>
        /// <param name="validationErrorsService">The validation errors service.</param>
        /// <param name="logger">The logger.</param>
        public EntryPoint(
            PersistDataConfiguration persistDataConfiguration,
            [KeyFilter(PersistenceStorageKeys.Blob)] IKeyValuePersistenceService storage,
            [KeyFilter(PersistenceStorageKeys.Redis)] IKeyValuePersistenceService redis,
            IXmlSerializationService xmlSerializationService,
            IJsonSerializationService jsonSerializationService,
            IValidationErrorsService validationErrorsService,
            ILogger logger)
        {
            _persistDataConfiguration = persistDataConfiguration;
            _storage = storage;
            _redis = redis;
            _xmlSerializationService = xmlSerializationService;
            _jsonSerializationService = jsonSerializationService;
            _validationErrorsService = validationErrorsService;
            _logger = logger;
        }

        /// <summary>
        /// Callback from Job Context Manager.
        /// </summary>
        /// <param name="jobContextMessage">The job context message.</param>
        /// <param name="cancellationToken">The callback cancellation token.</param>
        /// <returns>True if the callback succeeded, or false if the callback failed.</returns>
        public async Task<bool> Callback(IJobContextMessage jobContextMessage, CancellationToken cancellationToken)
        {
            var stopWatch = new Stopwatch();
            _logger.LogDebug("Inside DataStore callback");
            string ilrFilename = jobContextMessage.KeyValuePairs[JobContextMessageKey.Filename].ToString();

            stopWatch.Start();
            Task<Message> messageTask = ReadAndDeserialiseIlrAsync(ilrFilename);
            Task<FundingOutputs> fundingOutputTask = ReadAndDeserialiseAlbAsync(jobContextMessage);
            Task<List<string>> validLearnersTask = ReadAndDeserialiseValidLearnersAsync(jobContextMessage);
            Task<List<ValidationErrorDto>> validationErrorDto = ReadAndDeserialiseValidationErrorsAsync(jobContextMessage);

            if (!await WriteToDeds(
                jobContextMessage,
                cancellationToken,
                ilrFilename,
                messageTask,
                fundingOutputTask,
                validLearnersTask,
                validationErrorDto))
            {
                _logger.LogError("write to DataStore failed");
                return false;
            }

            _logger.LogDebug($"Persisted to DEDs in: {stopWatch.ElapsedMilliseconds}");
            stopWatch.Restart();

            await PeristValuesToStorage(jobContextMessage, validationErrorDto.Result);
            _logger.LogDebug($"Persisted validation errors to csv in: {stopWatch.ElapsedMilliseconds}");
            stopWatch.Restart();

            await DeletePersistedData(jobContextMessage);
            _logger.LogDebug($"Purged IO in: {stopWatch.ElapsedMilliseconds}");
            _logger.LogDebug("Completed DataStore callback");

            return true;
        }

        private async Task<bool> WriteToDeds(
            IJobContextMessage jobContextMessage,
            CancellationToken cancellationToken,
            string ilrFilename,
            Task<Message> messageTask,
            Task<FundingOutputs> fundingOutputTask,
            Task<List<string>> validLearnersTask,
            Task<List<ValidationErrorDto>> validationErrorDto)
        {
            int ukPrn = int.Parse(jobContextMessage.KeyValuePairs[JobContextMessageKey.UkPrn].ToString());

            using (SqlConnection connection =
                new SqlConnection(_persistDataConfiguration.ILRDataStoreConnectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    await connection.OpenAsync(cancellationToken);
                    if (cancellationToken.IsCancellationRequested)
                    {
                        return false;
                    }

                    transaction = connection.BeginTransaction();

                    StoreClear storeClear = new StoreClear(connection, transaction);
                    Task clearTask = storeClear.ClearAsync(ukPrn, Path.GetFileName(ilrFilename), cancellationToken);

                    await Task.WhenAll(messageTask, fundingOutputTask, validLearnersTask, validationErrorDto, clearTask);

                    StoreFileDetails storeFileDetails =
                        new StoreFileDetails(
                            connection,
                            transaction,
                            jobContextMessage);
                    Task storeFileDetailsTask = storeFileDetails.StoreAsync(cancellationToken);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        return false;
                    }

                    StoreIlr storeIlr = new StoreIlr(
                        connection,
                        transaction,
                        jobContextMessage);
                    Task storeIlrTask = storeIlr.StoreAsync(messageTask.Result, validLearnersTask.Result, cancellationToken);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        return false;
                    }

                    StoreRuleAlb storeRuleAlb = new StoreRuleAlb(connection, transaction);
                    Task storeRuleAlbTask = storeRuleAlb.StoreAsync(ukPrn, fundingOutputTask.Result, cancellationToken);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        return false;
                    }

                    StoreValidationOutput storeValidationOutput =
                        new StoreValidationOutput(connection, transaction, jobContextMessage, _validationErrorsService);
                    Task storeValidationOutputTask =
                        storeValidationOutput.StoreAsync(ukPrn, messageTask.Result, cancellationToken);

                    await Task.WhenAll(storeFileDetailsTask, storeIlrTask, storeRuleAlbTask, storeValidationOutputTask);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    _logger.LogError("Failed to persist to DEDs", ex);

                    try
                    {
                        transaction?.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        _logger.LogError("Failed to rollback DEDs persist transaction", ex2);
                    }

                    return false;
                }
            }

            return true;
        }

        private async Task PeristValuesToStorage(IJobContextMessage jobContextMessage, List<ValidationErrorDto> validationErrorDtos)
        {
            string key = await _redis.GetAsync(jobContextMessage.KeyValuePairs[JobContextMessageKey.ValidationErrors]
                .ToString());

            await _storage.SaveAsync($"{key}.json", _jsonSerializationService.Serialize(validationErrorDtos));
        }

        private async Task DeletePersistedData(IJobContextMessage jobContextMessage)
        {
            foreach (KeyValuePair<JobContextMessageKey, object> keyValuePair in jobContextMessage.KeyValuePairs)
            {
                string key = keyValuePair.Value.ToString();

                try
                {
                    await _redis.RemoveAsync(key);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Failed to delete key {key}", ex);
                }
            }
        }

        private async Task<List<ValidationErrorDto>> ReadAndDeserialiseValidationErrorsAsync(IJobContextMessage jobContextMessage)
        {
            string key = await _redis.GetAsync(jobContextMessage.KeyValuePairs[JobContextMessageKey.ValidationErrors]
                .ToString());

            List<ValidationErrorDto> validationErrorDto = _jsonSerializationService.Deserialize<List<ValidationErrorDto>>(key);
            return validationErrorDto;
        }

        private async Task<Message> ReadAndDeserialiseIlrAsync(string ilrFilename)
        {
            string ilr = await _storage.GetAsync(ilrFilename);

            Message message = _xmlSerializationService.Deserialize<Message>(ilr);
            return message;
        }

        private async Task<FundingOutputs> ReadAndDeserialiseAlbAsync(IJobContextMessage jobContextMessage)
        {
            string albFilename = jobContextMessage.KeyValuePairs[JobContextMessageKey.FundingAlbOutput].ToString();
            string alb = await _redis.GetAsync(albFilename);

            FundingOutputs fundingOutputs = _jsonSerializationService.Deserialize<FundingOutputs>(alb);
            return fundingOutputs;
        }

        private async Task<List<string>> ReadAndDeserialiseValidLearnersAsync(IJobContextMessage jobContextMessage)
        {
            string learnersValidStr = await _redis.GetAsync(jobContextMessage.KeyValuePairs[JobContextMessageKey.ValidLearnRefNumbers].ToString());
            List<string> validLearners = _jsonSerializationService.Deserialize<List<string>>(learnersValidStr);
            return validLearners;
        }
    }
}
