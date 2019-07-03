using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class AEC_global
    {
        public AEC_global()
        {
            AEC_Learners = new HashSet<AEC_Learner>();
        }

        public int UKPRN { get; set; }
        public string LARSVersion { get; set; }
        public string RulebaseVersion { get; set; }

        public virtual ICollection<AEC_Learner> AEC_Learners { get; set; }
    }
}
