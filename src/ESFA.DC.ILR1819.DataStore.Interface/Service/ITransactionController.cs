using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR.Model;

namespace ESFA.DC.ILR1819.DataStore.Interface.Service
{
    public interface ITransactionController
    {
        Task<bool> WriteToDeds(
            IDataStoreContext dataStoreContext,
            CancellationToken cancellationToken,
            Message message,
            List<string> validLearners,
            FM36Global fm36Global);
    }
}