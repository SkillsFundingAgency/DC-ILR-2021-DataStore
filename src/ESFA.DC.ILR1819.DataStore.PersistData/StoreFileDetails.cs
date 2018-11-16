using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.DateTimeProvider.Interface;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public sealed class StoreFileDetails : IStoreFileDetails
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public StoreFileDetails(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task StoreAsync(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            await StoreAsync(
                dataStoreContext.OriginalFilename,
                dataStoreContext.SubmissionDateTimeUtc,
                dataStoreContext.Ukprn,
                dataStoreContext.FileSizeInBytes,
                dataStoreContext.ValidLearnRefNumbersCount,
                dataStoreContext.InvalidLearnRefNumbersCount,
                dataStoreContext.ValidationTotalErrorCount,
                dataStoreContext.ValidationTotalWarningCount,
                sqlConnection,
                sqlTransaction,
                cancellationToken);
        }

        private async Task StoreAsync(
            string fileName,
            DateTime? submissionDateTimeUtc,
            int ukPrn,
            long fileSizeInBytes,
            int validLearnRefNumbersCount,
            int invalidLearnRefNumbersCount,
            int validationTotalErrorCount,
            int validationTotalWarningCount,
            SqlConnection sqlConnection,
            SqlTransaction sqlTransaction,
            CancellationToken cancellationToken)
        {
            FileDetail fileDetails = new FileDetail
            {
                UKPRN = ukPrn,
                Filename = fileName,
                SubmittedTime = submissionDateTimeUtc,
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
                ExecutionTime = submissionDateTimeUtc.Value.Subtract(_dateTimeProvider.GetNowUtc())
                    .ToString(@"dd\.hh\:mm\:ss"),
                ProcessingStep = "End"
            };

            string insertFileDetails =
                    $"INSERT INTO [dbo].[FileDetails] ([UKPRN], [Filename], [FileSizeKb], [TotalLearnersSubmitted], [TotalValidLearnersSubmitted], [TotalInvalidLearnersSubmitted], [TotalErrorCount], [TotalWarningCount], [SubmittedTime], [Success]) output INSERTED.ID VALUES ({fileDetails.UKPRN}, '{fileDetails.Filename}', {fileDetails.FileSizeKb}, {fileDetails.TotalLearnersSubmitted}, {fileDetails.TotalValidLearnersSubmitted}, {fileDetails.TotalInvalidLearnersSubmitted}, {fileDetails.TotalErrorCount}, {fileDetails.TotalWarningCount}, '{fileDetails.SubmittedTime:yyyy/MM/dd HH:mm:ss}', 1)";

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            using (SqlCommand sqlCommand = new SqlCommand(insertFileDetails, sqlConnection, sqlTransaction))
            {
                processingData.FileDetailsID = (long)await sqlCommand.ExecuteScalarAsync(cancellationToken);
            }

            string insertProcessingData = $"INSERT INTO [dbo].[ProcessingData] ([UKPRN], [FileDetailsID], [ProcessingStep], [ExecutionTime]) VALUES ({processingData.UKPRN}, {processingData.FileDetailsID}, '{processingData.ProcessingStep}', '{processingData.ExecutionTime}')";

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            using (SqlCommand sqlCommand = new SqlCommand(insertProcessingData, sqlConnection, sqlTransaction))
            {
                await sqlCommand.ExecuteNonQueryAsync(cancellationToken);
            }
        }
    }
}
