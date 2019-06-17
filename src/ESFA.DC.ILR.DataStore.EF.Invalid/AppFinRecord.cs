using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1920.DataStore.EF.Invalid
{
    public partial class AppFinRecord
    {
        public int AppFinRecord_Id { get; set; }
        public int UKPRN { get; set; }
        public int? LearningDelivery_Id { get; set; }
        public string LearnRefNumber { get; set; }
        public long AimSeqNumber { get; set; }
        public string AFinType { get; set; }
        public long? AFinCode { get; set; }
        public DateTime? AFinDate { get; set; }
        public long? AFinAmount { get; set; }
    }
}
