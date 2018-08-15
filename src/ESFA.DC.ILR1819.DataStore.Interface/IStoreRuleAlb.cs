using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IStoreRuleAlb
    {
        Task StoreAsync(int ukPrn, FundingOutputs fundingOutputs, CancellationToken cancellationToken);
    }
}
