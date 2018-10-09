using System;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.JobContextManager.Model.Interface;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services.Providers
{
    public class BaseFundingModelProviderService<T>
    {
        protected IKeyValuePersistenceService _redis;

        protected ISerializationService _jsonSerializationService;

        protected ILogger _logger;

        protected string _key;

        protected string _name;

        public async Task<T> ReadAndDeserialiseFileAsync(IJobContextMessage jobContextMessage, CancellationToken cancellationToken)
        {
            T fundingOutputs = default(T);

            try
            {
                string filename = jobContextMessage.KeyValuePairs[_key].ToString();
                string data = await _redis.GetAsync(filename, cancellationToken);

                if (!string.IsNullOrEmpty(data))
                {
                    fundingOutputs = _jsonSerializationService.Deserialize<T>(data);
                }
            }
            catch (Exception ex)
            {
                // Todo: Check behaviour
                _logger.LogError($"Failed to get & deserialise {_name} funding data. It will be ignored.", ex);
            }

            return fundingOutputs;
        }
    }
}
