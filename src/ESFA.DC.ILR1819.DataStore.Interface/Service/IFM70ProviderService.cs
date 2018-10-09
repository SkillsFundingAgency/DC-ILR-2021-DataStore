using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.JobContext.Interface;

namespace ESFA.DC.ILR1819.DataStore.Interface.Service
{
    public interface IFM70ProviderService
    {
        Task<FM70Global> ReadAndDeserialiseFileAsync(IJobContextMessage jobContextMessage, CancellationToken cancellationToken);
    }
}