using Autofac.Features.AttributeFilters;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.Dto;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services.Providers
{
    public class FM35ProviderService : BaseFundingModelProviderService<FM35Global>, IFM35ProviderService
    {
        public FM35ProviderService(
            [KeyFilter(PersistenceStorageKeys.Redis)]
            IKeyValuePersistenceService redis,
            IJsonSerializationService jsonSerializationService,
            ILogger logger)
        {
            _redis = redis;
            _jsonSerializationService = jsonSerializationService;
            _logger = logger;

            _key = JobContextMessageKey.FundingFm35Output;
            _name = "FM35";
        }
    }
}
