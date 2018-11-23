using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Invalid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Invalid
{
    public class LearnerEmploymentStatusBuilder
    {
        public static LearnerEmploymentStatu BuildInvalidLearnerEmploymentStatus(
            int ukprn,
            ILearner learner,
            ILearnerEmploymentStatus learnerEmploymentStatus,
            int learnerId,
            int learnerEmploymentStatusId)
        {
            return new LearnerEmploymentStatu
            {
                Learner_Id = learnerId,
                LearnerEmploymentStatus_Id = learnerEmploymentStatusId,
                UKPRN = ukprn,
                AgreeId = learnerEmploymentStatus.AgreeId,
                LearnRefNumber = learner.LearnRefNumber,
                DateEmpStatApp = learnerEmploymentStatus.DateEmpStatApp,
                EmpId = learnerEmploymentStatus.EmpIdNullable,
                EmpStat = learnerEmploymentStatus.EmpStat
            };
        }
    }
}