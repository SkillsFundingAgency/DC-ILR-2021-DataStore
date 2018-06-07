using ESFA.DC.IO.Redis.Config.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.Dto
{
    public class AzureCosmosKeyValuePersistenceConfig : IRedisKeyValuePersistenceServiceConfig
    {
        public AzureCosmosKeyValuePersistenceConfig(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }
    }
}
