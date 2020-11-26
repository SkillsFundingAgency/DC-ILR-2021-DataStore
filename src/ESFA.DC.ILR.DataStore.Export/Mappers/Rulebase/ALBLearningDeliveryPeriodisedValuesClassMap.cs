using ESFA.DC.ILR2021.DataStore.EF;

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
