using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.AttributeFilters;
using ESFA.DC.ILR1819.DataStore.Dto;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services.Providers
{
    public class ValidLearnerProviderService : IValidLearnerProviderService
    {
        private readonly IKeyValuePersistenceService _keyValuePersistenceService;
        private readonly IJsonSerializationService _jsonSerializationService;

        public ValidLearnerProviderService(
            IKeyValuePersistenceService keyValuePersistenceService,
            IJsonSerializationService jsonSerializationService)
        {
            _keyValuePersistenceService = keyValuePersistenceService;
            _jsonSerializationService = jsonSerializationService;
        }

        public async Task<List<string>> ReadAndDeserialiseValidLearnersAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            var learnersValidStr = await _keyValuePersistenceService.GetAsync(dataStoreContext.ValidLearnRefNumbersKey, cancellationToken);

            return _jsonSerializationService.Deserialize<List<string>>(learnersValidStr);
        }
    }
}
