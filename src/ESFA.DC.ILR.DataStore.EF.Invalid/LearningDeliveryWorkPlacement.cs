using System;

namespace ESFA.DC.ILR1920.DataStore.EF.Invalid
{
    public partial class LearningDeliveryWorkPlacement
    {
        public int LearningDeliveryWorkPlacement_Id { get; set; }
        public int? LearningDelivery_Id { get; set; }
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public long? AimSeqNumber { get; set; }
        public DateTime? WorkPlaceStartDate { get; set; }
        public DateTime? WorkPlaceEndDate { get; set; }
        public long? WorkPlaceHours { get; set; }
        public long? WorkPlaceMode { get; set; }
        public long? WorkPlaceEmpId { get; set; }
    }
}
