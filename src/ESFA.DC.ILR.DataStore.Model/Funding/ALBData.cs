using System.Collections.Generic;
using ESFA.DC.ILR1819.DataStore.EF;

namespace ESFA.DC.ILR1819.DataStore.Model.Funding
{
    public class ALBData
    {
        public ICollection<ALB_global> Globals { get; set; } = new List<ALB_global>();

        public ICollection<ALB_Learner> Learners { get; set; } = new List<ALB_Learner>();

        public ICollection<ALB_Learner_Period> LearnerPeriods { get; set; } = new List<ALB_Learner_Period>();

        public ICollection<ALB_Learner_PeriodisedValue> LearnerPeriodisedValues { get; set; } = new List<ALB_Learner_PeriodisedValue>();

        public ICollection<ALB_LearningDelivery> LearningDeliveries { get; set; } = new List<ALB_LearningDelivery>();

        public ICollection<ALB_LearningDelivery_Period> LearningDeliveryPeriods { get; set; } = new List<ALB_LearningDelivery_Period>();

        public ICollection<ALB_LearningDelivery_PeriodisedValue> LearningDeliveryPeriodisedValues { get; set; } = new List<ALB_LearningDelivery_PeriodisedValue>();
    }
}
