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
                    List<Task> tasks = new List<Task>();

                    await sqlConnection.OpenAsync(cancellationToken);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        _logger.LogDebug("WriteToDEDS exiting with cancellation request");
                        return false;
                    }

                    if (fm36Global == null || fm36Global.Learners == null)
                    {
                        _logger.LogDebug("FM36 output empty. No data to persist.");
                        return false;
                    }

                    using (var sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        try
                        {
                            await _storeClear.ClearAsync(dataStoreContext, sqlTransaction, cancellationToken);

                            Task storeHistoryTask = _storeFM36HistoryService.StoreAsync(dataStoreContext, sqlTransaction, fm36Global, cancellationToken);
                            tasks.Add(storeHistoryTask);

                            if (cancellationToken.IsCancellationRequested)
                            {
                                _logger.LogDebug("WriteToDEDS exiting with cancellation request");
                                return false;
                            }

                            await Task.WhenAll(tasks);

                            sqlTransaction.Commit();
                            successfullyCommitted = true;
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError("WriteToDEDS Failed to persist to DEDs", ex);
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
