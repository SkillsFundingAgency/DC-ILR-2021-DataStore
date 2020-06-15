using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearnerHEFinancialSupportClassMap : DefaultTableClassMap<LearnerHEFinancialSupport>
    {
        public ValidLearnerHEFinancialSupportClassMap()
        {
            Map(m => m.LearnerHE).Ignore();
        }
    }
}
