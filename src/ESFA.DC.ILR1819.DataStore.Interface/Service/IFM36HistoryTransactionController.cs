using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;

namespace ESFA.DC.ILR1819.DataStore.Interface.Service
{
    public interface IFM36HistoryTransactionController
    {
        Task<bool> WriteToDeds(
            IDataStoreContext dataStoreContext,
            CancellationToken cancellationToken,
            FM36Global fm36Global);
    }
}