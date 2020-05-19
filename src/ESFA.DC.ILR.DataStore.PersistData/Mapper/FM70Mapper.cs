using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.PersistData.Builders.Extension;
using ESFA.DC.ILR.DataStore.PersistData.Constants;
using ESFA.DC.ILR.DataStore.PersistData.Helpers;
using ESFA.DC.ILR.DataStore.PersistData.Model;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.PersistData.Mapper
{
    public class FM70Mapper : IFM70Mapper
    {
        public void MapData(IDataStoreCache cache, FM70Global fm70Global)
        {
            var learners = fm70Global?.Learners;

            if (learners == null)
            {
                return;
            }

            var ukprn = fm70Global.UKPRN;

            PopulateDataStoreCache(cache, learners, fm70Global, ukprn);
        }

        private void PopulateDataStoreCache(IDataStoreCache cache, IEnumerable<FM70Learner> learners, FM70Global fm70Global, int ukprn)
        {
            cache.AddRange(BuildGlobals(fm70Global, ukprn));

            learners.NullSafeForEach(learner =>
            {
                var learnRefNumber = learner.LearnRefNumber;

                cache.Add(BuildLearner(ukprn, learnRefNumber));
                learner.LearnerDPOutcomes.NullSafeForEach(learnerDp => cache.Add(BuildDPOutcome(learnerDp, ukprn, learnRefNumber)));
                learner.LearningDeliveries.NullSafeForEach(learningDelivery =>
                {
                    var aimSeqNumber = learningDelivery.AimSeqNumber.Value;

                    cache.Add(BuildLearningDelivery(learningDelivery, ukprn, learnRefNumber));
                    learningDelivery.LearningDeliveryDeliverableValues.NullSafeForEach(ldd => cache.Add(BuildLearningDeliveryDeliverable(ldd, ukprn, learnRefNumber, aimSeqNumber)));
                });
            });

            var learningDeliveryPeriodisedValues = learners.SelectMany(l => l.LearningDeliveries.SelectMany(ld => ld.LearningDeliveryDeliverableValues.Select(ldd =>
                    new FundModelESFLearningDeliveryPeriodisedValue<List<LearningDeliveryDeliverablePeriodisedValue>>(ukprn, l.LearnRefNumber, ld.AimSeqNumber.Value, ldd.DeliverableCode, ldd.LearningDeliveryDeliverablePeriodisedValues))));

            cache.AddRange(BuildLearningDeliveryDeliverablePeriods(learningDeliveryPeriodisedValues));

            learningDeliveryPeriodisedValues.NullSafeForEach(ldpv => ldpv.LearningDeliveryPeriodisedValue.NullSafeForEach(learningDeliveryPeriodisedValue => cache.Add(BuildLearningDeliveryDeliverablePeriodisedValue(learningDeliveryPeriodisedValue, ukprn, ldpv.AimSeqNumber, ldpv.LearnRefNumber, ldpv.EsfDeliverableCode))));
        }

        public List<ESF_global> BuildGlobals(FM70Global fm70Global, int ukprn)
        {
            return new List<ESF_global>()
            {
                new ESF_global
                {
                    UKPRN = ukprn,
                    RulebaseVersion = fm70Global.RulebaseVersion,
                }
            };
        }

        public ESF_Learner BuildLearner(int ukprn, string learnRefNumber)
        {
            return new ESF_Learner
            {
                UKPRN = ukprn,
                LearnRefNumber = learnRefNumber
            };
        }

        public ESF_DPOutcome BuildDPOutcome(LearnerDPOutcome learnerDpOutcome, int ukprn, string learnRefNumber)
        {
            return new ESF_DPOutcome
            {
                UKPRN = ukprn,
                LearnRefNumber = learnRefNumber,
                OutCode = learnerDpOutcome.OutCode,
                OutcomeDateForProgression = learnerDpOutcome.OutcomeDateForProgression,
                OutStartDate = learnerDpOutcome.OutStartDate,
                OutType = learnerDpOutcome.OutType,
                PotentialESFProgressionType = learnerDpOutcome.PotentialESFProgressionType,
                ProgressionType = learnerDpOutcome.ProgressionType,
                ReachedThreeMonthPoint = learnerDpOutcome.ReachedThreeMonthPoint,
                ReachedSixMonthPoint = learnerDpOutcome.ReachedSixMonthPoint,
                ReachedTwelveMonthPoint = learnerDpOutcome.ReachedTwelveMonthPoint
            };
        }

        public ESF_LearningDelivery BuildLearningDelivery(LearningDelivery ld, int ukprn, string learnRefNumber)
        {
            return new ESF_LearningDelivery
            {
                UKPRN = ukprn,
                LearnRefNumber = learnRefNumber,
                AimSeqNumber = ld.AimSeqNumber.Value,
                Achieved = ld.LearningDeliveryValue.Achieved,
                AddProgCostElig = ld.LearningDeliveryValue.AddProgCostElig,
                AdjustedAreaCostFactor = ld.LearningDeliveryValue.AdjustedAreaCostFactor,
                AdjustedPremiumFactor = ld.LearningDeliveryValue.AdjustedPremiumFactor,
                AdjustedStartDate = ld.LearningDeliveryValue.AdjustedStartDate,
                AimClassification = ld.LearningDeliveryValue.AimClassification,
                AimValue = ld.LearningDeliveryValue.AimValue,
                ApplicWeightFundRate = ld.LearningDeliveryValue.ApplicWeightFundRate,
                EligibleProgressionOutcomeCode = ld.LearningDeliveryValue.EligibleProgressionOutcomeCode,
                EligibleProgressionOutcomeType = ld.LearningDeliveryValue.EligibleProgressionOutcomeType,
                EligibleProgressionOutomeStartDate = ld.LearningDeliveryValue.EligibleProgressionOutomeStartDate,
                FundStart = ld.LearningDeliveryValue.FundStart,
                LARSWeightedRate = ld.LearningDeliveryValue.LARSWeightedRate,
                LatestPossibleStartDate = ld.LearningDeliveryValue.LatestPossibleStartDate,
                LDESFEngagementStartDate = ld.LearningDeliveryValue.LDESFEngagementStartDate,
                LearnDelLearnerEmpAtStart = ld.LearningDeliveryValue.LearnDelLearnerEmpAtStart,
                PotentiallyEligibleForProgression = ld.LearningDeliveryValue.PotentiallyEligibleForProgression,
                ProgressionEndDate = ld.LearningDeliveryValue.ProgressionEndDate,
                Restart = ld.LearningDeliveryValue.Restart,
                WeightedRateFromESOL = ld.LearningDeliveryValue.WeightedRateFromESOL,
            };
        }

        public ESF_LearningDeliveryDeliverable BuildLearningDeliveryDeliverable(LearningDeliveryDeliverableValues ldd, int ukprn, string learnRefNumber, int aimSeqNumber)
        {
            return new ESF_LearningDeliveryDeliverable
            {
                UKPRN = ukprn,
                LearnRefNumber = learnRefNumber,
                AimSeqNumber = aimSeqNumber,
                DeliverableCode = ldd.DeliverableCode,
                DeliverableUnitCost = ldd.DeliverableUnitCost
            };
        }

        public IEnumerable<ESF_LearningDeliveryDeliverable_Period> BuildLearningDeliveryDeliverablePeriods(IEnumerable<FundModelESFLearningDeliveryPeriodisedValue<List<LearningDeliveryDeliverablePeriodisedValue>>> periodisedValues)
        {
            var learningDeliveryDeliverablePeriods = new List<ESF_LearningDeliveryDeliverable_Period>();

            for (var i = 1; i < 13; i++)
            {
                learningDeliveryDeliverablePeriods.AddRange(
                    periodisedValues.Select(pv =>
                    new ESF_LearningDeliveryDeliverable_Period
                    {
                        UKPRN = pv.Ukprn,
                        LearnRefNumber = pv.LearnRefNumber,
                        AimSeqNumber = pv.AimSeqNumber,
                        DeliverableCode = pv.EsfDeliverableCode,
                        Period = i,
                        AchievementEarnings = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryDeliverablePeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM70Constants.AchievementEarnings), i),
                        AdditionalProgCostEarnings = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryDeliverablePeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM70Constants.AdditionalProgCostEarnings), i),
                        DeliverableVolume = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryDeliverablePeriodisedValue, long?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM70Constants.DeliverableVolume), i),
                        ProgressionEarnings = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryDeliverablePeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM70Constants.ProgressionEarnings), i),
                        ReportingVolume = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryDeliverablePeriodisedValue, int?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM70Constants.ReportingVolume), i),
                        StartEarnings = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryDeliverablePeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM70Constants.StartEarnings), i),
                    }));
            }

            return learningDeliveryDeliverablePeriods;
        }

        public ESF_LearningDeliveryDeliverable_PeriodisedValue BuildLearningDeliveryDeliverablePeriodisedValue(LearningDeliveryDeliverablePeriodisedValue lddpv, int ukprn, int aimSeqNumber, string learnRefNumber, string deliverableCode)
        {
            return new ESF_LearningDeliveryDeliverable_PeriodisedValue
            {
                UKPRN = ukprn,
                AimSeqNumber = aimSeqNumber,
                LearnRefNumber = learnRefNumber,
                DeliverableCode = deliverableCode,
                AttributeName = lddpv.AttributeName,
                Period_1 = lddpv.Period1,
                Period_2 = lddpv.Period2,
                Period_3 = lddpv.Period3,
                Period_4 = lddpv.Period4,
                Period_5 = lddpv.Period5,
                Period_6 = lddpv.Period6,
                Period_7 = lddpv.Period7,
                Period_8 = lddpv.Period8,
                Period_9 = lddpv.Period9,
                Period_10 = lddpv.Period10,
                Period_11 = lddpv.Period11,
                Period_12 = lddpv.Period12
            };
        }
    }
}