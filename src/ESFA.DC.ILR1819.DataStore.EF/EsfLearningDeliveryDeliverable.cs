﻿using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF
{
    public partial class EsfLearningDeliveryDeliverable
    {
        public EsfLearningDeliveryDeliverable()
        {
            EsfLearningDeliveryDeliverablePeriodisedValues = new HashSet<EsfLearningDeliveryDeliverablePeriodisedValue>();
        }

        public int Ukprn { get; set; }
        public string LearnRefNumber { get; set; }
        public int AimSeqNumber { get; set; }
        public string DeliverableCode { get; set; }
        public decimal? DeliverableUnitCost { get; set; }

        public virtual EsfLearningDelivery EsfLearningDelivery { get; set; }
        public virtual ICollection<EsfLearningDeliveryDeliverablePeriodisedValue> EsfLearningDeliveryDeliverablePeriodisedValues { get; set; }
    }
}
