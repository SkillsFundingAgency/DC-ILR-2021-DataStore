using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Invalid
{
    public partial class AppFinRecord
    {
        public int AppFinRecordId { get; set; }
        public int Ukprn { get; set; }
        public int? LearningDeliveryId { get; set; }
        public string LearnRefNumber { get; set; }
        public long AimSeqNumber { get; set; }
        public string AfinType { get; set; }
        public long? AfinCode { get; set; }
        public DateTime? AfinDate { get; set; }
        public long? AfinAmount { get; set; }
    }
}
