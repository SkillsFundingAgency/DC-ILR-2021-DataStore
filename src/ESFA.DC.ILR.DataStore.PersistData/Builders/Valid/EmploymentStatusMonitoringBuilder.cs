using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.PersistData.Builders.Valid
{
    public class EmploymentStatusMonitoringBuilder
    {
        public static EmploymentStatusMonitoring BuildValidEmploymentStatusMonitoring(
            int ukprn,
            ILearner learner,
            ILearnerEmploymentStatus learnerEmploymentStatus,
            IEmploymentStatusMonitoring employmentStatusMonitoring)
        {
            return new EmploymentStatusMonitoring
            {
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                DateEmpStatApp = learnerEmploymentStatus.DateEmpStatApp,
                ESMCode = employmentStatusMonitoring.ESMCode,
                ESMType = employmentStatusMonitoring.ESMType
            };
        }
    }
}