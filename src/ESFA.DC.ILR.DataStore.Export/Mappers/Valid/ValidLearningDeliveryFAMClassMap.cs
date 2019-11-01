using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearningDeliveryFAMClassMap : DefaultTableClassMap<LearningDeliveryFAM>
    {
        public ValidLearningDeliveryFAMClassMap()
        {
            Map(m => m.LearningDelivery).Ignore();
        }
    }
}
