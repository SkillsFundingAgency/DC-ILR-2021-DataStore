﻿using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF
{
    public partial class ESF_DPOutcome
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int OutCode { get; set; }
        public string OutType { get; set; }
        public DateTime OutStartDate { get; set; }
        public DateTime? OutcomeDateForProgression { get; set; }
        public bool? PotentialESFProgressionType { get; set; }
        public string ProgressionType { get; set; }
        public bool? ReachedSixMonthPoint { get; set; }
        public bool? ReachedThreeMonthPoint { get; set; }
        public bool? ReachedTwelveMonthPoint { get; set; }
    }
}
