using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    /// <summary>
    /// Entry point to the application. This class contains the job context callback.
    /// </summary>
    public sealed class EntryPoint : IEntryPoint
    {
        private readonly ITransactionController _transaction;
        private readonly IProviderService<Message> _ilrProviderService;
        private readonly IProviderService<FM36Global> _fm36ProviderService;
        private readonly IValidLearnerProviderService _validLearnerProviderService;
        private readonly ILogger _logger;

        public EntryPoint(
            ITransactionController transaction,
            IProviderService<Message> ilrProviderService,
            IProviderService<FM36Global> fm36ProviderService,
            IValidLearnerProviderService validLearnerProviderService,
            ILogger logger)
        {
            _transaction = transaction;
            _ilrProviderService = ilrProviderService;
            _fm36ProviderService = fm36ProviderService;
            _validLearnerProviderService = validLearnerProviderService;
            _logger = logger;
        }

        /// <summary>
        /// Callback from Job Context Manager.
        /// </summary>
        /// <param name="dataStoreContext">The dataStore context.</param>
        /// <param name="cancellationToken">The callback cancellation token.</param>
        /// <returns>True if the callback succeeded, or false if the callback failed.</returns>
        public async Task<bool> Callback(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            var stopWatch = new Stopwatch();
            _logger.LogDebug("Inside DataStore callback");
            string ilrFilename = dataStoreContext.Filename;

            try
            {
                stopWatch.Start();
                Task<Message> messageTask = _ilrProviderService.ProvideAsync(dataStoreContext, cancellationToken);
                Task<List<string>> validLearnersTask = _validLearnerProviderService.ReadAndDeserialiseValidLearnersAsync(dataStoreContext, cancellationToken);
                Task<FM36Global> fm36GlobalTask = _fm36ProviderService.ProvideAsync(dataStoreContext, cancellationToken);

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

                if (!await _transaction.WriteToDeds(dataStoreContext, cancellationToken, messageTask.Result, validLearnersTask.Result, fm36GlobalTask.Result))
                {
                    _logger.LogError("Write to DataStore failed");
                    return false;
                }

                _logger.LogDebug($"Persisted to DEDs in: {stopWatch.ElapsedMilliseconds}");
                stopWatch.Restart();

                _logger.LogDebug("Completed DataStore callback");
            }
            catch (Exception ex)
            {
                _logger.LogError($"DataStore callback exception {ex.Message}", ex);
            }

            return true;
        }
    }
}
