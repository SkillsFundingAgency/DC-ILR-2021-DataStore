using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF.Valid
{
    public partial class LearnerHE
    {
        public LearnerHE()
        {
            LearnerHEFinancialSupports = new HashSet<LearnerHEFinancialSupport>();
        }

        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public string UCASPERID { get; set; }
        public int? TTACCOM { get; set; }

        public virtual Learner Learner { get; set; }
        public virtual ICollection<LearnerHEFinancialSupport> LearnerHEFinancialSupports { get; set; }
    }
}
