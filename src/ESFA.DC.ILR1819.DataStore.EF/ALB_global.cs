using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF
{
    public partial class ALB_global
    {
        public ALB_global()
        {
            ALB_Learners = new HashSet<ALB_Learner>();
        }

        public int UKPRN { get; set; }
        public string LARSVersion { get; set; }
        public string PostcodeAreaCostVersion { get; set; }
        public string RulebaseVersion { get; set; }

        public virtual ICollection<ALB_Learner> ALB_Learners { get; set; }
    }
}
