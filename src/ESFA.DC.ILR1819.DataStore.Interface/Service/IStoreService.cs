﻿using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR1819.DataStore.Interface.Service
{
    public interface IStoreService<in T>
    {
        Task StoreAsync(SqlConnection sqlConnection, T fundingOutputs, CancellationToken cancellationToken);
    }
}
