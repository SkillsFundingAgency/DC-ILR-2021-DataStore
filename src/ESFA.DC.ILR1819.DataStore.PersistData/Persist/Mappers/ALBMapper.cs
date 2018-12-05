using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface.Mappers;
using ESFA.DC.ILR1819.DataStore.PersistData.Constants;
using ESFA.DC.ILR1819.DataStore.PersistData.Helpers;
using ESFA.DC.ILR1819.DataStore.PersistData.Model;
using static ESFA.DC.ILR1819.DataStore.PersistData.Constants.PersistDataConstants;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist.Mappers
{
    public class ALBMapper : IALBMapper
    {
        public ALBMapper()
        {
        }

        public ALB_global MapGlobal(ALBGlobal albGlobal)
        {
            return new ALB_global
            {
                UKPRN = albGlobal.UKPRN,
                LARSVersion = albGlobal.LARSVersion,
                PostcodeAreaCostVersion = albGlobal.PostcodeAreaCostVersion,
                RulebaseVersion = albGlobal.RulebaseVersion
            };
        }

        public IEnumerable<ALB_Learner> MapLearners(ALBGlobal albGlobal)
        {
            return albGlobal.Learners.Select(l => new ALB_Learner
            {
                UKPRN = albGlobal.UKPRN,
                LearnRefNumber = l.LearnRefNumber
            });
        }

        public IEnumerable<ALB_Learner_Period> MapLearnerPeriods(ALBGlobal albGlobal)
        {
            var periodisedValues = albGlobal.Learners.Select(l => new FundModelLearnerPeriodisedValue<List<LearnerPeriodisedValue>>(albGlobal.UKPRN, l.LearnRefNumber, l.LearnerPeriodisedValues));

            var learnerPeriods = new List<ALB_Learner_Period>();

            for (var i = 1; i < 13; i++)
            {
                learnerPeriods.AddRange(
                    periodisedValues.Select(pv =>
                    new ALB_Learner_Period
                    {
                        UKPRN = pv.Ukprn,
                        LearnRefNumber = pv.LearnRefNumber,
                        Period = i,
                        ALBSeqNum = GetPeriodValue<LearnerPeriodisedValue, int?>(pv.LearnerPeriodisedValue.FirstOrDefault(a => a.AttributeName == ALBConstants.ALBSeqNum), i),
                    }));
            }

            return learnerPeriods;
        }

        public IEnumerable<ALB_Learner_PeriodisedValues> MapLearnerPeriodisedValues(ALBGlobal albGlobal)
        {
            var periodisedValues = albGlobal.Learners.Select(l => new FundModelLearnerPeriodisedValue<List<LearnerPeriodisedValue>>(albGlobal.UKPRN, l.LearnRefNumber, l.LearnerPeriodisedValues));

            return
                   periodisedValues.SelectMany(pv => pv.LearnerPeriodisedValue
                   .Select(p =>
                   new ALB_Learner_PeriodisedValues
                   {
                       UKPRN = pv.Ukprn,
                       LearnRefNumber = pv.LearnRefNumber,
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

        public IEnumerable<ALB_LearningDelivery> MapLearningDeliveries(ALBGlobal albGlobal)
        {
            return albGlobal.Learners
               .SelectMany(l => l.LearningDeliveries.Select(ld =>
               new ALB_LearningDelivery
               {
                   UKPRN = albGlobal.UKPRN,
                   LearnRefNumber = l.LearnRefNumber,
                   AimSeqNumber = ld.AimSeqNumber,
                   Achieved = ld.LearningDeliveryValue.Achieved,
                   ActualNumInstalm = ld.LearningDeliveryValue.ActualNumInstalm,
                   AdvLoan = ld.LearningDeliveryValue.AdvLoan,
                   ApplicFactDate = ld.LearningDeliveryValue.ApplicFactDate,
                   ApplicProgWeightFact = ld.LearningDeliveryValue.ApplicProgWeightFact,
                   AreaCostFactAdj = ld.LearningDeliveryValue.AreaCostFactAdj,
                   AreaCostInstalment = ld.LearningDeliveryValue.AreaCostInstalment,
                   FundLine = ld.LearningDeliveryValue.FundLine,
                   FundStart = ld.LearningDeliveryValue.FundStart,
                   LearnDelApplicLARSCarPilFundSubRate = ld.LearningDeliveryValue.LearnDelApplicLARSCarPilFundSubRate,
                   LearnDelApplicSubsidyPilotAreaCode = ld.LearningDeliveryValue.LearnDelApplicSubsidyPilotAreaCode,
                   LearnDelCarLearnPilotAimValue = ld.LearningDeliveryValue.LearnDelCarLearnPilotAimValue,
                   LearnDelCarLearnPilotInstalAmount = ld.LearningDeliveryValue.LearnDelCarLearnPilotInstalAmount,
                   LearnDelEligCareerLearnPilot = ld.LearningDeliveryValue.LearnDelEligCareerLearnPilot,
                   LiabilityDate = ld.LearningDeliveryValue.LiabilityDate,
                   LoanBursAreaUplift = ld.LearningDeliveryValue.LoanBursAreaUplift,
                   LoanBursSupp = ld.LearningDeliveryValue.LoanBursSupp,
                   OutstndNumOnProgInstalm = ld.LearningDeliveryValue.OutstndNumOnProgInstalm,
                   WeightedRate = ld.LearningDeliveryValue.WeightedRate
               }));
        }

        public IEnumerable<ALB_LearningDelivery_Period> MapLearningDeliveryPeriods(ALBGlobal albGlobal)
        {
            var periodisedValues = albGlobal.Learners
               .SelectMany(l => l.LearningDeliveries.Select(ld =>
               new FundModelLearningDeliveryPeriodisedValue<List<LearningDeliveryPeriodisedValue>>(albGlobal.UKPRN, l.LearnRefNumber, ld.AimSeqNumber, ld.LearningDeliveryPeriodisedValues)));

            var learningDeliveryPeriods = new List<ALB_LearningDelivery_Period>();

            for (var i = 1; i < 13; i++)
            {
                learningDeliveryPeriods.AddRange(
                    periodisedValues.Select(pv =>
                    new ALB_LearningDelivery_Period
                    {
                        UKPRN = pv.Ukprn,
                        LearnRefNumber = pv.LearnRefNumber,
                        AimSeqNumber = pv.AimSeqNumber,
                        Period = i,
                        ALBSupportPayment = GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == ALBConstants.ALBSupportPayment), i),
                        AreaUpliftBalPayment = GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == ALBConstants.AreaUpliftBalPayment), i),
                        AreaUpliftOnProgPayment = GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == ALBConstants.AreaUpliftOnProgPayment), i),
                        LearnDelCarLearnPilotBalPayment = GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == ALBConstants.LearnDelCarLearnPilotBalPayment), i),
                        LearnDelCarLearnPilotOnProgPayment = GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == ALBConstants.LearnDelCarLearnPilotOnProgPayment), i)
                    }));
            }

            return learningDeliveryPeriods;
        }

        public IEnumerable<ALB_LearningDelivery_PeriodisedValues> MapLearningDeliveryPeriodisedValues(ALBGlobal albGLobal)
        {
            var periodisedValues = albGLobal.Learners
               .SelectMany(l => l.LearningDeliveries.Select(ld =>
               new FundModelLearningDeliveryPeriodisedValue<List<LearningDeliveryPeriodisedValue>>(albGLobal.UKPRN, l.LearnRefNumber, ld.AimSeqNumber, ld.LearningDeliveryPeriodisedValues)));

            return
                   periodisedValues.SelectMany(pv => pv.LearningDeliveryPeriodisedValue
                   .Select(p =>
                   new ALB_LearningDelivery_PeriodisedValues
                   {
                       UKPRN = pv.Ukprn,
                       AimSeqNumber = pv.AimSeqNumber,
                       LearnRefNumber = pv.LearnRefNumber,
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

        private static TR GetPeriodValue<T, TR>(T periodisedValue, int period)
        {
            var value = periodisedValue?.GetType().GetProperty($"{PeriodPrefix}{period.ToString()}")?.GetValue(periodisedValue);

            return TypeHelper.PeriodValueTypeHandler<TR>(value);
        }
    }
}