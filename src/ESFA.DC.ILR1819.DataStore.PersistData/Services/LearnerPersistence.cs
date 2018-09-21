using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationErrors.Interface;
using ESFA.DC.ILR1819.DataStore.Dto;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services
{
    public class LearnerPersistence : ILearnerPersistence
    {
        private readonly PersistDataConfiguration _persistDataConfiguration;
        private readonly IValidationErrorsService _validationErrorsService;
        private readonly ILogger _logger;
        private readonly ILearnerValidDataBuilder _learnerValidDataBuilder;
        private readonly ILearnerInvalidDataBuilder _learnerInvalidDataBuilder;

        public LearnerPersistence(
            PersistDataConfiguration persistDataConfiguration,
            IValidationErrorsService validationErrorsService,
            ILogger logger,
            ILearnerValidDataBuilder learnerValidDataBuilder,
            ILearnerInvalidDataBuilder learnerInvalidDataBuilder)
        {
            _persistDataConfiguration = persistDataConfiguration;
            _validationErrorsService = validationErrorsService;
            _logger = logger;
            _learnerValidDataBuilder = learnerValidDataBuilder;
            _learnerInvalidDataBuilder = learnerInvalidDataBuilder;
        }

        public async Task<bool> WriteToDeds(
            IJobContextMessage jobContextMessage,
            CancellationToken cancellationToken,
            string ilrFilename,
            Message message,
            ALBFundingOutputs fundingOutput,
            Global fm25FundingOutput,
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
                    await connection.OpenAsync(cancellationToken);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        return false;
                    }

                    transaction = connection.BeginTransaction();

                    StoreClear storeClear = new StoreClear(connection, transaction);
                    await storeClear.ClearAsync(ukPrn, Path.GetFileName(ilrFilename), cancellationToken);

                    StoreFileDetails storeFileDetails =
                        new StoreFileDetails(
                            connection,
                            transaction,
                            jobContextMessage);
                    Task storeFileDetailsTask = storeFileDetails.StoreAsync(cancellationToken);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        return false;
                    }

                    StoreIlr storeIlr = new StoreIlr(
                        connection,
                        transaction,
                        jobContextMessage,
                        _learnerValidDataBuilder,
                        _learnerInvalidDataBuilder);
                    Task storeIlrTask =
                        storeIlr.StoreAsync(message, validLearners, cancellationToken);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        return false;
                    }

                    Task storeRuleAlbTask = Task.CompletedTask;
                    if (fundingOutput != null && fundingOutput.Global != null)
                    {
                        StoreRuleAlb storeRuleAlb = new StoreRuleAlb(connection, transaction);
                        storeRuleAlbTask =
                            storeRuleAlb.StoreAsync(ukPrn, fundingOutput, cancellationToken);

                        if (cancellationToken.IsCancellationRequested)
                        {
                            return false;
                        }
                    }

                    Task storeFM25Task = Task.CompletedTask;
                    if (fm25FundingOutput != null)
                    {
                        StoreFM25 store = new StoreFM25(connection, transaction);
                        storeFM25Task =
                            store.StoreAsync(ukPrn, fm25FundingOutput, cancellationToken);

                        if (cancellationToken.IsCancellationRequested)
                        {
                            return false;
                        }
                    }

                    StoreValidationOutput storeValidationOutput =
                        new StoreValidationOutput(connection, transaction, jobContextMessage, _validationErrorsService);
                    Task storeValidationOutputTask =
                        storeValidationOutput.StoreAsync(ukPrn, message, cancellationToken);

                    await Task.WhenAll(
                        storeFileDetailsTask,
                        storeIlrTask,
                        storeRuleAlbTask,
                        storeFM25Task,
                        storeValidationOutputTask);

                    transaction.Commit();
                    successfullyCommitted = true;
                }
                catch (Exception ex)
                {
                    _logger.LogError("Failed to persist to DEDs", ex);
                }
                finally
                {
                    if (!successfullyCommitted)
                    {
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
