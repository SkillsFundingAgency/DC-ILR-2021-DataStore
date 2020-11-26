using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.PersistData.Constants;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.PersistData.Transactions.ILR
{
    public class FM25Transation : ITableSetTransaction
    {
        private readonly IPersistenceService _persistenceService;
        private readonly ILogger _logger;

        public int TaskOrder => 4;

        public string TaskKey => TaskNameConstants.TaskStoreFM25Tables;

        public FM25Transation(
            IPersistenceService persistenceService,
            ILogger logger)
        {
            _persistenceService = persistenceService;
            _logger = logger;
        }

        public async Task WriteAsync(IDataStoreCache cache, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            await _persistenceService.PersistFM25DataAsync(cache, connection, transaction, cancellationToken);
            _logger.LogDebug("WriteToDEDS - ILR FM25 Data Stored");
        }
    }
}
