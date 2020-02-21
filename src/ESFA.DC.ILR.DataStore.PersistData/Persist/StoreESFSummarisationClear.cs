using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.PersistData.Helpers;

namespace ESFA.DC.ILR.DataStore.PersistData.Persist
{
    public class StoreESFSummarisationClear : IStoreESFSummarisationClear
    {
        public async Task ClearAsync(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            var academicYear = $"20{dataStoreContext.CollectionYear.Substring(0, 2)}/{dataStoreContext.CollectionYear.Substring(2, 2)}";
            var collectionType = $"ILR{dataStoreContext.CollectionYear}";

            using (SqlCommand sqlCommand = new SqlCommand(BuildDeleteESFDataSql(), sqlConnection, sqlTransaction))
            {
                sqlCommand.Parameters.AddWithNullableValue("@UKPRN", dataStoreContext.Ukprn);
                sqlCommand.Parameters.AddWithNullableValue("@AcademicYear", academicYear);
                sqlCommand.Parameters.AddWithNullableValue("@CollectionReturnCode", dataStoreContext.CollectionPeriod);
                sqlCommand.Parameters.AddWithNullableValue("@CollectionType", collectionType);
                sqlCommand.CommandTimeout = 600;

                await sqlCommand.ExecuteNonQueryAsync(cancellationToken);
            }
        }

        private string BuildDeleteESFDataSql()
        {
            return @"DELETE FROM [Current].[ESFFundingData] 
                     WHERE UKPRN = @UKPRN AND AcademicYear = @AcademicYear AND CollectionReturnCode = @CollectionReturnCode

                     DELETE FROM [Current].[LatestProviderSubmission] 
                     WHERE UKPRN = @UKPRN AND CollectionType = @CollectionType AND CollectionReturnCode = @CollectionReturnCode";
        }
    }
}
