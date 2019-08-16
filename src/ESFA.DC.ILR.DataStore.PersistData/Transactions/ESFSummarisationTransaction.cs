using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.PersistData.Transactions
{
    public class ESFSummarisationTransaction : IESFSummarisationTransaction
    {
        private readonly IDataStorePersistenceService _dataStorePersistenceService;
        private readonly IPersistenceService _persistenceService;
        private readonly ILogger _logger;

        public ESFSummarisationTransaction(
            IDataStorePersistenceService dataStorePersistenceService,
            IPersistenceService persistenceService,
            ILogger logger)
        {
            _dataStorePersistenceService = dataStorePersistenceService;
            _persistenceService = persistenceService;
            _logger = logger;
        }

        public async Task WriteESFSummarisationAsync(IDataStoreContext dataStoreContext, IDataStoreCache cache, CancellationToken cancellationToken)
        {
            using (SqlConnection esfSummarisationConnection = new SqlConnection(dataStoreContext.SummarisationDatabaseConnectionString))
            {
                await esfSummarisationConnection.OpenAsync(cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                _logger.LogDebug("Starting ESF Summarisation History Transaction");

                using (SqlTransaction esfSummarisationTransaction = esfSummarisationConnection.BeginTransaction())
                {
                    try
                    {
                        await _dataStorePersistenceService.ClearEsfSummarisationDataAsync(dataStoreContext, esfSummarisationConnection, esfSummarisationTransaction, cancellationToken);
                        _logger.LogDebug("ESF Summarisation clean up successful");

                        await _persistenceService.PersistESFSummarisationDataAsync(cache, esfSummarisationConnection, esfSummarisationTransaction, cancellationToken);
                        _logger.LogDebug("ESF Summarisation persistence complete");

                        esfSummarisationTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogDebug($"ESF Summarisation Transaction failed attempting to rollback - {ex.Message}");

                        esfSummarisationTransaction.Rollback();

                        _logger.LogDebug("ESF Summarisation Transaction successfully rolled back");

                        throw;
                    }

                    _logger.LogDebug("ESF Summarisation Transaction complete");
                }
            }
        }
    }
}
