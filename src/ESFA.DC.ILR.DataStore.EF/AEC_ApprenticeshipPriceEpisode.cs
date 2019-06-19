using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class AEC_ApprenticeshipPriceEpisode
    {
        public AEC_ApprenticeshipPriceEpisode()
        {
            AEC_ApprenticeshipPriceEpisode_PeriodisedValues = new HashSet<AEC_ApprenticeshipPriceEpisode_PeriodisedValue>();
            AEC_ApprenticeshipPriceEpisode_Periods = new HashSet<AEC_ApprenticeshipPriceEpisode_Period>();
        }

        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public string PriceEpisodeIdentifier { get; set; }
        public decimal? TNP4 { get; set; }
        public decimal? TNP1 { get; set; }
        public DateTime? EpisodeStartDate { get; set; }
        public decimal? TNP2 { get; set; }
        public decimal? TNP3 { get; set; }
        public decimal? PriceEpisode1618FrameworkUpliftRemainingAmount { get; set; }
        public decimal? PriceEpisode1618FrameworkUpliftTotPrevEarnings { get; set; }
        public decimal? PriceEpisode1618FUBalValue { get; set; }
        public decimal? PriceEpisode1618FUMonthInstValue { get; set; }
        public decimal? PriceEpisode1618FUTotEarnings { get; set; }
        public decimal? PriceEpisodeUpperBandLimit { get; set; }
        public DateTime? PriceEpisodePlannedEndDate { get; set; }
        public DateTime? PriceEpisodeActualEndDate { get; set; }
        public DateTime? PriceEpisodeActualEndDateIncEPA { get; set; }
        public decimal? PriceEpisodeTotalTNPPrice { get; set; }
        public decimal? PriceEpisodeUpperLimitAdjustment { get; set; }
        public int? PriceEpisodePlannedInstalments { get; set; }
        public int? PriceEpisodeActualInstalments { get; set; }
        public decimal? PriceEpisodeCompletionElement { get; set; }
        public decimal? PriceEpisodePreviousEarnings { get; set; }
        public decimal? PriceEpisodeInstalmentValue { get; set; }
        public decimal? PriceEpisodeTotalEarnings { get; set; }
        public bool? PriceEpisodeCompleted { get; set; }
        public decimal? PriceEpisodeRemainingTNPAmount { get; set; }
        public decimal? PriceEpisodeRemainingAmountWithinUpperLimit { get; set; }
        public decimal? PriceEpisodeCappedRemainingTNPAmount { get; set; }
        public decimal? PriceEpisodeExpectedTotalMonthlyValue { get; set; }
        public int? PriceEpisodeAimSeqNumber { get; set; }
        public decimal? PriceEpisodeApplic1618FrameworkUpliftCompElement { get; set; }
        public string PriceEpisodeFundLineType { get; set; }
        public DateTime? EpisodeEffectiveTNPStartDate { get; set; }
        public DateTime? PriceEpisodeFirstAdditionalPaymentThresholdDate { get; set; }
        public DateTime? PriceEpisodeSecondAdditionalPaymentThresholdDate { get; set; }
        public string PriceEpisodeContractType { get; set; }
        public decimal? PriceEpisodePreviousEarningsSameProvider { get; set; }
        public decimal? PriceEpisodeTotalPMRs { get; set; }
        public decimal? PriceEpisodeCumulativePMRs { get; set; }
        public int? PriceEpisodeCompExemCode { get; set; }
        public DateTime? PriceEpisodeLearnerAdditionalPaymentThresholdDate { get; set; }
        public string PriceEpisodeAgreeId { get; set; }
        public DateTime? PriceEpisodeRedStartDate { get; set; }
        public int? PriceEpisodeRedStatusCode { get; set; }

        public virtual AEC_Learner AEC_Learner { get; set; }
        public virtual ICollection<AEC_ApprenticeshipPriceEpisode_PeriodisedValue> AEC_ApprenticeshipPriceEpisode_PeriodisedValues { get; set; }
        public virtual ICollection<AEC_ApprenticeshipPriceEpisode_Period> AEC_ApprenticeshipPriceEpisode_Periods { get; set; }
    }
}
