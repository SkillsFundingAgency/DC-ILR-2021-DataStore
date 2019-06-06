using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Invalid
{
    public partial class Learner
    {
        public int Learner_Id { get; set; }
        public string LearnRefNumber { get; set; }
        public int UKPRN { get; set; }
        public string PrevLearnRefNumber { get; set; }
        public long? PrevUKPRN { get; set; }
        public long? PMUKPRN { get; set; }
        public long? ULN { get; set; }
        public string FamilyName { get; set; }
        public string GivenNames { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public long? Ethnicity { get; set; }
        public string Sex { get; set; }
        public long? LLDDHealthProb { get; set; }
        public string NINumber { get; set; }
        public long? PriorAttain { get; set; }
        public long? Accom { get; set; }
        public long? ALSCost { get; set; }
        public long? PlanLearnHours { get; set; }
        public long? PlanEEPHours { get; set; }
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
        public long? OTJHours { get; set; }
    }
}
