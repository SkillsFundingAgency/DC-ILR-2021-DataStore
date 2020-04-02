using ESFA.DC.ILR2021.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearnerEmploymentStatusClassMap : DefaultTableClassMap<LearnerEmploymentStatus>
    {
        public ValidLearnerEmploymentStatusClassMap()
        {
            Map(m => m.Learner).Ignore();
        }
    }
}
