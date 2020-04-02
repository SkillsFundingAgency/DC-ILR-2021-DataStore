using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ALBLearningDeliveryPeriodClassMap : DefaultTableClassMap<ALB_LearningDelivery_Period>
    {
        public ALBLearningDeliveryPeriodClassMap()
        {
            Map(m => m.ALB_LearningDelivery).Ignore();
        }
    }
}
