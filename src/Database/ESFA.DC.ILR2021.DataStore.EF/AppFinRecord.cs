using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR2021.DataStore.EF
{
    public partial class AppFinRecord
    {
        public int AppFinRecord_Id { get; set; }
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int AimSeqNumber { get; set; }
        public string AFinType { get; set; }
        public int AFinCode { get; set; }
        public DateTime AFinDate { get; set; }
        public int AFinAmount { get; set; }

        public virtual LearningDelivery LearningDelivery { get; set; }
    }
}
