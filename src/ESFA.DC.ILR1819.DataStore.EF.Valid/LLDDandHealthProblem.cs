using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Valid
{
    public partial class LLDDandHealthProblem
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int LLDDCat { get; set; }
        public int? PrimaryLLDD { get; set; }
        public long LLDDandHealthProblem_ID { get; set; }

        public virtual Learner Learner { get; set; }
    }
}
