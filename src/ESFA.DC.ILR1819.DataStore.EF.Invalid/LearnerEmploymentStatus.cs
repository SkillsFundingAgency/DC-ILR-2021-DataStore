using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Invalid
{
    public partial class LearnerEmploymentStatus
    {
        public int LearnerEmploymentStatusId { get; set; }
        public int? LearnerId { get; set; }
        public int Ukprn { get; set; }
        public string LearnRefNumber { get; set; }
        public long? EmpStat { get; set; }
        public DateTime? DateEmpStatApp { get; set; }
        public long? EmpId { get; set; }
        public string AgreeId { get; set; }
    }
}
