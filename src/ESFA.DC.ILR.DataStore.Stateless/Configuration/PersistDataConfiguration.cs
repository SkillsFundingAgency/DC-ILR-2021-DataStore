﻿namespace ESFA.DC.ILR.DataStore.Stateless.Configuration
{
    public class PersistDataConfiguration
    {
        public string ILRDataStoreConnectionString { get; set; }

        public string AppEarnHistoryDataStoreConnectionString { get; set; }

        public string IlrValidationErrorsConnectionString { get; set; }
    }
}