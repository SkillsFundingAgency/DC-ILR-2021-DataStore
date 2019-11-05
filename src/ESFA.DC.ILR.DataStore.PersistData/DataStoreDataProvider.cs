using System.Collections.Generic;
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
using ESFA.DC.ILR.Model;

namespace ESFA.DC.ILR.DataStore.PersistData
{
    public class DataStoreDataProvider : IDataStoreDataProvider
    {
        private readonly IProviderService<Message> _ilrProviderService;
        private readonly IProviderService<ILR.Model.Loose.Message> _looseIlrProviderService;
        private readonly IProviderService<ALBGlobal> _albProviderService;
        private readonly IProviderService<FM25Global> _fm25ProviderService;
        private readonly IProviderService<FM35Global> _fm35ProviderService;
        private readonly IProviderService<FM36Global> _fm36ProviderService;
        private readonly IProviderService<FM70Global> _fm70ProviderService;
        private readonly IProviderService<FM81Global> _fm81ProviderService;
        private readonly IProviderService<List<string>> _validLearnerProviderService;
        private readonly IProviderService<List<ValidationError>> _validationErrorsProviderService;
        private readonly IProviderService<List<ValidationRule>> _rulesProviderService;
        private readonly IProviderService<ReferenceDataVersions> _referenceDataVersionProviderService;

        public DataStoreDataProvider(
            IProviderService<Message> ilrProviderService,
            IProviderService<ILR.Model.Loose.Message> looseIlrProviderService,
            IProviderService<ALBGlobal> albProviderService,
            IProviderService<FM25Global> fm25ProviderService,
            IProviderService<FM35Global> fm35ProviderService,
            IProviderService<FM36Global> fm36ProviderService,
            IProviderService<FM70Global> fm70ProviderService,
            IProviderService<FM81Global> fm81ProviderService,
            IProviderService<List<string>> validLearnerProviderService,
            IProviderService<List<ValidationError>> validationErrorsProviderService,
            IProviderService<List<ValidationRule>> rulesProviderService, 
            IProviderService<ReferenceDataVersions> referenceDataVersionProviderService)
        {
            _ilrProviderService = ilrProviderService;
            _looseIlrProviderService = looseIlrProviderService;
            _albProviderService = albProviderService;
            _fm25ProviderService = fm25ProviderService;
            _fm35ProviderService = fm35ProviderService;
            _fm36ProviderService = fm36ProviderService;
            _fm70ProviderService = fm70ProviderService;
            _fm81ProviderService = fm81ProviderService;
            _validLearnerProviderService = validLearnerProviderService;
            _validationErrorsProviderService = validationErrorsProviderService;
            _rulesProviderService = rulesProviderService;
            _referenceDataVersionProviderService = referenceDataVersionProviderService;
        }

        public Task<Message> ProvideMessageAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return _ilrProviderService.ProvideAsync(dataStoreContext, cancellationToken);
        }

        public Task<ILR.Model.Loose.Message> ProvideLooseMessageAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return _looseIlrProviderService.ProvideAsync(dataStoreContext, cancellationToken);
        }

        public Task<List<string>> ProvideValidLearnersAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return _validLearnerProviderService.ProvideAsync(dataStoreContext, cancellationToken);
        }

        public Task<ALBGlobal> ProvideALBAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return _albProviderService.ProvideAsync(dataStoreContext, cancellationToken);
        }

        public Task<FM25Global> ProvideFM25Async(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return _fm25ProviderService.ProvideAsync(dataStoreContext, cancellationToken);
        }

        public Task<FM35Global> ProvideFM35Async(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return _fm35ProviderService.ProvideAsync(dataStoreContext, cancellationToken);
        }

        public Task<FM36Global> ProvideFM36Async(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return _fm36ProviderService.ProvideAsync(dataStoreContext, cancellationToken);
        }

        public Task<FM70Global> ProvideFM70Async(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return _fm70ProviderService.ProvideAsync(dataStoreContext, cancellationToken);
        }

        public Task<FM81Global> ProvideFM81Async(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return _fm81ProviderService.ProvideAsync(dataStoreContext, cancellationToken);
        }

        public Task<List<ValidationError>> ProvideValidationErrorsAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return _validationErrorsProviderService.ProvideAsync(dataStoreContext, cancellationToken);
        }

        public Task<List<ValidationRule>> ProvideRulesAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return _rulesProviderService.ProvideAsync(dataStoreContext, cancellationToken);
        }

        public Task<ReferenceDataVersions> ProvideReferenceDataVersionsAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return _referenceDataVersionProviderService.ProvideAsync(dataStoreContext, cancellationToken);
        }
    }
}
