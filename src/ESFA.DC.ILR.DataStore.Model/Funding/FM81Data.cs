using System.Collections.Generic;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Model.Funding
{
    public class FM81Data
    {
        public ICollection<TBL_global> Globals { get; set; } = new List<TBL_global>();

        public ICollection<TBL_Learner> Learners { get; set; } = new List<TBL_Learner>();

        public ICollection<TBL_LearningDelivery> LearningDeliveries { get; set; } = new List<TBL_LearningDelivery>();

        public ICollection<TBL_LearningDelivery_Period> LearningDeliveryPeriods { get; set; } = new List<TBL_LearningDelivery_Period>();

        public ICollection<TBL_LearningDelivery_PeriodisedValue> LearningDeliveryPeriodisedValues { get; set; } = new List<TBL_LearningDelivery_PeriodisedValue>();
    }
}
