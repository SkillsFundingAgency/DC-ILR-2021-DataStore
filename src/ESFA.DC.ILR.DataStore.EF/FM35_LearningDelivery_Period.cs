using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class FM35_LearningDelivery_Period
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int AimSeqNumber { get; set; }
        public int Period { get; set; }
        public decimal? AchievePayment { get; set; }
        public decimal? AchievePayPct { get; set; }
        public decimal? AchievePayPctTrans { get; set; }
        public decimal? BalancePayment { get; set; }
        public decimal? BalancePaymentUncapped { get; set; }
        public decimal? BalancePct { get; set; }
        public decimal? BalancePctTrans { get; set; }
        public decimal? EmpOutcomePay { get; set; }
        public decimal? EmpOutcomePct { get; set; }
        public decimal? EmpOutcomePctTrans { get; set; }
        public int? InstPerPeriod { get; set; }
        public bool? LearnSuppFund { get; set; }
        public decimal? LearnSuppFundCash { get; set; }
        public decimal? OnProgPayment { get; set; }
        public decimal? OnProgPaymentUncapped { get; set; }
        public decimal? OnProgPayPct { get; set; }
        public decimal? OnProgPayPctTrans { get; set; }
        public int? TransInstPerPeriod { get; set; }

        public virtual FM35_LearningDelivery FM35_LearningDelivery { get; set; }
    }
}
