using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidProviderSpecDeliveryMonitoringClassMap : ClassMap<ProviderSpecDeliveryMonitoring>
    {
        public ValidProviderSpecDeliveryMonitoringClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.ProvSpecDelMonOccur);
            Map(m => m.ProvSpecDelMon);
        }
    }
}
