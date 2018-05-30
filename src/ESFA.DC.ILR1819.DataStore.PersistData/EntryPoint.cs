using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
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
    public sealed class EntryPoint
    {
        private readonly PersistDataConfiguration _persistDataConfiguration;

        private readonly IKeyValuePersistenceService _storage;

        private readonly IKeyValuePersistenceService _persist;

        private readonly ISerializationService _xmlSerializationService;

        private readonly ISerializationService _jsonSerializationService;

        private readonly IValidationErrorsService _validationErrorsService;

        private readonly ILogger _logger;

        public EntryPoint(
            PersistDataConfiguration persistDataConfiguration,
            IKeyValuePersistenceService storage,
            IKeyValuePersistenceService persist,
            IXmlSerializationService xmlSerializationService,
            IJsonSerializationService jsonSerializationService,
            IValidationErrorsService validationErrorsService,
            ILogger logger)
        {
            _persistDataConfiguration = persistDataConfiguration;
            _storage = storage;
            _persist = persist;
            _xmlSerializationService = xmlSerializationService;
            _jsonSerializationService = jsonSerializationService;
            _validationErrorsService = validationErrorsService;
            _logger = logger;
        }

        public async Task<bool> Callback(IJobContextMessage jobContextMessage, CancellationToken cancellationToken)
        {
            int ukPrn = int.Parse(jobContextMessage.KeyValuePairs[JobContextMessageKey.UkPrn].ToString());
            string ilrFilename = jobContextMessage.KeyValuePairs[JobContextMessageKey.Filename].ToString();

            Task<Message> messageTask = ReadAndDeserialiseIlrAsync(ilrFilename);
            Task<FundingOutputs> fundingOutputTask = ReadAndDeserialiseAlbAsync(jobContextMessage);
            Task<List<string>> validLearnersTask = ReadAndDeserialiseValidLearnersAsync(jobContextMessage);
            Task<ValidationErrorDto> validationErrorDto = ReadAndDeserialiseValidationErrorsAsync(jobContextMessage);

            using (SqlConnection connection =
                new SqlConnection(_persistDataConfiguration.ConnectionString))
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

                    StoreValidationOutput storeValidationOutput = new StoreValidationOutput(connection, transaction, jobContextMessage, _validationErrorsService);
                    Task storeValidationOutputTask = storeValidationOutput.StoreAsync(ukPrn, messageTask.Result, cancellationToken);

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

                return true;
            }
        }

        private async Task<ValidationErrorDto> ReadAndDeserialiseValidationErrorsAsync(IJobContextMessage jobContextMessage)
        {
            string val = await _storage.GetAsync(jobContextMessage.KeyValuePairs[JobContextMessageKey.ValidationErrors]
                .ToString());

            ValidationErrorDto validationErrorDto = _jsonSerializationService.Deserialize<ValidationErrorDto>(val);
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
            string alb = await _persist.GetAsync(albFilename);

            FundingOutputs fundingOutputs = _jsonSerializationService.Deserialize<FundingOutputs>(alb);
            return fundingOutputs;
        }

        private async Task<List<string>> ReadAndDeserialiseValidLearnersAsync(IJobContextMessage jobContextMessage)
        {
            string learnersValidStr = await _persist.GetAsync(jobContextMessage.KeyValuePairs[JobContextMessageKey.ValidLearnRefNumbers].ToString());
            List<string> validLearners = _jsonSerializationService.Deserialize<List<string>>(learnersValidStr);
            return validLearners;
        }
    }
}
