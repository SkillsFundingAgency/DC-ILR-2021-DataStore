namespace ESFA.DC.ILR.DataStore.Model.Interface
{
    public interface IDataStoreDataCache
    {
        IDataStoreCache ProcessingInformation { get; }

        IDataStoreCache ValidLearnerData { get; }

        IDataStoreCache InvalidLearnerData { get; }

        IDataStoreCache ValidationData { get; }

        IDataStoreCache ALBData { get; }

        IDataStoreCache FM25Data { get; }

        IDataStoreCache FM35Data { get; }

        IDataStoreCache FM36Data { get; }

        IDataStoreCache FM70Data { get; }

        IDataStoreCache FM81Data { get; }

        IDataStoreCache FM36HistoryData { get; }
    }
}
