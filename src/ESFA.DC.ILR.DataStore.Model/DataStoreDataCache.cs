using ESFA.DC.ILR.DataStore.Model.File;
using ESFA.DC.ILR.DataStore.Model.Funding;
using ESFA.DC.ILR.DataStore.Model.History;
using ESFA.DC.ILR.DataStore.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Model
{
    public class DataStoreDataCache : IDataStoreDataCache
    {
        public ProcessingInformationData ProcessingInformation { get; set; }

        public ValidLearnerData ValidLearnerData { get; set; }

        public InvalidLearnerData InvalidLearnerData { get; set; }
        
        public IDataStoreCache ValidationData { get; set; }

        public IDataStoreCache ALBData { get; set; }

        public IDataStoreCache FM25Data { get; set; }

        public FM35Data FM35Data { get; set; }

        public FM36Data FM36Data { get; set; }

        public FM70Data FM70Data { get; set; }

        public FM81Data FM81Data { get; set; }

        public FM36HistoryData FM36HistoryData { get; set; }
    }
}
