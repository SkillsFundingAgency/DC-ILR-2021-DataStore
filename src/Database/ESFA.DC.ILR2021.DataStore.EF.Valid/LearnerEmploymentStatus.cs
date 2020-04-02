using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF.Valid
{
    public partial class LearnerEmploymentStatus
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int EmpStat { get; set; }
        public DateTime DateEmpStatApp { get; set; }
        public int? EmpId { get; set; }

        public virtual Learner Learner { get; set; }
    }
}
