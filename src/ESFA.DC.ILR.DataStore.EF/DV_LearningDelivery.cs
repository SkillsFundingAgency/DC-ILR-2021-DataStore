﻿using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class DV_LearningDelivery
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int AimSeqNumber { get; set; }
        public int? LearnDel_AccToApp { get; set; }
        public DateTime? LearnDel_AccToAppEmpDate { get; set; }
        public int? LearnDel_AccToAppEmpStat { get; set; }
        public decimal? LearnDel_AchFullLevel2Pct { get; set; }
        public decimal? LearnDel_AchFullLevel3Pct { get; set; }
        public int? LearnDel_Achieved { get; set; }
        public int? LearnDel_AchievedIY { get; set; }
        public string LearnDel_AcMonthYTD { get; set; }
        public int? LearnDel_ActDaysILAfterCurrAcYr { get; set; }
        public int? LearnDel_ActDaysILCurrAcYr { get; set; }
        public int? LearnDel_ActEndDateOnAfterJan1 { get; set; }
        public int? LearnDel_ActEndDateOnAfterNov1 { get; set; }
        public int? LearnDel_ActEndDateOnAfterOct1 { get; set; }
        public int? LearnDel_ActiveIY { get; set; }
        public int? LearnDel_ActiveJan { get; set; }
        public int? LearnDel_ActiveNov { get; set; }
        public int? LearnDel_ActiveOct { get; set; }
        public int? LearnDel_ActTotalDaysIL { get; set; }
        public int? LearnDel_AdvLoan { get; set; }
        public int? LearnDel_AgeAimOrigStart { get; set; }
        public int? LearnDel_AgeAtStart { get; set; }
        public int? LearnDel_App { get; set; }
        public int? LearnDel_App1618Fund { get; set; }
        public int? LearnDel_App1925Fund { get; set; }
        public int? LearnDel_AppAimType { get; set; }
        public int? LearnDel_AppKnowl { get; set; }
        public int? LearnDel_AppMainAim { get; set; }
        public int? LearnDel_AppNonFund { get; set; }
        public int? LearnDel_BasicSkills { get; set; }
        public int? LearnDel_BasicSkillsParticipation { get; set; }
        public int? LearnDel_BasicSkillsType { get; set; }
        public int? LearnDel_CarryIn { get; set; }
        public int? LearnDel_ClassRm { get; set; }
        public int? LearnDel_CompAimApp { get; set; }
        public int? LearnDel_CompAimProg { get; set; }
        public int? LearnDel_Completed { get; set; }
        public int? LearnDel_CompletedIY { get; set; }
        public decimal? LearnDel_CompleteFullLevel2Pct { get; set; }
        public decimal? LearnDel_CompleteFullLevel3Pct { get; set; }
        public int? LearnDel_EFACoreAim { get; set; }
        public int? LearnDel_Emp6MonthAimStart { get; set; }
        public int? LearnDel_Emp6MonthProgStart { get; set; }
        public DateTime? LearnDel_EmpDateBeforeFDL { get; set; }
        public DateTime? LearnDel_EmpDatePriorFDL { get; set; }
        public int? LearnDel_EmpID { get; set; }
        public int? LearnDel_Employed { get; set; }
        public int? LearnDel_EmpStatFDL { get; set; }
        public int? LearnDel_EmpStatPrior { get; set; }
        public int? LearnDel_EmpStatPriorFDL { get; set; }
        public int? LearnDel_EnhanAppFund { get; set; }
        public decimal? LearnDel_FullLevel2AchPct { get; set; }
        public decimal? LearnDel_FullLevel2ContPct { get; set; }
        public decimal? LearnDel_FullLevel3AchPct { get; set; }
        public decimal? LearnDel_FullLevel3ContPct { get; set; }
        public int? LearnDel_FuncSkills { get; set; }
        public int? LearnDel_FundAgency { get; set; }
        public string LearnDel_FundingLineType { get; set; }
        public int? LearnDel_FundingSource { get; set; }
        public int? LearnDel_FundPrvYr { get; set; }
        public int? LearnDel_FundStart { get; set; }
        public int? LearnDel_GCE { get; set; }
        public int? LearnDel_GCSE { get; set; }
        public int? LearnDel_ILAcMonth1 { get; set; }
        public int? LearnDel_ILAcMonth10 { get; set; }
        public int? LearnDel_ILAcMonth11 { get; set; }
        public int? LearnDel_ILAcMonth12 { get; set; }
        public int? LearnDel_ILAcMonth2 { get; set; }
        public int? LearnDel_ILAcMonth3 { get; set; }
        public int? LearnDel_ILAcMonth4 { get; set; }
        public int? LearnDel_ILAcMonth5 { get; set; }
        public int? LearnDel_ILAcMonth6 { get; set; }
        public int? LearnDel_ILAcMonth7 { get; set; }
        public int? LearnDel_ILAcMonth8 { get; set; }
        public int? LearnDel_ILAcMonth9 { get; set; }
        public int? LearnDel_ILCurrAcYr { get; set; }
        public DateTime? LearnDel_IYActEndDate { get; set; }
        public DateTime? LearnDel_IYPlanEndDate { get; set; }
        public DateTime? LearnDel_IYStartDate { get; set; }
        public int? LearnDel_KeySkills { get; set; }
        public int? LearnDel_LargeEmpDiscountId { get; set; }
        public int? LearnDel_LargeEmployer { get; set; }
        public DateTime? LearnDel_LastEmpDate { get; set; }
        public int? LearnDel_LeaveMonth { get; set; }
        public int? LearnDel_LenEmp { get; set; }
        public int? LearnDel_LenUnemp { get; set; }
        public int? LearnDel_LoanBursFund { get; set; }
        public int? LearnDel_NotionLevel { get; set; }
        public int? LearnDel_NotionLevelV2 { get; set; }
        public int? LearnDel_NumHEDatasets { get; set; }
        public int? LearnDel_OccupAim { get; set; }
        public int? LearnDel_OLASS { get; set; }
        public int? LearnDel_OLASSCom { get; set; }
        public int? LearnDel_OLASSCus { get; set; }
        public DateTime? LearnDel_OrigStartDate { get; set; }
        public int? LearnDel_PlanDaysILAfterCurrAcYr { get; set; }
        public int? LearnDel_PlanDaysILCurrAcYr { get; set; }
        public int? LearnDel_PlanEndBeforeAug1 { get; set; }
        public int? LearnDel_PlanEndOnAfterJan1 { get; set; }
        public int? LearnDel_PlanEndOnAfterNov1 { get; set; }
        public int? LearnDel_PlanEndOnAfterOct1 { get; set; }
        public int? LearnDel_PlanTotalDaysIL { get; set; }
        public int? LearnDel_PriorEducationStatus { get; set; }
        public int? LearnDel_Prog { get; set; }
        public int? LearnDel_ProgAimAch { get; set; }
        public int? LearnDel_ProgAimApp { get; set; }
        public int? LearnDel_ProgCompleted { get; set; }
        public int? LearnDel_ProgCompletedIY { get; set; }
        public DateTime? LearnDel_ProgStartDate { get; set; }
        public int? LearnDel_QCF { get; set; }
        public int? LearnDel_QCFCert { get; set; }
        public int? LearnDel_QCFDipl { get; set; }
        public int? LearnDel_QCFType { get; set; }
        public int? LearnDel_RegAim { get; set; }
        public string LearnDel_SecSubAreaTier1 { get; set; }
        public string LearnDel_SecSubAreaTier2 { get; set; }
        public int? LearnDel_SFAApproved { get; set; }
        public int? LearnDel_SourceFundEFA { get; set; }
        public int? LearnDel_SourceFundSFA { get; set; }
        public int? LearnDel_StartBeforeApr1 { get; set; }
        public int? LearnDel_StartBeforeAug1 { get; set; }
        public int? LearnDel_StartBeforeDec1 { get; set; }
        public int? LearnDel_StartBeforeFeb1 { get; set; }
        public int? LearnDel_StartBeforeJan1 { get; set; }
        public int? LearnDel_StartBeforeJun1 { get; set; }
        public int? LearnDel_StartBeforeMar1 { get; set; }
        public int? LearnDel_StartBeforeMay1 { get; set; }
        public int? LearnDel_StartBeforeNov1 { get; set; }
        public int? LearnDel_StartBeforeOct1 { get; set; }
        public int? LearnDel_StartBeforeSep1 { get; set; }
        public int? LearnDel_StartIY { get; set; }
        public int? LearnDel_StartJan1 { get; set; }
        public int? LearnDel_StartMonth { get; set; }
        public int? LearnDel_StartNov1 { get; set; }
        public int? LearnDel_StartOct1 { get; set; }
        public int? LearnDel_SuccRateStat { get; set; }
        public int? LearnDel_TrainAimType { get; set; }
        public int? LearnDel_TransferDiffProvider { get; set; }
        public int? LearnDel_TransferDiffProviderGovStrat { get; set; }
        public int? LearnDel_TransferProvider { get; set; }
        public int? LearnDel_UfIProv { get; set; }
        public int? LearnDel_UnempBenFDL { get; set; }
        public int? LearnDel_UnempBenPrior { get; set; }
        public int? LearnDel_Withdrawn { get; set; }
        public string LearnDel_WorkplaceLocPostcode { get; set; }
        public int? Prog_AccToApp { get; set; }
        public int? Prog_Achieved { get; set; }
        public int? Prog_AchievedIY { get; set; }
        public DateTime? Prog_ActEndDate { get; set; }
        public int? Prog_ActiveIY { get; set; }
        public int? Prog_AgeAtStart { get; set; }
        public int? Prog_EarliestAim { get; set; }
        public int? Prog_Employed { get; set; }
        public int? Prog_FundPrvYr { get; set; }
        public int? Prog_ILCurrAcYear { get; set; }
        public int? Prog_LatestAim { get; set; }
        public int? Prog_SourceFundEFA { get; set; }
        public int? Prog_SourceFundSFA { get; set; }

        public virtual DV_Learner DV_Learner { get; set; }
    }
}
