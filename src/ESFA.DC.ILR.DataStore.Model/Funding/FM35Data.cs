using System.Collections.Generic;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Model.Funding
{
    public class FM35Data
    {
        public ICollection<FM35_global> Globals { get; set; } = new List<FM35_global>();

        public ICollection<FM35_Learner> Learners { get; set; } = new List<FM35_Learner>();

        public ICollection<FM35_LearningDelivery> LearningDeliveries { get; set; } = new List<FM35_LearningDelivery>();

        public ICollection<FM35_LearningDelivery_Period> LearningDeliveryPeriods { get; set; } = new List<FM35_LearningDelivery_Period>();

        public ICollection<FM35_LearningDelivery_PeriodisedValue> LearningDeliveryPeriodisedValues { get; set; } = new List<FM35_LearningDelivery_PeriodisedValue>();
    }
}
