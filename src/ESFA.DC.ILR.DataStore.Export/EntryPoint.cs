using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.Export
{
    public class EntryPoint : IExportEntryPoint
    {
        private readonly IExportTransactionController _transactionController;
        private readonly IDataStoreDataCacheProvider _dataStoreDataCacheProvider;
        private readonly ILogger _logger;

        public EntryPoint(IExportTransactionController transactionController, IDataStoreDataCacheProvider dataStoreDataCacheProvider, ILogger logger)
        {
            _transactionController = transactionController;
            _dataStoreDataCacheProvider = dataStoreDataCacheProvider;
            _logger = logger;
        }

        public async Task<bool> Callback(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            var stopWatch = new Stopwatch();
            _logger.LogDebug("Inside Mdb callback");

            try
            {
                stopWatch.Start();

                var dataStoreDataCache = await _dataStoreDataCacheProvider.ProvideAsync(dataStoreContext, cancellationToken);

                if (cancellationToken.IsCancellationRequested)
                {
                    _logger.LogDebug("DataStore callback cancelling before persistence");
                    return false;
                }

                if (!await _transactionController.WriteAsync(dataStoreContext, dataStoreDataCache, cancellationToken))
                {
                    _logger.LogError("Write to DataStore failed");
                    return false;
                }

                _logger.LogDebug($"Persisted to Mdb in: {stopWatch.ElapsedMilliseconds}");
                stopWatch.Restart();

                _logger.LogDebug("Completed Mdb callback");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mdb callback exception {ex.Message}", ex);
                throw;
            }

            return true;
        }
    }
}
