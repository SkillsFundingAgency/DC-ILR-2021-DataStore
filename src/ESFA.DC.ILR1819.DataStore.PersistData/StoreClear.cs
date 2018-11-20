using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR1819.DataStore.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public sealed class StoreClear : IStoreClear
    {
        public async Task ClearAsync(IDataStoreContext dataStoreContext, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            using (SqlCommand sqlCommand =
                    new SqlCommand("[dbo].[DeleteExistingRecords]", sqlTransaction.Connection, sqlTransaction))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@ukprn", SqlDbType.Int).Value = dataStoreContext.Ukprn;
                    sqlCommand.Parameters.Add("@fileName", SqlDbType.NVarChar).Value = dataStoreContext.OriginalFilename;
                    sqlCommand.CommandTimeout = 600;
                    await sqlCommand.ExecuteNonQueryAsync(cancellationToken);
            }
        }
    }
}
