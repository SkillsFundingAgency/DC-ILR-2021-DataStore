using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Invalid
{
    public partial class DPOutcome
    {
        public int DPOutcome_Id { get; set; }
        public int UKPRN { get; set; }
        public int? LearnerDestinationandProgression_Id { get; set; }
        public string LearnRefNumber { get; set; }
        public string OutType { get; set; }
        public long? OutCode { get; set; }
        public DateTime? OutStartDate { get; set; }
        public DateTime? OutEndDate { get; set; }
        public DateTime? OutCollDate { get; set; }
    }
}
