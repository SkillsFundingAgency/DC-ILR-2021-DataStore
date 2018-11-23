using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Valid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Valid
{
    public class ProviderSpecLearnerMonitoringBuilder
    {
        public static ProviderSpecLearnerMonitoring BuildValidProviderSpecLearnerMonitoring(
            IMessage ilr,
            ILearner learner,
            IProviderSpecLearnerMonitoring providerSpecLearnerMonitoring)
        {
            return new ProviderSpecLearnerMonitoring
            {
                LearnRefNumber = learner.LearnRefNumber,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                ProvSpecLearnMon = providerSpecLearnerMonitoring.ProvSpecLearnMon,
                ProvSpecLearnMonOccur = providerSpecLearnerMonitoring.ProvSpecLearnMonOccur
            };
        }
    }
}