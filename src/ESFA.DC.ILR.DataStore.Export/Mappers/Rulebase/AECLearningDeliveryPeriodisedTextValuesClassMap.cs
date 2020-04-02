using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class AECLearningDeliveryPeriodisedTextValuesClassMap : DefaultTableClassMap<AEC_LearningDelivery_PeriodisedTextValue>
    {
        public AECLearningDeliveryPeriodisedTextValuesClassMap()
        {
            Map(m => m.AEC_LearningDelivery).Ignore();
        }
    }
}
