using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationErrors.Interface;
using ESFA.DC.ILR.ValidationErrors.Interface.Models;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.JobContextManager.Model.Interface;
using ESFA.DC.Logging.Interfaces;
using ValidationError = ESFA.DC.ILR1819.DataStore.EF.ValidationError;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public sealed class StoreValidationOutput : IStoreValidationOutput
    {
        private readonly SqlConnection _connection;

        private readonly SqlTransaction _transaction;

        private readonly IJobContextMessage _jobContextMessage;

        private readonly IValidationErrorsService _validationErrorsService;

        private readonly ILogger _logger;

        public StoreValidationOutput(
            SqlConnection connection,
            SqlTransaction transaction,
            ILogger logger,
            IJobContextMessage jobContextMessage,
            IValidationErrorsService validationErrorsService)
        {
            _connection = connection;
            _transaction = transaction;
            _jobContextMessage = jobContextMessage;
            _validationErrorsService = validationErrorsService;
            _logger = logger;
        }

        public async Task StoreAsync(int ukPrn, IMessage ilr, CancellationToken cancellationToken)
        {
            _logger?.LogDebug("StoreValidationOutput.StoreAsync 1");
            string validationErrorsStorageKey =
                _jobContextMessage.KeyValuePairs[JobContextMessageKey.ValidationErrors].ToString();
            _logger?.LogDebug("StoreValidationOutput.StoreAsync 2");
            string validationErrorsLookupStorageKey =
                _jobContextMessage.KeyValuePairs[JobContextMessageKey.ValidationErrorLookups].ToString();
            _logger?.LogDebug("StoreValidationOutput.StoreAsync 3");
            string filename = _jobContextMessage.KeyValuePairs[JobContextMessageKey.Filename].ToString();
            _logger?.LogDebug("StoreValidationOutput.StoreAsync 4");
            List<ValidationErrorDto> validationErrorDtos = (await _validationErrorsService.GetValidationErrorsAsync(
                validationErrorsStorageKey,
                validationErrorsLookupStorageKey)).ToList();
            List<ValidationError> validationErrors = new List<ValidationError>(validationErrorDtos.Count);

            _logger?.LogDebug($"StoreValidationOutput.StoreAsync 5 {validationErrorDtos.Count}");
            long index = 0;
            foreach (ValidationErrorDto validationErrorDto in validationErrorDtos)
            {
                if (string.IsNullOrEmpty(validationErrorDto.Severity))
                {
                    _logger.LogDebug($"ValidationErrorDto {index} --> validation error");
                }

                try // Hal - trying to capture real data causing an error. Not necessarily intended for production code!
                {
                    validationErrors.Add(new ValidationError
                    {
                        UKPRN = ukPrn,
                        SWSupAimID = "Unknown",
                        FileLevelError = 1,
                        AimSeqNum = validationErrorDto.AimSequenceNumber,
                        ErrorMessage = validationErrorDto.ErrorMessage,
                        FieldValues = validationErrorDto.FieldValues,
                        LearnAimRef =
                            ilr.Learners.SingleOrDefault(x => x.LearnRefNumber == validationErrorDto.LearnerReferenceNumber)
                                ?.LearningDeliveries.SingleOrDefault(x => x.AimSeqNumber == validationErrorDto.AimSequenceNumber)
                                ?.LearnAimRef ?? "Unknown",
                        LearnRefNumber = validationErrorDto.LearnerReferenceNumber,
                        RuleName = validationErrorDto.RuleName,
                        Severity = validationErrorDto.Severity.Substring(0, 1),
                        Source = filename
                    });
                    ++index;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Index causing exception would be {index}", ex);
                }
            }

            _logger?.LogDebug("StoreValidationOutput.StoreAsync 6");
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            _logger?.LogDebug("StoreValidationOutput.StoreAsync 7");
            using (BulkInsert bulkInsert = new BulkInsert(_connection, _transaction, cancellationToken))
            {
                await bulkInsert.Insert("dbo.ValidationError", validationErrors);
            }

            _logger?.LogDebug("StoreValidationOutput.StoreAsync done");
        }
    }
}
