using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class FM35LearningDeliveryPeriodClassMap : DefaultTableClassMap<FM35_LearningDelivery_Period>
    {
        public FM35LearningDeliveryPeriodClassMap()
        {
            Map(m => m.FM35_LearningDelivery).Ignore();
        }
    }
}
