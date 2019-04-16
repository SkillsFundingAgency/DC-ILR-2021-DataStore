using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF
{
    public partial class ESF_Learner
    {
        public ESF_Learner()
        {
            ESF_LearningDeliveries = new HashSet<ESF_LearningDelivery>();
        }

        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }

        public virtual ESF_global UKPRNNavigation { get; set; }
        public virtual ICollection<ESF_LearningDelivery> ESF_LearningDeliveries { get; set; }
    }
}
