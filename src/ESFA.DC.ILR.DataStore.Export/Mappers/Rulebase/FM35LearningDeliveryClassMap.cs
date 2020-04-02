using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class FM35LearningDeliveryClassMap : DefaultTableClassMap<FM35_LearningDelivery>
    {
        public FM35LearningDeliveryClassMap()
        {
            Map(m => m.FM35_Learner).Ignore();
            Map(m => m.FM35_LearningDelivery_PeriodisedValues).Ignore();
            Map(m => m.FM35_LearningDelivery_Periods).Ignore();
        }
    }
}
