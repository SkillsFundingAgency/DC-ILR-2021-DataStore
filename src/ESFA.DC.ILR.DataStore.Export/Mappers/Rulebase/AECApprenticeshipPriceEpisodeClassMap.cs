using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class AECApprenticeshipPriceEpisodeClassMap : DefaultTableClassMap<AEC_ApprenticeshipPriceEpisode>
    {
        public AECApprenticeshipPriceEpisodeClassMap()
        {
            Map(m => m.AEC_ApprenticeshipPriceEpisode_PeriodisedValues).Ignore();
            Map(m => m.AEC_ApprenticeshipPriceEpisode_Periods).Ignore();
            Map(m => m.AEC_Learner).Ignore();
            Map(m => m.LearningDelivery).Ignore();
        }
    }
}
