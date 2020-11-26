using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.PersistData.Builders.Extension;
using ESFA.DC.ILR.DataStore.PersistData.Constants;
using ESFA.DC.ILR.DataStore.PersistData.Helpers;
using ESFA.DC.ILR.DataStore.PersistData.Model;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR2021.DataStore.EF;
using LearningDelivery = ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output.LearningDelivery;

namespace ESFA.DC.ILR.DataStore.PersistData.Mapper
{
    public class ALBMapper : IALBMapper
    {
        public void MapALBData(IDataStoreCache cache, ALBGlobal albGlobal)
        {
            var learners = albGlobal?.Learners;

            if (learners == null)
            {
                return;
            }

            var ukprn = albGlobal.UKPRN;

            PopulateDataStoreCache(cache, learners, albGlobal, ukprn);
        }

        private void PopulateDataStoreCache(IDataStoreCache cache, IEnumerable<ALBLearner> learners, ALBGlobal albGlobal, int ukprn)
        {
            cache.AddRange(BuildGlobals(albGlobal, ukprn));

            learners.NullSafeForEach(learner =>
            {
                var learnRefNumber = learner.LearnRefNumber;

                cache.Add(BuildLearner(learnRefNumber, ukprn));

                learner.LearningDeliveries.NullSafeForEach(ld => cache.Add(BuildLearningDelivery(ld, ukprn, learnRefNumber)));
            });

            var periodisedValues = learners.Select(l => new FundModelLearnerPeriodisedValue<List<LearnerPeriodisedValue>>(ukprn, l.LearnRefNumber, l.LearnerPeriodisedValues));

            cache.AddRange(BuildLearnerPeriods(periodisedValues, ukprn));

            periodisedValues.NullSafeForEach(pv => pv.LearnerPeriodisedValue.NullSafeForEach(lpv => cache.Add(BuildLearnerPeriodisedValue(lpv, ukprn, pv.LearnRefNumber))));

            var learningDeliveryPeriodisedValues = learners
                .SelectMany(l => l.LearningDeliveries.Select(ld =>
                    new FundModelLearningDeliveryPeriodisedValue<List<LearningDeliveryPeriodisedValue>>(ukprn, l.LearnRefNumber, ld.AimSeqNumber, ld.LearningDeliveryPeriodisedValues)));

            cache.AddRange(BuildLearningDeliveryPeriods(learningDeliveryPeriodisedValues, ukprn));

            learningDeliveryPeriodisedValues.NullSafeForEach(ldpv => ldpv.LearningDeliveryPeriodisedValue.NullSafeForEach(learningDeliveryPeriodisedValue => cache.Add(BuildLearningDeliveryPeriodisedValues(learningDeliveryPeriodisedValue, ldpv.AimSeqNumber, ukprn, ldpv.LearnRefNumber))));
        }

        public List<ALB_global> BuildGlobals(ALBGlobal albGlobal, int ukprn)
        {
            return new List<ALB_global>()
            {
                new ALB_global
                {
                    UKPRN = ukprn,
                    LARSVersion = albGlobal.LARSVersion,
                    PostcodeAreaCostVersion = albGlobal.PostcodeAreaCostVersion,
                    RulebaseVersion = albGlobal.RulebaseVersion
                }
            };
        }

        public ALB_Learner BuildLearner(string learnRefNumber, int ukprn)
        {
            return new ALB_Learner
            {
                UKPRN = ukprn,
                LearnRefNumber = learnRefNumber
            };
        }

        public List<ALB_Learner_Period> BuildLearnerPeriods(IEnumerable<FundModelLearnerPeriodisedValue<List<LearnerPeriodisedValue>>> periodisedValues, int ukprn)
        {
            var learnerPeriods = new List<ALB_Learner_Period>();

            for (var i = 1; i < 13; i++)
            {
                learnerPeriods.AddRange(
                    periodisedValues.Select(pv =>
                        new ALB_Learner_Period
                        {
                            UKPRN = ukprn,
                            LearnRefNumber = pv.LearnRefNumber,
                            Period = i,
                            ALBSeqNum = PeriodisedValueHelper.GetPeriodValue<LearnerPeriodisedValue, int?>(pv.LearnerPeriodisedValue.FirstOrDefault(a => a.AttributeName == ALBConstants.ALBSeqNum), i),
                        }));
            }

            return learnerPeriods;
        }

