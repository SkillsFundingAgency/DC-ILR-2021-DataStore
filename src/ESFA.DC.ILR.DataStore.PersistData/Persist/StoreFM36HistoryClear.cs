using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;

namespace ESFA.DC.ILR.DataStore.PersistData.Persist
{
    public sealed class StoreFM36HistoryClear : IStoreFM36HistoryClear
    {
        public async Task ClearAsync(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            using (SqlCommand sqlCommand =
                    new SqlCommand("[dbo].[PrepareForNewData]", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@pCollectionYear", SqlDbType.Int).Value = dataStoreContext.CollectionYear;
                    sqlCommand.Parameters.Add("@pCollectionReturnCode", SqlDbType.VarChar).Value = "R" + dataStoreContext.ReturnCode;
                    sqlCommand.Parameters.Add("@pukprn", SqlDbType.Int).Value = dataStoreContext.Ukprn;
                    sqlCommand.CommandTimeout = 600;
                    await sqlCommand.ExecuteNonQueryAsync(cancellationToken);
            }
        }
    }
}
