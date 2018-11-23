using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Valid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Valid
{
    public class EmploymentStatusMonitoringBuilder
    {
        public static EmploymentStatusMonitoring BuildValidEmploymentStatusMonitoring(
            IMessage ilr,
            ILearner learner,
            ILearnerEmploymentStatus learnerEmploymentStatus,
            IEmploymentStatusMonitoring employmentStatusMonitoring)
        {
            return new EmploymentStatusMonitoring
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                LearnRefNumber = learner.LearnRefNumber,
                DateEmpStatApp = learnerEmploymentStatus.DateEmpStatApp,
                ESMCode = employmentStatusMonitoring.ESMCode,
                ESMType = employmentStatusMonitoring.ESMType
            };
        }
    }
}