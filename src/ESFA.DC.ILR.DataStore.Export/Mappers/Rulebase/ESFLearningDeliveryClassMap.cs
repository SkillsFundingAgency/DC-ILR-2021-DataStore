using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ESFLearningDeliveryClassMap : DefaultTableClassMap<ESF_LearningDelivery>
    {
        public ESFLearningDeliveryClassMap()
        {
            Map(m => m.ESF_Learner).Ignore();
            Map(m => m.ESF_LearningDeliveryDeliverable_Periods).Ignore();
            Map(m => m.ESF_LearningDeliveryDeliverables).Ignore();
        }
    }
}
