using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Rulebase
{
    public class FM36PriceEpisodeBuilder
    {
        public static AEC_ApprenticeshipPriceEpisode BuildPriceEpisode(PriceEpisode episode, int ukPrn, string learnRefNum)
        {
            return new AEC_ApprenticeshipPriceEpisode
            {
                UKPRN = ukPrn,
                LearnRefNumber = learnRefNum,
                PriceEpisodeIdentifier = episode.PriceEpisodeIdentifier,
                EpisodeStartDate = episode.PriceEpisodeValues.EpisodeStartDate,
                TNP1 = episode.PriceEpisodeValues.TNP1,
                TNP2 = episode.PriceEpisodeValues.TNP2,
                TNP3 = episode.PriceEpisodeValues.TNP3,
                TNP4 = episode.PriceEpisodeValues.TNP4,
                PriceEpisodeUpperBandLimit = episode.PriceEpisodeValues.PriceEpisodeUpperBandLimit,
                PriceEpisodePlannedEndDate = episode.PriceEpisodeValues.PriceEpisodePlannedEndDate,
                PriceEpisodeActualEndDate = episode.PriceEpisodeValues.PriceEpisodeActualEndDate,
                PriceEpisodeTotalTNPPrice = episode.PriceEpisodeValues.PriceEpisodeTotalTNPPrice,
                PriceEpisodeUpperLimitAdjustment = episode.PriceEpisodeValues.PriceEpisodeUpperLimitAdjustment,
                PriceEpisodePlannedInstalments = episode.PriceEpisodeValues.PriceEpisodePlannedInstalments,
                PriceEpisodeActualInstalments = episode.PriceEpisodeValues.PriceEpisodeActualInstalments,
                PriceEpisodeInstalmentsThisPeriod = episode.PriceEpisodeValues.PriceEpisodeInstalmentsThisPeriod,
                PriceEpisodeCompletionElement = episode.PriceEpisodeValues.PriceEpisodeCompletionElement,
                PriceEpisodePreviousEarnings = episode.PriceEpisodeValues.PriceEpisodePreviousEarnings,
                PriceEpisodeInstalmentValue = episode.PriceEpisodeValues.PriceEpisodeInstalmentValue,
                PriceEpisodeOnProgPayment = episode.PriceEpisodeValues.PriceEpisodeOnProgPayment,
                PriceEpisodeTotalEarnings = episode.PriceEpisodeValues.PriceEpisodeTotalEarnings,
                PriceEpisodeBalanceValue = episode.PriceEpisodeValues.PriceEpisodeBalanceValue,
                PriceEpisodeBalancePayment = episode.PriceEpisodeValues.PriceEpisodeBalancePayment,
                PriceEpisodeCompleted = episode.PriceEpisodeValues.PriceEpisodeCompleted,
                PriceEpisodeCompletionPayment = episode.PriceEpisodeValues.PriceEpisodeCompletionPayment,
                PriceEpisodeRemainingTNPAmount = episode.PriceEpisodeValues.PriceEpisodeRemainingTNPAmount,
                PriceEpisodeRemainingAmountWithinUpperLimit = episode.PriceEpisodeValues.PriceEpisodeRemainingAmountWithinUpperLimit,
                PriceEpisodeCappedRemainingTNPAmount = episode.PriceEpisodeValues.PriceEpisodeCappedRemainingTNPAmount,
                PriceEpisodeExpectedTotalMonthlyValue = episode.PriceEpisodeValues.PriceEpisodeExpectedTotalMonthlyValue,
                PriceEpisodeAimSeqNumber = episode.PriceEpisodeValues.PriceEpisodeAimSeqNumber,
                PriceEpisodeFirstDisadvantagePayment = episode.PriceEpisodeValues.PriceEpisodeFirstDisadvantagePayment,
                PriceEpisodeSecondDisadvantagePayment = episode.PriceEpisodeValues.PriceEpisodeSecondDisadvantagePayment,
                PriceEpisodeApplic1618FrameworkUpliftBalancing = episode.PriceEpisodeValues.PriceEpisodeApplic1618FrameworkUpliftBalancing,
                PriceEpisodeApplic1618FrameworkUpliftCompletionPayment = episode.PriceEpisodeValues.PriceEpisodeApplic1618FrameworkUpliftCompletionPayment,
                PriceEpisodeApplic1618FrameworkUpliftOnProgPayment = episode.PriceEpisodeValues.PriceEpisodeApplic1618FrameworkUpliftOnProgPayment,
                PriceEpisodeSecondProv1618Pay = episode.PriceEpisodeValues.PriceEpisodeSecondProv1618Pay,
                PriceEpisodeFirstEmp1618Pay = episode.PriceEpisodeValues.PriceEpisodeFirstEmp1618Pay,
                PriceEpisodeSecondEmp1618Pay = episode.PriceEpisodeValues.PriceEpisodeSecondEmp1618Pay,
                PriceEpisodeFirstProv1618Pay = episode.PriceEpisodeValues.PriceEpisodeFirstProv1618Pay,
                PriceEpisodeLSFCash = episode.PriceEpisodeValues.PriceEpisodeLSFCash,
                PriceEpisodeFundLineType = episode.PriceEpisodeValues.PriceEpisodeFundLineType,
                PriceEpisodeSFAContribPct = episode.PriceEpisodeValues.PriceEpisodeSFAContribPct,
                PriceEpisodeLevyNonPayInd = episode.PriceEpisodeValues.PriceEpisodeLevyNonPayInd,
                EpisodeEffectiveTNPStartDate = episode.PriceEpisodeValues.EpisodeEffectiveTNPStartDate,
                PriceEpisodeFirstAdditionalPaymentThresholdDate = episode.PriceEpisodeValues.PriceEpisodeFirstAdditionalPaymentThresholdDate,
                PriceEpisodeSecondAdditionalPaymentThresholdDate = episode.PriceEpisodeValues.PriceEpisodeSecondAdditionalPaymentThresholdDate,
                PriceEpisodeContractType = episode.PriceEpisodeValues.PriceEpisodeContractType,
                PriceEpisodePreviousEarningsSameProvider = episode.PriceEpisodeValues.PriceEpisodePreviousEarningsSameProvider,
                PriceEpisodeTotProgFunding = episode.PriceEpisodeValues.PriceEpisodeTotProgFunding,
                PriceEpisodeProgFundIndMinCoInvest = episode.PriceEpisodeValues.PriceEpisodeProgFundIndMinCoInvest,
                PriceEpisodeProgFundIndMaxEmpCont = episode.PriceEpisodeValues.PriceEpisodeProgFundIndMaxEmpCont,
                PriceEpisodeTotalPMRs = episode.PriceEpisodeValues.PriceEpisodeTotalPMRs,
                PriceEpisodeCumulativePMRs = episode.PriceEpisodeValues.PriceEpisodeCumulativePMRs,
                PriceEpisodeCompExemCode = episode.PriceEpisodeValues.PriceEpisodeCompExemCode,
                PriceEpisodeLearnerAdditionalPaymentThresholdDate = episode.PriceEpisodeValues.PriceEpisodeLearnerAdditionalPaymentThresholdDate,
                PriceEpisodeAgreeId = episode.PriceEpisodeValues.PriceEpisodeAgreeId,
                PriceEpisodeRedStartDate = episode.PriceEpisodeValues.PriceEpisodeRedStartDate,
                PriceEpisodeRedStatusCode = episode.PriceEpisodeValues.PriceEpisodeRedStatusCode
            };
        }
    }
}
