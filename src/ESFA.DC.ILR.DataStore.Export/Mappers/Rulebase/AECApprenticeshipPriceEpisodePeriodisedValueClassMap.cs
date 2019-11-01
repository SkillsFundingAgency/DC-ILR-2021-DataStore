﻿using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class AECApprenticeshipPriceEpisodePeriodisedValueClassMap : DefaultTableClassMap<AEC_ApprenticeshipPriceEpisode_PeriodisedValue>
    {
        public AECApprenticeshipPriceEpisodePeriodisedValueClassMap()
        {
            Map(m => m.AEC_ApprenticeshipPriceEpisode).Ignore();
        }
    }
}
