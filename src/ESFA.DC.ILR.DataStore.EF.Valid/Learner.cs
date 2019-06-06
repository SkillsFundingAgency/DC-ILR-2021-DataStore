using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Valid
{
    public partial class Learner
    {
        public Learner()
        {
            ContactPreferences = new HashSet<ContactPreference>();
            LLDDandHealthProblems = new HashSet<LLDDandHealthProblem>();
            LearnerEmploymentStatuses = new HashSet<LearnerEmploymentStatus>();
            LearnerFAMs = new HashSet<LearnerFAM>();
            LearningDeliveries = new HashSet<LearningDelivery>();
            ProviderSpecLearnerMonitorings = new HashSet<ProviderSpecLearnerMonitoring>();
        }

        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public string PrevLearnRefNumber { get; set; }
        public int? PrevUKPRN { get; set; }
        public int? PMUKPRN { get; set; }
        public long ULN { get; set; }
        public string FamilyName { get; set; }
        public string GivenNames { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Ethnicity { get; set; }
        public string Sex { get; set; }
        public int LLDDHealthProb { get; set; }
        public string NINumber { get; set; }
        public int? PriorAttain { get; set; }
        public int? Accom { get; set; }
        public int? ALSCost { get; set; }
        public int? PlanLearnHours { get; set; }
        public int? PlanEEPHours { get; set; }
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

        public virtual LearnerHE LearnerHE { get; set; }
        public virtual ICollection<ContactPreference> ContactPreferences { get; set; }
        public virtual ICollection<LLDDandHealthProblem> LLDDandHealthProblems { get; set; }
        public virtual ICollection<LearnerEmploymentStatus> LearnerEmploymentStatuses { get; set; }
        public virtual ICollection<LearnerFAM> LearnerFAMs { get; set; }
        public virtual ICollection<LearningDelivery> LearningDeliveries { get; set; }
        public virtual ICollection<ProviderSpecLearnerMonitoring> ProviderSpecLearnerMonitorings { get; set; }
    }
}
