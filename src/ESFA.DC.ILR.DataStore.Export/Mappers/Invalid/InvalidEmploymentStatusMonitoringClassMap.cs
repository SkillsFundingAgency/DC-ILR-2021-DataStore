using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Invalid
{
    public class InvalidEmploymentStatusMonitoringClassMap : ClassMap<EmploymentStatusMonitoring>
    {
        public InvalidEmploymentStatusMonitoringClassMap()
        {
            Map(m => m.EmploymentStatusMonitoring_Id);
            Map(m => m.UKPRN);
            Map(m => m.LearnerEmploymentStatus_Id);
            Map(m => m.LearnRefNumber);
            Map(m => m.DateEmpStatApp);
            Map(m => m.ESMType);
            Map(m => m.ESMCode);
        }
    }
}
