using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF
{
    public partial class ValLearner
    {
        public int Ukprn { get; set; }
        public string LearnRefNumber { get; set; }

        public virtual ValGlobal UkprnNavigation { get; set; }
    }
}
