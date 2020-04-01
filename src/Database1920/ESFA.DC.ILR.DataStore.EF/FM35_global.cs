using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class FM35_global
    {
        public FM35_global()
        {
            FM35_Learners = new HashSet<FM35_Learner>();
        }

        public int UKPRN { get; set; }
        public string CurFundYr { get; set; }
        public string LARSVersion { get; set; }
        public string OrgVersion { get; set; }
        public string PostcodeDisadvantageVersion { get; set; }
        public string RulebaseVersion { get; set; }

        public virtual ICollection<FM35_Learner> FM35_Learners { get; set; }
    }
}
