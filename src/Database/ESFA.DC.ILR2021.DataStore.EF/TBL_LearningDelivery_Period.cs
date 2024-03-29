﻿using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF
{
    public partial class TBL_LearningDelivery_Period
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int AimSeqNumber { get; set; }
        public int Period { get; set; }
        public decimal? AchPayment { get; set; }
        public decimal? CoreGovContPayment { get; set; }
        public decimal? CoreGovContUncapped { get; set; }
        public int? InstPerPeriod { get; set; }
        public bool? LearnSuppFund { get; set; }
        public decimal? LearnSuppFundCash { get; set; }
        public decimal? MathEngBalPayment { get; set; }
        public decimal? MathEngBalPct { get; set; }
        public decimal? MathEngOnProgPayment { get; set; }
        public decimal? MathEngOnProgPct { get; set; }
        public decimal? SmallBusPayment { get; set; }
        public decimal? YoungAppFirstPayment { get; set; }
        public decimal? YoungAppPayment { get; set; }
        public decimal? YoungAppSecondPayment { get; set; }

        public virtual TBL_LearningDelivery TBL_LearningDelivery { get; set; }
    }
}
