using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.DataStore.Model;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.PersistData.Builders.Extension;
using ESFA.DC.ILR.DataStore.PersistData.Constants;
using ESFA.DC.ILR.DataStore.PersistData.Helpers;
using ESFA.DC.ILR.DataStore.PersistData.Model;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.PersistData.Mapper
{
    public class FM81Mapper : IFM81Mapper
    {
        public IDataStoreCache MapData(FM81Global fm81Global)
        {
            var cache = new DataStoreCache();
            var learners = fm81Global.Learners;

            if (learners == null)
            {
                return cache;
            }

            var ukprn = fm81Global.UKPRN;

            return PopulateDataStoreCache(cache, learners, fm81Global, ukprn);
        }

        private IDataStoreCache PopulateDataStoreCache(DataStoreCache dataCache, IEnumerable<FM81Learner> learners, FM81Global fm81Global, int ukprn)
        {
            dataCache.AddRange(BuildGlobals(fm81Global, ukprn));

            learners.NullSafeForEach(learner =>
            {
                var learnRefNumber = learner.LearnRefNumber;

                dataCache.Add(BuildLearner(ukprn, learnRefNumber));
                learner.LearningDeliveries.NullSafeForEach(learningDelivery => dataCache.Add(BuildLearningDelivery(learningDelivery, ukprn, learnRefNumber)));
            });

            var learningDeliveryPeriodisedValues = learners.SelectMany(l => l.LearningDeliveries.Select(ld =>
                    new FundModelLearningDeliveryPeriodisedValue<List<LearningDeliveryPeriodisedValue>>(fm81Global.UKPRN, l.LearnRefNumber, ld.AimSeqNumber.Value, ld.LearningDeliveryPeriodisedValues)));

            dataCache.AddRange(BuildLearningDeliveryPeriods(learningDeliveryPeriodisedValues));

            learningDeliveryPeriodisedValues.NullSafeForEach(ldpv => ldpv.LearningDeliveryPeriodisedValue.NullSafeForEach(learningDeliveryPeriodisedValue => dataCache.Add(BuildLearningDeliveryPeriodisedValue(learningDeliveryPeriodisedValue, ukprn, ldpv.AimSeqNumber, ldpv.LearnRefNumber))));

            return dataCache;
        }

        public IEnumerable<TBL_global> BuildGlobals(FM81Global fm81Global, int ukprn)
        {
            return new List<TBL_global>()
            {
                new TBL_global
                {
                    UKPRN = ukprn,
                    CurFundYr = fm81Global.CurFundYr,
                    LARSVersion = fm81Global.LARSVersion,
                    RulebaseVersion = fm81Global.RulebaseVersion,
                }
            };
        }

        public TBL_Learner BuildLearner(int ukprn, string learnRefNumber)
        {
            return new TBL_Learner
            {
                UKPRN = ukprn,
                LearnRefNumber = learnRefNumber,
            };
        }

        public TBL_LearningDelivery BuildLearningDelivery(LearningDelivery ld, int ukprn, string learnRefNumber)
        {
            return new TBL_LearningDelivery
            {
                UKPRN = ukprn,
                LearnRefNumber = learnRefNumber,
                AimSeqNumber = ld.AimSeqNumber.Value,
                AchApplicDate = ld.LearningDeliveryValues.AchApplicDate,
                AchEligible = ld.LearningDeliveryValues.AchEligible,
                Achieved = ld.LearningDeliveryValues.Achieved,
                AchievementApplicVal = ld.LearningDeliveryValues.AchievementApplicVal,
                AchPayment = ld.LearningDeliveryValues.AchPayment,
                ActualDaysIL = ld.LearningDeliveryValues.ActualDaysIL,
                ActualNumInstalm = ld.LearningDeliveryValues.ActualNumInstalm,
                AdjProgStartDate = ld.LearningDeliveryValues.AdjProgStartDate,
                AgeStandardStart = ld.LearningDeliveryValues.AgeStandardStart,
                ApplicFundValDate = ld.LearningDeliveryValues.ApplicFundValDate,
                CombinedAdjProp = ld.LearningDeliveryValues.CombinedAdjProp,
                CoreGovContCapApplicVal = ld.LearningDeliveryValues.CoreGovContCapApplicVal,
                CoreGovContPayment = ld.LearningDeliveryValues.CoreGovContPayment,
                CoreGovContUncapped = ld.LearningDeliveryValues.CoreGovContUncapped,
                EmpIdAchDate = ld.LearningDeliveryValues.EmpIdAchDate,
                EmpIdFirstDayStandard = ld.LearningDeliveryValues.EmpIdFirstDayStandard,
                EmpIdFirstYoungAppDate = ld.LearningDeliveryValues.EmpIdFirstYoungAppDate,
                EmpIdSecondYoungAppDate = ld.LearningDeliveryValues.EmpIdSecondYoungAppDate,
                EmpIdSmallBusDate = ld.LearningDeliveryValues.EmpIdSmallBusDate,
                FundLine = ld.LearningDeliveryValues.FundLine,
                InstPerPeriod = ld.LearningDeliveryValues.InstPerPeriod,
                LearnDelDaysIL = ld.LearningDeliveryValues.LearnDelDaysIL,
                LearnDelStandardAccDaysIL = ld.LearningDeliveryValues.LearnDelStandardAccDaysIL,
                LearnDelStandardPrevAccDaysIL = ld.LearningDeliveryValues.LearnDelStandardPrevAccDaysIL,
                LearnDelStandardTotalDaysIL = ld.LearningDeliveryValues.LearnDelStandardTotalDaysIL,
                LearnSuppFund = ld.LearningDeliveryValues.LearnSuppFund,
                LearnSuppFundCash = ld.LearningDeliveryValues.LearnSuppFundCash,
                MathEngAimValue = ld.LearningDeliveryValues.MathEngAimValue,
                MathEngBalPayment = ld.LearningDeliveryValues.MathEngBalPayment,
                MathEngBalPct = ld.LearningDeliveryValues.MathEngBalPct,
                MathEngLSFFundStart = ld.LearningDeliveryValues.MathEngLSFFundStart,
                MathEngLSFThresholdDays = ld.LearningDeliveryValues.MathEngLSFThresholdDays,
                MathEngOnProgPayment = ld.LearningDeliveryValues.MathEngOnProgPayment,
                MathEngOnProgPct = ld.LearningDeliveryValues.MathEngOnProgPct,
                OutstandNumOnProgInstalm = ld.LearningDeliveryValues.OutstandNumOnProgInstalm,
                PlannedNumOnProgInstalm = ld.LearningDeliveryValues.PlannedNumOnProgInstalm,
                PlannedTotalDaysIL = ld.LearningDeliveryValues.PlannedTotalDaysIL,
                ProgStandardStartDate = ld.LearningDeliveryValues.ProgStandardStartDate,
                SmallBusApplicVal = ld.LearningDeliveryValues.SmallBusApplicVal,
                SmallBusEligible = ld.LearningDeliveryValues.SmallBusEligible,
                SmallBusPayment = ld.LearningDeliveryValues.SmallBusPayment,
                SmallBusStatusFirstDayStandard = ld.LearningDeliveryValues.SmallBusStatusFirstDayStandard,
                SmallBusStatusThreshold = ld.LearningDeliveryValues.SmallBusStatusThreshold,
                YoungAppApplicVal = ld.LearningDeliveryValues.YoungAppApplicVal,
                YoungAppEligible = ld.LearningDeliveryValues.YoungAppEligible,
                YoungAppFirstPayment = ld.LearningDeliveryValues.YoungAppFirstPayment,
                YoungAppFirstThresholdDate = ld.LearningDeliveryValues.YoungAppFirstThresholdDate,
                YoungAppPayment = ld.LearningDeliveryValues.YoungAppPayment,
                YoungAppSecondPayment = ld.LearningDeliveryValues.YoungAppSecondPayment,
                YoungAppSecondThresholdDate = ld.LearningDeliveryValues.YoungAppSecondThresholdDate
            };
        }

        public IEnumerable<TBL_LearningDelivery_Period> BuildLearningDeliveryPeriods(IEnumerable<FundModelLearningDeliveryPeriodisedValue<List<LearningDeliveryPeriodisedValue>>> periodisedValues)
        {
            var learningDeliveryPeriods = new List<TBL_LearningDelivery_Period>();

            for (var i = 1; i < 13; i++)
            {
                learningDeliveryPeriods.AddRange(
                    periodisedValues.Select(pv =>
                    new TBL_LearningDelivery_Period
                    {
                        UKPRN = pv.Ukprn,
                        LearnRefNumber = pv.LearnRefNumber,
                        AimSeqNumber = pv.AimSeqNumber,
                        Period = i,
                        AchPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM81Constants.AchPayment), i),
                        CoreGovContPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM81Constants.CoreGovContPayment), i),
                        CoreGovContUncapped = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM81Constants.CoreGovContUncapped), i),
                        InstPerPeriod = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, int?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM81Constants.InstPerPeriod), i),
                        LearnSuppFund = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, bool?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM81Constants.LearnSuppFund), i),
                        LearnSuppFundCash = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM81Constants.LearnSuppFundCash), i),
                        MathEngBalPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM81Constants.MathEngBalPayment), i),
                        MathEngBalPct = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM81Constants.MathEngBalPct), i),
                        MathEngOnProgPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM81Constants.MathEngOnProgPayment), i),
                        MathEngOnProgPct = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM81Constants.MathEngOnProgPct), i),
                        SmallBusPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM81Constants.SmallBusPayment), i),
                        YoungAppFirstPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM81Constants.YoungAppFirstPayment), i),
                        YoungAppPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM81Constants.YoungAppPayment), i),
                        YoungAppSecondPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM81Constants.YoungAppSecondPayment), i),
                    }));
            }

            return learningDeliveryPeriods;
        }

        public TBL_LearningDelivery_PeriodisedValue BuildLearningDeliveryPeriodisedValue(LearningDeliveryPeriodisedValue learningDeliveryPeriodisedValue, int ukprn, int aimSeqNumber, string learnRefNumber)
        {
            return new TBL_LearningDelivery_PeriodisedValue
            {
                UKPRN = ukprn,
                AimSeqNumber = aimSeqNumber,
                LearnRefNumber = learnRefNumber,
                AttributeName = learningDeliveryPeriodisedValue.AttributeName,
                Period_1 = learningDeliveryPeriodisedValue.Period1,
                Period_2 = learningDeliveryPeriodisedValue.Period2,
                Period_3 = learningDeliveryPeriodisedValue.Period3,
                Period_4 = learningDeliveryPeriodisedValue.Period4,
                Period_5 = learningDeliveryPeriodisedValue.Period5,
                Period_6 = learningDeliveryPeriodisedValue.Period6,
                Period_7 = learningDeliveryPeriodisedValue.Period7,
                Period_8 = learningDeliveryPeriodisedValue.Period8,
                Period_9 = learningDeliveryPeriodisedValue.Period9,
                Period_10 = learningDeliveryPeriodisedValue.Period10,
                Period_11 = learningDeliveryPeriodisedValue.Period11,
                Period_12 = learningDeliveryPeriodisedValue.Period12
            };
        }
    }
}