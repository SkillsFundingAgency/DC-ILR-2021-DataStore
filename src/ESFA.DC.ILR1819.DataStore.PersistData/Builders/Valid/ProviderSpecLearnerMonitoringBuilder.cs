using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Valid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Valid
{
    public class ProviderSpecLearnerMonitoringBuilder
    {
        public static ProviderSpecLearnerMonitoring BuildValidProviderSpecLearnerMonitoring(
            int ukprn,
            ILearner learner,
            IProviderSpecLearnerMonitoring providerSpecLearnerMonitoring)
        {
            return new ProviderSpecLearnerMonitoring
            {
                LearnRefNumber = learner.LearnRefNumber,
                UKPRN = ukprn,
                ProvSpecLearnMon = providerSpecLearnerMonitoring.ProvSpecLearnMon,
                ProvSpecLearnMonOccur = providerSpecLearnerMonitoring.ProvSpecLearnMonOccur
            };
        }
    }
}