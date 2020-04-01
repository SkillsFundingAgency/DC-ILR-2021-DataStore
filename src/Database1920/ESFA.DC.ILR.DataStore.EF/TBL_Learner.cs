using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class TBL_Learner
    {
        public TBL_Learner()
        {
            TBL_LearningDeliveries = new HashSet<TBL_LearningDelivery>();
        }

        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }

        public virtual TBL_global UKPRNNavigation { get; set; }
        public virtual ICollection<TBL_LearningDelivery> TBL_LearningDeliveries { get; set; }
    }
}
