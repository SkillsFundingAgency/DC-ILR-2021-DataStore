using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Model;

namespace ESFA.DC.ILR1819.DataStore.Interface.Mappers
{
    public interface IFM36Mapper
    {
        FM36Data MapData(FM36Global fm36Global);

        IEnumerable<AEC_global> MapGlobals(FM36Global fm36Global);

        IEnumerable<AEC_Learner> MapLearners(FM36Global fm36Global);

        IEnumerable<AEC_LearningDelivery> MapLearningDeliveries(FM36Global fm36Global);

        IEnumerable<AEC_LearningDelivery_Period> MapLearningDeliveryPeriods(FM36Global fm36Global);

        IEnumerable<AEC_LearningDelivery_PeriodisedValue> MapLearningDeliveryPeriodisedValues(FM36Global fm36Global);

        IEnumerable<AEC_LearningDelivery_PeriodisedTextValue> MapLearningDeliveryPeriodisedTextValues(FM36Global fm36Global);

        IEnumerable<AEC_ApprenticeshipPriceEpisode> MapPriceEpisodes(FM36Global fm36Global);

        IEnumerable<AEC_ApprenticeshipPriceEpisode_Period> MapPriceEpisodePeriods(FM36Global fm36Global);

        IEnumerable<AEC_ApprenticeshipPriceEpisode_PeriodisedValue> MapPriceEpisodePeriodisedValues(FM36Global fm36Global);
    }
}
