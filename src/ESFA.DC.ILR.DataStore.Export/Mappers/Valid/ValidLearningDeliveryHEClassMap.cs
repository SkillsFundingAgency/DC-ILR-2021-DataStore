using ESFA.DC.ILR2021.DataStore.EF;

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
