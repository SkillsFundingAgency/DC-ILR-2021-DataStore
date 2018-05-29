//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ESFA.DC.ILR1819.DataStore.EF.Valid
{
    using System;
    using System.Collections.Generic;
    
    public partial class LearningDelivery
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public string LearnAimRef { get; set; }
        public int AimType { get; set; }
        public int AimSeqNumber { get; set; }
        public System.DateTime LearnStartDate { get; set; }
        public Nullable<System.DateTime> OrigLearnStartDate { get; set; }
        public System.DateTime LearnPlanEndDate { get; set; }
        public int FundModel { get; set; }
        public Nullable<int> ProgType { get; set; }
        public Nullable<int> FworkCode { get; set; }
        public Nullable<int> PwayCode { get; set; }
        public Nullable<int> StdCode { get; set; }
        public Nullable<int> PartnerUKPRN { get; set; }
        public string DelLocPostCode { get; set; }
        public Nullable<int> AddHours { get; set; }
        public Nullable<int> PriorLearnFundAdj { get; set; }
        public Nullable<int> OtherFundAdj { get; set; }
        public string ConRefNumber { get; set; }
        public string EPAOrgID { get; set; }
        public Nullable<int> EmpOutcome { get; set; }
        public int CompStatus { get; set; }
        public Nullable<System.DateTime> LearnActEndDate { get; set; }
        public Nullable<int> WithdrawReason { get; set; }
        public Nullable<int> Outcome { get; set; }
        public Nullable<System.DateTime> AchDate { get; set; }
        public string OutGrade { get; set; }
        public string SWSupAimId { get; set; }
    }
}