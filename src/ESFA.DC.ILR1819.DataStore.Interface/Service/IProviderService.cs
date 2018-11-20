using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR1819.DataStore.Interface.Service
{
    public interface IProviderService<T>
    {
        Task<T> ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken);
    }
}
