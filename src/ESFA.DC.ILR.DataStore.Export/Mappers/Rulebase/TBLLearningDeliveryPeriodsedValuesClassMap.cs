using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class TBLLearningDeliveryPeriodsedValuesClassMap : DefaultTableClassMap<TBL_LearningDelivery_PeriodisedValue>
    {
        public TBLLearningDeliveryPeriodsedValuesClassMap()
        {
            Map(m => m.TBL_LearningDelivery).Ignore();
        }
    }
}
