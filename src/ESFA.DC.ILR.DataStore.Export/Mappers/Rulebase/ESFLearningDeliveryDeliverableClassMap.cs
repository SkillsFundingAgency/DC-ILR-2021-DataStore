using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ESFLearningDeliveryDeliverableClassMap : DefaultTableClassMap<ESF_LearningDeliveryDeliverable>
    {
        public ESFLearningDeliveryDeliverableClassMap()
        {
            Map(m => m.ESF_LearningDelivery).Ignore();
            Map(m => m.ESF_LearningDeliveryDeliverable_PeriodisedValues).Ignore();
        }
    }
}
