using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Valid
{
    public partial class Dpoutcome
    {
        public int Ukprn { get; set; }
        public string LearnRefNumber { get; set; }
        public string OutType { get; set; }
        public int OutCode { get; set; }
        public DateTime OutStartDate { get; set; }
        public DateTime? OutEndDate { get; set; }
        public DateTime OutCollDate { get; set; }

        public virtual LearnerDestinationandProgression LearnerDestinationandProgression { get; set; }
    }
}
