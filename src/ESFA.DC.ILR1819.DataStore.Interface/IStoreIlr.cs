using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IStoreIlr
    {
        Task StoreAsync(IMessage ilr, List<string> validLearners, CancellationToken cancellationToken);
    }
}
