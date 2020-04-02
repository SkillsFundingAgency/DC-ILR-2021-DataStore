using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF.Valid
{
    public partial class ContactPreference
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public string ContPrefType { get; set; }
        public int ContPrefCode { get; set; }

        public virtual Learner Learner { get; set; }
    }
}
