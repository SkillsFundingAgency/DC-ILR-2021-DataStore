using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IStoreValidationOutput
    {
        Task StoreAsync(int ukPrn, CancellationToken cancellationToken);
    }
}
