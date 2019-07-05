using ESFA.DC.ILR.DataStore.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Model
{
    public class DataStoreDataCache : IDataStoreDataCache
    {
        public IDataStoreCache ProcessingInformation { get; set; }

        public IDataStoreCache ValidLearnerData { get; set; }

        public IDataStoreCache InvalidLearnerData { get; set; }
        
        public IDataStoreCache ValidationData { get; set; }

        public IDataStoreCache ALBData { get; set; }

        public IDataStoreCache FM25Data { get; set; }

        public IDataStoreCache FM35Data { get; set; }

        public IDataStoreCache FM36Data { get; set; }

        public IDataStoreCache FM70Data { get; set; }

        public IDataStoreCache FM81Data { get; set; }

        public IDataStoreCache FM36HistoryData { get; set; }
    }
}
