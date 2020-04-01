using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearningDeliveryHEClassMap : DefaultTableClassMap<LearningDeliveryHE>
    {
        public ValidLearningDeliveryHEClassMap()
        {
            Map(m => m.LearningDelivery).Ignore();
        }
    }
}
