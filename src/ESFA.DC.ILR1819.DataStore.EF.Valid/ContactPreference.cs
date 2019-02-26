using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Valid
{
    public partial class ContactPreference
    {
        public int Ukprn { get; set; }
        public string LearnRefNumber { get; set; }
        public string ContPrefType { get; set; }
        public int ContPrefCode { get; set; }

        public virtual Learner Learner { get; set; }
    }
}
