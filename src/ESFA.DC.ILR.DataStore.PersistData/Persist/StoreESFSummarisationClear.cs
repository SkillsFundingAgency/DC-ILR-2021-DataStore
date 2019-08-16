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
            return $"DELETE FROM [dbo].[ESF_FundingData] WHERE UKPRN = {dataStoreContext.Ukprn} AND CollectionYear = {dataStoreContext.CollectionYear} AND CollectionPeriod = {dataStoreContext.ReturnPeriod}";
        }
    }
}
