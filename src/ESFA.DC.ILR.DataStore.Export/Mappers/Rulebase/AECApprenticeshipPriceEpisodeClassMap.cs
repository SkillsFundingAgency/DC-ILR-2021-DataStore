using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class AECApprenticeshipPriceEpisodeClassMap : ClassMap<AEC_ApprenticeshipPriceEpisode>
    {
        public AECApprenticeshipPriceEpisodeClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.PriceEpisodeIdentifier);
            Map(m => m.TNP4);
            Map(m => m.TNP1);
            Map(m => m.EpisodeStartDate);
            Map(m => m.TNP2);
            Map(m => m.TNP3);
            Map(m => m.PriceEpisode1618FrameworkUpliftRemainingAmount);
            Map(m => m.PriceEpisode1618FrameworkUpliftTotPrevEarnings);
            Map(m => m.PriceEpisode1618FUBalValue);
            Map(m => m.PriceEpisode1618FUMonthInstValue);
            Map(m => m.PriceEpisode1618FUTotEarnings);
            Map(m => m.PriceEpisodeUpperBandLimit);
            Map(m => m.PriceEpisodePlannedEndDate);
            Map(m => m.PriceEpisodeActualEndDate);
            Map(m => m.PriceEpisodeActualEndDateIncEPA);
            Map(m => m.PriceEpisodeTotalTNPPrice);
            Map(m => m.PriceEpisodeUpperLimitAdjustment);
            Map(m => m.PriceEpisodePlannedInstalments);
            Map(m => m.PriceEpisodeActualInstalments);
            Map(m => m.PriceEpisodeCompletionElement);
            Map(m => m.PriceEpisodePreviousEarnings);
            Map(m => m.PriceEpisodeInstalmentValue);
            Map(m => m.PriceEpisodeTotalEarnings);
            Map(m => m.PriceEpisodeCompleted);
            Map(m => m.PriceEpisodeRemainingTNPAmount);
            Map(m => m.PriceEpisodeRemainingAmountWithinUpperLimit);
            Map(m => m.PriceEpisodeCappedRemainingTNPAmount);
            Map(m => m.PriceEpisodeExpectedTotalMonthlyValue);
            Map(m => m.PriceEpisodeAimSeqNumber);
            Map(m => m.PriceEpisodeApplic1618FrameworkUpliftCompElement);
            Map(m => m.PriceEpisodeFundLineType);
            Map(m => m.EpisodeEffectiveTNPStartDate);
            Map(m => m.PriceEpisodeFirstAdditionalPaymentThresholdDate);
            Map(m => m.PriceEpisodeSecondAdditionalPaymentThresholdDate);
            Map(m => m.PriceEpisodeContractType);
            Map(m => m.PriceEpisodePreviousEarningsSameProvider);
            Map(m => m.PriceEpisodeTotalPMRs);
            Map(m => m.PriceEpisodeCumulativePMRs);
            Map(m => m.PriceEpisodeCompExemCode);
            Map(m => m.PriceEpisodeLearnerAdditionalPaymentThresholdDate);
            Map(m => m.PriceEpisodeAgreeId);
            Map(m => m.PriceEpisodeRedStartDate);
            Map(m => m.PriceEpisodeRedStatusCode);
        }
    }
}
