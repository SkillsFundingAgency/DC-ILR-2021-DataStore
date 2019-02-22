﻿using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Invalid
{
    public partial class Dpoutcome
    {
        public int DpoutcomeId { get; set; }
        public int Ukprn { get; set; }
        public int? LearnerDestinationandProgressionId { get; set; }
        public string LearnRefNumber { get; set; }
        public string OutType { get; set; }
        public long? OutCode { get; set; }
        public DateTime? OutStartDate { get; set; }
        public DateTime? OutEndDate { get; set; }
        public DateTime? OutCollDate { get; set; }
    }
}
