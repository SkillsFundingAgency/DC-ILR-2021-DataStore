using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class AECApprenticeshipPriceEpisodePeriodClassMap : DefaultTableClassMap<AEC_ApprenticeshipPriceEpisode_Period>
    {
        public AECApprenticeshipPriceEpisodePeriodClassMap()
        {
            Map(m => m.AEC_ApprenticeshipPriceEpisode).Ignore();
        }
    }
}
