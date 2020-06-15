using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF
{
    public partial class AEC_LearningDelivery
    {
        public AEC_LearningDelivery()
        {
            AEC_LearningDelivery_PeriodisedTextValues = new HashSet<AEC_LearningDelivery_PeriodisedTextValue>();
            AEC_LearningDelivery_PeriodisedValues = new HashSet<AEC_LearningDelivery_PeriodisedValue>();
            AEC_LearningDelivery_Periods = new HashSet<AEC_LearningDelivery_Period>();
        }

        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int AimSeqNumber { get; set; }
        public int? ActualDaysIL { get; set; }
        public int? ActualNumInstalm { get; set; }
        public DateTime? AdjStartDate { get; set; }
        public int? AgeAtProgStart { get; set; }
        public DateTime? AppAdjLearnStartDate { get; set; }
        public DateTime? AppAdjLearnStartDateMatchPathway { get; set; }
        public DateTime? ApplicCompDate { get; set; }
        public decimal? CombinedAdjProp { get; set; }
        public bool? Completed { get; set; }
        public DateTime? FirstIncentiveThresholdDate { get; set; }
        public bool? FundStart { get; set; }
        public decimal? LDApplic1618FrameworkUpliftTotalActEarnings { get; set; }
        public string LearnAimRef { get; set; }
        public bool? LearnDel1618AtStart { get; set; }
        public int? LearnDelAppAccDaysIL { get; set; }
        public decimal? LearnDelApplicDisadvAmount { get; set; }
        public decimal? LearnDelApplicEmp1618Incentive { get; set; }
        public DateTime? LearnDelApplicEmpDate { get; set; }
        public decimal? LearnDelApplicProv1618FrameworkUplift { get; set; }
        public decimal? LearnDelApplicProv1618Incentive { get; set; }
        public int? LearnDelAppPrevAccDaysIL { get; set; }
        public int? LearnDelDaysIL { get; set; }
        public decimal? LearnDelDisadAmount { get; set; }
        public bool? LearnDelEligDisadvPayment { get; set; }
        public int? LearnDelEmpIdFirstAdditionalPaymentThreshold { get; set; }
        public int? LearnDelEmpIdSecondAdditionalPaymentThreshold { get; set; }
        public int? LearnDelHistDaysThisApp { get; set; }
        public decimal? LearnDelHistProgEarnings { get; set; }
        public string LearnDelInitialFundLineType { get; set; }
        public bool? LearnDelMathEng { get; set; }
        public decimal? MathEngAimValue { get; set; }
        public int? OutstandNumOnProgInstalm { get; set; }
        public int? PlannedNumOnProgInstalm { get; set; }
        public int? PlannedTotalDaysIL { get; set; }
        public DateTime? SecondIncentiveThresholdDate { get; set; }
        public int? ThresholdDays { get; set; }
        public DateTime? LearnDelProgEarliestACT2Date { get; set; }
        public bool? LearnDelNonLevyProcured { get; set; }
        public decimal? LearnDelApplicCareLeaverIncentive { get; set; }
        public int? LearnDelHistDaysCareLeavers { get; set; }
        public int? LearnDelAccDaysILCareLeavers { get; set; }
        public int? LearnDelPrevAccDaysILCareLeavers { get; set; }
        public DateTime? LearnDelLearnerAddPayThresholdDate { get; set; }
        public int? LearnDelRedCode { get; set; }
        public DateTime? LearnDelRedStartDate { get; set; }

        public virtual AEC_Learner AEC_Learner { get; set; }
        public virtual LearningDelivery LearningDelivery { get; set; }
        public virtual ICollection<AEC_LearningDelivery_PeriodisedTextValue> AEC_LearningDelivery_PeriodisedTextValues { get; set; }
        public virtual ICollection<AEC_LearningDelivery_PeriodisedValue> AEC_LearningDelivery_PeriodisedValues { get; set; }
        public virtual ICollection<AEC_LearningDelivery_Period> AEC_LearningDelivery_Periods { get; set; }
    }
}
