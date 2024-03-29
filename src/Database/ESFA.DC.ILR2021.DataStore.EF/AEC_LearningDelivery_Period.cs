﻿using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF
{
    public partial class AEC_LearningDelivery_Period
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int AimSeqNumber { get; set; }
        public int Period { get; set; }
        public decimal? DisadvFirstPayment { get; set; }
        public decimal? DisadvSecondPayment { get; set; }
        public string FundLineType { get; set; }
        public int? InstPerPeriod { get; set; }
        public decimal? LDApplic1618FrameworkUpliftBalancingPayment { get; set; }
        public decimal? LDApplic1618FrameworkUpliftCompletionPayment { get; set; }
        public decimal? LDApplic1618FrameworkUpliftOnProgPayment { get; set; }
        public string LearnDelContType { get; set; }
        public decimal? LearnDelFirstEmp1618Pay { get; set; }
        public decimal? LearnDelFirstProv1618Pay { get; set; }
        public int? LearnDelLevyNonPayInd { get; set; }
        public decimal? LearnDelSecondEmp1618Pay { get; set; }
        public decimal? LearnDelSecondProv1618Pay { get; set; }
        public bool? LearnDelSEMContWaiver { get; set; }
        public decimal? LearnDelSFAContribPct { get; set; }
        public decimal? LearnDelESFAContribPct { get; set; }
        public bool? LearnSuppFund { get; set; }
        public decimal? LearnSuppFundCash { get; set; }
        public decimal? MathEngBalPayment { get; set; }
        public decimal? MathEngOnProgPayment { get; set; }
        public decimal? ProgrammeAimBalPayment { get; set; }
        public decimal? ProgrammeAimCompletionPayment { get; set; }
        public decimal? ProgrammeAimOnProgPayment { get; set; }
        public decimal? ProgrammeAimProgFundIndMaxEmpCont { get; set; }
        public decimal? ProgrammeAimProgFundIndMinCoInvest { get; set; }
        public decimal? ProgrammeAimTotProgFund { get; set; }
        public decimal? LearnDelLearnAddPayment { get; set; }

        public virtual AEC_LearningDelivery AEC_LearningDelivery { get; set; }
    }
}
