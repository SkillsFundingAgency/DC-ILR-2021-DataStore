using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.AttributeFilters;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model;
using ESFA.DC.ILR1819.DataStore.Dto;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services.Providers
{
    public class ALBProviderService : BaseFundingModelProviderService<ALBFundingOutputs>, IALBProviderService
    {
        public ALBProviderService(
            [KeyFilter(PersistenceStorageKeys.Redis)] IKeyValuePersistenceService redis,
            IJsonSerializationService jsonSerializationService,
            ILogger logger)
        {
            _redis = redis;
            _jsonSerializationService = jsonSerializationService;
            _logger = logger;

            _key = JobContextMessageKey.FundingAlbOutput;
            _name = "ALB";
        }
    }
}
