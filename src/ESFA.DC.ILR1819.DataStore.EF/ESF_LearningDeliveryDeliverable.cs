using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR1819.DataStore.EF
{
    public partial class ESF_LearningDeliveryDeliverable
    {
        public ESF_LearningDeliveryDeliverable()
        {
            ESF_LearningDeliveryDeliverable_PeriodisedValues = new HashSet<ESF_LearningDeliveryDeliverable_PeriodisedValue>();
        }

        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int AimSeqNumber { get; set; }
        public string DeliverableCode { get; set; }
        public decimal? DeliverableUnitCost { get; set; }

        public virtual ESF_LearningDelivery ESF_LearningDelivery { get; set; }
        public virtual ICollection<ESF_LearningDeliveryDeliverable_PeriodisedValue> ESF_LearningDeliveryDeliverable_PeriodisedValues { get; set; }
    }
}
