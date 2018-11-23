using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Valid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Valid
{
    public class LearnerEmploymentStatusBuilder
    {
        public static LearnerEmploymentStatus BuildValidLearnerEmploymentStatus(
            IMessage ilr,
            ILearner learner,
            ILearnerEmploymentStatus learnerEmploymentStatus)
        {
            return new LearnerEmploymentStatus
            {
                UKPRN = ilr.LearningProviderEntity.UKPRN,
                AgreeId = learnerEmploymentStatus.AgreeId,
                LearnRefNumber = learner.LearnRefNumber,
                DateEmpStatApp = learnerEmploymentStatus.DateEmpStatApp,
                EmpId = learnerEmploymentStatus.EmpIdNullable,
                EmpStat = learnerEmploymentStatus.EmpStat
            };
        }
    }
}