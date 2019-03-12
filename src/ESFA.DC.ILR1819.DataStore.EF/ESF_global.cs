using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF
{
    public partial class ESF_global
    {
        public ESF_global()
        {
            ESF_Learners = new HashSet<ESF_Learner>();
        }

        public int UKPRN { get; set; }
        public string RulebaseVersion { get; set; }

        public virtual ICollection<ESF_Learner> ESF_Learners { get; set; }
    }
}
