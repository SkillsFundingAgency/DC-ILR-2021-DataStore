using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Invalid
{
    public partial class EmploymentStatusMonitoring
    {
        public int EmploymentStatusMonitoringId { get; set; }
        public int? LearnerEmploymentStatusId { get; set; }
        public int Ukprn { get; set; }
        public string LearnRefNumber { get; set; }
        public DateTime? DateEmpStatApp { get; set; }
        public string Esmtype { get; set; }
        public long? Esmcode { get; set; }
    }
}
