using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model;

namespace ESFA.DC.ILR1819.DataStore.Interface.Service
{
    public interface IIlrTransactionController
    {
        Task<bool> WriteToDeds(
            IDataStoreContext dataStoreContext,
            CancellationToken cancellationToken,
            Message message,
            List<string> validLearners);
    }
}