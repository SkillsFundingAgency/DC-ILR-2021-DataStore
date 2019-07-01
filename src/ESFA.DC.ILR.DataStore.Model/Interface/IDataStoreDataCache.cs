using ESFA.DC.ILR.DataStore.Model.File;
using ESFA.DC.ILR.DataStore.Model.Funding;
using ESFA.DC.ILR.DataStore.Model.History;

namespace ESFA.DC.ILR.DataStore.Model.Interface
{
    public interface IDataStoreDataCache
    {
        ProcessingInformationData ProcessingInformation { get; }

        ValidLearnerData ValidLearnerData { get; }

        InvalidLearnerData InvalidLearnerData { get; }

        IDataStoreCache ValidationData { get; }

        ALBData ALBData { get; }

        IDataStoreCache FM25Data { get; }

        FM35Data FM35Data { get; }

        FM36Data FM36Data { get; }

        FM70Data FM70Data { get; }

        FM81Data FM81Data { get; }

        FM36HistoryData FM36HistoryData { get; }
    }
}
