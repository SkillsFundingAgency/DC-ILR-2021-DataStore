using System;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Abstract
{
    public abstract class AbstractProviderService<T>
    {
        private readonly IKeyValuePersistenceService _keyValuePersistenceService;
        private readonly IJsonSerializationService _jsonSerializationService;
        private readonly ILogger _logger;

        protected AbstractProviderService(IKeyValuePersistenceService keyValuePersistenceService, IJsonSerializationService jsonSerializationService, ILogger logger)
        {
            _keyValuePersistenceService = keyValuePersistenceService;
            _jsonSerializationService = jsonSerializationService;
            _logger = logger;
        }

        protected async Task<T> ProvideAsync(string key, CancellationToken cancellationToken)
        {
            T fundingOutputs = default(T);

            try
            {
                string data = await _keyValuePersistenceService.GetAsync(key, cancellationToken);

                if (!string.IsNullOrEmpty(data))
                {
                    fundingOutputs = _jsonSerializationService.Deserialize<T>(data);
                }
            }
            catch (Exception ex)
            {
                // Todo: Check behaviour
                _logger.LogError($"Failed to provide {key} funding data. It will be ignored.", ex);
            }

            return fundingOutputs;
        }
    }
}
