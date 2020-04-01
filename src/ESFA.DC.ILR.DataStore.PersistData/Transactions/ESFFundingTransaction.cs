using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.PersistData.Transactions
{
    public class ESFFundingTransaction : IESFFundingTransaction
    {
        private readonly IDataStorePersistenceService _dataStorePersistenceService;
        private readonly IPersistenceService _persistenceService;
        private readonly ILogger _logger;

        public ESFFundingTransaction(
            IDataStorePersistenceService dataStorePersistenceService,
            IPersistenceService persistenceService,
            ILogger logger)
        {
            _dataStorePersistenceService = dataStorePersistenceService;
            _persistenceService = persistenceService;
            _logger = logger;
        }

        public async Task WriteESFFundingAsync(IDataStoreContext dataStoreContext, IDataStoreCache cache, CancellationToken cancellationToken)
        {
            using (SqlConnection esfFundingConnection = new SqlConnection(dataStoreContext.EsfFundingDatabaseConnectionString))
            {
                await esfFundingConnection.OpenAsync(cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                _logger.LogDebug("Starting ESF Funding Transaction");

                using (SqlTransaction esfFundingTransaction = esfFundingConnection.BeginTransaction())
                {
                    try
                    {
                        await _dataStorePersistenceService.ClearEsfSummarisationDataAsync(dataStoreContext, esfFundingConnection, esfFundingTransaction, cancellationToken);
                        _logger.LogDebug("ESF clean up successful");

                        await _persistenceService.PersistESFSummarisationDataAsync(cache, esfFundingConnection, esfFundingTransaction, cancellationToken);
                        _logger.LogDebug("ESF Funding persistence complete");

                        await _persistenceService.PersistESFLatestProviderSubmissionAsync(cache, esfFundingConnection, esfFundingTransaction, cancellationToken);
                        _logger.LogDebug("ESF Latest Provider Submission persistence complete");

                        esfFundingTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogDebug($"ESF Funding Transaction failed attempting to rollback - {ex.Message}");

                        esfFundingTransaction.Rollback();

                        _logger.LogDebug("ESF Funding Transaction successfully rolled back");

                        throw;
                    }

                    _logger.LogDebug("ESF Funding Transaction complete");
                }
            }
        }
    }
}
