using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidEmploymentStatusMonitoringClassMap : ClassMap<EmploymentStatusMonitoring>
    {
        public ValidEmploymentStatusMonitoringClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.DateEmpStatApp);
            Map(m => m.ESMType);
            Map(m => m.ESMCode);
        }
    }
}
