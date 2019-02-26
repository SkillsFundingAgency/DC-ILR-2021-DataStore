using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Valid
{
    public partial class EmploymentStatusMonitoring
    {
        public int Ukprn { get; set; }
        public string LearnRefNumber { get; set; }
        public DateTime DateEmpStatApp { get; set; }
        public string Esmtype { get; set; }
        public int? Esmcode { get; set; }
    }
}
