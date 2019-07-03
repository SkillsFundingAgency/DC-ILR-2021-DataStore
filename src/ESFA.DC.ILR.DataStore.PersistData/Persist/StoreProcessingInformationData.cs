using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.File;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.PersistData.Persist
{
    public sealed class StoreProcessingInformationData : IStoreService<ProcessingInformationData>
    {
        public async Task StoreAsync(ProcessingInformationData model, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            long fileDetailsId;

            using (SqlCommand sqlCommand = new SqlCommand(BuildInsertFileDetailsSql(model.FileDetail), sqlConnection))
            {
                fileDetailsId = (long)await sqlCommand.ExecuteScalarAsync(cancellationToken);
            }

            using (SqlCommand sqlCommand = new SqlCommand(BuildInsertProcessingDataSql(fileDetailsId, model.ProcessingData), sqlConnection))
            {
                await sqlCommand.ExecuteNonQueryAsync(cancellationToken);
            }
        }

        private string BuildInsertFileDetailsSql(FileDetail fileDetail)
        {
            return $"INSERT INTO [dbo].[FileDetails] ([UKPRN], [Filename], [FileSizeKb], [TotalLearnersSubmitted], [TotalValidLearnersSubmitted], [TotalInvalidLearnersSubmitted], [TotalErrorCount], [TotalWarningCount], [SubmittedTime], [Success]) output INSERTED.ID VALUES ({fileDetail.UKPRN}, '{fileDetail.Filename}', {fileDetail.FileSizeKb}, {fileDetail.TotalLearnersSubmitted}, {fileDetail.TotalValidLearnersSubmitted}, {fileDetail.TotalInvalidLearnersSubmitted}, {fileDetail.TotalErrorCount}, {fileDetail.TotalWarningCount}, '{fileDetail.SubmittedTime:yyyy/MM/dd HH:mm:ss}', 1)";
        }

        private string BuildInsertProcessingDataSql(long fileDetailsId, ProcessingData processingData)
        {
            return $"INSERT INTO [dbo].[ProcessingData] ([UKPRN], [FileDetailsID], [ProcessingStep], [ExecutionTime]) VALUES ({processingData.UKPRN}, {fileDetailsId}, '{processingData.ProcessingStep}', '{processingData.ExecutionTime}')";
        }
    }
}
