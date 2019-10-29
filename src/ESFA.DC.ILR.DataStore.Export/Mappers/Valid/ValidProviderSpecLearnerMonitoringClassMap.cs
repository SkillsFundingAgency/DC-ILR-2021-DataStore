using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidProviderSpecLearnerMonitoringClassMap : ClassMap<ProviderSpecLearnerMonitoring>
    {
        public ValidProviderSpecLearnerMonitoringClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.ProvSpecLearnMonOccur);
            Map(m => m.ProvSpecLearnMon);
        }
    }
}
