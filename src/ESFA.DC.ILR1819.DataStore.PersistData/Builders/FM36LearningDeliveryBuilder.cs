using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders
{
    public class FM36LearningDeliveryBuilder
    {
        public static AEC_LearningDelivery BuildLearningDelivery(LearningDelivery delivery, int ukPrn, string learnRefNum)
        {
            return new AEC_LearningDelivery
            {
                UKPRN = ukPrn,
                LearnRefNumber = learnRefNum,
                AimSeqNumber = delivery.AimSeqNumber,
                ActualDaysIL = delivery.LearningDeliveryValues.ActualDaysIL,
                ActualNumInstalm = delivery.LearningDeliveryValues.ActualNumInstalm,
                AdjStartDate = delivery.LearningDeliveryValues.AdjStartDate,
                AgeAtProgStart = delivery.LearningDeliveryValues.AgeAtProgStart,
                AppAdjLearnStartDate = delivery.LearningDeliveryValues.AppAdjLearnStartDate,
                AppAdjLearnStartDateMatchPathway = delivery.LearningDeliveryValues.AppAdjLearnStartDateMatchPathway,
                ApplicCompDate = delivery.LearningDeliveryValues.ApplicCompDate,
                CombinedAdjProp = delivery.LearningDeliveryValues.CombinedAdjProp,
                Completed = delivery.LearningDeliveryValues.Completed,
                FirstIncentiveThresholdDate = delivery.LearningDeliveryValues.FirstIncentiveThresholdDate,
                FundStart = delivery.LearningDeliveryValues.FundStart,
                LDApplic1618FrameworkUpliftBalancingValue = delivery.LearningDeliveryValues.LDApplic1618FrameworkUpliftBalancingValue,
                LDApplic1618FrameworkUpliftCompElement = delivery.LearningDeliveryValues.LDApplic1618FrameworkUpliftCompElement,
                LDApplic1618FRameworkUpliftCompletionValue = delivery.LearningDeliveryValues.LDApplic1618FRameworkUpliftCompletionValue,
                LDApplic1618FrameworkUpliftMonthInstalVal = delivery.LearningDeliveryValues.LDApplic1618FrameworkUpliftMonthInstalVal,
                LDApplic1618FrameworkUpliftPrevEarnings = delivery.LearningDeliveryValues.LDApplic1618FrameworkUpliftPrevEarnings,
                LDApplic1618FrameworkUpliftPrevEarningsStage1 = delivery.LearningDeliveryValues.LDApplic1618FrameworkUpliftPrevEarningsStage1,
                LDApplic1618FrameworkUpliftRemainingAmount = delivery.LearningDeliveryValues.LDApplic1618FrameworkUpliftRemainingAmount,
                LDApplic1618FrameworkUpliftTotalActEarnings = delivery.LearningDeliveryValues.LDApplic1618FrameworkUpliftTotalActEarnings,
                LearnAimRef = delivery.LearningDeliveryValues.LearnAimRef,
                LearnDel1618AtStart = delivery.LearningDeliveryValues.LearnDel1618AtStart,
                LearnDelAppAccDaysIL = delivery.LearningDeliveryValues.LearnDelAppPrevAccDaysIL,
                LearnDelApplicDisadvAmount = delivery.LearningDeliveryValues.LearnDelApplicDisadvAmount,
                LearnDelApplicEmp1618Incentive = delivery.LearningDeliveryValues.LearnDelApplicEmp1618Incentive,
                LearnDelApplicEmpDate = delivery.LearningDeliveryValues.LearnDelApplicEmpDate,
                LearnDelApplicProv1618FrameworkUplift = delivery.LearningDeliveryValues.LearnDelApplicProv1618FrameworkUplift,
                LearnDelApplicProv1618Incentive = delivery.LearningDeliveryValues.LearnDelApplicProv1618Incentive,
                LearnDelAppPrevAccDaysIL = delivery.LearningDeliveryValues.LearnDelAppPrevAccDaysIL,
                LearnDelDaysIL = delivery.LearningDeliveryValues.LearnDelDaysIL,
                LearnDelDisadAmount = delivery.LearningDeliveryValues.LearnDelDisadAmount,
                LearnDelEligDisadvPayment = delivery.LearningDeliveryValues.LearnDelEligDisadvPayment,
                LearnDelEmpIdFirstAdditionalPaymentThreshold = delivery.LearningDeliveryValues.LearnDelPrevAccDaysILCareLeavers,
                LearnDelEmpIdSecondAdditionalPaymentThreshold = delivery.LearningDeliveryValues.LearnDelPrevAccDaysILCareLeavers,
                LearnDelHistDaysThisApp = delivery.LearningDeliveryValues.LearnDelHistDaysThisApp,
                LearnDelHistProgEarnings = delivery.LearningDeliveryValues.LearnDelHistProgEarnings,
                LearnDelInitialFundLineType = delivery.LearningDeliveryValues.LearnDelInitialFundLineType,
                LearnDelMathEng = delivery.LearningDeliveryValues.LearnDelMathEng,
                MathEngAimValue = delivery.LearningDeliveryValues.MathEngAimValue,
                OutstandNumOnProgInstalm = delivery.LearningDeliveryValues.OutstandNumOnProgInstalm,
                PlannedNumOnProgInstalm = delivery.LearningDeliveryValues.PlannedNumOnProgInstalm,
                PlannedTotalDaysIL = delivery.LearningDeliveryValues.PlannedTotalDaysIL,
                SecondIncentiveThresholdDate = delivery.LearningDeliveryValues.SecondIncentiveThresholdDate,
                ThresholdDays = delivery.LearningDeliveryValues.ThresholdDays,
                LearnDelProgEarliestACT2Date = delivery.LearningDeliveryValues.LearnDelProgEarliestACT2Date,
                LearnDelNonLevyProcured = delivery.LearningDeliveryValues.LearnDelNonLevyProcured,
                LearnDelApplicCareLeaverIncentive = delivery.LearningDeliveryValues.LearnDelApplicCareLeaverIncentive,
                LearnDelHistDaysCareLeavers = delivery.LearningDeliveryValues.LearnDelHistDaysCareLeavers,
                LearnDelAccDaysILCareLeavers = delivery.LearningDeliveryValues.LearnDelAccDaysILCareLeavers,
                LearnDelPrevAccDaysILCareLeavers = delivery.LearningDeliveryValues.LearnDelPrevAccDaysILCareLeavers,
                LearnDelLearnerAddPayThresholdDate = delivery.LearningDeliveryValues.LearnDelLearnerAddPayThresholdDate,
                LearnDelRedCode = delivery.LearningDeliveryValues.LearnDelRedCode,
                LearnDelRedStartDate = delivery.LearningDeliveryValues.LearnDelRedStartDate
            };
        }
    }
}
