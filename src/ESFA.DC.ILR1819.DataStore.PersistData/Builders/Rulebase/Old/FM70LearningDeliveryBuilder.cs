using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Rulebase
{
    public class FM70LearningDeliveryBuilder
    {
        public static ESF_LearningDelivery BuildLearningDelivery(LearningDelivery delivery, int ukPrn, string learnRefNum)
        {
            return new ESF_LearningDelivery
            {
                UKPRN = ukPrn,
                LearnRefNumber = learnRefNum,
                AimSeqNumber = delivery.AimSeqNumber ?? 0,
                ApplicWeightFundRate = delivery.LearningDeliveryValue.ApplicWeightFundRate,
                AimValue = delivery.LearningDeliveryValue.AimValue,
                WeightedRateFromESOL = delivery.LearningDeliveryValue.WeightedRateFromESOL,
                Achieved = delivery.LearningDeliveryValue.Achieved,
                Restart = delivery.LearningDeliveryValue.Restart,
                FundStart = delivery.LearningDeliveryValue.FundStart,
                AddProgCostElig = delivery.LearningDeliveryValue.AddProgCostElig,
                AdjustedAreaCostFactor = delivery.LearningDeliveryValue.AdjustedAreaCostFactor,
                AdjustedPremiumFactor = delivery.LearningDeliveryValue.AdjustedPremiumFactor,
                AdjustedStartDate = delivery.LearningDeliveryValue.AdjustedStartDate,
                AimClassification = delivery.LearningDeliveryValue.AimClassification,
                EligibleProgressionOutcomeCode = delivery.LearningDeliveryValue.EligibleProgressionOutcomeCode,
                EligibleProgressionOutcomeType = delivery.LearningDeliveryValue.EligibleProgressionOutcomeType,
                EligibleProgressionOutomeStartDate = delivery.LearningDeliveryValue.EligibleProgressionOutomeStartDate,
                LARSWeightedRate = delivery.LearningDeliveryValue.LARSWeightedRate,
                LDESFEngagementStartDate = delivery.LearningDeliveryValue.LDESFEngagementStartDate,
                LatestPossibleStartDate = delivery.LearningDeliveryValue.LatestPossibleStartDate,
                PotentiallyEligibleForProgression = delivery.LearningDeliveryValue.PotentiallyEligibleForProgression,
                ProgressionEndDate = delivery.LearningDeliveryValue.ProgressionEndDate
            };
        }
    }
}
