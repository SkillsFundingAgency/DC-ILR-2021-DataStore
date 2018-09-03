using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.JobContext.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public sealed class StoreFileDetails : IStoreFileDetails
    {
        private readonly SqlConnection _sqlConnection;

        private readonly SqlTransaction _sqlTransaction;

        private readonly IJobContextMessage _jobContextMessage;

        public StoreFileDetails(SqlConnection sqlConnection, SqlTransaction sqlTransaction, IJobContextMessage jobContextMessage)
        {
            _sqlConnection = sqlConnection;
            _sqlTransaction = sqlTransaction;
            _jobContextMessage = jobContextMessage;
        }

        public async Task StoreAsync(CancellationToken cancellationToken)
        {
            GetAndCheckValues(out var ukPrn, out var fileSizeInBytes, out var validLearnRefNumbersCount, out var invalidLearnRefNumbersCount, out var validationTotalErrorCount, out var validationTotalWarningCount);
            await StoreAsync(ukPrn, fileSizeInBytes, validLearnRefNumbersCount, invalidLearnRefNumbersCount, validationTotalErrorCount, validationTotalWarningCount, cancellationToken);
        }

        private void GetAndCheckValues(out int ukPrn, out long fileSizeInBytes, out int validLearnRefNumbersCount, out int invalidLearnRefNumbersCount, out int validationTotalErrorCount, out int validationTotalWarningCount)
        {
            if (!_jobContextMessage.KeyValuePairs.ContainsKey(JobContextMessageKey.UkPrn) || !int.TryParse(_jobContextMessage.KeyValuePairs[JobContextMessageKey.UkPrn].ToString(), out ukPrn))
            {
                throw new ArgumentException($"{nameof(JobContextMessageKey.UkPrn)} is expected to be a number");
            }

            if (!_jobContextMessage.KeyValuePairs.ContainsKey(JobContextMessageKey.FileSizeInBytes) || !long.TryParse(_jobContextMessage.KeyValuePairs[JobContextMessageKey.FileSizeInBytes].ToString(), out fileSizeInBytes))
            {
                throw new ArgumentException($"{nameof(JobContextMessageKey.FileSizeInBytes)} is expected to be a number");
            }

            if (!_jobContextMessage.KeyValuePairs.ContainsKey(JobContextMessageKey.ValidLearnRefNumbersCount) || !int.TryParse(_jobContextMessage.KeyValuePairs[JobContextMessageKey.ValidLearnRefNumbersCount].ToString(), out validLearnRefNumbersCount))
            {
                throw new ArgumentException($"{nameof(JobContextMessageKey.ValidLearnRefNumbersCount)} is expected to be a number");
            }

            if (!_jobContextMessage.KeyValuePairs.ContainsKey(JobContextMessageKey.InvalidLearnRefNumbersCount) || !int.TryParse(_jobContextMessage.KeyValuePairs[JobContextMessageKey.InvalidLearnRefNumbersCount].ToString(), out invalidLearnRefNumbersCount))
            {
                throw new ArgumentException($"{nameof(JobContextMessageKey.InvalidLearnRefNumbersCount)} is expected to be a number");
            }

            if (!_jobContextMessage.KeyValuePairs.ContainsKey(JobContextMessageKey.ValidationTotalErrorCount) || !int.TryParse(_jobContextMessage.KeyValuePairs[JobContextMessageKey.ValidationTotalErrorCount].ToString(), out validationTotalErrorCount))
            {
                throw new ArgumentException($"{nameof(JobContextMessageKey.ValidationTotalErrorCount)} is expected to be a number");
            }

            if (!_jobContextMessage.KeyValuePairs.ContainsKey(JobContextMessageKey.ValidationTotalWarningCount) || !int.TryParse(_jobContextMessage.KeyValuePairs[JobContextMessageKey.ValidationTotalWarningCount].ToString(), out validationTotalWarningCount))
            {
                throw new ArgumentException($"{nameof(JobContextMessageKey.ValidationTotalWarningCount)} is expected to be a number");
            }
        }

        private async Task StoreAsync(
            int ukPrn,
            long fileSizeInBytes,
            int validLearnRefNumbersCount,
            int invalidLearnRefNumbersCount,
            int validationTotalErrorCount,
            int validationTotalWarningCount,
            CancellationToken cancellationToken)
        {
            FileDetail fileDetails = new FileDetail
            {
                UKPRN = ukPrn,
                Filename = Path.GetFileName(_jobContextMessage.KeyValuePairs[JobContextMessageKey.Filename].ToString()),
                SubmittedTime = _jobContextMessage.SubmissionDateTimeUtc,
                FileSizeKb = fileSizeInBytes / 1024,
                Success = true,
                TotalLearnersSubmitted = validLearnRefNumbersCount + invalidLearnRefNumbersCount,
                TotalInvalidLearnersSubmitted = invalidLearnRefNumbersCount,
                TotalValidLearnersSubmitted = validLearnRefNumbersCount,
                TotalErrorCount = validationTotalErrorCount,
                TotalWarningCount = validationTotalWarningCount
            };

            ProcessingData processingData = new ProcessingData
            {
                UKPRN = ukPrn,
                ExecutionTime = _jobContextMessage.SubmissionDateTimeUtc.Subtract(DateTime.UtcNow)
                    .ToString(@"dd\.hh\:mm\:ss"),
                ProcessingStep = "End"
            };

            string insertFileDetails =
                    $"INSERT INTO [dbo].[FileDetails] ([UKPRN], [Filename], [FileSizeKb], [TotalLearnersSubmitted], [TotalValidLearnersSubmitted], [TotalInvalidLearnersSubmitted], [TotalErrorCount], [TotalWarningCount], [SubmittedTime], [Success]) output INSERTED.ID VALUES ({fileDetails.UKPRN}, '{fileDetails.Filename}', {fileDetails.FileSizeKb}, {fileDetails.TotalLearnersSubmitted}, {fileDetails.TotalValidLearnersSubmitted}, {fileDetails.TotalInvalidLearnersSubmitted}, {fileDetails.TotalErrorCount}, {fileDetails.TotalWarningCount}, '{fileDetails.SubmittedTime:yyyy/MM/dd HH:mm:ss}', 1)";

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            using (SqlCommand sqlCommand =
                new SqlCommand(insertFileDetails, _sqlConnection, _sqlTransaction))
            {
                processingData.FileDetailsID = (long)await sqlCommand.ExecuteScalarAsync(cancellationToken);
            }

            string insertProcessingData = $"INSERT INTO [dbo].[ProcessingData] ([UKPRN], [FileDetailsID], [ProcessingStep], [ExecutionTime]) VALUES ({processingData.UKPRN}, {processingData.FileDetailsID}, '{processingData.ProcessingStep}', '{processingData.ExecutionTime}')";

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            using (SqlCommand sqlCommand =
                new SqlCommand(insertProcessingData, _sqlConnection, _sqlTransaction))
            {
                await sqlCommand.ExecuteNonQueryAsync(cancellationToken);
            }
        }
    }
}
