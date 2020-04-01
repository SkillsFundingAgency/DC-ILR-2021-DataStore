using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF.Invalid
{
    public partial class LearningDelivery
    {
        public int LearningDelivery_Id { get; set; }
        public int? Learner_Id { get; set; }
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public string LearnAimRef { get; set; }
        public long? AimType { get; set; }
        public long? AimSeqNumber { get; set; }
        public DateTime? LearnStartDate { get; set; }
        public DateTime? OrigLearnStartDate { get; set; }
        public DateTime? LearnPlanEndDate { get; set; }
        public long? FundModel { get; set; }
        public long? ProgType { get; set; }
        public long? FworkCode { get; set; }
        public long? PwayCode { get; set; }
        public long? StdCode { get; set; }
        public long? PartnerUKPRN { get; set; }
        public string DelLocPostCode { get; set; }
        public long? AddHours { get; set; }
        public long? PriorLearnFundAdj { get; set; }
        public long? OtherFundAdj { get; set; }
        public string ConRefNumber { get; set; }
        public string EPAOrgID { get; set; }
        public long? EmpOutcome { get; set; }
        public long? CompStatus { get; set; }
        public DateTime? LearnActEndDate { get; set; }
        public long? WithdrawReason { get; set; }
        public long? Outcome { get; set; }
        public DateTime? AchDate { get; set; }
        public string OutGrade { get; set; }
        public string SWSupAimId { get; set; }
        public long? PHours { get; set; }
        public string LSDPostcode { get; set; }
    }
}
