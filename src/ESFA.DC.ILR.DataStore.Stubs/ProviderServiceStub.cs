using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.ReferenceData;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR.IO.Model.Validation;

namespace ESFA.DC.ILR.DataStore.Stubs
{
    public class ProviderServiceStub :
        IProviderService<ALBGlobal>,
        IProviderService<FM25Global>,
        IProviderService<FM35Global>,
        IProviderService<FM36Global>,
        IProviderService<FM70Global>,
        IProviderService<FM81Global>,
        IProviderService<List<ILR.IO.Model.Validation.ValidationError>>,
        IProviderService<List<ValidationRule>>,
        IProviderService<List<string>>
    {
        Task<ALBGlobal> IProviderService<ALBGlobal>.ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ALBGlobal());
        }

        Task<FM25Global> IProviderService<FM25Global>.ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return Task.FromResult(new FM25Global());
        }

        Task<FM35Global> IProviderService<FM35Global>.ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return Task.FromResult(new FM35Global());
        }

        Task<FM36Global> IProviderService<FM36Global>.ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return Task.FromResult(new FM36Global());
        }

        Task<FM70Global> IProviderService<FM70Global>.ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return Task.FromResult(new FM70Global());
        }

        Task<FM81Global> IProviderService<FM81Global>.ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return Task.FromResult(new FM81Global());
        }

        Task<List<ValidationError>> IProviderService<List<ValidationError>>.ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return Task.FromResult(new List<ValidationError>());
        }

        public Task<List<ValidationRule>> ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return Task.FromResult(new List<ValidationRule>());
        }

        Task<List<string>> IProviderService<List<string>>.ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return Task.FromResult(new List<string>());
        }
    }
}
