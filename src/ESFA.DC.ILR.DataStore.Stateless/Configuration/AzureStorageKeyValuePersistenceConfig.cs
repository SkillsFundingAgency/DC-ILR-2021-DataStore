﻿using ESFA.DC.IO.AzureStorage.Config.Interfaces;

namespace ESFA.DC.ILR.DataStore.Stateless.Configuration
{
    public class AzureStorageKeyValuePersistenceConfig : IAzureStorageKeyValuePersistenceServiceConfig
    {
        public AzureStorageKeyValuePersistenceConfig(string connectionString, string containerName)
        {
            ConnectionString = connectionString;
            ContainerName = containerName;
        }

        public string ConnectionString { get; }

        public string ContainerName { get; }
    }
}
