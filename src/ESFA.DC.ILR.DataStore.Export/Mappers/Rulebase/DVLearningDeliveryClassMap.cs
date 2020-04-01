using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class DVLearningDeliveryClassMap : DefaultTableClassMap<DV_LearningDelivery>
    {
        public DVLearningDeliveryClassMap()
        {
            Map(m => m.DV_Learner).Ignore();
        }
    }
}
