using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class FM25_global
    {
        public FM25_global()
        {
            FM25_Learners = new HashSet<FM25_Learner>();
        }

        public int UKPRN { get; set; }
        public string LARSVersion { get; set; }
        public string OrgVersion { get; set; }
        public string PostcodeDisadvantageVersion { get; set; }
        public string RulebaseVersion { get; set; }

        public virtual ICollection<FM25_Learner> FM25_Learners { get; set; }
    }
}
