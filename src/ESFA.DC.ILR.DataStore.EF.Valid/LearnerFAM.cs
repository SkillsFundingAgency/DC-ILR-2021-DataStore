﻿namespace ESFA.DC.ILR1920.DataStore.EF.Valid
{
    public partial class LearnerFAM
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public string LearnFAMType { get; set; }
        public int LearnFAMCode { get; set; }

        public virtual Learner Learner { get; set; }
    }
}
