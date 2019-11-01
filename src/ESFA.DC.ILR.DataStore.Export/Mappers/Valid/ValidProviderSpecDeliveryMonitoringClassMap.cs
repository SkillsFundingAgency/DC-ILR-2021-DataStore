using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidProviderSpecDeliveryMonitoringClassMap : DefaultTableClassMap<ProviderSpecDeliveryMonitoring>
    {
        public ValidProviderSpecDeliveryMonitoringClassMap()
        {
            Map(m => m.LearningDelivery).Ignore();
        }
    }
}
