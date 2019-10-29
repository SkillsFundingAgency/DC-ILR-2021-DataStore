using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class FM35LearningDeliveryClassMap : ClassMap<FM35_LearningDelivery>
    {
        public FM35LearningDeliveryClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.AchApplicDate);
            Map(m => m.Achieved);
            Map(m => m.AchieveElement);
            Map(m => m.AchievePayElig);
            Map(m => m.AchievePayPctPreTrans);
            Map(m => m.AchPayTransHeldBack);
            Map(m => m.ActualDaysIL);
            Map(m => m.ActualNumInstalm);
            Map(m => m.ActualNumInstalmPreTrans);
            Map(m => m.ActualNumInstalmTrans);
            Map(m => m.AdjLearnStartDate);
            Map(m => m.AdltLearnResp);
            Map(m => m.AgeAimStart);
            Map(m => m.AimValue);
            Map(m => m.AppAdjLearnStartDate);
            Map(m => m.AppAgeFact);
            Map(m => m.AppATAGTA);
            Map(m => m.AppCompetency);
            Map(m => m.AppFuncSkill);
            Map(m => m.AppFuncSkill1618AdjFact);
            Map(m => m.AppKnowl);
            Map(m => m.AppLearnStartDate);
            Map(m => m.ApplicEmpFactDate);
            Map(m => m.ApplicFactDate);
            Map(m => m.ApplicFundRateDate);
            Map(m => m.ApplicProgWeightFact);
            Map(m => m.ApplicUnweightFundRate);
            Map(m => m.ApplicWeightFundRate);
            Map(m => m.AppNonFund);
            Map(m => m.AreaCostFactAdj);
            Map(m => m.BalInstalmPreTrans);
            Map(m => m.BaseValueUnweight);
            Map(m => m.CapFactor);
            Map(m => m.DisUpFactAdj);
            Map(m => m.EmpOutcomePayElig);
            Map(m => m.EmpOutcomePctHeldBackTrans);
            Map(m => m.EmpOutcomePctPreTrans);
            Map(m => m.EmpRespOth);
            Map(m => m.ESOL);
            Map(m => m.FullyFund);
            Map(m => m.FundLine);
            Map(m => m.FundStart);
            Map(m => m.LargeEmployerID);
            Map(m => m.LargeEmployerFM35Fctr);
            Map(m => m.LargeEmployerStatusDate);
            Map(m => m.LearnDelFundOrgCode);
            Map(m => m.LTRCUpliftFctr);
            Map(m => m.NonGovCont);
            Map(m => m.OLASSCustody);
            Map(m => m.OnProgPayPctPreTrans);
            Map(m => m.OutstndNumOnProgInstalm);
            Map(m => m.OutstndNumOnProgInstalmTrans);
            Map(m => m.PlannedNumOnProgInstalm);
            Map(m => m.PlannedNumOnProgInstalmTrans);
            Map(m => m.PlannedTotalDaysIL);
            Map(m => m.PlannedTotalDaysILPreTrans);
            Map(m => m.PropFundRemain);
            Map(m => m.PropFundRemainAch);
            Map(m => m.PrscHEAim);
            Map(m => m.Residential);
            Map(m => m.Restart);
            Map(m => m.SpecResUplift);
            Map(m => m.StartPropTrans);
            Map(m => m.ThresholdDays);
            Map(m => m.Traineeship);
            Map(m => m.Trans);
            Map(m => m.TrnAdjLearnStartDate);
            Map(m => m.TrnWorkPlaceAim);
            Map(m => m.TrnWorkPrepAim);
            Map(m => m.UnWeightedRateFromESOL);
            Map(m => m.UnweightedRateFromLARS);
            Map(m => m.WeightedRateFromESOL);
            Map(m => m.WeightedRateFromLARS);
        }
    }
}
