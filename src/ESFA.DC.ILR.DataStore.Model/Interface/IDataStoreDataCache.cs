﻿using ESFA.DC.ILR1819.DataStore.Model.File;
using ESFA.DC.ILR1819.DataStore.Model.Funding;
using ESFA.DC.ILR1819.DataStore.Model.History;

namespace ESFA.DC.ILR1819.DataStore.Model.Interface
{
    public interface IDataStoreDataCache
    {
        ProcessingInformationData ProcessingInformation { get; }

        ValidHeaderData ValidHeaderData { get; }

        InvalidHeaderData InvalidHeaderData { get; }

        ValidLearnerData ValidLearnerData { get; }

        InvalidLearnerData InvalidLearnerData { get; }

        ValidationData ValidationData { get; }

        ALBData ALBData { get; }

        FM25Data FM25Data { get; }

        FM35Data FM35Data { get; }

        FM36Data FM36Data { get; }

        FM70Data FM70Data { get; }

        FM81Data FM81Data { get; }

        FM36HistoryData FM36HistoryData { get; }
    }
}
