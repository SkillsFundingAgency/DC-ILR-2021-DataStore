using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.DataStore.Interface
{
    public interface IProviderService<T>
    {
        Task<T> ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken);
    }
}
