using ESFA.DC.ILR1920.DataStore.EF.Valid;

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
