using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Valid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Valid
{
    public class ProviderSpecDeliveryMonitoringBuilder
    {
        public static ProviderSpecDeliveryMonitoring BuildValidProviderSpecDeliveryMonitoringRecord(
            IMessage ilr,
            ILearner learner,
            ILearningDelivery learningDelivery,
            IProviderSpecDeliveryMonitoring providerSpecDeliveryMonitoring)
        {
            return new ProviderSpecDeliveryMonitoring
            {
                AimSeqNumber = learningDelivery.AimSeqNumber,
                LearnRefNumber = learner.LearnRefNumber,
                ProvSpecDelMon = providerSpecDeliveryMonitoring.ProvSpecDelMon,
                ProvSpecDelMonOccur = providerSpecDeliveryMonitoring.ProvSpecDelMonOccur,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN
            };
        }
    }
}