using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR1819.DataStore.Interface.Service
{
    public interface IStoreFM36HistoryService<in T>
    {
        Task StoreAsync(IDataStoreContext dataStoreContext, SqlTransaction transaction, T fundingOutputs, CancellationToken cancellationToken);
    }
}
