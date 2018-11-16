using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.AttributeFilters;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.Dto;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services.Providers
{
    public class ALBProviderService : BaseFundingModelProviderService<ALBGlobal>, IProviderService<ALBGlobal>
    {
        public ALBProviderService(
            [KeyFilter(PersistenceStorageKeys.Redis)]IKeyValuePersistenceService keyValuePersistenceService,
            IJsonSerializationService jsonSerializationService,
            ILogger logger)
        : base(keyValuePersistenceService, jsonSerializationService, logger)
        {
        }

        public Task<ALBGlobal> ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return ReadAndDeserialiseFileAsync(dataStoreContext.FundingALBOutputKey, cancellationToken);
        }
    }
}
