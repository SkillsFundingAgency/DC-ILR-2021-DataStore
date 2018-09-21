using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR.Model;
using ESFA.DC.JobContext.Interface;

namespace ESFA.DC.ILR1819.DataStore.Interface.Service
{
    public interface ILearnerPersistence
    {
        Task<bool> WriteToDeds(
            IJobContextMessage jobContextMessage,
            CancellationToken cancellationToken,
            string ilrFilename,
            Message message,
            ALBFundingOutputs fundingOutput,
            Global fm25FundingOutput,
            List<string> validLearners);
    }
}