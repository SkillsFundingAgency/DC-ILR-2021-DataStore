using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
        private readonly IEnumerable<ITableSetTransaction> _ilrTransactions;
        private readonly ILogger _logger;

        public ILRTransaction(
            IDataStorePersistenceService dataStorePersistenceService,
            IPersistenceService persistenceService,
            IEnumerable<ITableSetTransaction> ilrTransactions,
            ILogger logger)
        {
            _dataStorePersistenceService = dataStorePersistenceService;
            _persistenceService = persistenceService;
            _ilrTransactions = ilrTransactions;
            _logger = logger;
        }

        public async Task WriteILRDataAsync(IDataStoreContext dataStoreContext, IDataStoreCache cache, CancellationToken cancellationToken)
        {
            var transactions = _ilrTransactions
                .Where(t => dataStoreContext.Tasks.Contains(t.TaskKey, StringComparer.OrdinalIgnoreCase))
                .OrderBy(t => t.TaskOrder);

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

                        foreach (var transaction in transactions)
                        {
                            await transaction.WriteAsync(cache, ilrConnection, ilrTransaction, cancellationToken);
                        }

                        cancellationToken.ThrowIfCancellationRequested();

                        ilrTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"ILR Transaction failed attempting to rollback - {ex.Message}", ex);

                        ilrTransaction.Rollback();

                        _logger.LogDebug("ILR Transaction successfully rolled back");

                        throw;
                    }

                    _logger.LogDebug("ILR Transaction complete");
                }
            }
        }
    }
}
