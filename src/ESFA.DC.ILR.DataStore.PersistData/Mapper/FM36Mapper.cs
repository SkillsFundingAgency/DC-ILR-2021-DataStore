using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.DataStore.Model;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.PersistData.Builders.Extension;
using ESFA.DC.ILR.DataStore.PersistData.Constants;
using ESFA.DC.ILR.DataStore.PersistData.Helpers;
using ESFA.DC.ILR.DataStore.PersistData.Model;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.PersistData.Mapper
{
    public class FM36Mapper : IFM36Mapper
    {
        public IDataStoreCache MapData(FM36Global fm36Global)
        {
            var cache = new DataStoreCache();
            var learners = fm36Global.Learners;

            if (learners == null)
            {
                return cache;
            }

            var ukprn = fm36Global.UKPRN;

            return PopulateDataStoreCache(cache, learners, fm36Global, ukprn);
        }

        private IDataStoreCache PopulateDataStoreCache(DataStoreCache dataCache, IEnumerable<FM36Learner> learners, FM36Global fm36Global, int ukprn)
        {
            dataCache.AddRange(BuildGlobals(fm36Global, ukprn));

            learners.NullSafeForEach(learner =>
            {
                var learnRefNumber = learner.LearnRefNumber;

                dataCache.Add(BuildLearner(learner, ukprn, learnRefNumber));
                learner.LearningDeliveries.NullSafeForEach(learningDelivery => dataCache.Add(BuildLearningDelivery(learningDelivery, ukprn, learnRefNumber)));
                learner.PriceEpisodes.NullSafeForEach(priceEpisode => dataCache.Add(BuildPriceEpisode(priceEpisode, ukprn, learnRefNumber)));
            });

            var learningDeliveryPeriodisedValues = learners.SelectMany(l => l.LearningDeliveries.Select(ld =>
                    new FundModel36LearningDeliveryPeriodisedValue(fm36Global.UKPRN, l.LearnRefNumber, ld.AimSeqNumber, ld.LearningDeliveryPeriodisedValues, ld.LearningDeliveryPeriodisedTextValues)));

            dataCache.AddRange(BuildLearningDeliveryPeriods(learningDeliveryPeriodisedValues));

            learningDeliveryPeriodisedValues.NullSafeForEach(ldpv =>
            {
                ldpv.LearningDeliveryPeriodisedValue.NullSafeForEach(learningDeliveryPeriodisedValue => dataCache.Add(BuildLearningDeliveryPeriodisedValues(learningDeliveryPeriodisedValue, ukprn, ldpv.AimSeqNumber, ldpv.LearnRefNumber)));
                ldpv.LearningDeliveryPeriodisedTextValue.NullSafeForEach(learningDeliveryPeriodisedTextValue => dataCache.Add(BuildLearningDeliveryPeriodisedTextValues(learningDeliveryPeriodisedTextValue, ukprn, ldpv.AimSeqNumber, ldpv.LearnRefNumber)));
            });

            var priceEpisodePeriodisedValues = learners.SelectMany(l => l.PriceEpisodes.Select(pe =>
                    new FundModelPriceEpisodePeriodisedValue<List<PriceEpisodePeriodisedValues>>(fm36Global.UKPRN, l.LearnRefNumber, pe.PriceEpisodeIdentifier, pe.PriceEpisodePeriodisedValues)));

            dataCache.AddRange(BuildPriceEpisodePeriods(priceEpisodePeriodisedValues));

            priceEpisodePeriodisedValues.NullSafeForEach(pepv => pepv.PriceEpisodePeriodisedValue.NullSafeForEach(priceEpisodePeriodisedValue => dataCache.Add(BuildPriceEpisodePeriodisedValue(priceEpisodePeriodisedValue, ukprn, pepv.LearnRefNumber, pepv.PriceEpisodeIdentifier))));

            return dataCache;
        }

        public List<AEC_global> BuildGlobals(FM36Global fm36Global, int ukprn)
        {
            return new List<AEC_global>()
            {
                new AEC_global
                {
                    LARSVersion = fm36Global.LARSVersion,
                    UKPRN = ukprn,
                    RulebaseVersion = fm36Global.RulebaseVersion,
                }
            };
        }

        public AEC_Learner BuildLearner(FM36Learner fm36Learner, int ukprn, string learnRefNumber)
        {
            return new AEC_Learner
            {
                UKPRN = ukprn,
                LearnRefNumber = learnRefNumber,
                ULN = fm36Learner.ULN
            };
        }

        public AEC_LearningDelivery BuildLearningDelivery(LearningDelivery learningDelivery, int ukprn, string learnRefNumber)
        {
            return new AEC_LearningDelivery
            {
                UKPRN = ukprn,
                LearnRefNumber = learnRefNumber,
                AimSeqNumber = learningDelivery.AimSeqNumber,
                ActualDaysIL = learningDelivery.LearningDeliveryValues.ActualDaysIL,
                ActualNumInstalm = learningDelivery.LearningDeliveryValues.ActualNumInstalm,
                AdjStartDate = learningDelivery.LearningDeliveryValues.AdjStartDate,
                AgeAtProgStart = learningDelivery.LearningDeliveryValues.AgeAtProgStart,
                AppAdjLearnStartDate = learningDelivery.LearningDeliveryValues.AppAdjLearnStartDate,
                AppAdjLearnStartDateMatchPathway = learningDelivery.LearningDeliveryValues.AppAdjLearnStartDateMatchPathway,
                ApplicCompDate = learningDelivery.LearningDeliveryValues.ApplicCompDate,
                CombinedAdjProp = learningDelivery.LearningDeliveryValues.CombinedAdjProp,
                Completed = learningDelivery.LearningDeliveryValues.Completed,
                FirstIncentiveThresholdDate = learningDelivery.LearningDeliveryValues.FirstIncentiveThresholdDate,
                FundStart = learningDelivery.LearningDeliveryValues.FundStart,
                LDApplic1618FrameworkUpliftTotalActEarnings = learningDelivery.LearningDeliveryValues.LDApplic1618FrameworkUpliftTotalActEarnings,
                LearnAimRef = learningDelivery.LearningDeliveryValues.LearnAimRef,
                LearnDel1618AtStart = learningDelivery.LearningDeliveryValues.LearnDel1618AtStart,
                LearnDelAccDaysILCareLeavers = learningDelivery.LearningDeliveryValues.LearnDelAccDaysILCareLeavers,
                LearnDelAppAccDaysIL = learningDelivery.LearningDeliveryValues.LearnDelAppAccDaysIL,
                LearnDelApplicCareLeaverIncentive = learningDelivery.LearningDeliveryValues.LearnDelApplicCareLeaverIncentive,
                LearnDelApplicDisadvAmount = learningDelivery.LearningDeliveryValues.LearnDelApplicDisadvAmount,
                LearnDelApplicEmp1618Incentive = learningDelivery.LearningDeliveryValues.LearnDelApplicEmp1618Incentive,
                LearnDelApplicEmpDate = learningDelivery.LearningDeliveryValues.LearnDelApplicEmpDate,
                LearnDelApplicProv1618FrameworkUplift = learningDelivery.LearningDeliveryValues.LearnDelApplicProv1618FrameworkUplift,
                LearnDelApplicProv1618Incentive = learningDelivery.LearningDeliveryValues.LearnDelApplicProv1618Incentive,
                LearnDelAppPrevAccDaysIL = learningDelivery.LearningDeliveryValues.LearnDelAppPrevAccDaysIL,
                LearnDelDaysIL = learningDelivery.LearningDeliveryValues.LearnDelDaysIL,
                LearnDelDisadAmount = learningDelivery.LearningDeliveryValues.LearnDelDisadAmount,
                LearnDelEligDisadvPayment = learningDelivery.LearningDeliveryValues.LearnDelEligDisadvPayment,
                LearnDelEmpIdFirstAdditionalPaymentThreshold = learningDelivery.LearningDeliveryValues.LearnDelEmpIdFirstAdditionalPaymentThreshold,
                LearnDelEmpIdSecondAdditionalPaymentThreshold = learningDelivery.LearningDeliveryValues.LearnDelEmpIdSecondAdditionalPaymentThreshold,
                LearnDelHistDaysCareLeavers = learningDelivery.LearningDeliveryValues.LearnDelHistDaysCareLeavers,
                LearnDelHistDaysThisApp = learningDelivery.LearningDeliveryValues.LearnDelHistDaysThisApp,
                LearnDelHistProgEarnings = learningDelivery.LearningDeliveryValues.LearnDelHistProgEarnings,
                LearnDelInitialFundLineType = learningDelivery.LearningDeliveryValues.LearnDelInitialFundLineType,
                LearnDelLearnerAddPayThresholdDate = learningDelivery.LearningDeliveryValues.LearnDelLearnerAddPayThresholdDate,
                LearnDelMathEng = learningDelivery.LearningDeliveryValues.LearnDelMathEng,
                LearnDelNonLevyProcured = learningDelivery.LearningDeliveryValues.LearnDelNonLevyProcured,
                LearnDelPrevAccDaysILCareLeavers = learningDelivery.LearningDeliveryValues.LearnDelPrevAccDaysILCareLeavers,
                LearnDelProgEarliestACT2Date = learningDelivery.LearningDeliveryValues.LearnDelProgEarliestACT2Date,
                LearnDelRedCode = learningDelivery.LearningDeliveryValues.LearnDelRedCode,
                LearnDelRedStartDate = learningDelivery.LearningDeliveryValues.LearnDelRedStartDate,
                MathEngAimValue = learningDelivery.LearningDeliveryValues.MathEngAimValue,
                OutstandNumOnProgInstalm = learningDelivery.LearningDeliveryValues.OutstandNumOnProgInstalm,
                PlannedNumOnProgInstalm = learningDelivery.LearningDeliveryValues.PlannedNumOnProgInstalm,
                PlannedTotalDaysIL = learningDelivery.LearningDeliveryValues.PlannedTotalDaysIL,
                SecondIncentiveThresholdDate = learningDelivery.LearningDeliveryValues.SecondIncentiveThresholdDate,
                ThresholdDays = learningDelivery.LearningDeliveryValues.ThresholdDays,
            };
        }

        public IEnumerable<AEC_LearningDelivery_Period> BuildLearningDeliveryPeriods(IEnumerable<FundModel36LearningDeliveryPeriodisedValue> periodisedValues)
        {
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

        public AEC_LearningDelivery_PeriodisedValue BuildLearningDeliveryPeriodisedValues(LearningDeliveryPeriodisedValues learningDeliveryPeriodisedValue, int ukprn, int aimSeqNumber, string learnAimRef)
        {
            return new AEC_LearningDelivery_PeriodisedValue
            {
                UKPRN = ukprn,
                AimSeqNumber = aimSeqNumber,
                LearnRefNumber = learnAimRef,
                AttributeName = learningDeliveryPeriodisedValue.AttributeName,
                Period_1 = learningDeliveryPeriodisedValue.Period1,
                Period_2 = learningDeliveryPeriodisedValue.Period2,
                Period_3 = learningDeliveryPeriodisedValue.Period3,
                Period_4 = learningDeliveryPeriodisedValue.Period4,
                Period_5 = learningDeliveryPeriodisedValue.Period5,
                Period_6 = learningDeliveryPeriodisedValue.Period6,
                Period_7 = learningDeliveryPeriodisedValue.Period7,
                Period_8 = learningDeliveryPeriodisedValue.Period8,
                Period_9 = learningDeliveryPeriodisedValue.Period9,
                Period_10 = learningDeliveryPeriodisedValue.Period10,
                Period_11 = learningDeliveryPeriodisedValue.Period11,
                Period_12 = learningDeliveryPeriodisedValue.Period12
            };
        }

        public AEC_LearningDelivery_PeriodisedTextValue BuildLearningDeliveryPeriodisedTextValues(LearningDeliveryPeriodisedTextValues learningDeliveryPeriodisedTextValue, int ukprn, int aimSeqNumber, string learnAimRef)
        {
            return new AEC_LearningDelivery_PeriodisedTextValue
            {
                UKPRN = ukprn,
                AimSeqNumber = aimSeqNumber,
                LearnRefNumber = learnAimRef,
                AttributeName = learningDeliveryPeriodisedTextValue.AttributeName,
                Period_1 = learningDeliveryPeriodisedTextValue.Period1,
                Period_2 = learningDeliveryPeriodisedTextValue.Period2,
                Period_3 = learningDeliveryPeriodisedTextValue.Period3,
                Period_4 = learningDeliveryPeriodisedTextValue.Period4,
                Period_5 = learningDeliveryPeriodisedTextValue.Period5,
                Period_6 = learningDeliveryPeriodisedTextValue.Period6,
                Period_7 = learningDeliveryPeriodisedTextValue.Period7,
                Period_8 = learningDeliveryPeriodisedTextValue.Period8,
                Period_9 = learningDeliveryPeriodisedTextValue.Period9,
                Period_10 = learningDeliveryPeriodisedTextValue.Period10,
                Period_11 = learningDeliveryPeriodisedTextValue.Period11,
                Period_12 = learningDeliveryPeriodisedTextValue.Period12
            };
        }

        public AEC_ApprenticeshipPriceEpisode BuildPriceEpisode(PriceEpisode pe, int ukprn, string learnRefNumber)
        {
            return new AEC_ApprenticeshipPriceEpisode
            {
                 UKPRN = ukprn,
                 LearnRefNumber = learnRefNumber,
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
                 PriceEpisodeCompletionElement = pe.PriceEpisodeValues.PriceEpisodeCompletionElement,
                 PriceEpisodePreviousEarnings = pe.PriceEpisodeValues.PriceEpisodePreviousEarnings,
                 PriceEpisodeInstalmentValue = pe.PriceEpisodeValues.PriceEpisodeInstalmentValue,
                 PriceEpisodeTotalEarnings = pe.PriceEpisodeValues.PriceEpisodeTotalEarnings,
                 PriceEpisodeCompleted = pe.PriceEpisodeValues.PriceEpisodeCompleted,
                 PriceEpisodeRemainingTNPAmount = pe.PriceEpisodeValues.PriceEpisodeRemainingTNPAmount,
                 PriceEpisodeRemainingAmountWithinUpperLimit = pe.PriceEpisodeValues.PriceEpisodeRemainingAmountWithinUpperLimit,
                 PriceEpisodeCappedRemainingTNPAmount = pe.PriceEpisodeValues.PriceEpisodeCappedRemainingTNPAmount,
                 PriceEpisodeExpectedTotalMonthlyValue = pe.PriceEpisodeValues.PriceEpisodeExpectedTotalMonthlyValue,
                 // PriceEpisodeAimSeqNumber = pe.PriceEpisodeValues.PriceEpisodeAimSeqNumber, - waiting for FS output, changed from long to int
                 PriceEpisodeFundLineType = pe.PriceEpisodeValues.PriceEpisodeFundLineType,
                 EpisodeEffectiveTNPStartDate = pe.PriceEpisodeValues.EpisodeEffectiveTNPStartDate,
                 PriceEpisodeFirstAdditionalPaymentThresholdDate = pe.PriceEpisodeValues.PriceEpisodeFirstAdditionalPaymentThresholdDate,
                 PriceEpisodeSecondAdditionalPaymentThresholdDate = pe.PriceEpisodeValues.PriceEpisodeSecondAdditionalPaymentThresholdDate,
                 PriceEpisodeContractType = pe.PriceEpisodeValues.PriceEpisodeContractType,
                 PriceEpisodePreviousEarningsSameProvider = pe.PriceEpisodeValues.PriceEpisodePreviousEarningsSameProvider,
                 PriceEpisodeTotalPMRs = pe.PriceEpisodeValues.PriceEpisodeTotalPMRs,
                 PriceEpisodeCumulativePMRs = pe.PriceEpisodeValues.PriceEpisodeCumulativePMRs,
                 PriceEpisodeCompExemCode = pe.PriceEpisodeValues.PriceEpisodeCompExemCode,
                 PriceEpisodeLearnerAdditionalPaymentThresholdDate = pe.PriceEpisodeValues.PriceEpisodeLearnerAdditionalPaymentThresholdDate,
                 PriceEpisodeAgreeId = pe.PriceEpisodeValues.PriceEpisodeAgreeId,
                 PriceEpisodeRedStartDate = pe.PriceEpisodeValues.PriceEpisodeRedStartDate,
                 PriceEpisodeRedStatusCode = pe.PriceEpisodeValues.PriceEpisodeRedStatusCode,

                 // ToDo: populate below when FM36 output from FS is ready
                 // PriceEpisodeActualEndDateIncEPA =
                 // PriceEpisode1618FUBalValue =
                 // PriceEpisodeApplic1618FrameworkUpliftCompElement =
                 // PriceEpisode1618FrameworkUpliftTotPrevEarnings =
                 // PriceEpisode1618FrameworkUpliftRemainingAmount =
                 // PriceEpisode1618FUMonthInstValue =
                 // PriceEpisode1618FUTotEarnings =
            };
        }

        public IEnumerable<AEC_ApprenticeshipPriceEpisode_Period> BuildPriceEpisodePeriods(IEnumerable<FundModelPriceEpisodePeriodisedValue<List<PriceEpisodePeriodisedValues>>> periodisedValues)
        {
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

        public AEC_ApprenticeshipPriceEpisode_PeriodisedValue BuildPriceEpisodePeriodisedValue(PriceEpisodePeriodisedValues priceEpisodePeriodisedValue, int ukprn, string learnRefNumber, string priceEpisodeId)
        {
            return new AEC_ApprenticeshipPriceEpisode_PeriodisedValue
            {
                UKPRN = ukprn,
                LearnRefNumber = learnRefNumber,
                PriceEpisodeIdentifier = priceEpisodeId,
                AttributeName = priceEpisodePeriodisedValue.AttributeName,
                Period_1 = priceEpisodePeriodisedValue.Period1,
                Period_2 = priceEpisodePeriodisedValue.Period2,
                Period_3 = priceEpisodePeriodisedValue.Period3,
                Period_4 = priceEpisodePeriodisedValue.Period4,
                Period_5 = priceEpisodePeriodisedValue.Period5,
                Period_6 = priceEpisodePeriodisedValue.Period6,
                Period_7 = priceEpisodePeriodisedValue.Period7,
                Period_8 = priceEpisodePeriodisedValue.Period8,
                Period_9 = priceEpisodePeriodisedValue.Period9,
                Period_10 = priceEpisodePeriodisedValue.Period10,
                Period_11 = priceEpisodePeriodisedValue.Period11,
                Period_12 = priceEpisodePeriodisedValue.Period12
            };
        }
    }
}