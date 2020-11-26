using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF
{
    public partial class FM35_Learner
    {
        public FM35_Learner()
        {
            FM35_LearningDeliveries = new HashSet<FM35_LearningDelivery>();
        }

        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }

        public virtual Learner Learner { get; set; }
        public virtual FM35_global UKPRNNavigation { get; set; }
        public virtual ICollection<FM35_LearningDelivery> FM35_LearningDeliveries { get; set; }
    }
}
