using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Invalid
{
    public partial class ContactPreference
    {
        public int ContactPreferenceId { get; set; }
        public int? LearnerId { get; set; }
        public int Ukprn { get; set; }
        public string LearnRefNumber { get; set; }
        public string ContPrefType { get; set; }
        public long? ContPrefCode { get; set; }
    }
}
