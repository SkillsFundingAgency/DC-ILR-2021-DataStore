using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model;
using ESFA.DC.JobContext.Interface;

namespace ESFA.DC.ILR1819.DataStore.Interface.Service
{
    public interface IFM36ProviderService
    {
        Task<FM36FundingOutputs> ReadAndDeserialiseFileAsync(IJobContextMessage jobContextMessage, CancellationToken cancellationToken);
    }
}