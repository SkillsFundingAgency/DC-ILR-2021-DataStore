using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class DV_global
    {
        public DV_global()
        {
            DV_Learners = new HashSet<DV_Learner>();
        }

        public int UKPRN { get; set; }
        public string RulebaseVersion { get; set; }

        public virtual ICollection<DV_Learner> DV_Learners { get; set; }
    }
}
