using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.PersistData
{
    public class FM36HistoryTransactionController : IFM36HistoryTransactionController
    {
        private readonly IDataStorePersistenceService _dataStorePersistenceService;
        private readonly IPersistenceService _persistenceService;
        private readonly ILogger _logger;

        public FM36HistoryTransactionController(
            IDataStorePersistenceService dataStorePersistenceService,
            IPersistenceService persistenceService,
            ILogger logger)
        {
            _dataStorePersistenceService = dataStorePersistenceService;
            _persistenceService = persistenceService;
            _logger = logger;
        }

        public async Task WriteFM36HistoryAsync(IDataStoreContext dataStoreContext, IDataStoreCache cache, CancellationToken cancellationToken)
        {
            using (SqlConnection fm36HistoryConnection = new SqlConnection(dataStoreContext.AppEarnHistoryDatabaseConnectionString))
            {
                await fm36HistoryConnection.OpenAsync(cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();
                _logger.LogDebug("WriteToDEDS FM36 History Started");

                await _dataStorePersistenceService.ClearFm36HistoryDataAsync(dataStoreContext, fm36HistoryConnection, cancellationToken);
                _logger.LogDebug("FM36 History Clean Up successful");

                await _persistenceService.PersistFM36HistoryDataAsync(cache, fm36HistoryConnection, cancellationToken);
                _logger.LogDebug("FM36 History persistence complete");
            }

            _logger.LogDebug("FM36 History Transaction complete");
        }
    }
}
