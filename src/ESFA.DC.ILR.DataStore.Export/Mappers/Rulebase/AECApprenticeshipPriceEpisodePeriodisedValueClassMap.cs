﻿using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class AECApprenticeshipPriceEpisodePeriodisedValueClassMap : ClassMap<AEC_ApprenticeshipPriceEpisode_PeriodisedValue>
    {
        public AECApprenticeshipPriceEpisodePeriodisedValueClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.PriceEpisodeIdentifier);
            Map(m => m.AttributeName);
            Map(m => m.Period_1);
            Map(m => m.Period_2);
            Map(m => m.Period_3);
            Map(m => m.Period_4);
            Map(m => m.Period_5);
            Map(m => m.Period_6);
            Map(m => m.Period_7);
            Map(m => m.Period_8);
            Map(m => m.Period_9);
            Map(m => m.Period_10);
            Map(m => m.Period_11);
            Map(m => m.Period_12);
        }
    }
}
