using System;
using System.Collections.Generic;
using System.Text;

namespace ESFA.DC.ILR1819.DataStore.Dto
{
    public class AzureCosmosOptions
    {
        public string CosmosEndpointUrl { get; set; }

        public string CosmosAuthKeyOrResourceToken { get; set; }
    }
}
