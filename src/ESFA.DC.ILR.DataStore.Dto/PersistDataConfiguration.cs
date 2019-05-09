namespace ESFA.DC.ILR.DataStore.Dto
{
    public sealed class PersistDataConfiguration
    {
        public string ILRDataStoreConnectionString { get; set; }

        public string AppEarnHistoryDataStoreConnectionString { get; set; }

        public string IlrValidationErrorsConnectionString { get; set; }
    }
}
