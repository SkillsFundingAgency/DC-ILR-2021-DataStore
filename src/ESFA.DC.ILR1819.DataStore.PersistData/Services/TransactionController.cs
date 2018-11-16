using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly IEnumerable<IModelService> _modelServices;
        private readonly IStoreFileDetails _storeFileDetails;
        private readonly IStoreIlr _storeIlr;
        private readonly IStoreValidationOutput _storeValidationOutput;
        private readonly IStoreClear _storeClear;

        public TransactionController(
            PersistDataConfiguration persistDataConfiguration,
            ILogger logger,
            IEnumerable<IModelService> modelServices,
            IStoreFileDetails storeFileDetails,
            IStoreIlr storeIlr,
            IStoreValidationOutput storeValidationOutput,
            IStoreClear storeClear)
        {
            _persistDataConfiguration = persistDataConfiguration;
            _logger = logger;
            _modelServices = modelServices;
            _storeFileDetails = storeFileDetails;
            _storeIlr = storeIlr;
            _storeValidationOutput = storeValidationOutput;
            _storeClear = storeClear;
        }

        public async Task<bool> WriteToDeds(IDataStoreContext dataStoreContext, CancellationToken cancellationToken, Message message, List<string> validLearners)
        {
            var ukPrn = dataStoreContext.Ukprn;
            var originalFileName = dataStoreContext.OriginalFilename;

            bool successfullyCommitted = false;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_persistDataConfiguration.ILRDataStoreConnectionString))
                {
                    List<Task> tasks = new List<Task>();

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
                            await _storeClear.ClearAsync(sqlConnection, sqlTransaction, ukPrn, originalFileName, cancellationToken);

                            Task storeFileDetailsTask = _storeFileDetails.StoreAsync(dataStoreContext, sqlConnection, sqlTransaction, cancellationToken);
                            tasks.Add(storeFileDetailsTask);

                            if (cancellationToken.IsCancellationRequested)
                            {
                                _logger.LogDebug("WriteToDEDS exiting with cancellation request");
                                return false;
                            }

                            Task storeIlrTask = _storeIlr.StoreAsync(dataStoreContext, sqlConnection, sqlTransaction, message, validLearners, cancellationToken);
                            tasks.Add(storeIlrTask);

                            if (cancellationToken.IsCancellationRequested)
                            {
                                _logger.LogDebug("WriteToDEDS exiting with cancellation request");
                                return false;
                            }

                            foreach (var modelService in _modelServices)
                            {
                                var modelServiceTask = modelService.GetAndStoreModel(dataStoreContext, sqlConnection, sqlTransaction, cancellationToken);

                                tasks.Add(modelServiceTask);

                                if (cancellationToken.IsCancellationRequested)
                                {
                                    _logger.LogDebug("WriteToDEDS exiting with cancellation request");
                                    return false;
                                }
                            }

                            Task storeValidationOutputTask = _storeValidationOutput.StoreAsync(dataStoreContext, sqlConnection, sqlTransaction, ukPrn, message, cancellationToken);
                            tasks.Add(storeValidationOutputTask);

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
                _logger.LogError("Transaction Controller Transactional Exception", exception);
                throw;
            }

            return successfullyCommitted;
        }
    }
}
