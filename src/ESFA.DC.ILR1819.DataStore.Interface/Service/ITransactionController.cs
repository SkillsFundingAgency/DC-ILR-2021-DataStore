using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model;
using ESFA.DC.JobContextManager.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.Interface.Service
{
    public interface ITransactionController
    {
        Task<bool> WriteToDeds(
            IJobContextMessage jobContextMessage,
            CancellationToken cancellationToken,
            Message message,
            List<string> validLearners);
    }
}