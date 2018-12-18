using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR1819.DataStore.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public sealed class StoreFM36HistoryClear : IStoreFM36HistoryClear
    {
        public async Task ClearAsync(IDataStoreContext dataStoreContext, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            using (SqlCommand sqlCommand =
                    new SqlCommand("[dbo].[PrepareForNewData]", sqlTransaction.Connection, sqlTransaction))
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
