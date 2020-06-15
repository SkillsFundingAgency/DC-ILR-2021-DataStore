using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class AECLearningDeliveryClassMap : DefaultTableClassMap<AEC_LearningDelivery>
    {
        public AECLearningDeliveryClassMap()
        {
            Map(m => m.AEC_Learner).Ignore();
            Map(m => m.AEC_LearningDelivery_PeriodisedTextValues).Ignore();
            Map(m => m.AEC_LearningDelivery_PeriodisedValues).Ignore();
            Map(m => m.AEC_LearningDelivery_Periods).Ignore();
            Map(m => m.LearningDelivery).Ignore();
        }
    }
}
