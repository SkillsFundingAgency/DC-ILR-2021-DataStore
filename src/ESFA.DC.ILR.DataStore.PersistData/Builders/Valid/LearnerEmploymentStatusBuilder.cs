using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.PersistData.Builders.Valid
{
    public class LearnerEmploymentStatusBuilder
    {
        public static LearnerEmploymentStatus BuildValidLearnerEmploymentStatus(
            int ukprn,
            ILearner learner,
            ILearnerEmploymentStatus learnerEmploymentStatus)
        {
            return new LearnerEmploymentStatus
            {
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