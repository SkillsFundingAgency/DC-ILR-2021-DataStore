using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR1819.DataStore.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface ITransactionController
    {
        Task<bool> WriteAsync(IDataStoreContext dataStoreContext, IDataStoreDataCache dataStoreDataCache, CancellationToken cancellationToken);
    }
}