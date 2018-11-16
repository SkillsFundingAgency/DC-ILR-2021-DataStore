using System;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services.Providers
{
    public class BaseFundingModelProviderService<T>
    {
        private readonly IKeyValuePersistenceService _keyValuePersistenceService;
        private readonly IJsonSerializationService _jsonSerializationService;
        private readonly ILogger _logger;

        protected BaseFundingModelProviderService(IKeyValuePersistenceService keyValuePersistenceService, IJsonSerializationService jsonSerializationService, ILogger logger)
        {
            _keyValuePersistenceService = keyValuePersistenceService;
            _jsonSerializationService = jsonSerializationService;
            _logger = logger;
        }

        protected async Task<T> ReadAndDeserialiseFileAsync(string key, CancellationToken cancellationToken)
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
                _logger.LogError($"Failed to get & deserialise {key} funding data. It will be ignored.", ex);
            }

            return fundingOutputs;
        }
    }
}
