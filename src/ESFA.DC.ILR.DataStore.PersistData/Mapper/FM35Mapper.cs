using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.DataStore.Model.Funding;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.PersistData.Constants;
using ESFA.DC.ILR1819.DataStore.PersistData.Helpers;
using ESFA.DC.ILR1819.DataStore.PersistData.Model;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Mapper
{
    public class FM35Mapper : IFM35Mapper
    {
        public FM35Data MapData(FM35Global fm35Global)
        {
            var data = new FM35Data();

            if (fm35Global.Learners != null)
            {
                data.Globals = MapGlobals(fm35Global).ToList();
                data.Learners = MapLearners(fm35Global).ToList();
                data.LearningDeliveries = MapLearningDeliveries(fm35Global).ToList();
                data.LearningDeliveryPeriods = MapLearningDeliveryPeriods(fm35Global).ToList();
                data.LearningDeliveryPeriodisedValues = MapLearningDeliveryPeriodisedValues(fm35Global).ToList();
            }

            return data;
        }

        public IEnumerable<FM35_global> MapGlobals(FM35Global fm35Global)
        {
            return new List<FM35_global>()
            {
                new FM35_global
                {
                    CurFundYr = fm35Global.CurFundYr,
                    LARSVersion = fm35Global.LARSVersion,
                    UKPRN = fm35Global.UKPRN,
                    RulebaseVersion = fm35Global.RulebaseVersion,
                    OrgVersion = fm35Global.OrgVersion,
                    PostcodeDisadvantageVersion = fm35Global.PostcodeDisadvantageVersion
                }
            };
        }

        public IEnumerable<FM35_Learner> MapLearners(FM35Global fm35Global)
        {
            return fm35Global.Learners.Select(l => new FM35_Learner
            {
                UKPRN = fm35Global.UKPRN,
                LearnRefNumber = l.LearnRefNumber
            });
        }

        public IEnumerable<FM35_LearningDelivery> MapLearningDeliveries(FM35Global fm35Global)
        {
            return fm35Global.Learners
                .SelectMany(l => l.LearningDeliveries.Select(ld =>
                new FM35_LearningDelivery
                {
                    UKPRN = fm35Global.UKPRN,
                    LearnRefNumber = l.LearnRefNumber,
                    AimSeqNumber = ld.AimSeqNumber.Value,
                    AchApplicDate = ld.LearningDeliveryValue.AchApplicDate,
                    Achieved = ld.LearningDeliveryValue.Achieved,
                    AchieveElement = ld.LearningDeliveryValue.AchieveElement,
                    AchievePayElig = ld.LearningDeliveryValue.AchievePayElig,
                    AchievePayPctPreTrans = ld.LearningDeliveryValue.AchievePayPctPreTrans,
                    AchPayTransHeldBack = ld.LearningDeliveryValue.AchPayTransHeldBack,
                    ActualDaysIL = ld.LearningDeliveryValue.ActualDaysIL,
                    ActualNumInstalm = ld.LearningDeliveryValue.ActualNumInstalm,
                    ActualNumInstalmPreTrans = ld.LearningDeliveryValue.ActualNumInstalmPreTrans,
                    ActualNumInstalmTrans = ld.LearningDeliveryValue.ActualNumInstalmTrans,
                    AdjLearnStartDate = ld.LearningDeliveryValue.AdjLearnStartDate,
                    AdltLearnResp = ld.LearningDeliveryValue.AdltLearnResp,
                    AgeAimStart = ld.LearningDeliveryValue.AgeAimStart,
                    AimValue = ld.LearningDeliveryValue.AimValue,
                    AppAdjLearnStartDate = ld.LearningDeliveryValue.AppAdjLearnStartDate,
                    AppAgeFact = ld.LearningDeliveryValue.AppAgeFact,
                    AppATAGTA = ld.LearningDeliveryValue.AppATAGTA,
                    AppCompetency = ld.LearningDeliveryValue.AppCompetency,
                    AppFuncSkill = ld.LearningDeliveryValue.AppFuncSkill,
                    AppFuncSkill1618AdjFact = ld.LearningDeliveryValue.AppFuncSkill1618AdjFact,
                    AppKnowl = ld.LearningDeliveryValue.AppKnowl,
                    AppLearnStartDate = ld.LearningDeliveryValue.AppLearnStartDate,
                    ApplicEmpFactDate = ld.LearningDeliveryValue.ApplicEmpFactDate,
                    ApplicFactDate = ld.LearningDeliveryValue.ApplicFactDate,
                    ApplicFundRateDate = ld.LearningDeliveryValue.ApplicFundRateDate,
                    ApplicProgWeightFact = ld.LearningDeliveryValue.ApplicProgWeightFact,
                    ApplicUnweightFundRate = ld.LearningDeliveryValue.ApplicUnweightFundRate,
                    ApplicWeightFundRate = ld.LearningDeliveryValue.ApplicWeightFundRate,
                    AppNonFund = ld.LearningDeliveryValue.AppNonFund,
                    AreaCostFactAdj = ld.LearningDeliveryValue.AreaCostFactAdj,
                    BalInstalmPreTrans = ld.LearningDeliveryValue.BalInstalmPreTrans,
                    BaseValueUnweight = ld.LearningDeliveryValue.BaseValueUnweight,
                    CapFactor = ld.LearningDeliveryValue.CapFactor,
                    DisUpFactAdj = ld.LearningDeliveryValue.DisUpFactAdj,
                    EmpOutcomePayElig = ld.LearningDeliveryValue.EmpOutcomePayElig,
                    EmpOutcomePctHeldBackTrans = ld.LearningDeliveryValue.EmpOutcomePctHeldBackTrans,
                    EmpOutcomePctPreTrans = ld.LearningDeliveryValue.EmpOutcomePctPreTrans,
                    EmpRespOth = ld.LearningDeliveryValue.EmpRespOth,
                    ESOL = ld.LearningDeliveryValue.ESOL,
                    FullyFund = ld.LearningDeliveryValue.FullyFund,
                    FundLine = ld.LearningDeliveryValue.FundLine,
                    FundStart = ld.LearningDeliveryValue.FundStart,
                    LargeEmployerID = ld.LearningDeliveryValue.LargeEmployerID,
                    LargeEmployerFM35Fctr = ld.LearningDeliveryValue.LargeEmployerFM35Fctr,
                    LargeEmployerStatusDate = ld.LearningDeliveryValue.LargeEmployerStatusDate,
                    LTRCUpliftFctr = ld.LearningDeliveryValue.LTRCUpliftFctr,
                    NonGovCont = ld.LearningDeliveryValue.NonGovCont,
                    OLASSCustody = ld.LearningDeliveryValue.OLASSCustody,
                    OnProgPayPctPreTrans = ld.LearningDeliveryValue.OnProgPayPctPreTrans,
                    OutstndNumOnProgInstalm = ld.LearningDeliveryValue.OutstndNumOnProgInstalm,
                    OutstndNumOnProgInstalmTrans = ld.LearningDeliveryValue.OutstndNumOnProgInstalmTrans,
                    PlannedNumOnProgInstalm = ld.LearningDeliveryValue.PlannedNumOnProgInstalm,
                    PlannedNumOnProgInstalmTrans = ld.LearningDeliveryValue.PlannedNumOnProgInstalmTrans,
                    PlannedTotalDaysIL = ld.LearningDeliveryValue.PlannedTotalDaysIL,
                    PlannedTotalDaysILPreTrans = ld.LearningDeliveryValue.PlannedTotalDaysILPreTrans,
                    PropFundRemain = ld.LearningDeliveryValue.PropFundRemain,
                    PropFundRemainAch = ld.LearningDeliveryValue.PropFundRemainAch,
                    PrscHEAim = ld.LearningDeliveryValue.PrscHEAim,
                    Residential = ld.LearningDeliveryValue.Residential,
                    Restart = ld.LearningDeliveryValue.Restart,
                    SpecResUplift = ld.LearningDeliveryValue.SpecResUplift,
                    StartPropTrans = ld.LearningDeliveryValue.StartPropTrans,
                    ThresholdDays = ld.LearningDeliveryValue.ThresholdDays,
                    Traineeship = ld.LearningDeliveryValue.Traineeship,
                    Trans = ld.LearningDeliveryValue.Trans,
                    TrnAdjLearnStartDate = ld.LearningDeliveryValue.TrnAdjLearnStartDate,
                    TrnWorkPlaceAim = ld.LearningDeliveryValue.TrnWorkPlaceAim,
                    TrnWorkPrepAim = ld.LearningDeliveryValue.TrnWorkPrepAim,
                    UnWeightedRateFromESOL = ld.LearningDeliveryValue.UnWeightedRateFromESOL,
                    UnweightedRateFromLARS = ld.LearningDeliveryValue.UnweightedRateFromLARS,
                    WeightedRateFromESOL = ld.LearningDeliveryValue.WeightedRateFromESOL,
                    WeightedRateFromLARS = ld.LearningDeliveryValue.WeightedRateFromLARS
                }));
        }

        public IEnumerable<FM35_LearningDelivery_Period> MapLearningDeliveryPeriods(FM35Global fm35Global)
        {
            var periodisedValues = fm35Global.Learners
               .SelectMany(l => l.LearningDeliveries.Select(ld =>
               new FundModelLearningDeliveryPeriodisedValue<List<LearningDeliveryPeriodisedValue>>(fm35Global.UKPRN, l.LearnRefNumber, ld.AimSeqNumber.Value, ld.LearningDeliveryPeriodisedValues)));

            var learningDeliveryPeriods = new List<FM35_LearningDelivery_Period>();

            for (var i = 1; i < 13; i++)
            {
                learningDeliveryPeriods.AddRange(
                    periodisedValues.Select(pv =>
                    new FM35_LearningDelivery_Period
                    {
                        UKPRN = pv.Ukprn,
                        LearnRefNumber = pv.LearnRefNumber,
                        AimSeqNumber = pv.AimSeqNumber,
                        Period = i,
                        AchievePayPct = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM35Constants.AchievePayPct), i),
                        AchievePayPctTrans = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM35Constants.AchievePayPctTrans), i),
                        AchievePayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM35Constants.AchievePayment), i),
                        BalancePayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM35Constants.BalancePayment), i),
                        BalancePaymentUncapped = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM35Constants.BalancePaymentUncapped), i),
                        BalancePct = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM35Constants.BalancePct), i),
                        BalancePctTrans = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM35Constants.BalancePctTrans), i),
                        EmpOutcomePay = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM35Constants.EmpOutcomePay), i),
                        EmpOutcomePct = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM35Constants.EmpOutcomePct), i),
                        EmpOutcomePctTrans = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM35Constants.EmpOutcomePctTrans), i),
                        InstPerPeriod = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, int?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM35Constants.InstPerPeriod), i),
                        LearnSuppFund = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, bool?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM35Constants.LearnSuppFund), i),
                        LearnSuppFundCash = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM35Constants.LearnSuppFundCash), i),
                        OnProgPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM35Constants.OnProgPayment), i),
                        OnProgPayPct = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM35Constants.OnProgPayPct), i),
                        OnProgPayPctTrans = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM35Constants.OnProgPayPctTrans), i),
                        OnProgPaymentUncapped = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM35Constants.OnProgPaymentUncapped), i),
                        TransInstPerPeriod = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValue, int?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM35Constants.TransInstPerPeriod), i)
                    }));
            }

            return learningDeliveryPeriods;
        }

        public IEnumerable<FM35_LearningDelivery_PeriodisedValue> MapLearningDeliveryPeriodisedValues(FM35Global fm35Global)
        {
            var periodisedValues = fm35Global.Learners
               .SelectMany(l => l.LearningDeliveries.Select(ld =>
               new FundModelLearningDeliveryPeriodisedValue<List<LearningDeliveryPeriodisedValue>>(fm35Global.UKPRN, l.LearnRefNumber, ld.AimSeqNumber.Value, ld.LearningDeliveryPeriodisedValues)));

            return
                   periodisedValues.SelectMany(pv => pv.LearningDeliveryPeriodisedValue
                   .Select(p =>
                   new FM35_LearningDelivery_PeriodisedValue
                   {
                       UKPRN = pv.Ukprn,
                       AimSeqNumber = pv.AimSeqNumber,
                       LearnRefNumber = pv.LearnRefNumber,
                       AttributeName = p.AttributeName,
                       Period_1 = p.Period1,
                       Period_2 = p.Period2,
                       Period_3 = p.Period3,
                       Period_4 = p.Period4,
                       Period_5 = p.Period5,
                       Period_6 = p.Period6,
                       Period_7 = p.Period7,
                       Period_8 = p.Period8,
                       Period_9 = p.Period9,
                       Period_10 = p.Period10,
                       Period_11 = p.Period11,
                       Period_12 = p.Period12
                   }));
        }
    }
}