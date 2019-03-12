using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF.Invalid
{
    public partial class ProviderSpecDeliveryMonitoring
    {
        public int ProviderSpecDeliveryMonitoring_Id { get; set; }
        public int UKPRN { get; set; }
        public int? LearningDelivery_Id { get; set; }
        public string LearnRefNumber { get; set; }
        public long? AimSeqNumber { get; set; }
        public string ProvSpecDelMonOccur { get; set; }
        public string ProvSpecDelMon { get; set; }
    }
}
