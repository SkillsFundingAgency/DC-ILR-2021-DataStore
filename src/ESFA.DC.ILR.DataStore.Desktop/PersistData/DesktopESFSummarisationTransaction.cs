using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Desktop.PersistData
{
    public class DesktopESFSummarisationTransaction : IESFSummarisationTransaction
    {
        public Task WriteESFSummarisationAsync(IDataStoreContext dataStoreContext, IDataStoreCache cache, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
