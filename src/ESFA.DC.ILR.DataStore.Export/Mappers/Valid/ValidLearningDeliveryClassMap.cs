using ESFA.DC.ILR2021.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearningDeliveryClassMap : DefaultTableClassMap<LearningDelivery>
    {
        public ValidLearningDeliveryClassMap()
        {
            Map(m => m.Learner).Ignore();
            Map(m => m.AppFinRecords).Ignore();
            Map(m => m.LearningDeliveryFAMs).Ignore();
            Map(m => m.LearningDeliveryHE).Ignore();
            Map(m => m.LearningDeliveryWorkPlacements).Ignore();
            Map(m => m.ProviderSpecDeliveryMonitorings).Ignore();
        }
    }
}
