using ESFA.DC.ILR1920.DataStore.EF.Valid;

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
