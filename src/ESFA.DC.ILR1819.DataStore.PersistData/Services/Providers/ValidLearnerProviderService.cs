using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.AttributeFilters;
using ESFA.DC.ILR1819.DataStore.Dto;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services.Providers
{
    public class ValidLearnerProviderService : IValidLearnerProviderService
    {
        private readonly IKeyValuePersistenceService _redis;
        private readonly ISerializationService _jsonSerializationService;

        public ValidLearnerProviderService(
            [KeyFilter(PersistenceStorageKeys.Redis)] IKeyValuePersistenceService redis,
            IJsonSerializationService jsonSerializationService)
        {
            _redis = redis;
            _jsonSerializationService = jsonSerializationService;
        }

        public async Task<List<string>> ReadAndDeserialiseValidLearnersAsync(IJobContextMessage jobContextMessage, CancellationToken cancellationToken)
        {
            var learnersValidStr = string.Empty;
            if (jobContextMessage.KeyValuePairs.ContainsKey(JobContextMessageKey.ValidLearnRefNumbers))
            {
                learnersValidStr =
                    await _redis.GetAsync(
                        jobContextMessage.KeyValuePairs[JobContextMessageKey.ValidLearnRefNumbers].ToString(),
                        cancellationToken);
            }

            var validLearners = new List<string>();
            if (!string.IsNullOrEmpty(learnersValidStr))
            {
                validLearners = _jsonSerializationService.Deserialize<List<string>>(learnersValidStr);
            }

            return validLearners;
        }
    }
}
