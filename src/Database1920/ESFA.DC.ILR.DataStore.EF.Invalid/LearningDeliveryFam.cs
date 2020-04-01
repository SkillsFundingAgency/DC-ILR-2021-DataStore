using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF.Invalid
{
    public partial class LearningDeliveryFAM
    {
        public int LearningDeliveryFAM_Id { get; set; }
        public int? LearningDelivery_Id { get; set; }
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public long? AimSeqNumber { get; set; }
        public string LearnDelFAMType { get; set; }
        public string LearnDelFAMCode { get; set; }
        public DateTime? LearnDelFAMDateFrom { get; set; }
        public DateTime? LearnDelFAMDateTo { get; set; }
    }
}
