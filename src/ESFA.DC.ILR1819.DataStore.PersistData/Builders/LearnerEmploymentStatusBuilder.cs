using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders
{
    public class LearnerEmploymentStatusBuilder
    {
        public static EF.Valid.LearnerEmploymentStatus BuildValidLearnerEmploymentStatus(
            IMessage ilr,
            ILearner learner,
            ILearnerEmploymentStatus learnerEmploymentStatus)
        {
            return new EF.Valid.LearnerEmploymentStatus
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                AgreeId = learnerEmploymentStatus.AgreeId,
                LearnRefNumber = learner.LearnRefNumber,
                DateEmpStatApp = learnerEmploymentStatus.DateEmpStatApp,
                EmpId = learnerEmploymentStatus.EmpIdNullable,
                EmpStat = learnerEmploymentStatus.EmpStat
            };
        }

        public static EF.Invalid.LearnerEmploymentStatu BuildInvalidLearnerEmploymentStatus(
            IMessage ilr,
            ILearner learner,
            ILearnerEmploymentStatus learnerEmploymentStatus,
            int learnerId,
            int learnerEmploymentStatusId)
        {
            return new EF.Invalid.LearnerEmploymentStatu
            {
                Learner_Id = learnerId,
                LearnerEmploymentStatus_Id = learnerEmploymentStatusId,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                AgreeId = learnerEmploymentStatus.AgreeId,
                LearnRefNumber = learner.LearnRefNumber,
                DateEmpStatApp = learnerEmploymentStatus.DateEmpStatApp,
                EmpId = learnerEmploymentStatus.EmpIdNullable,
                EmpStat = learnerEmploymentStatus.EmpStat
            };
        }
    }
}