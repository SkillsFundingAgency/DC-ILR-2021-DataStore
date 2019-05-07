using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Model;
using ESFA.DC.ILR1819.DataStore.Model.Funding;
using ESFA.DC.ILR1819.DataStore.PersistData.Constants;
using ESFA.DC.ILR1819.DataStore.PersistData.Helpers;
using ESFA.DC.ILR1819.DataStore.PersistData.Model;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Mapper
{
    public class FM81Mapper : IFM81Mapper
    {
        public FM81Data MapData(FM81Global fm81Global)
        {
            var data = new FM81Data();

            if (fm81Global.Learners != null)
            {
                data.Globals = MapGlobals(fm81Global).ToList();
                data.Learners = MapLearners(fm81Global).ToList();
                data.LearningDeliveries = MapLearningDeliveries(fm81Global).ToList();
                data.LearningDeliveryPeriods = MapLearningDeliveryPeriods(fm81Global).ToList();
                data.LearningDeliveryPeriodisedValues = MapLearningDeliveryPeriodisedValues(fm81Global).ToList();
            }

            return data;
        }

        public IEnumerable<TBL_global> MapGlobals(FM81Global fm81Global)
        {
            return new List<TBL_global>()
                {
                    new TBL_global
                    {
                        UKPRN = fm81Global.UKPRN,
                        CurFundYr = fm81Global.CurFundYr,
                        LARSVersion = fm81Global.LARSVersion,
                        RulebaseVersion = fm81Global.RulebaseVersion,
                    }
                };
        }

        public IEnumerable<TBL_Learner> MapLearners(FM81Global fm81Global)
        {
            return fm81Global.Learners.Select(l =>
            new TBL_Learner
            {
                UKPRN = fm81Global.UKPRN,
                LearnRefNumber = l.LearnRefNumber,
            });
        }

        public IEnumerable<TBL_LearningDelivery> MapLearningDeliveries(FM81Global fm81Global)
        {
            return fm81Global.Learners.SelectMany(l => l.LearningDeliveries.Select(ld =>
               new TBL_LearningDelivery
               {
                   UKPRN = fm81Global.UKPRN,
                   LearnRefNumber = l.LearnRefNumber,
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
               }));
        }

        public IEnumerable<TBL_LearningDelivery_Period> MapLearningDeliveryPeriods(FM81Global fm81Global)
        {
            var periodisedValues = fm81Global.Learners
               .SelectMany(l => l.LearningDeliveries.Select(ld =>
               new FundModelLearningDeliveryPeriodisedValue<List<LearningDeliveryPeriodisedValue>>(fm81Global.UKPRN, l.LearnRefNumber, ld.AimSeqNumber.Value, ld.LearningDeliveryPeriodisedValues)));

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

        public IEnumerable<TBL_LearningDelivery_PeriodisedValue> MapLearningDeliveryPeriodisedValues(FM81Global fm81Global)
        {
            var periodisedValues = fm81Global.Learners
               .SelectMany(l => l.LearningDeliveries.Select(ld =>
               new FundModelLearningDeliveryPeriodisedValue<List<LearningDeliveryPeriodisedValue>>(fm81Global.UKPRN, l.LearnRefNumber, ld.AimSeqNumber.Value, ld.LearningDeliveryPeriodisedValues)));

            return
                   periodisedValues.SelectMany(pv => pv.LearningDeliveryPeriodisedValue
                   .Select(p =>
                   new TBL_LearningDelivery_PeriodisedValue
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
    }
}