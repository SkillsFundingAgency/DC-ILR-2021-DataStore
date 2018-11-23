using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Rulebase
{
    public class FM81LearningDeliveryBuilder
    {
        public static TBL_LearningDelivery BuildLearningDelivery(int ukPrn, string learnerRefNum, LearningDelivery attribute)
        {
            return new TBL_LearningDelivery
            {
                UKPRN = ukPrn,
                LearnRefNumber = learnerRefNum,
                AimSeqNumber = attribute.AimSeqNumber ?? 0,
                AchApplicDate = attribute.LearningDeliveryValues.AchApplicDate,
                Achieved = attribute.LearningDeliveryValues.Achieved,
                AchEligible = attribute.LearningDeliveryValues.AchEligible,
                AchievementApplicVal = attribute.LearningDeliveryValues.AchievementApplicVal,
                AchPayment = attribute.LearningDeliveryValues.AchPayment,
                AdjProgStartDate = attribute.LearningDeliveryValues.AdjProgStartDate,
                ActualDaysIL = attribute.LearningDeliveryValues.ActualDaysIL,
                ActualNumInstalm = attribute.LearningDeliveryValues.ActualNumInstalm,
                AgeStandardStart = attribute.LearningDeliveryValues.AgeStandardStart,
                ApplicFundValDate = attribute.LearningDeliveryValues.ApplicFundValDate,
                CombinedAdjProp = attribute.LearningDeliveryValues.CombinedAdjProp,
                CoreGovContCapApplicVal = attribute.LearningDeliveryValues.CoreGovContCapApplicVal,
                CoreGovContPayment = attribute.LearningDeliveryValues.CoreGovContPayment,
                CoreGovContUncapped = attribute.LearningDeliveryValues.CoreGovContUncapped,
                LearnSuppFundCash = attribute.LearningDeliveryValues.CoreGovContUncapped,
                EmpIdAchDate = attribute.LearningDeliveryValues.EmpIdAchDate,
                EmpIdFirstDayStandard = attribute.LearningDeliveryValues.EmpIdFirstDayStandard,
                EmpIdFirstYoungAppDate = attribute.LearningDeliveryValues.EmpIdFirstYoungAppDate,
                EmpIdSecondYoungAppDate = attribute.LearningDeliveryValues.EmpIdSecondYoungAppDate,
                EmpIdSmallBusDate = attribute.LearningDeliveryValues.EmpIdSmallBusDate,
                FundLine = attribute.LearningDeliveryValues.FundLine,
                InstPerPeriod = attribute.LearningDeliveryValues.InstPerPeriod,
                LearnDelDaysIL = attribute.LearningDeliveryValues.LearnDelDaysIL,
                LearnDelStandardAccDaysIL = attribute.LearningDeliveryValues.LearnDelStandardAccDaysIL,
                LearnDelStandardPrevAccDaysIL = attribute.LearningDeliveryValues.LearnDelStandardPrevAccDaysIL,
                LearnDelStandardTotalDaysIL = attribute.LearningDeliveryValues.LearnDelStandardTotalDaysIL,
                LearnSuppFund = attribute.LearningDeliveryValues.LearnSuppFund,
                MathEngAimValue = attribute.LearningDeliveryValues.MathEngAimValue,
                MathEngBalPayment = attribute.LearningDeliveryValues.MathEngBalPayment,
                MathEngBalPct = attribute.LearningDeliveryValues.MathEngBalPct,
                MathEngLSFFundStart = attribute.LearningDeliveryValues.MathEngLSFFundStart,
                MathEngLSFThresholdDays = attribute.LearningDeliveryValues.MathEngLSFThresholdDays,
                MathEngOnProgPayment = attribute.LearningDeliveryValues.MathEngOnProgPayment,
                MathEngOnProgPct = attribute.LearningDeliveryValues.MathEngOnProgPct,
                OutstandNumOnProgInstalm = attribute.LearningDeliveryValues.OutstandNumOnProgInstalm,
                PlannedNumOnProgInstalm = attribute.LearningDeliveryValues.PlannedNumOnProgInstalm,
                PlannedTotalDaysIL = attribute.LearningDeliveryValues.PlannedTotalDaysIL,
                ProgStandardStartDate = attribute.LearningDeliveryValues.ProgStandardStartDate,
                SmallBusApplicVal = attribute.LearningDeliveryValues.SmallBusApplicVal,
                SmallBusEligible = attribute.LearningDeliveryValues.SmallBusEligible,
                SmallBusPayment = attribute.LearningDeliveryValues.SmallBusPayment,
                SmallBusStatusFirstDayStandard = attribute.LearningDeliveryValues.SmallBusStatusFirstDayStandard,
                SmallBusStatusThreshold = attribute.LearningDeliveryValues.SmallBusStatusThreshold,
                YoungAppApplicVal = attribute.LearningDeliveryValues.YoungAppApplicVal,
                YoungAppEligible = attribute.LearningDeliveryValues.YoungAppEligible,
                YoungAppFirstPayment = attribute.LearningDeliveryValues.YoungAppFirstPayment,
                YoungAppFirstThresholdDate = attribute.LearningDeliveryValues.YoungAppFirstThresholdDate,
                YoungAppPayment = attribute.LearningDeliveryValues.YoungAppPayment,
                YoungAppSecondPayment = attribute.LearningDeliveryValues.YoungAppSecondPayment,
                YoungAppSecondThresholdDate = attribute.LearningDeliveryValues.YoungAppSecondThresholdDate,
            };
        }
    }
}
