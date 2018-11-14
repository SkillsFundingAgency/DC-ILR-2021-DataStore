using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.JobContextManager.Model.Interface;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    /// <summary>
    /// Entry point to the application. This class contains the job context callback.
    /// </summary>
    public sealed class EntryPoint : IEntryPoint
    {
        private readonly ITransactionController _learnerPersistence;
        private readonly IILRProviderService _ilrProviderService;
        private readonly IValidLearnerProviderService _validLearnerProviderService;
        private readonly ILogger _logger;

        public EntryPoint(
            ITransactionController learnerPersistence,
            IILRProviderService ilrProviderService,
            IValidLearnerProviderService validLearnerProviderService,
            ILogger logger)
        {
            _learnerPersistence = learnerPersistence;
            _ilrProviderService = ilrProviderService;
            _validLearnerProviderService = validLearnerProviderService;
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

            try
            {
                stopWatch.Start();
                Task<Message> messageTask = _ilrProviderService.ReadAndDeserialiseIlrAsync(ilrFilename, cancellationToken);
                Task<List<string>> validLearnersTask = _validLearnerProviderService.ReadAndDeserialiseValidLearnersAsync(jobContextMessage, cancellationToken);

                await Task.WhenAll(messageTask, validLearnersTask);

                if (messageTask.Result == null)
                {
                    _logger.LogDebug("DataStore callback could not read file - exiting before persistence");
                    return false;
                }

                if (cancellationToken.IsCancellationRequested)
                {
                    _logger.LogDebug("DataStore callback cancelling before persistence");
                    return false;
                }

                if (!await _learnerPersistence.WriteToDeds(
                    jobContextMessage,
                    cancellationToken,
                    messageTask.Result,
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
            }
            catch (Exception ex)
            {
                _logger.LogError($"DataStore callback exception {ex.Message}", ex);
            }

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
                        // can't turn this back on in here. DS doesn't go last!
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
