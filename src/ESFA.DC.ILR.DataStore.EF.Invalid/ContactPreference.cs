using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF.Invalid
{
    public partial class ContactPreference
    {
        public int ContactPreference_Id { get; set; }
        public int? Learner_Id { get; set; }
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public string ContPrefType { get; set; }
        public long? ContPrefCode { get; set; }
    }
}
