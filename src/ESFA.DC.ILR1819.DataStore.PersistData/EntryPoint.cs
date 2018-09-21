using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    /// <summary>
    /// Entry point to the application. This class contains the job context callback.
    /// </summary>
    public sealed class EntryPoint
    {
        private readonly ILearnerPersistence _learnerPersistence;
        private readonly IILRProviderService _ilrProviderService;
        private readonly IValidLearnerProviderService _validLearnerProviderService;
        private readonly IALBProviderService _albProviderService;
        private readonly IFM25ProviderService _fm25ProviderService;
        private readonly ILogger _logger;

        public EntryPoint(
            ILearnerPersistence learnerPersistence,
            IILRProviderService ilrProviderService,
            IValidLearnerProviderService validLearnerProviderService,
            IALBProviderService albProviderService,
            IFM25ProviderService fm25ProviderService,
            ILogger logger)
        {
            _learnerPersistence = learnerPersistence;
            _ilrProviderService = ilrProviderService;
            _validLearnerProviderService = validLearnerProviderService;
            _albProviderService = albProviderService;
            _fm25ProviderService = fm25ProviderService;
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
            Task<Message> messageTask = _ilrProviderService.ReadAndDeserialiseIlrAsync(ilrFilename, cancellationToken);
            Task<List<string>> validLearnersTask = _validLearnerProviderService.ReadAndDeserialiseValidLearnersAsync(jobContextMessage, cancellationToken);

            Task<ALBFundingOutputs> fundingOutputTask = _albProviderService.ReadAndDeserialiseFileAsync(jobContextMessage, cancellationToken);
            Task<Global> fm25OutputTask = _fm25ProviderService.ReadAndDeserialiseFileAsync(jobContextMessage, cancellationToken);

            await Task.WhenAll(messageTask, fundingOutputTask, validLearnersTask, fm25OutputTask);

            if (messageTask.Result == null)
            {
                return false;
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return false;
            }

            if (!await _learnerPersistence.WriteToDeds(
                jobContextMessage,
                cancellationToken,
                ilrFilename,
                messageTask.Result,
                fundingOutputTask.Result,
                fm25OutputTask.Result,
                validLearnersTask.Result))
            {
                _logger.LogError("write to DataStore failed");
                return false;
            }

            _logger.LogDebug($"Persisted to DEDs in: {stopWatch.ElapsedMilliseconds}");
            stopWatch.Restart();

            await DeletePersistedData(jobContextMessage);
            _logger.LogDebug($"Purged IO in: {stopWatch.ElapsedMilliseconds}");
            _logger.LogDebug("Completed DataStore callback");

            return true;
        }

        private async Task DeletePersistedData(IJobContextMessage jobContextMessage)
        {
            try
            {
                foreach (KeyValuePair<string, object> keyValuePair in jobContextMessage.KeyValuePairs)
                {
                    string key = keyValuePair.Value?.ToString();
                    if (string.IsNullOrEmpty(key))
                    {
                        continue;
                    }

                    try
                    {
                        // Todo: Turn this back on
                        // await _redis.RemoveAsync(key);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Failed to delete key {key}", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to delete persisted data", ex);
            }
        }
    }
}
