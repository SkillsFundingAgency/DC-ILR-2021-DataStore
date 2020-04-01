using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class ValidationError
    {
        public long Id { get; set; }
        public int? UKPRN { get; set; }
        public string Source { get; set; }
        public string LearnAimRef { get; set; }
        public long? AimSeqNum { get; set; }
        public string SWSupAimID { get; set; }
        public string ErrorMessage { get; set; }
        public string FieldValues { get; set; }
        public string LearnRefNumber { get; set; }
        public string RuleName { get; set; }
        public string Severity { get; set; }
        public int? FileLevelError { get; set; }
    }
}
