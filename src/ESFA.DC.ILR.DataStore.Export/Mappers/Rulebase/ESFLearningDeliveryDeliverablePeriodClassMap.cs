using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ESFLearningDeliveryDeliverablePeriodClassMap : DefaultTableClassMap<ESF_LearningDeliveryDeliverable_Period>
    {
        public ESFLearningDeliveryDeliverablePeriodClassMap()
        {
            Map(m => m.ESF_LearningDelivery).Ignore();
        }
    }
}
