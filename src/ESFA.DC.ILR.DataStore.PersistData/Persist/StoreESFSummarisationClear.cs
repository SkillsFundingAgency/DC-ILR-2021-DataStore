using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;

namespace ESFA.DC.ILR.DataStore.PersistData.Persist
{
    public class StoreESFSummarisationClear : IStoreESFSummarisationClear
    {
        public async Task ClearAsync(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            using (SqlCommand sqlCommand = new SqlCommand(BuildDeleteESFFundingDataSql(dataStoreContext), sqlConnection, sqlTransaction))
            {
                await sqlCommand.ExecuteNonQueryAsync(cancellationToken);
            }
        }

        private string BuildDeleteESFFundingDataSql(IDataStoreContext dataStoreContext)
        {
            var academicYear = $"20{dataStoreContext.CollectionYear.Substring(0, 2)}/{dataStoreContext.CollectionYear.Substring(2, 2)}";

            return $"DELETE FROM [Current].[ESFFundingData] WHERE UKPRN = {dataStoreContext.Ukprn} AND AcademicYear = '{academicYear}' AND CollectionReturnCode = '{dataStoreContext.CollectionPeriod}'";
        }
    }
}
