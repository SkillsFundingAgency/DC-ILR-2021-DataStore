using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ESFLearningDeliveryClassMap : ClassMap<ESF_LearningDelivery>
    {
        public ESFLearningDeliveryClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.Achieved);
            Map(m => m.AddProgCostElig);
            Map(m => m.AdjustedAreaCostFactor);
            Map(m => m.AdjustedPremiumFactor);
            Map(m => m.AdjustedStartDate);
            Map(m => m.AimClassification);
            Map(m => m.AimValue);
            Map(m => m.ApplicWeightFundRate);
            Map(m => m.EligibleProgressionOutcomeCode);
            Map(m => m.EligibleProgressionOutcomeType);
            Map(m => m.EligibleProgressionOutomeStartDate);
            Map(m => m.FundStart);
            Map(m => m.LARSWeightedRate);
            Map(m => m.LatestPossibleStartDate);
            Map(m => m.LDESFEngagementStartDate);
            Map(m => m.LearnDelLearnerEmpAtStart);
            Map(m => m.PotentiallyEligibleForProgression);
            Map(m => m.ProgressionEndDate);
            Map(m => m.Restart);
            Map(m => m.WeightedRateFromESOL);
        }
    }
}
