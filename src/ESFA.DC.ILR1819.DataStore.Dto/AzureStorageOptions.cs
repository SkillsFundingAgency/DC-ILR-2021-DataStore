using System;
using System.Collections.Generic;
using System.Text;

namespace ESFA.DC.ILR1819.DataStore.Dto
{
    public class AzureStorageOptions
    {
        public string AzureBlobConnectionString { get; set; }

        public string AzureContainerReference { get; set; }
    }
}
