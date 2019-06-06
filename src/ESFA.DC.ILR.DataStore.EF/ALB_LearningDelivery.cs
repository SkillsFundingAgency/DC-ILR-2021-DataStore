using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class ALB_LearningDelivery
    {
        public ALB_LearningDelivery()
        {
            ALB_LearningDelivery_PeriodisedValues = new HashSet<ALB_LearningDelivery_PeriodisedValue>();
            ALB_LearningDelivery_Periods = new HashSet<ALB_LearningDelivery_Period>();
        }

        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int AimSeqNumber { get; set; }
        public decimal? AreaCostFactAdj { get; set; }
        public decimal? WeightedRate { get; set; }
        public int? PlannedNumOnProgInstalm { get; set; }
        public bool? FundStart { get; set; }
        public bool? Achieved { get; set; }
        public int? ActualNumInstalm { get; set; }
        public int? OutstndNumOnProgInstalm { get; set; }
        public decimal? AreaCostInstalment { get; set; }
        public bool? AdvLoan { get; set; }
        public bool? LoanBursAreaUplift { get; set; }
        public bool? LoanBursSupp { get; set; }
        public string FundLine { get; set; }
        public DateTime? LiabilityDate { get; set; }
        public string ApplicProgWeightFact { get; set; }
        public DateTime? ApplicFactDate { get; set; }
        public bool? LearnDelEligCareerLearnPilot { get; set; }
        public string LearnDelApplicSubsidyPilotAreaCode { get; set; }
        public decimal? LearnDelApplicLARSCarPilFundSubRate { get; set; }
        public decimal? LearnDelCarLearnPilotAimValue { get; set; }
        public decimal? LearnDelCarLearnPilotInstalAmount { get; set; }

        public virtual ALB_Learner ALB_Learner { get; set; }
        public virtual ICollection<ALB_LearningDelivery_PeriodisedValue> ALB_LearningDelivery_PeriodisedValues { get; set; }
        public virtual ICollection<ALB_LearningDelivery_Period> ALB_LearningDelivery_Periods { get; set; }
    }
}
