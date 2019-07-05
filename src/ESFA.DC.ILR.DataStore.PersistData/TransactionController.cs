using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.PersistData
{
    public class TransactionController : ITransactionController
    {
        private readonly IDataStorePersistenceService _dataStorePersistenceService;
        private readonly IPersistenceService _persistenceService;
        private readonly ILogger _logger;

        public TransactionController(
            IDataStorePersistenceService dataStorePersistenceService,
            IPersistenceService persistenceService,
            ILogger logger)
        {
            _dataStorePersistenceService = dataStorePersistenceService;
            _persistenceService = persistenceService;
            _logger = logger;
        }

        public async Task<bool> WriteAsync(IDataStoreContext dataStoreContext, IDataStoreCache cache, CancellationToken cancellationToken)
        {
            // Create the TransactionScope to execute the commands, guaranteeing
            // that both commands can commit or roll back as a single unit of work.
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 25, 0), TransactionScopeAsyncFlowOption.Enabled))
            {
                using (SqlConnection ilrConnection = new SqlConnection(dataStoreContext.IlrDatabaseConnectionString))
                {
                    await ilrConnection.OpenAsync(cancellationToken);

                    cancellationToken.ThrowIfCancellationRequested();

                    await _dataStorePersistenceService.ClearIlrDataAsync(dataStoreContext, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR Data cleared");
                    cancellationToken.ThrowIfCancellationRequested();

                    await  _persistenceService.PersistProcessingInformationDataAsync(cache, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR File Details Stored");
                    cancellationToken.ThrowIfCancellationRequested();

                    await _persistenceService.PersistInvalidLearnerDataAsync(cache, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR Invalid Learner Data Stored");
                    cancellationToken.ThrowIfCancellationRequested();

                    await _persistenceService.PersistValidLearnerDataAsync(cache, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR Valid Learner Data Stored");
                    cancellationToken.ThrowIfCancellationRequested();

                    await _persistenceService.PersistALBDataAsync(cache, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR ALB Data Stored");
                    await _persistenceService.PersistFM25DataAsync(cache, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR FM25 Data Stored");
                    await _persistenceService.PersistFM35DataAsync(cache, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR FM35 Data Stored");
                    await _persistenceService.PersistFM36DataAsync(cache, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR FM36 Data Stored");
                    await _persistenceService.PersistFM70DataAsync(cache, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR FM70 Data Stored");
                    await _persistenceService.PersistFM81DataAsync(cache, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR FM81 Data Stored");

                    await  _persistenceService.PersistValidationDataAsync(cache, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR Validation Output Data Stored");

                    cancellationToken.ThrowIfCancellationRequested();

                    //Nest the FM36History store so that the ILR data has to be successful
                    //using (SqlConnection fm36HistoryConnection = new SqlConnection(dataStoreContext.AppEarnHistoryDatabaseConnectionString))
                    //{
                    //    await fm36HistoryConnection.OpenAsync(cancellationToken);

                    //    cancellationToken.ThrowIfCancellationRequested();
                    //    _logger.LogDebug("WriteToDEDS FM36 History Started");

                    //    await _dataStorePersistenceService.ClearFm36HistoryDataAsync(dataStoreContext, fm36HistoryConnection, cancellationToken);
                    //    _logger.LogDebug("FM36 History Clean Up successful");

                    //    await _persistenceService.PersistFM36HistoryDataAsync(dataStoreDataCache.FM36HistoryData, fm36HistoryConnection, cancellationToken);
                    //    _logger.LogDebug("FM36 History persistence complete");
                    //}

                    //_logger.LogDebug("FM36 History Transaction complete");
                }

                // The Complete method commits the transaction. If an exception has been thrown,
                // Complete is not called and the transaction is rolled back.
                scope.Complete();
            }

            _logger.LogDebug("ILR Transaction complete");
            return true;
        }
    }
}