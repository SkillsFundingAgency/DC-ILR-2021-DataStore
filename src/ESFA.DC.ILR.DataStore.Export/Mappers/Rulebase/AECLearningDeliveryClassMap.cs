using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class AECLearningDeliveryClassMap : ClassMap<AEC_LearningDelivery>
    {
        public AECLearningDeliveryClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.ActualDaysIL);
            Map(m => m.ActualNumInstalm);
            Map(m => m.AdjStartDate);
            Map(m => m.AgeAtProgStart);
            Map(m => m.AppAdjLearnStartDate);
            Map(m => m.AppAdjLearnStartDateMatchPathway);
            Map(m => m.ApplicCompDate);
            Map(m => m.CombinedAdjProp);
            Map(m => m.Completed);
            Map(m => m.FirstIncentiveThresholdDate);
            Map(m => m.FundStart);
            Map(m => m.LDApplic1618FrameworkUpliftTotalActEarnings);
            Map(m => m.LearnAimRef);
            Map(m => m.LearnDel1618AtStart);
            Map(m => m.LearnDelAppAccDaysIL);
            Map(m => m.LearnDelApplicDisadvAmount);
            Map(m => m.LearnDelApplicEmp1618Incentive);
            Map(m => m.LearnDelApplicEmpDate);
            Map(m => m.LearnDelApplicProv1618FrameworkUplift);
            Map(m => m.LearnDelApplicProv1618Incentive);
            Map(m => m.LearnDelAppPrevAccDaysIL);
            Map(m => m.LearnDelDaysIL);
            Map(m => m.LearnDelDisadAmount);
            Map(m => m.LearnDelEligDisadvPayment);
            Map(m => m.LearnDelEmpIdFirstAdditionalPaymentThreshold);
            Map(m => m.LearnDelEmpIdSecondAdditionalPaymentThreshold);
            Map(m => m.LearnDelHistDaysThisApp);
            Map(m => m.LearnDelHistProgEarnings);
            Map(m => m.LearnDelInitialFundLineType);
            Map(m => m.LearnDelMathEng);
            Map(m => m.MathEngAimValue);
            Map(m => m.OutstandNumOnProgInstalm);
            Map(m => m.PlannedNumOnProgInstalm);
            Map(m => m.PlannedTotalDaysIL);
            Map(m => m.SecondIncentiveThresholdDate);
            Map(m => m.ThresholdDays);
            Map(m => m.LearnDelProgEarliestACT2Date);
            Map(m => m.LearnDelNonLevyProcured);
            Map(m => m.LearnDelApplicCareLeaverIncentive);
            Map(m => m.LearnDelHistDaysCareLeavers);
            Map(m => m.LearnDelAccDaysILCareLeavers);
            Map(m => m.LearnDelPrevAccDaysILCareLeavers);
            Map(m => m.LearnDelLearnerAddPayThresholdDate);
            Map(m => m.LearnDelRedCode);
            Map(m => m.LearnDelRedStartDate);
        }
    }
}
