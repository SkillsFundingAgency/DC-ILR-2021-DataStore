using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Invalid
{
    public partial class EmploymentStatusMonitoring
    {
        public int EmploymentStatusMonitoring_Id { get; set; }
        public int? LearnerEmploymentStatus_Id { get; set; }
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public DateTime? DateEmpStatApp { get; set; }
        public string ESMType { get; set; }
        public long? ESMCode { get; set; }
    }
}
