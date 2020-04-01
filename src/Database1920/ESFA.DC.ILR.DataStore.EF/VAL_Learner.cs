using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class VAL_Learner
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }

        public virtual VAL_global UKPRNNavigation { get; set; }
    }
}
