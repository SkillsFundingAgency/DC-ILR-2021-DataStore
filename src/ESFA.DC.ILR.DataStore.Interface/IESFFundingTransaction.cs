using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Interface
{
    public interface IESFFundingTransaction
    {
        Task WriteESFFundingAsync(IDataStoreContext dataStoreContext, IDataStoreCache cache, CancellationToken cancellationToken);
    }
}
