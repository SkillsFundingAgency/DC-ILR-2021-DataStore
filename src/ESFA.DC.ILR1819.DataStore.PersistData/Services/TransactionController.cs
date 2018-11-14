using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationErrors.Interface;
using ESFA.DC.ILR1819.DataStore.Dto;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.JobContextManager.Model.Interface;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services
{
    public class TransactionController : ITransactionController
    {
        private readonly PersistDataConfiguration _persistDataConfiguration;
        private readonly ILogger _logger;
        private readonly IList<IModelService> _modelServices;
        private readonly IStoreFileDetails _storeFileDetails;
        private readonly IStoreIlr _storeIlr;
        private readonly IStoreValidationOutput _storeValidationOutput;
        private readonly IStoreClear _storeClear;

        public TransactionController(
            PersistDataConfiguration persistDataConfiguration,
            ILogger logger,
            IList<IModelService> modelServices,
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

        public async Task<bool> WriteToDeds(
            IJobContextMessage jobContextMessage,
            CancellationToken cancellationToken,
            string ilrFilename,
            Message message,
            List<string> validLearners)
        {
            int ukPrn = int.Parse(jobContextMessage.KeyValuePairs[JobContextMessageKey.UkPrn].ToString());
            bool successfullyCommitted = false;

            using (SqlConnection sqlConnection = new SqlConnection(_persistDataConfiguration.ILRDataStoreConnectionString))
            {
                SqlTransaction sqlTransaction = null;

                try
                {
                    List<Task> tasks = new List<Task>();

                    await sqlConnection.OpenAsync(cancellationToken);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        _logger.LogDebug("WriteToDEDS exiting with cancellation request");
                        return false;
                    }

                    sqlTransaction = sqlConnection.BeginTransaction();

                    await _storeClear.ClearAsync(sqlConnection, sqlTransaction, ukPrn, Path.GetFileName(ilrFilename), cancellationToken);

                    Task storeFileDetailsTask = _storeFileDetails.StoreAsync(jobContextMessage, sqlConnection, sqlTransaction, cancellationToken);
                    tasks.Add(storeFileDetailsTask);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        _logger.LogDebug("WriteToDEDS exiting with cancellation request");
                        return false;
                    }

                    Task storeIlrTask = _storeIlr.StoreAsync(jobContextMessage, sqlConnection, sqlTransaction, message, validLearners, cancellationToken);
                    tasks.Add(storeIlrTask);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        _logger.LogDebug("WriteToDEDS exiting with cancellation request");
                        return false;
                    }

                    foreach (var service in _modelServices)
                    {
                        Task modelTask = Task.CompletedTask;
                        bool success = await service.GetModel(jobContextMessage, cancellationToken);
                        if (!success)
                        {
                            _logger.LogDebug($"Failed to get model so not storing");
                            continue;
                        }

                        modelTask = service.StoreModel(sqlConnection, sqlTransaction, cancellationToken);

                        tasks.Add(modelTask);

                        if (cancellationToken.IsCancellationRequested)
                        {
                            _logger.LogDebug("WriteToDEDS exiting with cancellation request");
                            return false;
                        }
                    }

                    Task storeValidationOutputTask = _storeValidationOutput.StoreAsync(jobContextMessage, sqlConnection, sqlTransaction, ukPrn, message, cancellationToken);
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

            return successfullyCommitted;
        }
    }
}
