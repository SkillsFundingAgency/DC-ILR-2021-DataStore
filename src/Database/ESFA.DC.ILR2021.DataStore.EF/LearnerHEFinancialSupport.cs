using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF
{
    public partial class LearnerHEFinancialSupport
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int FINTYPE { get; set; }
        public int FINAMOUNT { get; set; }

        public virtual LearnerHE LearnerHE { get; set; }
    }
}
