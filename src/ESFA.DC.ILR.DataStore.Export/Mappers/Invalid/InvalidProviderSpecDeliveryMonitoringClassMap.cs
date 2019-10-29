using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Invalid
{
    public class InvalidProviderSpecDeliveryMonitoringClassMap : ClassMap<ProviderSpecDeliveryMonitoring>
    {
        public InvalidProviderSpecDeliveryMonitoringClassMap()
        {
            Map(m => m.ProviderSpecDeliveryMonitoring_Id);
            Map(m => m.UKPRN);
            Map(m => m.LearningDelivery_Id);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.ProvSpecDelMonOccur);
            Map(m => m.ProvSpecDelMon);
        }
    }
}
