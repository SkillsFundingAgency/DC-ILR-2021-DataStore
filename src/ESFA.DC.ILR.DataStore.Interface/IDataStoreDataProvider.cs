using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.Data.ILR.ValidationErrors.Model;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR.IO.Model.Validation;
using ESFA.DC.ILR.Model;

namespace ESFA.DC.ILR.DataStore.Interface
{
    public interface IDataStoreDataProvider
    {
        Task<Message> ProvideMessageAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken);

        Task<List<string>> ProvideValidLearnersAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken);

        Task<ALBGlobal> ProvideALBAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken);

        Task<FM25Global> ProvideFM25Async(IDataStoreContext dataStoreContext, CancellationToken cancellationToken);

        Task<FM35Global> ProvideFM35Async(IDataStoreContext dataStoreContext, CancellationToken cancellationToken);

        Task<FM36Global> ProvideFM36Async(IDataStoreContext dataStoreContext, CancellationToken cancellationToken);

        Task<FM70Global> ProvideFM70Async(IDataStoreContext dataStoreContext, CancellationToken cancellationToken);

        Task<FM81Global> ProvideFM81Async(IDataStoreContext dataStoreContext, CancellationToken cancellationToken);

        Task<List<ValidationError>> ProvideValidationErrorsAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken);

        Task<List<Rule>> ProvideRulesAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken);
    }
}
