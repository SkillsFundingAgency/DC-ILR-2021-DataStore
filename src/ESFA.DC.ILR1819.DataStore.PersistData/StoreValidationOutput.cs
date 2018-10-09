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
using ValidationError = ESFA.DC.ILR1819.DataStore.EF.ValidationError;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public sealed class StoreValidationOutput : IStoreValidationOutput
    {
        private readonly SqlConnection _connection;

        private readonly SqlTransaction _transaction;

        private readonly IJobContextMessage _jobContextMessage;

        private readonly IValidationErrorsService _validationErrorsService;

        public StoreValidationOutput(
            SqlConnection connection,
            SqlTransaction transaction,
            IJobContextMessage jobContextMessage,
            IValidationErrorsService validationErrorsService)
        {
            _connection = connection;
            _transaction = transaction;
            _jobContextMessage = jobContextMessage;
            _validationErrorsService = validationErrorsService;
        }

        public async Task StoreAsync(int ukPrn, IMessage ilr, CancellationToken cancellationToken)
        {
            string validationErrorsStorageKey =
                _jobContextMessage.KeyValuePairs[JobContextMessageKey.ValidationErrors].ToString();
            string validationErrorsLookupStorageKey =
                _jobContextMessage.KeyValuePairs[JobContextMessageKey.ValidationErrorLookups].ToString();
            string filename = _jobContextMessage.KeyValuePairs[JobContextMessageKey.Filename].ToString();
            List<ValidationErrorDto> validationErrorDtos = (await _validationErrorsService.GetValidationErrorsAsync(
                validationErrorsStorageKey,
                validationErrorsLookupStorageKey)).ToList();
            List<ValidationError> validationErrors = new List<ValidationError>(validationErrorDtos.Count);

            foreach (ValidationErrorDto validationErrorDto in validationErrorDtos)
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
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            using (BulkInsert bulkInsert = new BulkInsert(_connection, _transaction, cancellationToken))
            {
                await bulkInsert.Insert("dbo.ValidationError", validationErrors);
            }
        }
    }
}
