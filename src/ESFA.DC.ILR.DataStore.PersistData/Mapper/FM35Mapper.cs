using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.PersistData.Builders.Extension;
using ESFA.DC.ILR.DataStore.PersistData.Constants;
using ESFA.DC.ILR.DataStore.PersistData.Helpers;
using ESFA.DC.ILR.DataStore.PersistData.Model;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR2021.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.PersistData.Mapper
{
    public class FM35Mapper : IFM35Mapper
    {
        public void MapData(IDataStoreCache cache, FM35Global fm35Global)
        {
            var learners = fm35Global?.Learners;

            if (learners == null)
            {
                return;
            }

            var ukprn = fm35Global.UKPRN;

            PopulateDataStoreCache(cache, learners, fm35Global, ukprn);
        }

        private void PopulateDataStoreCache(IDataStoreCache cache, IEnumerable<FM35Learner> learners, FM35Global fm35Global, int ukprn)
        {
            cache.AddRange(BuildGlobals(fm35Global, ukprn));

            learners.NullSafeForEach(learner =>
            {
                var learnRefNumber = learner.LearnRefNumber;

                cache.Add(BuildLearner(ukprn, learnRefNumber));

                learner.LearningDeliveries.NullSafeForEach(learningDelivery => cache.Add(BuildLearningDelivery(learningDelivery, ukprn, learnRefNumber)));
            });

            var learningDeliveryPeriodisedValues = learners.SelectMany(l => l.LearningDeliveries.Select(ld =>
                    new FundModelLearningDeliveryPeriodisedValue<List<LearningDeliveryPeriodisedValue>>(ukprn, l.LearnRefNumber, ld.AimSeqNumber.Value, ld.LearningDeliveryPeriodisedValues)));

            cache.AddRange(BuildLearningDeliveryPeriods(learningDeliveryPeriodisedValues));

            learningDeliveryPeriodisedValues.NullSafeForEach(ldpv => ldpv.LearningDeliveryPeriodisedValue.NullSafeForEach(learningDeliveryPeriodisedValue => cache.Add(BuildLearningDeliveryPeriodisedValues(learningDeliveryPeriodisedValue, ldpv.AimSeqNumber, ukprn, ldpv.LearnRefNumber))));
        }

        public List<FM35_global> BuildGlobals(FM35Global fm35Global, int ukprn)
        {
            return new List<FM35_global>()
            {
                new FM35_global
                {
                    CurFundYr = fm35Global.CurFundYr,
                    LARSVersion = fm35Global.LARSVersion,
                    UKPRN = ukprn,
                    RulebaseVersion = fm35Global.RulebaseVersion,
                    OrgVersion = fm35Global.OrgVersion,
                    PostcodeDisadvantageVersion = fm35Global.PostcodeDisadvantageVersion
                }
            };
        }

        public FM35_Learner BuildLearner(int ukprn, string learnRefNumber)
        {
            return new FM35_Learner
            {
                UKPRN = ukprn,
                LearnRefNumber = learnRefNumber
            };
        }

        public FM35_LearningDelivery BuildLearningDelivery(LearningDelivery learningDelivery, int ukprn, string learnRefNumber)
        {
            return new FM35_LearningDelivery
            {
                UKPRN = ukprn,
                LearnRefNumber = learnRefNumber,
                AimSeqNumber = learningDelivery.AimSeqNumber.Value,
                AchApplicDate = learningDelivery.LearningDeliveryValue.AchApplicDate,
                Achieved = learningDelivery.LearningDeliveryValue.Achieved,
                AchieveElement = learningDelivery.LearningDeliveryValue.AchieveElement,
                AchievePayElig = learningDelivery.LearningDeliveryValue.AchievePayElig,
                AchievePayPctPreTrans = learningDelivery.LearningDeliveryValue.AchievePayPctPreTrans,
                AchPayTransHeldBack = learningDelivery.LearningDeliveryValue.AchPayTransHeldBack,
                ActualDaysIL = learningDelivery.LearningDeliveryValue.ActualDaysIL,
                ActualNumInstalm = learningDelivery.LearningDeliveryValue.ActualNumInstalm,
                ActualNumInstalmPreTrans = learningDelivery.LearningDeliveryValue.ActualNumInstalmPreTrans,
                ActualNumInstalmTrans = learningDelivery.LearningDeliveryValue.ActualNumInstalmTrans,
                AdjLearnStartDate = learningDelivery.LearningDeliveryValue.AdjLearnStartDate,
                AdltLearnResp = learningDelivery.LearningDeliveryValue.AdltLearnResp,
                AgeAimStart = learningDelivery.LearningDeliveryValue.AgeAimStart,
                AimValue = learningDelivery.LearningDeliveryValue.AimValue,
                AppAdjLearnStartDate = learningDelivery.LearningDeliveryValue.AppAdjLearnStartDate,
                AppAgeFact = learningDelivery.LearningDeliveryValue.AppAgeFact,
                AppATAGTA = learningDelivery.LearningDeliveryValue.AppATAGTA,
                AppCompetency = learningDelivery.LearningDeliveryValue.AppCompetency,
                AppFuncSkill = learningDelivery.LearningDeliveryValue.AppFuncSkill,
                AppFuncSkill1618AdjFact = learningDelivery.LearningDeliveryValue.AppFuncSkill1618AdjFact,
                AppKnowl = learningDelivery.LearningDeliveryValue.AppKnowl,
                AppLearnStartDate = learningDelivery.LearningDeliveryValue.AppLearnStartDate,
                ApplicEmpFactDate = learningDelivery.LearningDeliveryValue.ApplicEmpFactDate,
                ApplicFactDate = learningDelivery.LearningDeliveryValue.ApplicFactDate,
                ApplicFundRateDate = learningDelivery.LearningDeliveryValue.ApplicFundRateDate,
                ApplicProgWeightFact = learningDelivery.LearningDeliveryValue.ApplicProgWeightFact,
                ApplicUnweightFundRate = learningDelivery.LearningDeliveryValue.ApplicUnweightFundRate,
                ApplicWeightFundRate = learningDelivery.LearningDeliveryValue.ApplicWeightFundRate,
                AppNonFund = learningDelivery.LearningDeliveryValue.AppNonFund,
                AreaCostFactAdj = learningDelivery.LearningDeliveryValue.AreaCostFactAdj,
                BalInstalmPreTrans = learningDelivery.LearningDeliveryValue.BalInstalmPreTrans,
                BaseValueUnweight = learningDelivery.LearningDeliveryValue.BaseValueUnweight,
                CapFactor = learningDelivery.LearningDeliveryValue.CapFactor,
                DisUpFactAdj = learningDelivery.LearningDeliveryValue.DisUpFactAdj,
                EmpOutcomePayElig = learningDelivery.LearningDeliveryValue.EmpOutcomePayElig,
                EmpOutcomePctHeldBackTrans = learningDelivery.LearningDeliveryValue.EmpOutcomePctHeldBackTrans,
                EmpOutcomePctPreTrans = learningDelivery.LearningDeliveryValue.EmpOutcomePctPreTrans,
                EmpRespOth = learningDelivery.LearningDeliveryValue.EmpRespOth,
                ESOL = learningDelivery.LearningDeliveryValue.ESOL,
                FullyFund = learningDelivery.LearningDeliveryValue.FullyFund,
                FundLine = learningDelivery.LearningDeliveryValue.FundLine,
                FundStart = learningDelivery.LearningDeliveryValue.FundStart,
                LargeEmployerID = learningDelivery.LearningDeliveryValue.LargeEmployerID,
                LargeEmployerFM35Fctr = learningDelivery.LearningDeliveryValue.LargeEmployerFM35Fctr,
                LargeEmployerStatusDate = learningDelivery.LearningDeliveryValue.LargeEmployerStatusDate,
                LearnDelFundOrgCode = learningDelivery.LearningDeliveryValue.LearnDelFundOrgCode,
                LTRCUpliftFctr = learningDelivery.LearningDeliveryValue.LTRCUpliftFctr,
                NonGovCont = learningDelivery.LearningDeliveryValue.NonGovCont,
                OLASSCustody = learningDelivery.LearningDeliveryValue.OLASSCustody,
                OnProgPayPctPreTrans = learningDelivery.LearningDeliveryValue.OnProgPayPctPreTrans,
                OutstndNumOnProgInstalm = learningDelivery.LearningDeliveryValue.OutstndNumOnProgInstalm,
                OutstndNumOnProgInstalmTrans = learningDelivery.LearningDeliveryValue.OutstndNumOnProgInstalmTrans,
                PlannedNumOnProgInstalm = learningDelivery.LearningDeliveryValue.PlannedNumOnProgInstalm,
                PlannedNumOnProgInstalmTrans = learningDelivery.LearningDeliveryValue.PlannedNumOnProgInstalmTrans,
                PlannedTotalDaysIL = learningDelivery.LearningDeliveryValue.PlannedTotalDaysIL,
                PlannedTotalDaysILPreTrans = learningDelivery.LearningDeliveryValue.PlannedTotalDaysILPreTrans,
                PropFundRemain = learningDelivery.LearningDeliveryValue.PropFundRemain,
                PropFundRemainAch = learningDelivery.LearningDeliveryValue.PropFundRemainAch,
                PrscHEAim = learningDelivery.LearningDeliveryValue.PrscHEAim,
                Residential = learningDelivery.LearningDeliveryValue.Residential,
                Restart = learningDelivery.LearningDeliveryValue.Restart,
                SpecResUplift = learningDelivery.LearningDeliveryValue.SpecResUplift,
                StartPropTrans = learningDelivery.LearningDeliveryValue.StartPropTrans,
                ThresholdDays = learningDelivery.LearningDeliveryValue.ThresholdDays,
                Traineeship = learningDelivery.LearningDeliveryValue.Traineeship,
                Trans = learningDelivery.LearningDeliveryValue.Trans,
                TrnAdjLearnStartDate = learningDelivery.LearningDeliveryValue.TrnAdjLearnStartDate,
                TrnWorkPlaceAim = learningDelivery.LearningDeliveryValue.TrnWorkPlaceAim,
                TrnWorkPrepAim = learningDelivery.LearningDeliveryValue.TrnWorkPrepAim,
                UnWeightedRateFromESOL = learningDelivery.LearningDeliveryValue.UnWeightedRateFromESOL,
                UnweightedRateFromLARS = learningDelivery.LearningDeliveryValue.UnweightedRateFromLARS,
                WeightedRateFromESOL = learningDelivery.LearningDeliveryValue.WeightedRateFromESOL,
                WeightedRateFromLARS = learningDelivery.LearningDeliveryValue.WeightedRateFromLARS
            };
        }

        public List<FM35_LearningDelivery_Period> BuildLearningDeliveryPeriods(IEnumerable<FundModelLearningDeliveryPeriodisedValue<List<LearningDeliveryPeriodisedValue>>> periodisedValues)
        {
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

        public FM35_LearningDelivery_PeriodisedValue BuildLearningDeliveryPeriodisedValues(LearningDeliveryPeriodisedValue ldpv, int aimSeqNumber, int ukprn, string learnRefNumber)
        {
            return new FM35_LearningDelivery_PeriodisedValue
            {
                UKPRN = ukprn,
                AimSeqNumber = aimSeqNumber,
                LearnRefNumber = learnRefNumber,
                AttributeName = ldpv.AttributeName,
                Period_1 = ldpv.Period1,
                Period_2 = ldpv.Period2,
                Period_3 = ldpv.Period3,
                Period_4 = ldpv.Period4,
                Period_5 = ldpv.Period5,
                Period_6 = ldpv.Period6,
                Period_7 = ldpv.Period7,
                Period_8 = ldpv.Period8,
                Period_9 = ldpv.Period9,
                Period_10 = ldpv.Period10,
                Period_11 = ldpv.Period11,
                Period_12 = ldpv.Period12
            };
        }
    }
}