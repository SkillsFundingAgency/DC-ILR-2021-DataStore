using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IStoreClear
    {
        Task ClearAsync(int ukPrn, string filename, CancellationToken cancellationToken);
    }
}
