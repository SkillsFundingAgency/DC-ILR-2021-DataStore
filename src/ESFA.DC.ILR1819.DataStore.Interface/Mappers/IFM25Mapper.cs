﻿using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Model;

namespace ESFA.DC.ILR1819.DataStore.Interface.Mappers
{
    public interface IFM25Mapper
    {
        FM25Data MapData(FM25Global fm25Global);

        IEnumerable<FM25_global> MapFM25Global(FM25Global fm25Global);

        IEnumerable<FM25_Learner> MapFM25Learners(FM25Global fm25Global);

        IEnumerable<FM25_FM35_global> MapFM25_35_Global(FM25Global fm25Global);

        IEnumerable<FM25_FM35_Learner_Period> MapFM25_35_LearnerPeriod(FM25Global fm25Global);

        IEnumerable<FM25_FM35_Learner_PeriodisedValue> MapFM25_35_LearnerPeriodisedValues(FM25Global fm25Global);
    }
}
