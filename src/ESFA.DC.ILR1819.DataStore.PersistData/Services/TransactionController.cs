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
        private readonly IValidationErrorsService _validationErrorsService;
        private readonly ILogger _logger;
        private readonly ILearnerValidDataBuilder _learnerValidDataBuilder;
        private readonly ILearnerInvalidDataBuilder _learnerInvalidDataBuilder;
        private readonly IList<IModelService> _modelServices;

        public TransactionController(
            PersistDataConfiguration persistDataConfiguration,
            IValidationErrorsService validationErrorsService,
            ILogger logger,
            ILearnerValidDataBuilder learnerValidDataBuilder,
            ILearnerInvalidDataBuilder learnerInvalidDataBuilder,
            IList<IModelService> modelServices)
        {
            _persistDataConfiguration = persistDataConfiguration;
            _validationErrorsService = validationErrorsService;
            _logger = logger;
            _learnerValidDataBuilder = learnerValidDataBuilder;
            _learnerInvalidDataBuilder = learnerInvalidDataBuilder;

            _modelServices = modelServices;
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

            using (SqlConnection connection =
                new SqlConnection(_persistDataConfiguration.ILRDataStoreConnectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    List<Task> tasks = new List<Task>();

                    await connection.OpenAsync(cancellationToken);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        _logger.LogDebug("WriteToDEDS exiting with cancellation request");
                        return false;
                    }

                    _logger.LogDebug("WriteToDEDS beginning transaction");
                    transaction = connection.BeginTransaction();

                    _logger.LogDebug("WriteToDEDS clearing data");
                    StoreClear storeClear = new StoreClear(connection, transaction);
                    await storeClear.ClearAsync(ukPrn, Path.GetFileName(ilrFilename), cancellationToken);
                    _logger.LogDebug("WriteToDEDS building storage tasks");

                    StoreFileDetails storeFileDetails =
                        new StoreFileDetails(
                            connection,
                            transaction,
                            jobContextMessage);
                    Task storeFileDetailsTask = storeFileDetails.StoreAsync(cancellationToken);
                    tasks.Add(storeFileDetailsTask);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        _logger.LogDebug("WriteToDEDS exiting with cancellation request");
                        return false;
                    }

                    _logger.LogDebug("WriteToDEDS building store ILR tasks");
                    StoreIlr storeIlr = new StoreIlr(
                        connection,
                        transaction,
                        jobContextMessage,
                        _learnerValidDataBuilder,
                        _learnerInvalidDataBuilder);
                    Task storeIlrTask =
                        storeIlr.StoreAsync(message, validLearners, cancellationToken);
                    tasks.Add(storeIlrTask);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        _logger.LogDebug("WriteToDEDS exiting with cancellation request");
                        return false;
                    }

                    _logger.LogDebug($"WriteToDEDS building store model tasks {_modelServices.Count}");

                    foreach (var service in _modelServices)
                    {
                        Task modelTask = Task.CompletedTask;
                        bool success = await service.GetModel(jobContextMessage, cancellationToken);
                        if (!success)
                        {
                            _logger.LogDebug($"Failed to get model so not storing");
                            continue;
                        }

                        _logger.LogDebug($"WriteToDEDS adding store model task");
                        modelTask = service.StoreModel(connection, transaction, cancellationToken);

                        tasks.Add(modelTask);

                        if (cancellationToken.IsCancellationRequested)
                        {
                            _logger.LogDebug("WriteToDEDS exiting with cancellation request");
                            return false;
                        }
                    }

                    _logger.LogDebug("WriteToDEDS building store validation tasks");

                    StoreValidationOutput storeValidationOutput =
                        new StoreValidationOutput(connection, transaction, jobContextMessage, _validationErrorsService);
                    Task storeValidationOutputTask =
                        storeValidationOutput.StoreAsync(ukPrn, message, cancellationToken);
                    tasks.Add(storeValidationOutputTask);

                    _logger.LogDebug($"WriteToDEDS has {tasks.Count} tasks to perform");

                    await Task.WhenAll(tasks);

                    _logger.LogDebug("WriteToDEDS Transaction to be commited");
                    transaction.Commit();
                    _logger.LogDebug("WriteToDEDS Transaction has commited");
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
                            transaction?.Rollback();
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
