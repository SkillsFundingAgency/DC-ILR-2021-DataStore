using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.PersistData
{
    /// <summary>
    /// Entry point to the application. This class contains the job context callback.
    /// </summary>
    public sealed class EntryPoint : IEntryPoint
    {
        private readonly ITransactionController _transaction;
        private readonly IDataStoreDataCacheProvider _dataStoreDataCacheProvider;
        private readonly ILogger _logger;

        public EntryPoint(
            ITransactionController transaction,
            IDataStoreDataCacheProvider dataStoreDataCacheProvider,
            ILogger logger)
        {
            _transaction = transaction;
            _dataStoreDataCacheProvider = dataStoreDataCacheProvider;
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

            try
            {
                stopWatch.Start();

                var dataStoreDataCache = await _dataStoreDataCacheProvider.ProvideAsync(dataStoreContext, cancellationToken);

                if (cancellationToken.IsCancellationRequested)
                {
                    _logger.LogDebug("DataStore callback cancelling before persistence");
                    return false;
                }

                if (!await _transaction.WriteAsync(dataStoreContext, dataStoreDataCache, cancellationToken))
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
                throw;
            }

            return true;
        }
    }
}
