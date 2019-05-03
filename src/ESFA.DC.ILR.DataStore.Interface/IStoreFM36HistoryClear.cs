using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IStoreFM36HistoryClear
    {
        Task ClearAsync(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, CancellationToken cancellationToken);
    }
}
