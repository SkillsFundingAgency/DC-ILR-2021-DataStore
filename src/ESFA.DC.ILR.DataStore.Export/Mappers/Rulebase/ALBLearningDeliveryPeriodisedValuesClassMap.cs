using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ALBLearningDeliveryPeriodisedValuesClassMap : DefaultTableClassMap<ALB_LearningDelivery_PeriodisedValue>
    {
        public ALBLearningDeliveryPeriodisedValuesClassMap()
        {
            Map(m => m.ALB_LearningDelivery).Ignore();
        }
    }
}
