using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF.Invalid
{
    public partial class LearnerFAM
    {
        public int LearnerFAM_Id { get; set; }
        public int? Learner_Id { get; set; }
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public string LearnFAMType { get; set; }
        public long? LearnFAMCode { get; set; }
    }
}
