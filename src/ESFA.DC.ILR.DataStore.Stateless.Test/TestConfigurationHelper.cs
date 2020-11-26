using System.Collections.Generic;
using ESFA.DC.FileService.Config;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Stateless.Configuration;
using ESFA.DC.ServiceFabric.Common.Config;
using ESFA.DC.ServiceFabric.Common.Config.Interface;
using ESFA.DC.ServiceFabric.Helpers.Interfaces;

namespace ESFA.DC.ILR.DataStore.Stateless.Test
{
    public sealed class TestConfigurationHelper : IServiceFabricConfigurationService
    {
        public T GetConfigSectionAs<T>(string sectionName)
        {
            switch (sectionName)
            {
                case "DataStoreSection":
                    return (T)(object)new PersistDataConfiguration()
                    {
                        ILRDataStoreConnectionString = "Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;",
                        AppEarnHistoryDataStoreConnectionString = "Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;",
                    };
                case "AzureStorageFileServiceConfiguration":
                    return (T)(object)new AzureStorageFileServiceConfiguration()
                    {
                        ConnectionString = "AzureBlobConnectionString",
                    };
                case "VersionSection":
                    return (T)(object)new VersionInfo()
                    {
                        ServiceReleaseVersion = "ServiceReleaseVersion"
                    };
                case "StatelessServiceConfiguration":
                    return (T)(object)new StatelessServiceConfiguration()
                    {
                    };
            }

            return default(T);
        }

        public IDictionary<string, string> GetConfigSectionAsDictionary(string sectionName)
        {
            throw new System.NotImplementedException();
        }

        public IStatelessServiceConfiguration GetConfigSectionAsStatelessServiceConfiguration()
        {
            throw new System.NotImplementedException();
        }
    }
}
