using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.PersistData.Constants;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.PersistData.Transactions.ILR
{
    public class FM35Transation : ITableSetTransaction
    {
        private readonly IPersistenceService _persistenceService;
        private readonly ILogger _logger;

        public int TaskOrder => 5;

        public string TaskKey => TaskNameConstants.TaskStoreFM35Tables;

        public FM35Transation(
            IPersistenceService persistenceService,
            ILogger logger)
        {
            _persistenceService = persistenceService;
            _logger = logger;
        }

        public async Task WriteAsync(IDataStoreCache cache, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            await _persistenceService.PersistFM35DataAsync(cache, connection, transaction, cancellationToken);
            _logger.LogDebug("WriteToDEDS - ILR FM35 Data Stored");
        }
    }
}
