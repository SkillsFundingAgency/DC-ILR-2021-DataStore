using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF
{
    public partial class LearnerDestinationandProgression
    {
        public LearnerDestinationandProgression()
        {
            DPOutcomes = new HashSet<DPOutcome>();
        }

        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public long ULN { get; set; }

        public virtual ICollection<DPOutcome> DPOutcomes { get; set; }
    }
}
