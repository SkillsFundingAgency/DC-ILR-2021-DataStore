using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class DVLearnerClassMap : ClassMap<DV_Learner>
    {
        public DVLearnerClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.Learn_3rdSector);
            Map(m => m.Learn_Active);
            Map(m => m.Learn_ActiveJan);
            Map(m => m.Learn_ActiveNov);
            Map(m => m.Learn_ActiveOct);
            Map(m => m.Learn_Age31Aug);
            Map(m => m.Learn_BasicSkill);
            Map(m => m.Learn_EmpStatFDL);
            Map(m => m.Learn_EmpStatPrior);
            Map(m => m.Learn_FirstFullLevel2);
            Map(m => m.Learn_FirstFullLevel2Ach);
            Map(m => m.Learn_FirstFullLevel3);
            Map(m => m.Learn_FirstFullLevel3Ach);
            Map(m => m.Learn_FullLevel2);
            Map(m => m.Learn_FullLevel2Ach);
            Map(m => m.Learn_FullLevel3);
            Map(m => m.Learn_FullLevel3Ach);
            Map(m => m.Learn_FundAgency);
            Map(m => m.Learn_FundingSource);
            Map(m => m.Learn_FundPrvYr);
            Map(m => m.Learn_ILAcMonth1);
            Map(m => m.Learn_ILAcMonth10);
            Map(m => m.Learn_ILAcMonth11);
            Map(m => m.Learn_ILAcMonth12);
            Map(m => m.Learn_ILAcMonth2);
            Map(m => m.Learn_ILAcMonth3);
            Map(m => m.Learn_ILAcMonth4);
            Map(m => m.Learn_ILAcMonth5);
            Map(m => m.Learn_ILAcMonth6);
            Map(m => m.Learn_ILAcMonth7);
            Map(m => m.Learn_ILAcMonth8);
            Map(m => m.Learn_ILAcMonth9);
            Map(m => m.Learn_ILCurrAcYr);
            Map(m => m.Learn_LargeEmployer);
            Map(m => m.Learn_LenEmp);
            Map(m => m.Learn_LenUnemp);
            Map(m => m.Learn_LrnAimRecords);
            Map(m => m.Learn_ModeAttPlanHrs);
            Map(m => m.Learn_NotionLev);
            Map(m => m.Learn_NotionLevV2);
            Map(m => m.Learn_OLASS);
            Map(m => m.Learn_PrefMethContact);
            Map(m => m.Learn_PrimaryLLDD);
            Map(m => m.Learn_PriorEducationStatus);
            Map(m => m.Learn_UnempBenFDL);
            Map(m => m.Learn_UnempBenPrior);
            Map(m => m.Learn_Uplift1516EFA);
            Map(m => m.Learn_Uplift1516SFA);

        }
    }
}
