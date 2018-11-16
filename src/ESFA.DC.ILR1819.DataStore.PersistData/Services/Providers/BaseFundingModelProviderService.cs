using System;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR1819.DataStore.Interface;
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

        private readonly string _fundModelName;

        protected BaseFundingModelProviderService(IKeyValuePersistenceService keyValuePersistenceService, IJsonSerializationService jsonSerializationService, ILogger logger, string fundModelName)
        {
            _keyValuePersistenceService = keyValuePersistenceService;
            _jsonSerializationService = jsonSerializationService;
            _logger = logger;
            _fundModelName = fundModelName;
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
                _logger.LogError($"Failed to get & deserialise {_fundModelName} funding data. It will be ignored.", ex);
            }

            return fundingOutputs;
        }
    }
}
