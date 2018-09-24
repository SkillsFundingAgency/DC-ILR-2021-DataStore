using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model;
using ESFA.DC.JobContext.Interface;

namespace ESFA.DC.ILR1819.DataStore.Interface.Service
{
    public interface IFM35ProviderService
    {
        Task<FM35FundingOutputs> ReadAndDeserialiseFileAsync(IJobContextMessage jobContextMessage, CancellationToken cancellationToken);
    }
}