using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Invalid
{
    public class InvalidProviderSpecLearnerMonitoringClassMap : ClassMap<ProviderSpecLearnerMonitoring>
    {
        public InvalidProviderSpecLearnerMonitoringClassMap()
        {
            Map(m => m.ProviderSpecLearnerMonitoring_Id);
            Map(m => m.UKPRN);
            Map(m => m.Learner_Id);
            Map(m => m.LearnRefNumber);
            Map(m => m.ProvSpecLearnMonOccur);
            Map(m => m.ProvSpecLearnMon);
        }
    }
}
