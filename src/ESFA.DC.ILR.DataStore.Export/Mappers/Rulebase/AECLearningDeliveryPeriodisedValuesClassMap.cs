using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class AECLearningDeliveryPeriodisedValuesClassMap : DefaultTableClassMap<AEC_LearningDelivery_PeriodisedValue>
    {
        public AECLearningDeliveryPeriodisedValuesClassMap()
        {
            Map(m => m.AEC_LearningDelivery).Ignore();
        }
    }
}
