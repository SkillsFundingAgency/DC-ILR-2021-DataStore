using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders
{
    public class ProviderSpecDeliveryMonitoringBuilder
    {
        public static EF.Valid.ProviderSpecDeliveryMonitoring BuildValidProviderSpecDeliveryMonitoringRecord(
            IMessage ilr,
            ILearner learner,
            ILearningDelivery learningDelivery,
            IProviderSpecDeliveryMonitoring providerSpecDeliveryMonitoring)
        {
            return new EF.Valid.ProviderSpecDeliveryMonitoring
            {
                AimSeqNumber = learningDelivery.AimSeqNumber,
                LearnRefNumber = learner.LearnRefNumber,
                ProvSpecDelMon = providerSpecDeliveryMonitoring.ProvSpecDelMon,
                ProvSpecDelMonOccur = providerSpecDeliveryMonitoring.ProvSpecDelMonOccur,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN
            };
        }

        public static EF.Invalid.ProviderSpecDeliveryMonitoring BuildInvalidProviderSpecDeliveryMonitoringRecord(
            IMessage ilr,
            ILearner learner,
            ILearningDelivery learningDelivery,
            IProviderSpecDeliveryMonitoring providerSpecDeliveryMonitoring,
            int learnerDeliveryId,
            int providerSpecDeliveryMonitoringId)
        {
            return new EF.Invalid.ProviderSpecDeliveryMonitoring
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