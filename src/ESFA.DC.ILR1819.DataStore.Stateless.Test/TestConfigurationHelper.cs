using ESFA.DC.ILR1819.DataStore.Dto;
using ESFA.DC.ServiceFabric.Helpers.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.Stateless.Test
{
    public sealed class TestConfigurationHelper : IConfigurationHelper
    {
        public T GetSectionValues<T>(string sectionName)
        {
            switch (sectionName)
            {
                case "RedisSection":
                    return (T)(object)new RedisOptions();
                case "AzureStorageSection":
                    return (T)(object)new AzureStorageOptions();
                case "ServiceBusSettings":
                    return (T)(object)new ServiceBusOptions();
                case "DataStoreSection":
                    return (T)(object)new PersistDataConfiguration();
                case "VersionSection":
                    return (T)(object)new VersionInfo();
                case "LoggerSection":
                    return (T)(object)new LoggerOptions();
                case "JobStatusSection":
                    return (T)(object)new JobStatusQueueOptions();
            }

            return default(T);
        }
    }
}
