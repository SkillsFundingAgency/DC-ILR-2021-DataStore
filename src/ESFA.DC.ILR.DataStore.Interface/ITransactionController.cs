using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Interface
{
    public interface ITransactionController
    {
        Task<bool> WriteAsync(IDataStoreContext dataStoreContext, IDataStoreDataCache dataStoreDataCache, CancellationToken cancellationToken);
    }
}