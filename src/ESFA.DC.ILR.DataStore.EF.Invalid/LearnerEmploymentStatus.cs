using System;

namespace ESFA.DC.ILR1920.DataStore.EF.Invalid
{
    public partial class LearnerEmploymentStatus
    {
        public int LearnerEmploymentStatus_Id { get; set; }
        public int? Learner_Id { get; set; }
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public long? EmpStat { get; set; }
        public DateTime? DateEmpStatApp { get; set; }
        public long? EmpId { get; set; }
        public string AgreeId { get; set; }
    }
}
