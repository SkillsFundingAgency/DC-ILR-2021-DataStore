using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Invalid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Invalid
{
    public class ProviderSpecLearnerMonitoringBuilder
    {
        public static ProviderSpecLearnerMonitoring BuildInvalidProviderSpecLearnerMonitoring(
            IMessage ilr,
            ILearner learner,
            IProviderSpecLearnerMonitoring providerSpecLearnerMonitoring,
            int learnerId,
            int providerSpecLearnerMonitoringId)
        {
            return new ProviderSpecLearnerMonitoring
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