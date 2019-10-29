using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class TBLLearningDeliveryClassMap : ClassMap<TBL_LearningDelivery>
    {
        public TBLLearningDeliveryClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.ProgStandardStartDate);
            Map(m => m.FundLine);
            Map(m => m.MathEngAimValue);
            Map(m => m.PlannedNumOnProgInstalm);
            Map(m => m.LearnSuppFundCash);
            Map(m => m.AdjProgStartDate);
            Map(m => m.LearnSuppFund);
            Map(m => m.AdjStartDate);
            Map(m => m.MathEngOnProgPayment);
            Map(m => m.InstPerPeriod);
            Map(m => m.SmallBusPayment);
            Map(m => m.YoungAppSecondPayment);
            Map(m => m.CoreGovContPayment);
            Map(m => m.YoungAppEligible);
            Map(m => m.SmallBusEligible);
            Map(m => m.MathEngOnProgPct);
            Map(m => m.AgeStandardStart);
            Map(m => m.SmallBusThresholdDate);
            Map(m => m.YoungAppSecondThresholdDate);
            Map(m => m.EmpIdFirstDayStandard);
            Map(m => m.EmpIdFirstYoungAppDate);
            Map(m => m.EmpIdSecondYoungAppDate);
            Map(m => m.EmpIdSmallBusDate);
            Map(m => m.YoungAppFirstThresholdDate);
            Map(m => m.AchApplicDate);
            Map(m => m.AchEligible);
            Map(m => m.Achieved);
            Map(m => m.AchievementApplicVal);
            Map(m => m.AchPayment);
            Map(m => m.ActualNumInstalm);
            Map(m => m.CombinedAdjProp);
            Map(m => m.EmpIdAchDate);
            Map(m => m.LearnDelDaysIL);
            Map(m => m.LearnDelStandardAccDaysIL);
            Map(m => m.LearnDelStandardPrevAccDaysIL);
            Map(m => m.LearnDelStandardTotalDaysIL);
            Map(m => m.ActualDaysIL);
            Map(m => m.MathEngBalPayment);
            Map(m => m.MathEngBalPct);
            Map(m => m.MathEngLSFFundStart);
            Map(m => m.PlannedTotalDaysIL);
            Map(m => m.MathEngLSFThresholdDays);
            Map(m => m.OutstandNumOnProgInstalm);
            Map(m => m.SmallBusApplicVal);
            Map(m => m.SmallBusStatusFirstDayStandard);
            Map(m => m.SmallBusStatusThreshold);
            Map(m => m.YoungAppApplicVal);
            Map(m => m.CoreGovContCapApplicVal);
            Map(m => m.CoreGovContUncapped);
            Map(m => m.ApplicFundValDate);
            Map(m => m.YoungAppFirstPayment);
            Map(m => m.YoungAppPayment);
        }
    }
}
