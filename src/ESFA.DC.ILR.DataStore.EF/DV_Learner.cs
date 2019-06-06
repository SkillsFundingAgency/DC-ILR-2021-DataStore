using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class DV_Learner
    {
        public DV_Learner()
        {
            DV_LearningDeliveries = new HashSet<DV_LearningDelivery>();
        }

        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int? Learn_3rdSector { get; set; }
        public int? Learn_Active { get; set; }
        public int? Learn_ActiveJan { get; set; }
        public int? Learn_ActiveNov { get; set; }
        public int? Learn_ActiveOct { get; set; }
        public int? Learn_Age31Aug { get; set; }
        public int? Learn_BasicSkill { get; set; }
        public int? Learn_EmpStatFDL { get; set; }
        public int? Learn_EmpStatPrior { get; set; }
        public int? Learn_FirstFullLevel2 { get; set; }
        public int? Learn_FirstFullLevel2Ach { get; set; }
        public int? Learn_FirstFullLevel3 { get; set; }
        public int? Learn_FirstFullLevel3Ach { get; set; }
        public int? Learn_FullLevel2 { get; set; }
        public int? Learn_FullLevel2Ach { get; set; }
        public int? Learn_FullLevel3 { get; set; }
        public int? Learn_FullLevel3Ach { get; set; }
        public int? Learn_FundAgency { get; set; }
        public int? Learn_FundingSource { get; set; }
        public int? Learn_FundPrvYr { get; set; }
        public int? Learn_ILAcMonth1 { get; set; }
        public int? Learn_ILAcMonth10 { get; set; }
        public int? Learn_ILAcMonth11 { get; set; }
        public int? Learn_ILAcMonth12 { get; set; }
        public int? Learn_ILAcMonth2 { get; set; }
        public int? Learn_ILAcMonth3 { get; set; }
        public int? Learn_ILAcMonth4 { get; set; }
        public int? Learn_ILAcMonth5 { get; set; }
        public int? Learn_ILAcMonth6 { get; set; }
        public int? Learn_ILAcMonth7 { get; set; }
        public int? Learn_ILAcMonth8 { get; set; }
        public int? Learn_ILAcMonth9 { get; set; }
        public int? Learn_ILCurrAcYr { get; set; }
        public int? Learn_LargeEmployer { get; set; }
        public int? Learn_LenEmp { get; set; }
        public int? Learn_LenUnemp { get; set; }
        public int? Learn_LrnAimRecords { get; set; }
        public int? Learn_ModeAttPlanHrs { get; set; }
        public int? Learn_NotionLev { get; set; }
        public int? Learn_NotionLevV2 { get; set; }
        public int? Learn_OLASS { get; set; }
        public int? Learn_PrefMethContact { get; set; }
        public int? Learn_PrimaryLLDD { get; set; }
        public int? Learn_PriorEducationStatus { get; set; }
        public int? Learn_UnempBenFDL { get; set; }
        public int? Learn_UnempBenPrior { get; set; }
        public decimal? Learn_Uplift1516EFA { get; set; }
        public decimal? Learn_Uplift1516SFA { get; set; }

        public virtual DV_global UKPRNNavigation { get; set; }
        public virtual ICollection<DV_LearningDelivery> DV_LearningDeliveries { get; set; }
    }
}
