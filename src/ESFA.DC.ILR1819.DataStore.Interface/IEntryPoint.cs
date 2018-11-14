using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.JobContextManager.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IEntryPoint
    {
        Task<bool> Callback(IJobContextMessage jobContextMessage, CancellationToken cancellationToken);
    }
}
