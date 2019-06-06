using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Invalid
{
    public partial class LLDDandHealthProblem
    {
        public int LLDDandHealthProblem_Id { get; set; }
        public int? Learner_Id { get; set; }
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public long? LLDDCat { get; set; }
        public long? PrimaryLLDD { get; set; }
    }
}
