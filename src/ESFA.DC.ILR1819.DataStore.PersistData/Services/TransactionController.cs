using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR1819.DataStore.Dto;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services
{
    public class TransactionController : ITransactionController
    {
        private readonly PersistDataConfiguration _persistDataConfiguration;
        private readonly ILogger _logger;
        private readonly IEnumerable<IFundModelService> _fundModelServices;
        private readonly IStoreFileDetails _storeFileDetails;
        private readonly IStoreIlr _storeIlr;
        private readonly IStoreValidationOutput _storeValidationOutput;
        private readonly IStoreClear _storeClearIlr;
        private readonly IStoreFM36HistoryClear _storeClearFM36;
        private readonly IStoreFM36HistoryService _storeFM36HistoryService;

        public TransactionController(
            PersistDataConfiguration persistDataConfiguration,
            ILogger logger,
            IEnumerable<IFundModelService> fundModelServices,
            IStoreFileDetails storeFileDetails,
            IStoreIlr storeIlr,
            IStoreValidationOutput storeValidationOutput,
            IStoreClear storeClearIlr,
            IStoreFM36HistoryClear storeClearFM36,
            IStoreFM36HistoryService storeFM36HistoryService)
        {
            _persistDataConfiguration = persistDataConfiguration;
            _logger = logger;
            _fundModelServices = fundModelServices;
            _storeFileDetails = storeFileDetails;
            _storeIlr = storeIlr;
            _storeValidationOutput = storeValidationOutput;
            _storeClearIlr = storeClearIlr;
            _storeClearFM36 = storeClearFM36;
            _storeFM36HistoryService = storeFM36HistoryService;
        }

        public async Task<bool> WriteToDeds(IDataStoreContext dataStoreContext, CancellationToken cancellationToken, Message message, List<string> validLearners, FM36Global fm36Global)
        {
            // Create the TransactionScope to execute the commands, guaranteeing
            // that both commands can commit or roll back as a single unit of work.
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 25, 0), TransactionScopeAsyncFlowOption.Enabled))
            {
                using (SqlConnection ilrConnection = new SqlConnection(_persistDataConfiguration.ILRDataStoreConnectionString))
                {
                    await ilrConnection.OpenAsync(cancellationToken);

                    cancellationToken.ThrowIfCancellationRequested();

                    await _storeClearIlr.ClearAsync(dataStoreContext, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR Data cleared");

                    await _storeFileDetails.StoreAsync(dataStoreContext, ilrConnection, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR File Details Stored");

                    cancellationToken.ThrowIfCancellationRequested();

                    await _storeIlr.StoreAsync(dataStoreContext, ilrConnection, message, validLearners, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR Data Stored");

                    cancellationToken.ThrowIfCancellationRequested();

                    foreach (var fundModelService in _fundModelServices)
                    {
                        await fundModelService.GetAndStoreFundModel(dataStoreContext, ilrConnection, cancellationToken);

                        cancellationToken.ThrowIfCancellationRequested();
                    }

                    _logger.LogDebug("WriteToDEDS - ILR FundModel Data Stored");

                    await _storeValidationOutput.StoreAsync(dataStoreContext, ilrConnection, dataStoreContext.Ukprn, message, cancellationToken);
                    _logger.LogDebug("WriteToDEDS - ILR Validation Output Data Stored");

                    // Nest the FM36History store so that the ILR data has to be successful
                    using (SqlConnection fm36HistoryConnection = new SqlConnection(_persistDataConfiguration.AppEarnHistoryDataStoreConnectionString))
                    {
                        await fm36HistoryConnection.OpenAsync();

                        cancellationToken.ThrowIfCancellationRequested();

                        _logger.LogDebug("WriteToDEDS FM36 History Started");

                        await _storeClearFM36.ClearAsync(dataStoreContext, fm36HistoryConnection, cancellationToken);
                        _logger.LogDebug("FM36 History Clean Up successful");

                        await _storeFM36HistoryService.StoreAsync(dataStoreContext, fm36HistoryConnection, fm36Global, cancellationToken);
                        _logger.LogDebug("FM36 History persistance complete");
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