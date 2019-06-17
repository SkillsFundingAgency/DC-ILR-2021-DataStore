using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF.Invalid
{
    public partial class LearnerHEFinancialSupport
    {
        public int LearnerHEFinancialSupport_Id { get; set; }
        public int? LearnerHE_Id { get; set; }
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public long? FINTYPE { get; set; }
        public long? FINAMOUNT { get; set; }
    }
}
