using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Invalid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Invalid
{
    public class ProviderSpecDeliveryMonitoringBuilder
    {
        public static ProviderSpecDeliveryMonitoring BuildInvalidProviderSpecDeliveryMonitoringRecord(
            IMessage ilr,
            ILearner learner,
            ILearningDelivery learningDelivery,
            IProviderSpecDeliveryMonitoring providerSpecDeliveryMonitoring,
            int learnerDeliveryId,
            int providerSpecDeliveryMonitoringId)
        {
            return new ProviderSpecDeliveryMonitoring
            {
                ProviderSpecDeliveryMonitoring_Id = providerSpecDeliveryMonitoringId,
                LearningDelivery_Id = learnerDeliveryId,
                AimSeqNumber = learningDelivery.AimSeqNumber,
                LearnRefNumber = learner.LearnRefNumber,
                ProvSpecDelMon = providerSpecDeliveryMonitoring.ProvSpecDelMon,
                ProvSpecDelMonOccur = providerSpecDeliveryMonitoring.ProvSpecDelMonOccur,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN
            };
        }
    }
}