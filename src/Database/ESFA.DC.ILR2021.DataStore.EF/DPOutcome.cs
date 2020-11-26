using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF
{
    public partial class DPOutcome
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public string OutType { get; set; }
        public int OutCode { get; set; }
        public DateTime OutStartDate { get; set; }
        public DateTime? OutEndDate { get; set; }
        public DateTime OutCollDate { get; set; }

        public virtual LearnerDestinationandProgression LearnerDestinationandProgression { get; set; }
    }
}
