using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.PersistData.Transactions
{
    public class ILRTransaction : IILRTransaction
    {
        private readonly IDataStorePersistenceService _dataStorePersistenceService;
        private readonly IPersistenceService _persistenceService;
        private readonly ILogger _logger;

        public ILRTransaction(
            IDataStorePersistenceService dataStorePersistenceService,
            IPersistenceService persistenceService,
            ILogger logger)
        {
            _dataStorePersistenceService = dataStorePersistenceService;
            _persistenceService = persistenceService;
            _logger = logger;
        }

        public async Task WriteILRDataAsync(IDataStoreContext dataStoreContext, IDataStoreCache cache, CancellationToken cancellationToken)
        {
            using (SqlConnection ilrConnection = new SqlConnection(dataStoreContext.IlrDatabaseConnectionString))
            {
                await ilrConnection.OpenAsync(cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                _logger.LogDebug("Starting ILR Transaction");

                using (SqlTransaction ilrTransaction = ilrConnection.BeginTransaction())
                {
                    try
                    {
                        await _dataStorePersistenceService.ClearIlrDataAsync(dataStoreContext, ilrConnection, ilrTransaction, cancellationToken);
                        _logger.LogDebug("WriteToDEDS - ILR Data cleared");
                        cancellationToken.ThrowIfCancellationRequested();

                        await _persistenceService.PersistProcessingInformationDataAsync(cache, ilrConnection, ilrTransaction, cancellationToken);
                        _logger.LogDebug("WriteToDEDS - ILR File Details Stored");
                        cancellationToken.ThrowIfCancellationRequested();

                        await _persistenceService.PersistInvalidLearnerDataAsync(cache, ilrConnection, ilrTransaction, cancellationToken);
                        _logger.LogDebug("WriteToDEDS - ILR Invalid Learner Data Stored");
                        cancellationToken.ThrowIfCancellationRequested();

                        await _persistenceService.PersistValidLearnerDataAsync(cache, ilrConnection, ilrTransaction, cancellationToken);
                        _logger.LogDebug("WriteToDEDS - ILR Valid Learner Data Stored");
                        cancellationToken.ThrowIfCancellationRequested();

                        await _persistenceService.PersistALBDataAsync(cache, ilrConnection, ilrTransaction, cancellationToken);
                        _logger.LogDebug("WriteToDEDS - ILR ALB Data Stored");
                        await _persistenceService.PersistFM25DataAsync(cache, ilrConnection, ilrTransaction, cancellationToken);
                        _logger.LogDebug("WriteToDEDS - ILR FM25 Data Stored");
                        await _persistenceService.PersistFM35DataAsync(cache, ilrConnection, ilrTransaction, cancellationToken);
                        _logger.LogDebug("WriteToDEDS - ILR FM35 Data Stored");
                        await _persistenceService.PersistFM36DataAsync(cache, ilrConnection, ilrTransaction, cancellationToken);
                        _logger.LogDebug("WriteToDEDS - ILR FM36 Data Stored");
                        await _persistenceService.PersistFM70DataAsync(cache, ilrConnection, ilrTransaction, cancellationToken);
                        _logger.LogDebug("WriteToDEDS - ILR FM70 Data Stored");
                        await _persistenceService.PersistFM81DataAsync(cache, ilrConnection, ilrTransaction, cancellationToken);
                        _logger.LogDebug("WriteToDEDS - ILR FM81 Data Stored");

                        await _persistenceService.PersistValidationDataAsync(cache, ilrConnection, ilrTransaction, cancellationToken);
                        _logger.LogDebug("WriteToDEDS - ILR Validation Output Data Stored");

                        cancellationToken.ThrowIfCancellationRequested();

                        ilrTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogDebug($"ILR Transaction failed attempting to rollback - {ex.Message}");

                        ilrTransaction.Rollback();

                        _logger.LogDebug("ILR Transaction successfully rolled back");
                    }
                }
            }
        }
    }
}
