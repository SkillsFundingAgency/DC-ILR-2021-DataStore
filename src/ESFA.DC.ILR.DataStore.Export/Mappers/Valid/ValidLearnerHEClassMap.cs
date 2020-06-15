using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearnerHEClassMap : DefaultTableClassMap<LearnerHE>
    {
        public ValidLearnerHEClassMap()
        {
            Map(m => m.Learner).Ignore();
            Map(m => m.LearnerHEFinancialSupports).Ignore();
        }
    }
}
