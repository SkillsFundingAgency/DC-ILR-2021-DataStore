using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;

namespace ESFA.DC.ILR.DataStore.Stubs
{
    public class StoreServiceStub<T> : IStoreService<T>
    {
        public Task StoreAsync(T model, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
