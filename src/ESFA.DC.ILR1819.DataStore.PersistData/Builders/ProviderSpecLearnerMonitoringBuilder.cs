using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders
{
    public class ProviderSpecLearnerMonitoringBuilder
    {
        public static EF.Valid.ProviderSpecLearnerMonitoring BuildValidProviderSpecLearnerMonitoring(
            IMessage ilr,
            ILearner learner,
            IProviderSpecLearnerMonitoring providerSpecLearnerMonitoring)
        {
            return new EF.Valid.ProviderSpecLearnerMonitoring
            {
                LearnRefNumber = learner.LearnRefNumber,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                ProvSpecLearnMon = providerSpecLearnerMonitoring.ProvSpecLearnMon,
                ProvSpecLearnMonOccur = providerSpecLearnerMonitoring.ProvSpecLearnMonOccur
            };
        }

        public static EF.Invalid.ProviderSpecLearnerMonitoring BuildInvalidProviderSpecLearnerMonitoring(
            IMessage ilr,
            ILearner learner,
            IProviderSpecLearnerMonitoring providerSpecLearnerMonitoring,
            int learnerId,
            int providerSpecLearnerMonitoringId)
        {
            return new EF.Invalid.ProviderSpecLearnerMonitoring
            {
                ProviderSpecLearnerMonitoring_Id = providerSpecLearnerMonitoringId,
                Learner_Id = learnerId,
                LearnRefNumber = learner.LearnRefNumber,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                ProvSpecLearnMon = providerSpecLearnerMonitoring.ProvSpecLearnMon,
                ProvSpecLearnMonOccur = providerSpecLearnerMonitoring.ProvSpecLearnMonOccur
            };
        }
    }
}