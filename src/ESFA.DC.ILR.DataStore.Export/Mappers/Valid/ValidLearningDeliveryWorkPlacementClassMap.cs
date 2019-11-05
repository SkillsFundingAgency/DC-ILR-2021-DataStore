using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearningDeliveryWorkPlacementClassMap : DefaultTableClassMap<LearningDeliveryWorkPlacement>
    {
        public ValidLearningDeliveryWorkPlacementClassMap()
        {
            Map(m => m.LearningDelivery).Ignore();
        }
    }
}
