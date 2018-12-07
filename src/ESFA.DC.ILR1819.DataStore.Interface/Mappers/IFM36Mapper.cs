﻿using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;

namespace ESFA.DC.ILR1819.DataStore.Interface.Mappers
{
    public interface IFM36Mapper
    {
        AEC_global MapGlobal(FM36Global fm36Global);

        IEnumerable<AEC_Learner> MapLearners(FM36Global fm36Global);

        IEnumerable<AEC_LearningDelivery> MapLearningDeliveries(FM36Global fm36Global);

        IEnumerable<AEC_LearningDelivery_Period> MapLearningDeliveryPeriods(FM36Global fm36Global);

        IEnumerable<AEC_LearningDelivery_PeriodisedValues> MapLearningDeliveryPeriodisedValues(FM36Global fm36Global);

        IEnumerable<AEC_LearningDelivery_PeriodisedTextValues> MapLearningDeliveryPeriodisedTextValues(FM36Global fm36Global);

        IEnumerable<AEC_ApprenticeshipPriceEpisode> MapPriceEpisodes(FM36Global fm36Global);

        IEnumerable<AEC_ApprenticeshipPriceEpisode_Period> MapPriceEpisodePeriods(FM36Global fm36Global);

        IEnumerable<AEC_ApprenticeshipPriceEpisode_PeriodisedValues> MapPriceEpisodePeriodisedValues(FM36Global fm36Global);
    }
}
