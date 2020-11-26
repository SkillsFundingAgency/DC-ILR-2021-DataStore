using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF.Valid
{
    public partial class EmploymentStatusMonitoring
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public DateTime DateEmpStatApp { get; set; }
        public string ESMType { get; set; }
        public int? ESMCode { get; set; }
    }
}
