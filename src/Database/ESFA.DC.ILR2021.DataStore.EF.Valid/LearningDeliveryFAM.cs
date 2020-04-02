using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF.Valid
{
    public partial class LearningDeliveryFAM
    {
        public int LearningDeliveryFAM_Id { get; set; }
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int AimSeqNumber { get; set; }
        public string LearnDelFAMType { get; set; }
        public string LearnDelFAMCode { get; set; }
        public DateTime? LearnDelFAMDateFrom { get; set; }
        public DateTime? LearnDelFAMDateTo { get; set; }

        public virtual LearningDelivery LearningDelivery { get; set; }
    }
}
