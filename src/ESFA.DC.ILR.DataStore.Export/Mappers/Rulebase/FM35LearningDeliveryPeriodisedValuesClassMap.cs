using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class FM35LearningDeliveryPeriodisedValuesClassMap : DefaultTableClassMap<FM35_LearningDelivery_PeriodisedValue>
    {
        public FM35LearningDeliveryPeriodisedValuesClassMap()
        {
            Map(m => m.FM35_LearningDelivery).Ignore();
        }
    }
}
