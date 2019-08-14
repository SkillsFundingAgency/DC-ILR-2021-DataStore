using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Interface
{
    public interface IILRTransaction
    {
        Task WriteILRDataAsync(IDataStoreContext dataStoreContext, IDataStoreCache cache, CancellationToken cancellationToken);
    }
}
