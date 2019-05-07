﻿using ESFA.DC.ILR1819.DataStore.Model.File;
using ESFA.DC.ILR1819.DataStore.Model.Funding;
using ESFA.DC.ILR1819.DataStore.Model.History;
using ESFA.DC.ILR1819.DataStore.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.Model
{
    public class DataStoreDataCache : IDataStoreDataCache
    {
        public ProcessingInformationData ProcessingInformation { get; set; }

        public ValidHeaderData ValidHeaderData { get; set; }

        public InvalidHeaderData InvalidHeaderData { get; set; }

        public ValidLearnerData ValidLearnerData { get; set; }

        public InvalidLearnerData InvalidLearnerData { get; set; }

        public ValidationData ValidationData { get; set; }

        public ALBData ALBData { get; set; }

        public FM25Data FM25Data { get; set; }

        public FM35Data FM35Data { get; set; }

        public FM36Data FM36Data { get; set; }

        public FM70Data FM70Data { get; set; }

        public FM81Data FM81Data { get; set; }
        public FM36HistoryData FM36HistoryData { get; set; }
    }
}
