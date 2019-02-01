using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.Dto;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services
{
    public class FM36HistoryTransactionController : IFM36HistoryTransactionController
    {
        private readonly PersistDataConfiguration _persistDataConfiguration;
        private readonly ILogger _logger;
        private readonly IStoreFM36HistoryClear _storeClear;
        private readonly IStoreFM36HistoryService<FM36Global> _storeFM36HistoryService;

        public FM36HistoryTransactionController(
            PersistDataConfiguration persistDataConfiguration,
            ILogger logger,
            IStoreFM36HistoryClear storeClear,
            IStoreFM36HistoryService<FM36Global> storeFM36HistoryService)
        {
            _persistDataConfiguration = persistDataConfiguration;
            _logger = logger;
            _storeClear = storeClear;
            _storeFM36HistoryService = storeFM36HistoryService;
        }

        public async Task<bool> WriteToDeds(IDataStoreContext dataStoreContext, CancellationToken cancellationToken, FM36Global fm36Global)
        {
            var ukPrn = dataStoreContext.Ukprn;

            bool successfullyCommitted = false;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_persistDataConfiguration.AppEarnHistoryDataStoreConnectionString))
                {
                    await sqlConnection.OpenAsync(cancellationToken);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        _logger.LogDebug("WriteToDEDS exiting with cancellation request");
                        return false;
                    }

                    using (var sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        try
                        {
                            await _storeClear.ClearAsync(dataStoreContext, sqlTransaction, cancellationToken);
                            _logger.LogDebug("FM36 History Clean Up successful");

                            await _storeFM36HistoryService.StoreAsync(dataStoreContext, sqlTransaction, fm36Global, cancellationToken);

                            if (cancellationToken.IsCancellationRequested)
                            {
                                sqlTransaction.Rollback();
                                _logger.LogDebug("WriteToDEDS FM36 History exiting with cancellation request");
                                return false;
                            }

                            sqlTransaction.Commit();
                            successfullyCommitted = true;
                            _logger.LogDebug("FM36 History persisted successfully");
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError("WriteToDEDS FM36 Failed to persist to DEDs", ex);
                        }
                        finally
                        {
                            if (!successfullyCommitted)
                            {
                                _logger.LogDebug("Not successfully commited trying to rollback");
                                try
                                {
                                    sqlTransaction?.Rollback();
                                }
                                catch (Exception ex2)
                                {
                                    _logger.LogError("Failed to rollback DEDs persist transaction", ex2);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.LogError("FM36 History Transaction Controller Transactional Exception", exception);
                throw;
            }

            return successfullyCommitted;
        }
    }
}
