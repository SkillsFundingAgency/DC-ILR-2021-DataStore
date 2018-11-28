using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.PersistData.Helpers;
using static ESFA.DC.ILR1819.DataStore.PersistData.Constants.PersistDataConstants;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Rulebase
{
    public class FM35DataBuilder : IRulebaseDataBuilder<FM35Global, IEnumerable<FM35_global>>
    {
        public FM35DataBuilder()
        {
        }

        public IEnumerable<FM35_global> BuildRulebaseData(FM35Global fundingOutput)
        {
            return new List<FM35_global>
            {
                new FM35_global
                {
                    CurFundYr = fundingOutput.CurFundYr,
                    LARSVersion = fundingOutput.LARSVersion,
                    UKPRN = fundingOutput.UKPRN,
                    RulebaseVersion = fundingOutput.RulebaseVersion,
                    OrgVersion = fundingOutput.OrgVersion,
                    PostcodeDisadvantageVersion = fundingOutput.PostcodeDisadvantageVersion,
                    FM35_Learner = fundingOutput.Learners.Select(l =>
                        new FM35_Learner
                        {
                            UKPRN = fundingOutput.UKPRN,
                            LearnRefNumber = l.LearnRefNumber,
                            FM35_LearningDelivery = l.LearningDeliveries.Select(ld => BuildLearningDelivery(fundingOutput.UKPRN, l.LearnRefNumber, ld)).ToList()
                        }).ToList()
                }
            };
        }

        public IEnumerable<FM35_Learner> BuildLearners(FM35Global fm35Global)
        {
            return fm35Global.Learners.Select(
                l =>
                        new FM35_Learner
                        {
                            UKPRN = fm35Global.UKPRN,
                            LearnRefNumber = l.LearnRefNumber
                        });
        }

        public FM35_LearningDelivery BuildLearningDelivery(int ukPrn, string learnRefNumber, LearningDelivery delivery)
        {
            return new FM35_LearningDelivery
            {
                UKPRN = ukPrn,
                LearnRefNumber = learnRefNumber,
                AimSeqNumber = delivery.AimSeqNumber.Value,
                AchApplicDate = delivery.LearningDeliveryValue.AchApplicDate,
                Achieved = delivery.LearningDeliveryValue.Achieved,
                AchieveElement = delivery.LearningDeliveryValue.AchieveElement,
                AchievePayElig = delivery.LearningDeliveryValue.AchievePayElig,
                AchievePayPctPreTrans = delivery.LearningDeliveryValue.AchievePayPctPreTrans,
                AchPayTransHeldBack = delivery.LearningDeliveryValue.AchPayTransHeldBack,
                ActualDaysIL = delivery.LearningDeliveryValue.ActualDaysIL,
                ActualNumInstalm = delivery.LearningDeliveryValue.ActualNumInstalm,
                ActualNumInstalmPreTrans = delivery.LearningDeliveryValue.ActualNumInstalmPreTrans,
                ActualNumInstalmTrans = delivery.LearningDeliveryValue.ActualNumInstalmTrans,
                AdjLearnStartDate = delivery.LearningDeliveryValue.AdjLearnStartDate,
                AdltLearnResp = delivery.LearningDeliveryValue.AdltLearnResp,
                AgeAimStart = delivery.LearningDeliveryValue.AgeAimStart,
                AimValue = delivery.LearningDeliveryValue.AimValue,
                AppAdjLearnStartDate = delivery.LearningDeliveryValue.AppAdjLearnStartDate,
                AppAgeFact = delivery.LearningDeliveryValue.AppAgeFact,
                AppATAGTA = delivery.LearningDeliveryValue.AppATAGTA,
                AppCompetency = delivery.LearningDeliveryValue.AppCompetency,
                AppFuncSkill = delivery.LearningDeliveryValue.AppFuncSkill,
                AppFuncSkill1618AdjFact = delivery.LearningDeliveryValue.AppFuncSkill1618AdjFact,
                AppKnowl = delivery.LearningDeliveryValue.AppKnowl,
                AppLearnStartDate = delivery.LearningDeliveryValue.AppLearnStartDate,
                ApplicEmpFactDate = delivery.LearningDeliveryValue.ApplicEmpFactDate,
                ApplicFactDate = delivery.LearningDeliveryValue.ApplicFactDate,
                ApplicFundRateDate = delivery.LearningDeliveryValue.ApplicFundRateDate,
                ApplicProgWeightFact = delivery.LearningDeliveryValue.ApplicProgWeightFact,
                ApplicUnweightFundRate = delivery.LearningDeliveryValue.ApplicUnweightFundRate,
                ApplicWeightFundRate = delivery.LearningDeliveryValue.ApplicWeightFundRate,
                AppNonFund = delivery.LearningDeliveryValue.AppNonFund,
                AreaCostFactAdj = delivery.LearningDeliveryValue.AreaCostFactAdj,
                BalInstalmPreTrans = delivery.LearningDeliveryValue.BalInstalmPreTrans,
                BaseValueUnweight = delivery.LearningDeliveryValue.BaseValueUnweight,
                CapFactor = delivery.LearningDeliveryValue.CapFactor,
                DisUpFactAdj = delivery.LearningDeliveryValue.DisUpFactAdj,
                EmpOutcomePayElig = delivery.LearningDeliveryValue.EmpOutcomePayElig,
                EmpOutcomePctHeldBackTrans = delivery.LearningDeliveryValue.EmpOutcomePctHeldBackTrans,
                EmpOutcomePctPreTrans = delivery.LearningDeliveryValue.EmpOutcomePctPreTrans,
                EmpRespOth = delivery.LearningDeliveryValue.EmpRespOth,
                ESOL = delivery.LearningDeliveryValue.ESOL,
                FullyFund = delivery.LearningDeliveryValue.FullyFund,
                FundLine = delivery.LearningDeliveryValue.FundLine,
                FundStart = delivery.LearningDeliveryValue.FundStart,
                LargeEmployerID = delivery.LearningDeliveryValue.LargeEmployerID,
                LargeEmployerFM35Fctr = delivery.LearningDeliveryValue.LargeEmployerFM35Fctr,
                LargeEmployerStatusDate = delivery.LearningDeliveryValue.LargeEmployerStatusDate,
                LTRCUpliftFctr = delivery.LearningDeliveryValue.LTRCUpliftFctr,
                NonGovCont = delivery.LearningDeliveryValue.NonGovCont,
                OLASSCustody = delivery.LearningDeliveryValue.OLASSCustody,
                OnProgPayPctPreTrans = delivery.LearningDeliveryValue.OnProgPayPctPreTrans,
                OutstndNumOnProgInstalm = delivery.LearningDeliveryValue.OutstndNumOnProgInstalm,
                OutstndNumOnProgInstalmTrans = delivery.LearningDeliveryValue.OutstndNumOnProgInstalmTrans,
                PlannedNumOnProgInstalm = delivery.LearningDeliveryValue.PlannedNumOnProgInstalm,
                PlannedNumOnProgInstalmTrans = delivery.LearningDeliveryValue.PlannedNumOnProgInstalmTrans,
                PlannedTotalDaysIL = delivery.LearningDeliveryValue.PlannedTotalDaysIL,
                PlannedTotalDaysILPreTrans = delivery.LearningDeliveryValue.PlannedTotalDaysILPreTrans,
                PropFundRemain = delivery.LearningDeliveryValue.PropFundRemain,
                PropFundRemainAch = delivery.LearningDeliveryValue.PropFundRemainAch,
                PrscHEAim = delivery.LearningDeliveryValue.PrscHEAim,
                Residential = delivery.LearningDeliveryValue.Residential,
                Restart = delivery.LearningDeliveryValue.Restart,
                SpecResUplift = delivery.LearningDeliveryValue.SpecResUplift,
                StartPropTrans = delivery.LearningDeliveryValue.StartPropTrans,
                ThresholdDays = delivery.LearningDeliveryValue.ThresholdDays,
                Traineeship = delivery.LearningDeliveryValue.Traineeship,
                Trans = delivery.LearningDeliveryValue.Trans,
                TrnAdjLearnStartDate = delivery.LearningDeliveryValue.TrnAdjLearnStartDate,
                TrnWorkPlaceAim = delivery.LearningDeliveryValue.TrnWorkPlaceAim,
                TrnWorkPrepAim = delivery.LearningDeliveryValue.TrnWorkPrepAim,
                UnWeightedRateFromESOL = delivery.LearningDeliveryValue.UnWeightedRateFromESOL,
                UnweightedRateFromLARS = delivery.LearningDeliveryValue.UnweightedRateFromLARS,
                WeightedRateFromESOL = delivery.LearningDeliveryValue.WeightedRateFromESOL,
                WeightedRateFromLARS = delivery.LearningDeliveryValue.WeightedRateFromLARS,
                FM35_LearningDelivery_Period = BuildLearningDeliveryPeriods(ukPrn, learnRefNumber, delivery.AimSeqNumber.Value, delivery.LearningDeliveryPeriodisedValues),
                FM35_LearningDelivery_PeriodisedValues = BuildLearningDeliveryPeriodisedValues(ukPrn, learnRefNumber, delivery.AimSeqNumber.Value, delivery.LearningDeliveryPeriodisedValues)
            };
        }

        public ICollection<FM35_LearningDelivery_Period> BuildLearningDeliveryPeriods(int ukPrn, string learnRefNumber, int aimSeqNumber, IEnumerable<LearningDeliveryPeriodisedValue> periodisedValues)
        {
            var learningDeliveryPeriods = new List<FM35_LearningDelivery_Period>();

            for (var i = 1; i < 13; i++)
            {
                learningDeliveryPeriods.Add(new FM35_LearningDelivery_Period
                {
                    LearnRefNumber = learnRefNumber,
                    UKPRN = ukPrn,
                    Period = i,
                    AimSeqNumber = aimSeqNumber,
                    AchievePayPct = GetPeriodValueForDelivery<decimal?>(periodisedValues.FirstOrDefault(pv => pv.AttributeName == nameof(FM35_LearningDelivery_Period.AchievePayPct)), i),
                    AchievePayPctTrans = GetPeriodValueForDelivery<decimal?>(periodisedValues.FirstOrDefault(pv => pv.AttributeName == nameof(FM35_LearningDelivery_Period.AchievePayPctTrans)), i),
                    AchievePayment = GetPeriodValueForDelivery<decimal?>(periodisedValues.FirstOrDefault(pv => pv.AttributeName == nameof(FM35_LearningDelivery_Period.AchievePayment)), i),
                    BalancePayment = GetPeriodValueForDelivery<decimal?>(periodisedValues.FirstOrDefault(pv => pv.AttributeName == nameof(FM35_LearningDelivery_Period.BalancePayment)), i),
                    BalancePaymentUncapped = GetPeriodValueForDelivery<decimal?>(periodisedValues.FirstOrDefault(pv => pv.AttributeName == nameof(FM35_LearningDelivery_Period.BalancePaymentUncapped)), i),
                    BalancePct = GetPeriodValueForDelivery<decimal?>(periodisedValues.FirstOrDefault(pv => pv.AttributeName == nameof(FM35_LearningDelivery_Period.BalancePct)), i),
                    BalancePctTrans = GetPeriodValueForDelivery<decimal?>(periodisedValues.FirstOrDefault(pv => pv.AttributeName == nameof(FM35_LearningDelivery_Period.BalancePctTrans)), i),
                    EmpOutcomePay = GetPeriodValueForDelivery<decimal?>(periodisedValues.FirstOrDefault(pv => pv.AttributeName == nameof(FM35_LearningDelivery_Period.EmpOutcomePay)), i),
                    EmpOutcomePct = GetPeriodValueForDelivery<decimal?>(periodisedValues.FirstOrDefault(pv => pv.AttributeName == nameof(FM35_LearningDelivery_Period.EmpOutcomePct)), i),
                    EmpOutcomePctTrans = GetPeriodValueForDelivery<decimal?>(periodisedValues.FirstOrDefault(pv => pv.AttributeName == nameof(FM35_LearningDelivery_Period.EmpOutcomePctTrans)), i),
                    InstPerPeriod = GetPeriodValueForDelivery<int?>(periodisedValues.FirstOrDefault(pv => pv.AttributeName == nameof(FM35_LearningDelivery_Period.InstPerPeriod)), i),
                    LearnSuppFund = GetPeriodValueForDelivery<bool?>(periodisedValues.FirstOrDefault(pv => pv.AttributeName == nameof(FM35_LearningDelivery_Period.LearnSuppFund)), i),
                    LearnSuppFundCash = GetPeriodValueForDelivery<decimal?>(periodisedValues.FirstOrDefault(pv => pv.AttributeName == nameof(FM35_LearningDelivery_Period.LearnSuppFundCash)), i),
                    OnProgPayment = GetPeriodValueForDelivery<decimal?>(periodisedValues.FirstOrDefault(pv => pv.AttributeName == nameof(FM35_LearningDelivery_Period.OnProgPayment)), i),
                    OnProgPayPct = GetPeriodValueForDelivery<decimal?>(periodisedValues.FirstOrDefault(pv => pv.AttributeName == nameof(FM35_LearningDelivery_Period.OnProgPayPct)), i),
                    OnProgPayPctTrans = GetPeriodValueForDelivery<decimal?>(periodisedValues.FirstOrDefault(pv => pv.AttributeName == nameof(FM35_LearningDelivery_Period.OnProgPayPctTrans)), i),
                    OnProgPaymentUncapped = GetPeriodValueForDelivery<decimal?>(periodisedValues.FirstOrDefault(pv => pv.AttributeName == nameof(FM35_LearningDelivery_Period.OnProgPaymentUncapped)), i),
                    TransInstPerPeriod = GetPeriodValueForDelivery<int?>(periodisedValues.FirstOrDefault(pv => pv.AttributeName == nameof(FM35_LearningDelivery_Period.TransInstPerPeriod)), i)
                });
            }

            return learningDeliveryPeriods;
        }

        public ICollection<FM35_LearningDelivery_PeriodisedValues> BuildLearningDeliveryPeriodisedValues(int ukPrn, string learnRefNumber, int aimSeqNumber, IEnumerable<LearningDeliveryPeriodisedValue> periodisedValues)
        {
            var learningDeliveryPeriodisedValues = new List<FM35_LearningDelivery_PeriodisedValues>();

            foreach (var value in periodisedValues)
            {
                learningDeliveryPeriodisedValues.Add(new FM35_LearningDelivery_PeriodisedValues
                {
                    UKPRN = ukPrn,
                    AimSeqNumber = aimSeqNumber,
                    LearnRefNumber = learnRefNumber,
                    AttributeName = value.AttributeName,
                    Period_1 = value.Period1,
                    Period_2 = value.Period2,
                    Period_3 = value.Period3,
                    Period_4 = value.Period4,
                    Period_5 = value.Period5,
                    Period_6 = value.Period6,
                    Period_7 = value.Period7,
                    Period_8 = value.Period8,
                    Period_9 = value.Period9,
                    Period_10 = value.Period10,
                    Period_11 = value.Period11,
                    Period_12 = value.Period12
                });
            }

            return learningDeliveryPeriodisedValues;
        }

        private static TR GetPeriodValueForDelivery<TR>(LearningDeliveryPeriodisedValue periodisedValue, int period)
        {
            var value = periodisedValue?.GetType().GetProperty($"{PeriodPrefix}{period.ToString()}")?.GetValue(periodisedValue);

            return TypeHelper.PeriodValueTypeHandler<TR>(value);
        }
    }
}