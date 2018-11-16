using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR1819.DataStore.Interface;

namespace ESFA.DC.ILR1819.DataStore.Stateless.Test.Stubs
{
    public class ModelServiceStub : IModelService
    {
        public Task GetAndStoreModel(IDataStoreContext dataStoreContext, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