        public ALB_Learner_PeriodisedValue BuildLearnerPeriodisedValue(LearnerPeriodisedValue periodisedValue, int ukprn, string learnRefNumber)
        {
            return new ALB_Learner_PeriodisedValue
            {
                UKPRN = ukprn,
                LearnRefNumber = learnRefNumber,
                AttributeName = periodisedValue.AttributeName,
                Period_1 = periodisedValue.Period1,
                Period_2 = periodisedValue.Period2,
                Period_3 = periodisedValue.Period3,
                Period_4 = periodisedValue.Period4,
                Period_5 = periodisedValue.Period5,
                Period_6 = periodisedValue.Period6,
                Period_7 = periodisedValue.Period7,
                Period_8 = periodisedValue.Period8,
                Period_9 = periodisedValue.Period9,
                Period_10 = periodisedValue.Period10,
                Period_11 = periodisedValue.Period11,
                Period_12 = periodisedValue.Period12
            };
        }

        public ALB_LearningDelivery BuildLearningDelivery(LearningDelivery ld, int ukprn, string learnRefNumber)
        {
            return new ALB_LearningDelivery
            {
                UKPRN = ukprn,
                LearnRefNumber = learnRefNumber,
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
                LiabilityDate = ld.LearningDeliveryValue.LiabilityDate,
                LoanBursAreaUplift = ld.LearningDeliveryValue.LoanBursAreaUplift,
                LoanBursSupp = ld.LearningDeliveryValue.LoanBursSupp,
                OutstndNumOnProgInstalm = ld.LearningDeliveryValue.OutstndNumOnProgInstalm,
                PlannedNumOnProgInstalm = ld.LearningDeliveryValue.PlannedNumOnProgInstalm,
                WeightedRate = ld.LearningDeliveryValue.WeightedRate,
            };
        }

        public IEnumerable<ALB_LearningDelivery_Period> BuildLearningDeliveryPeriods(IEnumerable<FundModelLearningDeliveryPeriodisedValue<List<LearningDeliveryPeriodisedValue>>> periodisedValues, int ukprn)
        {
            var learningDeliveryPeriods = new List<ALB_LearningDelivery_Period>();

            for (var i = 1; i < 13; i++)
            {
                learningDeliveryPeriods.AddRange(
                    periodisedValues.Select(pv =>
                        new ALB_LearningDelivery_Period
                        {
                            UKPRN = ukprn,
                            LearnRefNumber = pv.LearnRefNumber,
                            AimSeqNumber = pv.AimSeqNumber,
                            Period = i,
                            ALBCode = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, int?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == ALBConstants.ALBCode), i),
                            ALBSupportPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == ALBConstants.ALBSupportPayment), i),
                            AreaUpliftBalPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == ALBConstants.AreaUpliftBalPayment), i),
                            AreaUpliftOnProgPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == ALBConstants.AreaUpliftOnProgPayment), i)
                        }));
            }

            return learningDeliveryPeriods;
        }

        public ALB_LearningDelivery_PeriodisedValue BuildLearningDeliveryPeriodisedValues(LearningDeliveryPeriodisedValue ldpv, int aimSeqNumber, int ukprn, string learnRefNumber)
        {
            return new ALB_LearningDelivery_PeriodisedValue
            {
                UKPRN = ukprn,
                AimSeqNumber = aimSeqNumber,
                LearnRefNumber = learnRefNumber,
                AttributeName = ldpv.AttributeName,
                Period_1 = ldpv.Period1,
                Period_2 = ldpv.Period2,
                Period_3 = ldpv.Period3,
                Period_4 = ldpv.Period4,
                Period_5 = ldpv.Period5,
                Period_6 = ldpv.Period6,
                Period_7 = ldpv.Period7,
                Period_8 = ldpv.Period8,
                Period_9 = ldpv.Period9,
                Period_10 = ldpv.Period10,
                Period_11 = ldpv.Period11,
                Period_12 = ldpv.Period12
            };
        }
    }
}