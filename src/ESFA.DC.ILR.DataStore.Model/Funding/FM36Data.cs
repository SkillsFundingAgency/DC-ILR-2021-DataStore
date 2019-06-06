using System.Collections.Generic;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Model.Funding
{
    public class FM36Data
    {
        public ICollection<AEC_global> Globals { get; set; } = new List<AEC_global>();

        public ICollection<AEC_Learner> Learners { get; set; } = new List<AEC_Learner>();

        public ICollection<AEC_LearningDelivery> LearningDeliveries { get; set; } = new List<AEC_LearningDelivery>();

        public ICollection<AEC_LearningDelivery_Period> LearningDeliveryPeriods { get; set; } = new List<AEC_LearningDelivery_Period>();

        public ICollection<AEC_LearningDelivery_PeriodisedValue> LearningDeliveryPeriodisedValues { get; set; } = new List<AEC_LearningDelivery_PeriodisedValue>();

        public ICollection<AEC_LearningDelivery_PeriodisedTextValue> LearningDeliveryPeriodisedTextValues { get; set; } = new List<AEC_LearningDelivery_PeriodisedTextValue>();

        public ICollection<AEC_ApprenticeshipPriceEpisode> ApprenticeshipPriceEpisodes { get; set; } = new List<AEC_ApprenticeshipPriceEpisode>();

        public ICollection<AEC_ApprenticeshipPriceEpisode_Period> ApprenticeshipPriceEpisodePeriods { get; set; } = new List<AEC_ApprenticeshipPriceEpisode_Period>();

        public ICollection<AEC_ApprenticeshipPriceEpisode_PeriodisedValue> ApprenticeshipPriceEpisodePeriodisedValues { get; set; } = new List<AEC_ApprenticeshipPriceEpisode_PeriodisedValue>();
    }
}
