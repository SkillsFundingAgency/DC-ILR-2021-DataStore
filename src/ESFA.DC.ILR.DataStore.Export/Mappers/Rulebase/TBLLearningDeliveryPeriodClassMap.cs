using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class TBLLearningDeliveryPeriodClassMap : DefaultTableClassMap<TBL_LearningDelivery_Period>
    {
        public TBLLearningDeliveryPeriodClassMap()
        {
            Map(m => m.TBL_LearningDelivery).Ignore();
        }
    }
}
