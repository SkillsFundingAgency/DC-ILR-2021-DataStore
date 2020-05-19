using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.PersistData.Constants;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.PersistData.Transactions.ILR
{
    public class FM70Transation : ITableSetTransaction
    {
        private readonly IPersistenceService _persistenceService;
        private readonly ILogger _logger;

        public int TaskOrder => 7;

        public string TaskKey => TaskNameConstants.TaskStoreFM70Tables;

        public FM70Transation(
            IPersistenceService persistenceService,
            ILogger logger)
        {
            _persistenceService = persistenceService;
            _logger = logger;
        }

        public async Task WriteAsync(IDataStoreCache cache, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            await _persistenceService.PersistFM70DataAsync(cache, connection, transaction, cancellationToken);
            _logger.LogDebug("WriteToDEDS - ILR FM70 Data Stored");
        }
    }
}
