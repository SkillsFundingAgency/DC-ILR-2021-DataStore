using ESFA.DC.IO.AzureStorage.Config.Interfaces;

namespace ESFA.DC.ILR.DataStore.Stateless.Configuration
{
    public class IOConfiguration : IAzureStorageKeyValuePersistenceServiceConfig
    {
        public string ConnectionString { get; set; }

        public string ContainerName { get; set; }
    }
}
