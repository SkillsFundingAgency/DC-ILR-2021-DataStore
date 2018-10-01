using Autofac.Features.AttributeFilters;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.Dto;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services.Providers
{
    public class FM36ProviderService : BaseFundingModelProviderService<FM36Global>, IFM36ProviderService
    {
        public FM36ProviderService(
            [KeyFilter(PersistenceStorageKeys.Redis)]
            IKeyValuePersistenceService redis,
            IJsonSerializationService jsonSerializationService,
            ILogger logger)
        {
            _redis = redis;
            _jsonSerializationService = jsonSerializationService;
            _logger = logger;

            _key = JobContextMessageKey.FundingFm36Output;
            _name = "FM36";
        }
    }
}
