using ESFA.DC.ILR1920.DataStore.EF.Valid;

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
