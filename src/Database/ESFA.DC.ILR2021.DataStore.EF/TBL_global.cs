using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF
{
    public partial class TBL_global
    {
        public TBL_global()
        {
            TBL_Learners = new HashSet<TBL_Learner>();
        }

        public int UKPRN { get; set; }
        public string CurFundYr { get; set; }
        public string LARSVersion { get; set; }
        public string RulebaseVersion { get; set; }

        public virtual ICollection<TBL_Learner> TBL_Learners { get; set; }
    }
}
