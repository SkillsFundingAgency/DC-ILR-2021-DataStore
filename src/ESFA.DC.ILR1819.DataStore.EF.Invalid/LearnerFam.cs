using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Invalid
{
    public partial class LearnerFam
    {
        public int LearnerFamId { get; set; }
        public int? LearnerId { get; set; }
        public int Ukprn { get; set; }
        public string LearnRefNumber { get; set; }
        public string LearnFamtype { get; set; }
        public long? LearnFamcode { get; set; }
    }
}
