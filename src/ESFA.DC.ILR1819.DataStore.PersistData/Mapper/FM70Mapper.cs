using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface.Mappers;
using ESFA.DC.ILR1819.DataStore.Model;
using ESFA.DC.ILR1819.DataStore.PersistData.Constants;
using ESFA.DC.ILR1819.DataStore.PersistData.Helpers;
using ESFA.DC.ILR1819.DataStore.PersistData.Model;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Mapper
{
    public class FM70Mapper : IFM70Mapper
    {
        public FM70Data MapData(FM70Global fm70Global)
        {
            var data = new FM70Data();

            if (fm70Global.Learners != null)
            {
                data.Globals = MapGlobals(fm70Global).ToList();
                data.Learners = MapLearners(fm70Global).ToList();
                data.DPOutcomes = MapDPOutcomes(fm70Global).ToList();
                data.LearningDeliveries = MapLearningDeliveries(fm70Global).ToList();
                data.LearningDeliveryDeliverables = MapLearningDeliveryDeliverables(fm70Global).ToList();
                data.LearningDeliveryDeliverablePeriods = MapLearningDeliveryDeliverablePeriods(fm70Global).ToList();
                data.LearningDeliveryDeliverablePeriodisedValues = MapLearningDeliveryDeliverablePeriodisedValues(fm70Global).ToList();
            }

            return data;
        }

        public IEnumerable<ESF_global> MapGlobals(FM70Global fm70Global)
        {
            return new List<ESF_global>()
            {
                new ESF_global
                {
                    UKPRN = fm70Global.UKPRN,
                    RulebaseVersion = fm70Global.RulebaseVersion,
                }
            };
        }

        public IEnumerable<ESF_Learner> MapLearners(FM70Global fm70Global)
        {
            return fm70Global.Learners.Select(l =>
            new ESF_Learner
            {
                UKPRN = fm70Global.UKPRN,
                LearnRefNumber = l.LearnRefNumber
            });
        }

        public IEnumerable<ESF_DPOutcome> MapDPOutcomes(FM70Global fm70Global)
        {
            return fm70Global.Learners.SelectMany(l => l.LearnerDPOutcomes.Select(dp =>
            new ESF_DPOutcome
            {
                UKPRN = fm70Global.UKPRN,
                LearnRefNumber = l.LearnRefNumber,
                OutCode = dp.OutCode,
                OutcomeDateForProgression = dp.OutcomeDateForProgression,
                OutStartDate = dp.OutStartDate,
                OutType = dp.OutType,
                PotentialESFProgressionType = dp.PotentialESFProgressionType,
                ProgressionType = dp.ProgressionType,
                ReachedThreeMonthPoint = dp.ReachedThreeMonthPoint,
                ReachedSixMonthPoint = dp.ReachedSixMonthPoint,
                ReachedTwelveMonthPoint = dp.ReachedTwelveMonthPoint
            }));
        }

        public IEnumerable<ESF_LearningDelivery> MapLearningDeliveries(FM70Global fm70Global)
        {
            return fm70Global.Learners.SelectMany(l => l.LearningDeliveries.Select(ld =>
               new ESF_LearningDelivery
               {
                   UKPRN = fm70Global.UKPRN,
                   LearnRefNumber = l.LearnRefNumber,
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
               }));
        }

        public IEnumerable<ESF_LearningDeliveryDeliverable> MapLearningDeliveryDeliverables(FM70Global fm70Global)
        {
            return fm70Global.Learners.SelectMany(l => l.LearningDeliveries
            .SelectMany(ld => ld.LearningDeliveryDeliverableValues.Select(ldd =>
            new ESF_LearningDeliveryDeliverable
            {
                UKPRN = fm70Global.UKPRN,
                LearnRefNumber = l.LearnRefNumber,
                AimSeqNumber = ld.AimSeqNumber.Value,
                DeliverableCode = ldd.DeliverableCode,
                DeliverableUnitCost = ldd.DeliverableUnitCost
            })));
        }

        public IEnumerable<ESF_LearningDeliveryDeliverable_Period> MapLearningDeliveryDeliverablePeriods(FM70Global fm70Global)
        {
            var periodisedValues = fm70Global.Learners.SelectMany(l => l.LearningDeliveries
           .SelectMany(ld => ld.LearningDeliveryDeliverableValues.Select(ldd =>
            new FundModelESFLearningDeliveryPeriodisedValue<List<LearningDeliveryDeliverablePeriodisedValue>>(fm70Global.UKPRN, l.LearnRefNumber, ld.AimSeqNumber.Value, ldd.DeliverableCode, ldd.LearningDeliveryDeliverablePeriodisedValues))));

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

        public IEnumerable<ESF_LearningDeliveryDeliverable_PeriodisedValue> MapLearningDeliveryDeliverablePeriodisedValues(FM70Global fm70Global)
        {
            var periodisedValues = fm70Global.Learners.SelectMany(l => l.LearningDeliveries
            .SelectMany(ld => ld.LearningDeliveryDeliverableValues.Select(ldd =>
             new FundModelESFLearningDeliveryPeriodisedValue<List<LearningDeliveryDeliverablePeriodisedValue>>(fm70Global.UKPRN, l.LearnRefNumber, ld.AimSeqNumber.Value, ldd.DeliverableCode, ldd.LearningDeliveryDeliverablePeriodisedValues))));

            return
                   periodisedValues.SelectMany(pv => pv.LearningDeliveryPeriodisedValue
                   .Select(p =>
                   new ESF_LearningDeliveryDeliverable_PeriodisedValue
                   {
                       UKPRN = pv.Ukprn,
                       AimSeqNumber = pv.AimSeqNumber,
                       LearnRefNumber = pv.LearnRefNumber,
                       DeliverableCode = pv.EsfDeliverableCode,
                       AttributeName = p.AttributeName,
                       Period_1 = p.Period1,
                       Period_2 = p.Period2,
                       Period_3 = p.Period3,
                       Period_4 = p.Period4,
                       Period_5 = p.Period5,
                       Period_6 = p.Period6,
                       Period_7 = p.Period7,
                       Period_8 = p.Period8,
                       Period_9 = p.Period9,
                       Period_10 = p.Period10,
                       Period_11 = p.Period11,
                       Period_12 = p.Period12
                   }));
        }
    }
}