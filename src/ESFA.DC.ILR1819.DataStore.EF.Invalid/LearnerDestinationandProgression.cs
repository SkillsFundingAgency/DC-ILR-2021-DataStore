using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Invalid
{
    public partial class LearnerDestinationandProgression
    {
        public int LearnerDestinationandProgressionId { get; set; }
        public int Ukprn { get; set; }
        public string LearnRefNumber { get; set; }
        public long? Uln { get; set; }
    }
}
