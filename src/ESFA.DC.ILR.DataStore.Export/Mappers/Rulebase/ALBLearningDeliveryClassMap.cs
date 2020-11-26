using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ALBLearningDeliveryClassMap : DefaultTableClassMap<ALB_LearningDelivery>
    {
        public ALBLearningDeliveryClassMap()
        {
            Map(m => m.ALB_Learner).Ignore();
            Map(m => m.ALB_LearningDelivery_PeriodisedValues).Ignore();
            Map(m => m.ALB_LearningDelivery_Periods).Ignore();
            Map(m => m.LearningDelivery).Ignore();
        }
    }
}
