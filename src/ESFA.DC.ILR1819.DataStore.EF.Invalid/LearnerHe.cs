using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Invalid
{
    public partial class LearnerHe
    {
        public int LearnerHeId { get; set; }
        public int? LearnerId { get; set; }
        public int Ukprn { get; set; }
        public string LearnRefNumber { get; set; }
        public string Ucasperid { get; set; }
        public long? Ttaccom { get; set; }
    }
}
