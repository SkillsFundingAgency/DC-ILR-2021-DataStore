using System;
using System.Collections.Generic;
using System.Text;
using ESFA.DC.IO.AzureCosmos.Config.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.Dto
{
    public class AzureCosmosKeyValuePersistenceConfig : IAzureCosmosKeyValuePersistenceServiceConfig
    {
        public AzureCosmosKeyValuePersistenceConfig(string endpointUrl, string authKeyOrResourceToken)
        {
            EndpointUrl = endpointUrl;
            AuthKeyOrResourceToken = authKeyOrResourceToken;
        }

        public string EndpointUrl { get; }

        public string AuthKeyOrResourceToken { get; }
    }
}
