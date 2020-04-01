using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class TBL_LearningDelivery
    {
        public TBL_LearningDelivery()
        {
            TBL_LearningDelivery_PeriodisedValues = new HashSet<TBL_LearningDelivery_PeriodisedValue>();
            TBL_LearningDelivery_Periods = new HashSet<TBL_LearningDelivery_Period>();
        }

        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int AimSeqNumber { get; set; }
        public DateTime? ProgStandardStartDate { get; set; }
        public string FundLine { get; set; }
        public decimal? MathEngAimValue { get; set; }
        public int? PlannedNumOnProgInstalm { get; set; }
        public decimal? LearnSuppFundCash { get; set; }
        public DateTime? AdjProgStartDate { get; set; }
        public bool? LearnSuppFund { get; set; }
        public DateTime? AdjStartDate { get; set; }
        public decimal? MathEngOnProgPayment { get; set; }
        public int? InstPerPeriod { get; set; }
        public decimal? SmallBusPayment { get; set; }
        public decimal? YoungAppSecondPayment { get; set; }
        public decimal? CoreGovContPayment { get; set; }
        public bool? YoungAppEligible { get; set; }
        public bool? SmallBusEligible { get; set; }
        public int? MathEngOnProgPct { get; set; }
        public int? AgeStandardStart { get; set; }
        public DateTime? SmallBusThresholdDate { get; set; }
        public DateTime? YoungAppSecondThresholdDate { get; set; }
        public int? EmpIdFirstDayStandard { get; set; }
        public int? EmpIdFirstYoungAppDate { get; set; }
        public int? EmpIdSecondYoungAppDate { get; set; }
        public int? EmpIdSmallBusDate { get; set; }
        public DateTime? YoungAppFirstThresholdDate { get; set; }
        public DateTime? AchApplicDate { get; set; }
        public bool? AchEligible { get; set; }
        public bool? Achieved { get; set; }
        public decimal? AchievementApplicVal { get; set; }
        public decimal? AchPayment { get; set; }
        public int? ActualNumInstalm { get; set; }
        public decimal? CombinedAdjProp { get; set; }
        public int? EmpIdAchDate { get; set; }
        public int? LearnDelDaysIL { get; set; }
        public int? LearnDelStandardAccDaysIL { get; set; }
        public int? LearnDelStandardPrevAccDaysIL { get; set; }
        public int? LearnDelStandardTotalDaysIL { get; set; }
        public int? ActualDaysIL { get; set; }
        public decimal? MathEngBalPayment { get; set; }
        public long? MathEngBalPct { get; set; }
        public bool? MathEngLSFFundStart { get; set; }
        public int? PlannedTotalDaysIL { get; set; }
        public int? MathEngLSFThresholdDays { get; set; }
        public int? OutstandNumOnProgInstalm { get; set; }
        public decimal? SmallBusApplicVal { get; set; }
        public int? SmallBusStatusFirstDayStandard { get; set; }
        public int? SmallBusStatusThreshold { get; set; }
        public decimal? YoungAppApplicVal { get; set; }
        public long? CoreGovContCapApplicVal { get; set; }
        public decimal? CoreGovContUncapped { get; set; }
        public DateTime? ApplicFundValDate { get; set; }
        public decimal? YoungAppFirstPayment { get; set; }
        public decimal? YoungAppPayment { get; set; }

        public virtual TBL_Learner TBL_Learner { get; set; }
        public virtual ICollection<TBL_LearningDelivery_PeriodisedValue> TBL_LearningDelivery_PeriodisedValues { get; set; }
        public virtual ICollection<TBL_LearningDelivery_Period> TBL_LearningDelivery_Periods { get; set; }
    }
}
