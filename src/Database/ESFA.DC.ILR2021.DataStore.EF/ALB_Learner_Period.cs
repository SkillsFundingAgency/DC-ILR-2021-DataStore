using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF
{
    public partial class ALB_Learner_Period
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int Period { get; set; }
        public int? ALBSeqNum { get; set; }

        public virtual ALB_Learner ALB_Learner { get; set; }
    }
}
