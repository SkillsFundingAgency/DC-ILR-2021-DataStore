﻿namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class VALFD_ValidationError
    {
        public int UKPRN { get; set; }
        public long AimSeqNumber { get; set; }
        public string ErrorString { get; set; }
        public string FieldValues { get; set; }
        public string LearnRefNumber { get; set; }
        public string RuleId { get; set; }
    }
}
