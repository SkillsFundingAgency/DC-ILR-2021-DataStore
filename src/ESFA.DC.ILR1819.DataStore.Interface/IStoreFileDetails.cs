using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IStoreFileDetails
    {
        Task StoreAsync(IDataStoreContext dataStoreContext, SqlTransaction sqlTransaction, CancellationToken cancellationToken);
    }
}
