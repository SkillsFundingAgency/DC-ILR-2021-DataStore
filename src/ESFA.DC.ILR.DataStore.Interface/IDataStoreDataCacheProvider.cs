using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR1819.DataStore.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IDataStoreDataCacheProvider
    {
        Task<IDataStoreDataCache> ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken);
    }
}
