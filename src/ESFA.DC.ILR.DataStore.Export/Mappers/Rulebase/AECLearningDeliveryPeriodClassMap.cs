using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class AECLearningDeliveryPeriodClassMap : DefaultTableClassMap<AEC_LearningDelivery_Period>
    {
        public AECLearningDeliveryPeriodClassMap()
        {
            Map(m => m.AEC_LearningDelivery).Ignore();
        }
    }
}
