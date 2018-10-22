using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.JobContextManager.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.Interface.Service
{
    public interface IALBProviderService
    {
        Task<ALBGlobal> ReadAndDeserialiseFileAsync(IJobContextMessage jobContextMessage, CancellationToken cancellationToken);
    }
}