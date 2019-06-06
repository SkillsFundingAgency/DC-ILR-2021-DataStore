using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.PersistData.Builders.Invalid
{
    public class ProviderSpecLearnerMonitoringBuilder
    {
        public static ProviderSpecLearnerMonitoring BuildInvalidProviderSpecLearnerMonitoring(
            int ukprn,
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
                UKPRN = ukprn,
                ProvSpecLearnMon = providerSpecLearnerMonitoring.ProvSpecLearnMon,
                ProvSpecLearnMonOccur = providerSpecLearnerMonitoring.ProvSpecLearnMonOccur
            };
        }
    }
}