using ESFA.DC.IO.Redis.Config.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.Dto
{
    public class RedisKeyValuePersistenceConfig : IRedisKeyValuePersistenceServiceConfig
    {
        public RedisKeyValuePersistenceConfig(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }
    }
}
