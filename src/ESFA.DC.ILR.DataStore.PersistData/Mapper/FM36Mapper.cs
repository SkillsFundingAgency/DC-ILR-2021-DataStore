using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Model;
using ESFA.DC.ILR1819.DataStore.Model.Funding;
using ESFA.DC.ILR1819.DataStore.PersistData.Constants;
using ESFA.DC.ILR1819.DataStore.PersistData.Helpers;
using ESFA.DC.ILR1819.DataStore.PersistData.Model;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Mapper
{
    public class FM36Mapper : IFM36Mapper
    {
        public FM36Data MapData(FM36Global fm36Global)
        {
            var data = new FM36Data();

            if (fm36Global.Learners != null)
            {
                data.Globals = MapGlobals(fm36Global).ToList();
                data.Learners = MapLearners(fm36Global).ToList();
                data.LearningDeliveries = MapLearningDeliveries(fm36Global).ToList();
                data.LearningDeliveryPeriods = MapLearningDeliveryPeriods(fm36Global).ToList();
                data.LearningDeliveryPeriodisedValues = MapLearningDeliveryPeriodisedValues(fm36Global).ToList();
                data.LearningDeliveryPeriodisedTextValues = MapLearningDeliveryPeriodisedTextValues(fm36Global).ToList();
                data.ApprenticeshipPriceEpisodes = MapPriceEpisodes(fm36Global).ToList();
                data.ApprenticeshipPriceEpisodePeriods = MapPriceEpisodePeriods(fm36Global).ToList();
                data.ApprenticeshipPriceEpisodePeriodisedValues = MapPriceEpisodePeriodisedValues(fm36Global).ToList();
            }

            return data;
        }

        public IEnumerable<AEC_global> MapGlobals(FM36Global fm36Global)
        {
            return new List<AEC_global>()
            {
                new AEC_global
                {
                    Year = fm36Global.Year,
                    LARSVersion = fm36Global.LARSVersion,
                    UKPRN = fm36Global.UKPRN,
                    RulebaseVersion = fm36Global.RulebaseVersion,
                }
            };
        }

        public IEnumerable<AEC_Learner> MapLearners(FM36Global fm36Global)
        {
            return fm36Global
                .Learners
                .Select(l => new AEC_Learner
            {
                UKPRN = fm36Global.UKPRN,
                LearnRefNumber = l.LearnRefNumber,
                ULN = l.ULN
            });
        }

        public IEnumerable<AEC_LearningDelivery> MapLearningDeliveries(FM36Global fm36Global)
        {
            return fm36Global
                .Learners
                .SelectMany(
                    l => l
                        .LearningDeliveries
                        .Select(ld =>
                new AEC_LearningDelivery
                {
                    UKPRN = fm36Global.UKPRN,
                    LearnRefNumber = l.LearnRefNumber,
                    AimSeqNumber = ld.AimSeqNumber,
                    ActualDaysIL = ld.LearningDeliveryValues.ActualDaysIL,
                    ActualNumInstalm = ld.LearningDeliveryValues.ActualNumInstalm,
                    AdjStartDate = ld.LearningDeliveryValues.AdjStartDate,
                    AgeAtProgStart = ld.LearningDeliveryValues.AgeAtProgStart,
                    AppAdjLearnStartDate = ld.LearningDeliveryValues.AppAdjLearnStartDate,
                    AppAdjLearnStartDateMatchPathway = ld.LearningDeliveryValues.AppAdjLearnStartDateMatchPathway,
                    ApplicCompDate = ld.LearningDeliveryValues.ApplicCompDate,
                    CombinedAdjProp = ld.LearningDeliveryValues.CombinedAdjProp,
                    Completed = ld.LearningDeliveryValues.Completed,
                    FirstIncentiveThresholdDate = ld.LearningDeliveryValues.FirstIncentiveThresholdDate,
                    FundStart = ld.LearningDeliveryValues.FundStart,
                    LDApplic1618FrameworkUpliftBalancingValue = ld.LearningDeliveryValues.LDApplic1618FrameworkUpliftBalancingValue,
                    LDApplic1618FrameworkUpliftCompElement = ld.LearningDeliveryValues.LDApplic1618FrameworkUpliftCompElement,
                    LDApplic1618FRameworkUpliftCompletionValue = ld.LearningDeliveryValues.LDApplic1618FRameworkUpliftCompletionValue,
                    LDApplic1618FrameworkUpliftMonthInstalVal = ld.LearningDeliveryValues.LDApplic1618FrameworkUpliftMonthInstalVal,
                    LDApplic1618FrameworkUpliftPrevEarnings = ld.LearningDeliveryValues.LDApplic1618FrameworkUpliftPrevEarnings,
                    LDApplic1618FrameworkUpliftPrevEarningsStage1 = ld.LearningDeliveryValues.LDApplic1618FrameworkUpliftPrevEarningsStage1,
                    LDApplic1618FrameworkUpliftRemainingAmount = ld.LearningDeliveryValues.LDApplic1618FrameworkUpliftRemainingAmount,
                    LDApplic1618FrameworkUpliftTotalActEarnings = ld.LearningDeliveryValues.LDApplic1618FrameworkUpliftTotalActEarnings,
                    LearnAimRef = ld.LearningDeliveryValues.LearnAimRef,
                    LearnDel1618AtStart = ld.LearningDeliveryValues.LearnDel1618AtStart,
                    LearnDelAccDaysILCareLeavers = ld.LearningDeliveryValues.LearnDelAccDaysILCareLeavers,
                    LearnDelAppAccDaysIL = ld.LearningDeliveryValues.LearnDelAppAccDaysIL,
                    LearnDelApplicCareLeaverIncentive = ld.LearningDeliveryValues.LearnDelApplicCareLeaverIncentive,
                    LearnDelApplicDisadvAmount = ld.LearningDeliveryValues.LearnDelApplicDisadvAmount,
                    LearnDelApplicEmp1618Incentive = ld.LearningDeliveryValues.LearnDelApplicEmp1618Incentive,
                    LearnDelApplicEmpDate = ld.LearningDeliveryValues.LearnDelApplicEmpDate,
                    LearnDelApplicProv1618FrameworkUplift = ld.LearningDeliveryValues.LearnDelApplicProv1618FrameworkUplift,
                    LearnDelApplicProv1618Incentive = ld.LearningDeliveryValues.LearnDelApplicProv1618Incentive,
                    LearnDelAppPrevAccDaysIL = ld.LearningDeliveryValues.LearnDelAppPrevAccDaysIL,
                    LearnDelDaysIL = ld.LearningDeliveryValues.LearnDelDaysIL,
                    LearnDelDisadAmount = ld.LearningDeliveryValues.LearnDelDisadAmount,
                    LearnDelEligDisadvPayment = ld.LearningDeliveryValues.LearnDelEligDisadvPayment,
                    LearnDelEmpIdFirstAdditionalPaymentThreshold = ld.LearningDeliveryValues.LearnDelEmpIdFirstAdditionalPaymentThreshold,
                    LearnDelEmpIdSecondAdditionalPaymentThreshold = ld.LearningDeliveryValues.LearnDelEmpIdSecondAdditionalPaymentThreshold,
                    LearnDelHistDaysCareLeavers = ld.LearningDeliveryValues.LearnDelHistDaysCareLeavers,
                    LearnDelHistDaysThisApp = ld.LearningDeliveryValues.LearnDelHistDaysThisApp,
                    LearnDelHistProgEarnings = ld.LearningDeliveryValues.LearnDelHistProgEarnings,
                    LearnDelInitialFundLineType = ld.LearningDeliveryValues.LearnDelInitialFundLineType,
                    LearnDelLearnerAddPayThresholdDate = ld.LearningDeliveryValues.LearnDelLearnerAddPayThresholdDate,
                    LearnDelMathEng = ld.LearningDeliveryValues.LearnDelMathEng,
                    LearnDelNonLevyProcured = ld.LearningDeliveryValues.LearnDelNonLevyProcured,
                    LearnDelPrevAccDaysILCareLeavers = ld.LearningDeliveryValues.LearnDelPrevAccDaysILCareLeavers,
                    LearnDelProgEarliestACT2Date = ld.LearningDeliveryValues.LearnDelProgEarliestACT2Date,
                    LearnDelRedCode = ld.LearningDeliveryValues.LearnDelRedCode,
                    LearnDelRedStartDate = ld.LearningDeliveryValues.LearnDelRedStartDate,
                    MathEngAimValue = ld.LearningDeliveryValues.MathEngAimValue,
                    OutstandNumOnProgInstalm = ld.LearningDeliveryValues.OutstandNumOnProgInstalm,
                    PlannedNumOnProgInstalm = ld.LearningDeliveryValues.PlannedNumOnProgInstalm,
                    PlannedTotalDaysIL = ld.LearningDeliveryValues.PlannedTotalDaysIL,
                    SecondIncentiveThresholdDate = ld.LearningDeliveryValues.SecondIncentiveThresholdDate,
                    ThresholdDays = ld.LearningDeliveryValues.ThresholdDays,
                }));
        }

        public IEnumerable<AEC_LearningDelivery_Period> MapLearningDeliveryPeriods(FM36Global fm36Global)
        {
            var periodisedValues = fm36Global.Learners
               .SelectMany(l => l.LearningDeliveries.Select(ld =>
               new FundModel36LearningDeliveryPeriodisedValue(fm36Global.UKPRN, l.LearnRefNumber, ld.AimSeqNumber, ld.LearningDeliveryPeriodisedValues, ld.LearningDeliveryPeriodisedTextValues)));

            var learningDeliveryPeriods = new List<AEC_LearningDelivery_Period>();

            for (var i = 1; i < 13; i++)
            {
                learningDeliveryPeriods.AddRange(
                    periodisedValues.Select(pv =>
                    new AEC_LearningDelivery_Period
                    {
                        UKPRN = pv.Ukprn,
                        LearnRefNumber = pv.LearnRefNumber,
                        AimSeqNumber = pv.AimSeqNumber,
                        Period = i,
                        DisadvFirstPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.DisadvFirstPayment), i),
                        DisadvSecondPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.DisadvSecondPayment), i),
                        FundLineType = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedTextValues, string>(pv.LearningDeliveryPeriodisedTextValue.FirstOrDefault(a => a.AttributeName == FM36Constants.FundLineType), i),
                        InstPerPeriod = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, int?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.InstPerPeriod), i),
                        LDApplic1618FrameworkUpliftBalancingPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.LDApplic1618FrameworkUpliftBalancingPayment), i),
                        LDApplic1618FrameworkUpliftCompletionPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.LDApplic1618FrameworkUpliftCompletionPayment), i),
                        LDApplic1618FrameworkUpliftOnProgPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.LDApplic1618FrameworkUpliftOnProgPayment), i),
                        LearnDelContType = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedTextValues, string>(pv.LearningDeliveryPeriodisedTextValue.FirstOrDefault(a => a.AttributeName == FM36Constants.LearnDelContType), i),
                        LearnDelFirstEmp1618Pay = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, int?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.LearnDelFirstEmp1618Pay), i),
                        LearnDelFirstProv1618Pay = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.LearnDelFirstProv1618Pay), i),
                        LearnDelLearnAddPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.LearnDelLearnAddPayment), i),
                        LearnDelLevyNonPayInd = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, int?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.LearnDelLevyNonPayInd), i),
                        LearnDelSecondEmp1618Pay = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.LearnDelSecondEmp1618Pay), i),
                        LearnDelSecondProv1618Pay = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.LearnDelSecondProv1618Pay), i),
                        LearnDelSEMContWaiver = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, bool?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.LearnDelSEMContWaiver), i),
                        LearnDelSFAContribPct = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.LearnDelSFAContribPct), i),
                        LearnSuppFund = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, bool?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.LearnSuppFund), i),
                        LearnSuppFundCash = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.LearnSuppFundCash), i),
                        MathEngBalPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.MathEngBalPayment), i),
                        MathEngBalPct = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.MathEngBalPct), i),
                        MathEngOnProgPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.MathEngOnProgPayment), i),
                        MathEngOnProgPct = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.MathEngOnProgPct), i),
                        ProgrammeAimBalPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.ProgrammeAimBalPayment), i),
                        ProgrammeAimCompletionPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.ProgrammeAimCompletionPayment), i),
                        ProgrammeAimOnProgPayment = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.ProgrammeAimOnProgPayment), i),
                        ProgrammeAimProgFundIndMaxEmpCont = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.ProgrammeAimProgFundIndMaxEmpCont), i),
                        ProgrammeAimProgFundIndMinCoInvest = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.ProgrammeAimProgFundIndMinCoInvest), i),
                        ProgrammeAimTotProgFund = PeriodisedValueHelper.GetPeriodValue<LearningDeliveryPeriodisedValues, decimal?>(pv.LearningDeliveryPeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.ProgrammeAimTotProgFund), i),
                    }));
            }

            return learningDeliveryPeriods;
        }

        public IEnumerable<AEC_LearningDelivery_PeriodisedValue> MapLearningDeliveryPeriodisedValues(FM36Global fm36Global)
        {
            var periodisedValues = fm36Global.Learners
               .SelectMany(l => l.LearningDeliveries.Select(ld =>
               new FundModel36LearningDeliveryPeriodisedValue(fm36Global.UKPRN, l.LearnRefNumber, ld.AimSeqNumber, ld.LearningDeliveryPeriodisedValues, ld.LearningDeliveryPeriodisedTextValues)));

            return
                   periodisedValues.SelectMany(pv => pv.LearningDeliveryPeriodisedValue
                   .Select(p =>
                   new AEC_LearningDelivery_PeriodisedValue
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

        public IEnumerable<AEC_LearningDelivery_PeriodisedTextValue> MapLearningDeliveryPeriodisedTextValues(FM36Global fm36Global)
        {
            var periodisedValues = fm36Global.Learners
              .SelectMany(l => l.LearningDeliveries.Select(ld =>
              new FundModel36LearningDeliveryPeriodisedValue(fm36Global.UKPRN, l.LearnRefNumber, ld.AimSeqNumber, ld.LearningDeliveryPeriodisedValues, ld.LearningDeliveryPeriodisedTextValues)));

            return
                   periodisedValues.SelectMany(pv => pv.LearningDeliveryPeriodisedTextValue
                   .Select(p =>
                   new AEC_LearningDelivery_PeriodisedTextValue
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

        public IEnumerable<AEC_ApprenticeshipPriceEpisode> MapPriceEpisodes(FM36Global fm36Global)
        {
            return fm36Global.Learners
                .SelectMany(l => l.PriceEpisodes.Select(pe =>
                 new AEC_ApprenticeshipPriceEpisode
                 {
                     UKPRN = fm36Global.UKPRN,
                     LearnRefNumber = l.LearnRefNumber,
                     PriceEpisodeIdentifier = pe.PriceEpisodeIdentifier,
                     TNP4 = pe.PriceEpisodeValues.TNP4,
                     TNP1 = pe.PriceEpisodeValues.TNP1,
                     EpisodeStartDate = pe.PriceEpisodeValues.EpisodeStartDate,
                     TNP2 = pe.PriceEpisodeValues.TNP2,
                     TNP3 = pe.PriceEpisodeValues.TNP3,
                     PriceEpisodeUpperBandLimit = pe.PriceEpisodeValues.PriceEpisodeUpperBandLimit,
                     PriceEpisodePlannedEndDate = pe.PriceEpisodeValues.PriceEpisodePlannedEndDate,
                     PriceEpisodeActualEndDate = pe.PriceEpisodeValues.PriceEpisodeActualEndDate,
                     PriceEpisodeTotalTNPPrice = pe.PriceEpisodeValues.PriceEpisodeTotalTNPPrice,
                     PriceEpisodeUpperLimitAdjustment = pe.PriceEpisodeValues.PriceEpisodeUpperLimitAdjustment,
                     PriceEpisodePlannedInstalments = pe.PriceEpisodeValues.PriceEpisodePlannedInstalments,
                     PriceEpisodeActualInstalments = pe.PriceEpisodeValues.PriceEpisodeActualInstalments,
                     PriceEpisodeInstalmentsThisPeriod = pe.PriceEpisodeValues.PriceEpisodeInstalmentsThisPeriod,
                     PriceEpisodeCompletionElement = pe.PriceEpisodeValues.PriceEpisodeCompletionElement,
                     PriceEpisodePreviousEarnings = pe.PriceEpisodeValues.PriceEpisodePreviousEarnings,
                     PriceEpisodeInstalmentValue = pe.PriceEpisodeValues.PriceEpisodeInstalmentValue,
                     PriceEpisodeOnProgPayment = pe.PriceEpisodeValues.PriceEpisodeOnProgPayment,
                     PriceEpisodeTotalEarnings = pe.PriceEpisodeValues.PriceEpisodeTotalEarnings,
                     PriceEpisodeBalanceValue = pe.PriceEpisodeValues.PriceEpisodeBalanceValue,
                     PriceEpisodeBalancePayment = pe.PriceEpisodeValues.PriceEpisodeBalancePayment,
                     PriceEpisodeCompleted = pe.PriceEpisodeValues.PriceEpisodeCompleted,
                     PriceEpisodeCompletionPayment = pe.PriceEpisodeValues.PriceEpisodeCompletionPayment,
                     PriceEpisodeRemainingTNPAmount = pe.PriceEpisodeValues.PriceEpisodeRemainingTNPAmount,
                     PriceEpisodeRemainingAmountWithinUpperLimit = pe.PriceEpisodeValues.PriceEpisodeRemainingAmountWithinUpperLimit,
                     PriceEpisodeCappedRemainingTNPAmount = pe.PriceEpisodeValues.PriceEpisodeCappedRemainingTNPAmount,
                     PriceEpisodeExpectedTotalMonthlyValue = pe.PriceEpisodeValues.PriceEpisodeExpectedTotalMonthlyValue,
                     PriceEpisodeAimSeqNumber = pe.PriceEpisodeValues.PriceEpisodeAimSeqNumber,
                     PriceEpisodeFirstDisadvantagePayment = pe.PriceEpisodeValues.PriceEpisodeFirstDisadvantagePayment,
                     PriceEpisodeSecondDisadvantagePayment = pe.PriceEpisodeValues.PriceEpisodeSecondDisadvantagePayment,
                     PriceEpisodeApplic1618FrameworkUpliftBalancing = pe.PriceEpisodeValues.PriceEpisodeApplic1618FrameworkUpliftBalancing,
                     PriceEpisodeApplic1618FrameworkUpliftCompletionPayment = pe.PriceEpisodeValues.PriceEpisodeApplic1618FrameworkUpliftCompletionPayment,
                     PriceEpisodeApplic1618FrameworkUpliftOnProgPayment = pe.PriceEpisodeValues.PriceEpisodeApplic1618FrameworkUpliftOnProgPayment,
                     PriceEpisodeSecondProv1618Pay = pe.PriceEpisodeValues.PriceEpisodeSecondProv1618Pay,
                     PriceEpisodeFirstEmp1618Pay = pe.PriceEpisodeValues.PriceEpisodeFirstEmp1618Pay,
                     PriceEpisodeSecondEmp1618Pay = pe.PriceEpisodeValues.PriceEpisodeSecondEmp1618Pay,
                     PriceEpisodeFirstProv1618Pay = pe.PriceEpisodeValues.PriceEpisodeFirstProv1618Pay,
                     PriceEpisodeLSFCash = pe.PriceEpisodeValues.PriceEpisodeLSFCash,
                     PriceEpisodeFundLineType = pe.PriceEpisodeValues.PriceEpisodeFundLineType,
                     PriceEpisodeSFAContribPct = pe.PriceEpisodeValues.PriceEpisodeSFAContribPct,
                     PriceEpisodeLevyNonPayInd = pe.PriceEpisodeValues.PriceEpisodeLevyNonPayInd,
                     EpisodeEffectiveTNPStartDate = pe.PriceEpisodeValues.EpisodeEffectiveTNPStartDate,
                     PriceEpisodeFirstAdditionalPaymentThresholdDate = pe.PriceEpisodeValues.PriceEpisodeFirstAdditionalPaymentThresholdDate,
                     PriceEpisodeSecondAdditionalPaymentThresholdDate = pe.PriceEpisodeValues.PriceEpisodeSecondAdditionalPaymentThresholdDate,
                     PriceEpisodeContractType = pe.PriceEpisodeValues.PriceEpisodeContractType,
                     PriceEpisodePreviousEarningsSameProvider = pe.PriceEpisodeValues.PriceEpisodePreviousEarningsSameProvider,
                     PriceEpisodeTotProgFunding = pe.PriceEpisodeValues.PriceEpisodeTotProgFunding,
                     PriceEpisodeProgFundIndMinCoInvest = pe.PriceEpisodeValues.PriceEpisodeProgFundIndMinCoInvest,
                     PriceEpisodeProgFundIndMaxEmpCont = pe.PriceEpisodeValues.PriceEpisodeProgFundIndMaxEmpCont,
                     PriceEpisodeTotalPMRs = pe.PriceEpisodeValues.PriceEpisodeTotalPMRs,
                     PriceEpisodeCumulativePMRs = pe.PriceEpisodeValues.PriceEpisodeCumulativePMRs,
                     PriceEpisodeCompExemCode = pe.PriceEpisodeValues.PriceEpisodeCompExemCode,
                     PriceEpisodeLearnerAdditionalPaymentThresholdDate = pe.PriceEpisodeValues.PriceEpisodeLearnerAdditionalPaymentThresholdDate,
                     PriceEpisodeAgreeId = pe.PriceEpisodeValues.PriceEpisodeAgreeId,
                     PriceEpisodeRedStartDate = pe.PriceEpisodeValues.PriceEpisodeRedStartDate,
                     PriceEpisodeRedStatusCode = pe.PriceEpisodeValues.PriceEpisodeRedStatusCode,
                 }));
        }

        public IEnumerable<AEC_ApprenticeshipPriceEpisode_Period> MapPriceEpisodePeriods(FM36Global fm36Global)
        {
            var periodisedValues = fm36Global.Learners
               .SelectMany(l => l.PriceEpisodes.Select(pe =>
               new FundModelPriceEpisodePeriodisedValue<List<PriceEpisodePeriodisedValues>>(fm36Global.UKPRN, l.LearnRefNumber, pe.PriceEpisodeIdentifier, pe.PriceEpisodePeriodisedValues)));

            var learningDeliveryPeriods = new List<AEC_ApprenticeshipPriceEpisode_Period>();

            for (var i = 1; i < 13; i++)
            {
                learningDeliveryPeriods.AddRange(
                    periodisedValues.Select(pv =>
                    new AEC_ApprenticeshipPriceEpisode_Period
                    {
                        UKPRN = pv.Ukprn,
                        LearnRefNumber = pv.LearnRefNumber,
                        PriceEpisodeIdentifier = pv.PriceEpisodeIdentifier,
                        Period = i,
                        PriceEpisodeApplic1618FrameworkUpliftBalancing = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, decimal?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeApplic1618FrameworkUpliftBalancing), i),
                        PriceEpisodeApplic1618FrameworkUpliftCompletionPayment = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, decimal?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeApplic1618FrameworkUpliftCompletionPayment), i),
                        PriceEpisodeApplic1618FrameworkUpliftOnProgPayment = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, decimal?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeApplic1618FrameworkUpliftOnProgPayment), i),
                        PriceEpisodeBalancePayment = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, decimal?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeBalancePayment), i),
                        PriceEpisodeBalanceValue = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, decimal?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeBalanceValue), i),
                        PriceEpisodeCompletionPayment = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, decimal?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeCompletionPayment), i),
                        PriceEpisodeFirstDisadvantagePayment = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, decimal?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeFirstDisadvantagePayment), i),
                        PriceEpisodeFirstEmp1618Pay = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, decimal?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeFirstEmp1618Pay), i),
                        PriceEpisodeFirstProv1618Pay = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, decimal?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeFirstProv1618Pay), i),
                        PriceEpisodeInstalmentsThisPeriod = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, int?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeInstalmentsThisPeriod), i),
                        PriceEpisodeLevyNonPayInd = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, int?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeLevyNonPayInd), i),
                        PriceEpisodeLSFCash = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, decimal?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeLSFCash), i),
                        PriceEpisodeOnProgPayment = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, decimal?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeOnProgPayment), i),
                        PriceEpisodeProgFundIndMaxEmpCont = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, decimal?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeProgFundIndMaxEmpCont), i),
                        PriceEpisodeProgFundIndMinCoInvest = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, decimal?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeProgFundIndMinCoInvest), i),
                        PriceEpisodeSecondDisadvantagePayment = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, decimal?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeSecondDisadvantagePayment), i),
                        PriceEpisodeSecondEmp1618Pay = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, decimal?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeSecondEmp1618Pay), i),
                        PriceEpisodeSecondProv1618Pay = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, decimal?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeSecondProv1618Pay), i),
                        PriceEpisodeSFAContribPct = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, decimal?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeSFAContribPct), i),
                        PriceEpisodeTotProgFunding = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, decimal?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeTotProgFunding), i),
                        PriceEpisodeLearnerAdditionalPayment = PeriodisedValueHelper.GetPeriodValue<PriceEpisodePeriodisedValues, decimal?>(pv.PriceEpisodePeriodisedValue.FirstOrDefault(a => a.AttributeName == FM36Constants.PriceEpisodeLearnerAdditionalPayment), i),
                    }));
            }

            return learningDeliveryPeriods;
        }

        public IEnumerable<AEC_ApprenticeshipPriceEpisode_PeriodisedValue> MapPriceEpisodePeriodisedValues(FM36Global fm36Global)
        {
            var periodisedValues = fm36Global.Learners
               .SelectMany(l => l.PriceEpisodes.Select(pe =>
               new FundModelPriceEpisodePeriodisedValue<List<PriceEpisodePeriodisedValues>>(fm36Global.UKPRN, l.LearnRefNumber, pe.PriceEpisodeIdentifier, pe.PriceEpisodePeriodisedValues)));

            return
                   periodisedValues.SelectMany(pv => pv.PriceEpisodePeriodisedValue
                   .Select(p =>
                   new AEC_ApprenticeshipPriceEpisode_PeriodisedValue
                   {
                       UKPRN = pv.Ukprn,
                       LearnRefNumber = pv.LearnRefNumber,
                       PriceEpisodeIdentifier = pv.PriceEpisodeIdentifier,
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