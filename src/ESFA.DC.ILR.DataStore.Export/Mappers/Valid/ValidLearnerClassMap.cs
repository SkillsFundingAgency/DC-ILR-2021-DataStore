using ESFA.DC.ILR2021.DataStore.EF;

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
            Map(m => m.FM25_Learner).Ignore();
            Map(m => m.FM35_Learner).Ignore();
            Map(m => m.ALB_Learner).Ignore();
            Map(m => m.AEC_Learner).Ignore();
            Map(m => m.TBL_Learner).Ignore();
            Map(m => m.ESF_Learner).Ignore();
        }
    }
}
