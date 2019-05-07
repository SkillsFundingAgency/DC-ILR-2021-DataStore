using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.IO.Model.Validation;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR.DataStore.PersistData.Providers
{
    public class ValidationErrorsProviderService : IProviderService<List<ValidationError>>
    {
        private readonly IJsonSerializationService _jsonSerializationService;
        private readonly IKeyValuePersistenceService _keyValuePersistenceService;

        public ValidationErrorsProviderService(
            IJsonSerializationService jsonSerializationService,
            IKeyValuePersistenceService keyValuePersistenceService)
        {
            _jsonSerializationService = jsonSerializationService;
            _keyValuePersistenceService = keyValuePersistenceService;
        }

        public async Task<List<ValidationError>> ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            var validationErrors = await _keyValuePersistenceService.GetAsync(dataStoreContext.ValidationErrorsKey, cancellationToken);

            return _jsonSerializationService.Deserialize<List<ValidationError>>(validationErrors);
        }
    }
}
