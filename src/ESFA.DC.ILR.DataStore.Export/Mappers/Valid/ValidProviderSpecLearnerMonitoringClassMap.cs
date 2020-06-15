using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidProviderSpecLearnerMonitoringClassMap : DefaultTableClassMap<ProviderSpecLearnerMonitoring>
    {
        public ValidProviderSpecLearnerMonitoringClassMap()
        {
            Map(m => m.Learner).Ignore();
        }
    }
}
