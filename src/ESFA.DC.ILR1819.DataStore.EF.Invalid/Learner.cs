using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Invalid
{
    public partial class Learner
    {
        public int LearnerId { get; set; }
        public string LearnRefNumber { get; set; }
        public int Ukprn { get; set; }
        public string PrevLearnRefNumber { get; set; }
        public long? PrevUkprn { get; set; }
        public long? Pmukprn { get; set; }
        public long? Uln { get; set; }
        public string FamilyName { get; set; }
        public string GivenNames { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public long? Ethnicity { get; set; }
        public string Sex { get; set; }
        public long? LlddhealthProb { get; set; }
        public string Ninumber { get; set; }
        public long? PriorAttain { get; set; }
        public long? Accom { get; set; }
        public long? Alscost { get; set; }
        public long? PlanLearnHours { get; set; }
        public long? PlanEephours { get; set; }
        public string MathGrade { get; set; }
        public string EngGrade { get; set; }
        public string PostcodePrior { get; set; }
        public string Postcode { get; set; }
        public string AddLine1 { get; set; }
        public string AddLine2 { get; set; }
        public string AddLine3 { get; set; }
        public string AddLine4 { get; set; }
        public string TelNo { get; set; }
        public string Email { get; set; }
        public string CampId { get; set; }
        public long? Otjhours { get; set; }
    }
}
