using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IStoreService<in T>
    {
        Task StoreAsync(T model, SqlConnection sqlConnection, CancellationToken cancellationToken);
    }
}
