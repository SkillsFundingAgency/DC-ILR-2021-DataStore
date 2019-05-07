using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using ESFA.DC.ILR.DataStore.Dto;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public class TransactionController : ITransactionController
    {
        private readonly PersistDataConfiguration _persistDataConfiguration;
        private readonly IDataStorePersistenceService _dataStorePersistenceService;
        private readonly ILogger _logger;

        public TransactionController(
            PersistDataConfiguration persistDataConfiguration,
            IDataStorePersistenceService dataStorePersistenceService,
            ILogger logger)
        {
            _persistDataConfiguration = persistDataConfiguration;
            _dataStorePersistenceService = dataStorePersistenceService;
            _logger = logger;
        }

        public async Task<bool> WriteAsync(IDataStoreContext dataStoreContext, IDataStoreDataCache dataStoreDataCache, CancellationToken cancellationToken)
        {
            // Create the TransactionScope to execute the commands, guaranteeing
            // that both commands can commit or roll back as a single unit of work.
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 25, 0), TransactionScopeAsyncFlowOption.Enabled))
            {
                using (SqlConnection ilrConnection = new SqlConnection(_persistDataConfiguration.ILRDataStoreConnectionString))
                {
                    await ilrConnection.OpenAsync(cancellationToken);

                    cancellationToken.ThrowIfCancellationRequested();

                    await _dataStorePersistenceService.ClearIlrDataAsync(dataStoreContext, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR Data cleared");
                    cancellationToken.ThrowIfCancellationRequested();

                    await _dataStorePersistenceService.StoreProcessingInformationDataAsync(dataStoreDataCache.ProcessingInformation, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR File Details Stored");
                    cancellationToken.ThrowIfCancellationRequested();

                    await _dataStorePersistenceService.StoreInvalidHeaderDataAsync(dataStoreDataCache.InvalidHeaderData, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR Invalid Header Data Stored");
                    cancellationToken.ThrowIfCancellationRequested();

                    await _dataStorePersistenceService.StoreInvalidLearnerDataAsync(dataStoreDataCache.InvalidLearnerData, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR Invalid Learner Data Stored");
                    cancellationToken.ThrowIfCancellationRequested();

                    await _dataStorePersistenceService.StoreValidHeaderDataAsync(dataStoreDataCache.ValidHeaderData, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR Valid Header Data Stored");
                    cancellationToken.ThrowIfCancellationRequested();

                    await _dataStorePersistenceService.StoreValidLearnerDataAsync(dataStoreDataCache.ValidLearnerData, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR Valid Learner Data Stored");
                    cancellationToken.ThrowIfCancellationRequested();

                    await _dataStorePersistenceService.StoreALBDataAsync(dataStoreDataCache.ALBData, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR ALB Data Stored");
                    await _dataStorePersistenceService.StoreFM25DataAsync(dataStoreDataCache.FM25Data, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR FM25 Data Stored");
                    await _dataStorePersistenceService.StoreFM35DataAsync(dataStoreDataCache.FM35Data, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR FM35 Data Stored");
                    await _dataStorePersistenceService.StoreFM36DataAsync(dataStoreDataCache.FM36Data, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR FM36 Data Stored");
                    await _dataStorePersistenceService.StoreFM70DataAsync(dataStoreDataCache.FM70Data, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR FM70 Data Stored");
                    await _dataStorePersistenceService.StoreFM81DataAsync(dataStoreDataCache.FM81Data, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR FM81 Data Stored");

                    await _dataStorePersistenceService.StoreValidationDataAsync(dataStoreDataCache.ValidationData, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR Validation Output Data Stored");

                    cancellationToken.ThrowIfCancellationRequested();

                    // Nest the FM36History store so that the ILR data has to be successful
                    using (SqlConnection fm36HistoryConnection = new SqlConnection(_persistDataConfiguration.AppEarnHistoryDataStoreConnectionString))
                    {
                        await fm36HistoryConnection.OpenAsync(cancellationToken);

                        cancellationToken.ThrowIfCancellationRequested();
                        _logger.LogDebug("WriteToDEDS FM36 History Started");

                        await _dataStorePersistenceService.ClearFm36HistoryDataAsync(dataStoreContext, fm36HistoryConnection, cancellationToken);
                        _logger.LogDebug("FM36 History Clean Up successful");

                        await _dataStorePersistenceService.StoreFM36HistoryDataAsync(dataStoreDataCache.FM36HistoryData, fm36HistoryConnection, cancellationToken);
                        _logger.LogDebug("FM36 History persistence complete");
                    }

                    _logger.LogDebug("FM36 History Transaction complete");
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