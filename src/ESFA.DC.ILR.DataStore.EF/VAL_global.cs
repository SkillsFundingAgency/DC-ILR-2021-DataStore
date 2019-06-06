using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class VAL_global
    {
        public VAL_global()
        {
            VAL_Learners = new HashSet<VAL_Learner>();
        }

        public int UKPRN { get; set; }
        public string EmployerVersion { get; set; }
        public string LARSVersion { get; set; }
        public string OrgVersion { get; set; }
        public string PostcodeVersion { get; set; }
        public string RulebaseVersion { get; set; }

        public virtual ICollection<VAL_Learner> VAL_Learners { get; set; }
    }
}
