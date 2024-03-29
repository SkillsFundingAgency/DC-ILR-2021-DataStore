﻿using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;

namespace ESFA.DC.ILR.DataStore.PersistData.Persist
{
    public sealed class StoreClear : IStoreClear
    {
        public async Task ClearAsync(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            using (SqlCommand sqlCommand =
                    new SqlCommand("[dbo].[DeleteExistingRecords]", sqlConnection, sqlTransaction))
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
