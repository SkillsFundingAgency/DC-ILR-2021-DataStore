using System;
using System.ComponentModel.DataAnnotations;

namespace ESFA.DC.ILR1920.DataStore.EF.Valid
{
    public class LearnerLearningDeliveryEntity
    {
        [Key]
        public Guid Id { get; set; }
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public long ULN { get; set; }
        public string FamilyName { get; set; }
        public string GivenNames { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string NINumber { get; set; }
        public int AimType { get; set; }
        public DateTime LearnStartDate { get; set; }
        public DateTime LearnPlanEndDate { get; set; }
        public int FundModel { get; set; }
        public int? StdCode { get; set; }
        public string DelLocPostCode { get; set; }
        public string EPAOrgID { get; set; }
        public int CompStatus { get; set; }
        public DateTime? LearnActEndDate { get; set; }
        public int? WithdrawReason { get; set; }
        public int? Outcome { get; set; }
        public DateTime? AchDate { get; set; }
        public string OutGrade { get; set; }
    }
}
