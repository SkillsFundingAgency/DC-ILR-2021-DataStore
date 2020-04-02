using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF.Invalid
{
    public partial class LearnerHE
    {
        public int LearnerHE_Id { get; set; }
        public int? Learner_Id { get; set; }
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public string UCASPERID { get; set; }
        public long? TTACCOM { get; set; }
    }
}
