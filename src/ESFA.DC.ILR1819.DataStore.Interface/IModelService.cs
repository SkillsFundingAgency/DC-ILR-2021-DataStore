using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IModelService
    {
        Task GetAndStoreModel(IDataStoreContext dataStoreContext, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken);
    }
}