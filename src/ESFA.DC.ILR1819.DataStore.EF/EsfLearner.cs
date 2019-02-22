using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF
{
    public partial class EsfLearner
    {
        public EsfLearner()
        {
            EsfLearningDeliveries = new HashSet<EsfLearningDelivery>();
        }

        public int Ukprn { get; set; }
        public string LearnRefNumber { get; set; }

        public virtual EsfGlobal UkprnNavigation { get; set; }
        public virtual ICollection<EsfLearningDelivery> EsfLearningDeliveries { get; set; }
    }
}
