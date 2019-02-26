using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF
{
    public partial class TblLearner
    {
        public TblLearner()
        {
            TblLearningDeliveries = new HashSet<TblLearningDelivery>();
        }

        public int Ukprn { get; set; }
        public string LearnRefNumber { get; set; }

        public virtual TblGlobal UkprnNavigation { get; set; }
        public virtual ICollection<TblLearningDelivery> TblLearningDeliveries { get; set; }
    }
}
