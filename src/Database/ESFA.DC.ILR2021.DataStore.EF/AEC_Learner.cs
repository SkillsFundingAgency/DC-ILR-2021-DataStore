using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF
{
    public partial class AEC_Learner
    {
        public AEC_Learner()
        {
            AEC_ApprenticeshipPriceEpisodes = new HashSet<AEC_ApprenticeshipPriceEpisode>();
            AEC_LearningDeliveries = new HashSet<AEC_LearningDelivery>();
        }

        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public long ULN { get; set; }

        public virtual Learner Learner { get; set; }
        public virtual AEC_global UKPRNNavigation { get; set; }
        public virtual ICollection<AEC_ApprenticeshipPriceEpisode> AEC_ApprenticeshipPriceEpisodes { get; set; }
        public virtual ICollection<AEC_LearningDelivery> AEC_LearningDeliveries { get; set; }
    }
}
