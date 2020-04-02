using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class TBLLearningDeliveryClassMap : DefaultTableClassMap<TBL_LearningDelivery>
    {
        public TBLLearningDeliveryClassMap()
        {
            Map(m => m.TBL_Learner).Ignore();
            Map(m => m.TBL_LearningDelivery_PeriodisedValues).Ignore();
            Map(m => m.TBL_LearningDelivery_Periods).Ignore();
        }
    }
}
