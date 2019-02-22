using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Invalid
{
    public partial class LearningDeliveryWorkPlacement
    {
        public int LearningDeliveryWorkPlacementId { get; set; }
        public int? LearningDeliveryId { get; set; }
        public int Ukprn { get; set; }
        public string LearnRefNumber { get; set; }
        public long? AimSeqNumber { get; set; }
        public DateTime? WorkPlaceStartDate { get; set; }
        public DateTime? WorkPlaceEndDate { get; set; }
        public long? WorkPlaceHours { get; set; }
        public long? WorkPlaceMode { get; set; }
        public long? WorkPlaceEmpId { get; set; }
    }
}
