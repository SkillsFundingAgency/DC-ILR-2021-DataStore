using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF
{
    public partial class FM25_FM35_global
    {
        public FM25_FM35_global()
        {
            FM25_FM35_Learner_PeriodisedValues = new HashSet<FM25_FM35_Learner_PeriodisedValue>();
            FM25_FM35_Learner_Periods = new HashSet<FM25_FM35_Learner_Period>();
        }

        public int UKPRN { get; set; }
        public string RulebaseVersion { get; set; }

        public virtual ICollection<FM25_FM35_Learner_PeriodisedValue> FM25_FM35_Learner_PeriodisedValues { get; set; }
        public virtual ICollection<FM25_FM35_Learner_Period> FM25_FM35_Learner_Periods { get; set; }
    }
}
