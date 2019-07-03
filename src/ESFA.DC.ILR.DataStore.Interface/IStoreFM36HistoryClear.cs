using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.DataStore.Interface
{
    public interface IStoreFM36HistoryClear
    {
        Task ClearAsync(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, CancellationToken cancellationToken);
    }
}
