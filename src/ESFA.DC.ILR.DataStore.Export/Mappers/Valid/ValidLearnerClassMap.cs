using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearnerClassMap : DefaultTableClassMap<Learner>
    {
        public ValidLearnerClassMap()
        {
            Map(m => m.ContactPreferences).Ignore();
            Map(m => m.LLDDandHealthProblems).Ignore();
            Map(m => m.LearnerEmploymentStatuses).Ignore();
            Map(m => m.LearnerFAMs).Ignore();
            Map(m => m.LearningDeliveries).Ignore();
            Map(m => m.LearnerHE).Ignore();
            Map(m => m.ProviderSpecLearnerMonitorings).Ignore();
        }
    }
}
