using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF
{
    public partial class ESF_LearningDelivery
    {
        public ESF_LearningDelivery()
        {
            ESF_LearningDeliveryDeliverable_Periods = new HashSet<ESF_LearningDeliveryDeliverable_Period>();
            ESF_LearningDeliveryDeliverables = new HashSet<ESF_LearningDeliveryDeliverable>();
        }

        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int AimSeqNumber { get; set; }
        public bool? Achieved { get; set; }
        public bool? AddProgCostElig { get; set; }
        public decimal? AdjustedAreaCostFactor { get; set; }
        public decimal? AdjustedPremiumFactor { get; set; }
        public DateTime? AdjustedStartDate { get; set; }
        public string AimClassification { get; set; }
        public decimal? AimValue { get; set; }
        public decimal? ApplicWeightFundRate { get; set; }
        public long? EligibleProgressionOutcomeCode { get; set; }
        public string EligibleProgressionOutcomeType { get; set; }
        public DateTime? EligibleProgressionOutomeStartDate { get; set; }
        public bool? FundStart { get; set; }
        public decimal? LARSWeightedRate { get; set; }
        public DateTime? LatestPossibleStartDate { get; set; }
        public DateTime? LDESFEngagementStartDate { get; set; }
        public bool? LearnDelLearnerEmpAtStart { get; set; }
        public bool? PotentiallyEligibleForProgression { get; set; }
        public DateTime? ProgressionEndDate { get; set; }
        public bool? Restart { get; set; }
        public decimal? WeightedRateFromESOL { get; set; }

        public virtual ESF_Learner ESF_Learner { get; set; }
        public virtual ICollection<ESF_LearningDeliveryDeliverable_Period> ESF_LearningDeliveryDeliverable_Periods { get; set; }
        public virtual ICollection<ESF_LearningDeliveryDeliverable> ESF_LearningDeliveryDeliverables { get; set; }
    }
}
