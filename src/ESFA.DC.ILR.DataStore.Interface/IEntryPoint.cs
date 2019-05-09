using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.DataStore.Interface
{
    public interface IEntryPoint
    {
        Task<bool> Callback(IDataStoreContext dataStoreContext, CancellationToken cancellationToken);
    }
}
