using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class AEC_LearningDelivery_PeriodisedValue
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int AimSeqNumber { get; set; }
        public string AttributeName { get; set; }
        public decimal? Period_1 { get; set; }
        public decimal? Period_2 { get; set; }
        public decimal? Period_3 { get; set; }
        public decimal? Period_4 { get; set; }
        public decimal? Period_5 { get; set; }
        public decimal? Period_6 { get; set; }
        public decimal? Period_7 { get; set; }
        public decimal? Period_8 { get; set; }
        public decimal? Period_9 { get; set; }
        public decimal? Period_10 { get; set; }
        public decimal? Period_11 { get; set; }
        public decimal? Period_12 { get; set; }

        public virtual AEC_LearningDelivery AEC_LearningDelivery { get; set; }
    }
}
