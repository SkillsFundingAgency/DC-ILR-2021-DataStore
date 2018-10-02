using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.JobContextManager.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.Interface.Service
{
    public interface IValidLearnerProviderService
    {
        Task<List<string>> ReadAndDeserialiseValidLearnersAsync(
            IJobContextMessage jobContextMessage,
            CancellationToken cancellationToken);
    }
}