﻿using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF
{
    public partial class FM25_Learner
    {
        public FM25_Learner()
        {
            FM25_FM35_Learner_PeriodisedValues = new HashSet<FM25_FM35_Learner_PeriodisedValue>();
            FM25_FM35_Learner_Periods = new HashSet<FM25_FM35_Learner_Period>();
        }

        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int? AcadMonthPayment { get; set; }
        public bool? AcadProg { get; set; }
        public int? ActualDaysILCurrYear { get; set; }
        public decimal? AreaCostFact1618Hist { get; set; }
        public decimal? Block1DisadvUpliftNew { get; set; }
        public decimal? Block2DisadvElementsNew { get; set; }
        public string ConditionOfFundingEnglish { get; set; }
        public string ConditionOfFundingMaths { get; set; }
        public int? CoreAimSeqNumber { get; set; }
        public decimal? FullTimeEquiv { get; set; }
        public string FundLine { get; set; }
        public DateTime? LearnerActEndDate { get; set; }
        public DateTime? LearnerPlanEndDate { get; set; }
        public DateTime? LearnerStartDate { get; set; }
        public decimal? NatRate { get; set; }
        public decimal? OnProgPayment { get; set; }
        public int? PlannedDaysILCurrYear { get; set; }
        public decimal? ProgWeightHist { get; set; }
        public decimal? ProgWeightNew { get; set; }
        public decimal? PrvDisadvPropnHist { get; set; }
        public decimal? PrvHistLrgProgPropn { get; set; }
        public decimal? PrvRetentFactHist { get; set; }
        public string RateBand { get; set; }
        public decimal? RetentNew { get; set; }
        public bool? StartFund { get; set; }
        public int? ThresholdDays { get; set; }

        public virtual FM25_global UKPRNNavigation { get; set; }
        public virtual ICollection<FM25_FM35_Learner_PeriodisedValue> FM25_FM35_Learner_PeriodisedValues { get; set; }
        public virtual ICollection<FM25_FM35_Learner_Period> FM25_FM35_Learner_Periods { get; set; }
    }
}
