using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.PersistData.Builders.Invalid
{
    public class EmploymentStatusMonitoringBuilder
    {
        public static EmploymentStatusMonitoring BuildInvalidEmploymentStatusMonitoring(
            int ukprn,
            ILearner learner,
            ILearnerEmploymentStatus learnerEmploymentStatus,
            IEmploymentStatusMonitoring employmentStatusMonitoring,
            int learnerEmploymentStatusId,
            int learnerEmploymentStatusMonitoringId)
        {
            return new EmploymentStatusMonitoring
            {
                EmploymentStatusMonitoring_Id = learnerEmploymentStatusMonitoringId,
                LearnerEmploymentStatus_Id = learnerEmploymentStatusId,
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                DateEmpStatApp = learnerEmploymentStatus.DateEmpStatApp,
                ESMCode = employmentStatusMonitoring.ESMCode,
                ESMType = employmentStatusMonitoring.ESMType
            };
        }
    }
}