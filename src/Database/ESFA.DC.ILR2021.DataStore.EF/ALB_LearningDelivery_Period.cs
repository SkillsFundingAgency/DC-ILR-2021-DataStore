﻿using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF
{
    public partial class ALB_LearningDelivery_Period
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int AimSeqNumber { get; set; }
        public int Period { get; set; }
        public decimal? AreaUpliftOnProgPayment { get; set; }
        public decimal? AreaUpliftBalPayment { get; set; }
        public int? ALBCode { get; set; }
        public decimal? ALBSupportPayment { get; set; }

        public virtual ALB_LearningDelivery ALB_LearningDelivery { get; set; }
    }
}
