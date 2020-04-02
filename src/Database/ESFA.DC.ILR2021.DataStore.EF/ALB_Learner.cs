using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF
{
    public partial class ALB_Learner
    {
        public ALB_Learner()
        {
            ALB_Learner_PeriodisedValues = new HashSet<ALB_Learner_PeriodisedValue>();
            ALB_Learner_Periods = new HashSet<ALB_Learner_Period>();
            ALB_LearningDeliveries = new HashSet<ALB_LearningDelivery>();
        }

        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }

        public virtual ALB_global UKPRNNavigation { get; set; }
        public virtual ICollection<ALB_Learner_PeriodisedValue> ALB_Learner_PeriodisedValues { get; set; }
        public virtual ICollection<ALB_Learner_Period> ALB_Learner_Periods { get; set; }
        public virtual ICollection<ALB_LearningDelivery> ALB_LearningDeliveries { get; set; }
    }
}
