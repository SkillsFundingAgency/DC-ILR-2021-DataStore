using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.PersistData.Constants;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.PersistData.Transactions.ILR
{
    public class ALBTransaction : ITableSetTransaction
    {
        private readonly IPersistenceService _persistenceService;
        private readonly ILogger _logger;

        public int TaskOrder => 3;

        public string TaskKey => TaskNameConstants.TaskStoreALBTables;

        public ALBTransaction(
            IPersistenceService persistenceService,
            ILogger logger)
        {
            _persistenceService = persistenceService;
            _logger = logger;
        }

        public async Task WriteAsync(IDataStoreCache cache, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            await _persistenceService.PersistALBDataAsync(cache, connection, transaction, cancellationToken);
            _logger.LogDebug("WriteToDEDS - ILR ALB Data Stored");
        }
    }
}
