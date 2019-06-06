using System.Collections.Generic;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Model.Funding
{
    public class FM70Data
    {
        public ICollection<ESF_global> Globals { get; set; } = new List<ESF_global>();

        public ICollection<ESF_Learner> Learners { get; set; } = new List<ESF_Learner>();

        public ICollection<ESF_DPOutcome> DPOutcomes { get; set; } = new List<ESF_DPOutcome>();

        public ICollection<ESF_LearningDelivery> LearningDeliveries { get; set; } = new List<ESF_LearningDelivery>();

        public ICollection<ESF_LearningDeliveryDeliverable> LearningDeliveryDeliverables { get; set; } = new List<ESF_LearningDeliveryDeliverable>();

        public ICollection<ESF_LearningDeliveryDeliverable_Period> LearningDeliveryDeliverablePeriods { get; set; } = new List<ESF_LearningDeliveryDeliverable_Period>();

        public ICollection<ESF_LearningDeliveryDeliverable_PeriodisedValue> LearningDeliveryDeliverablePeriodisedValues { get; set; } = new List<ESF_LearningDeliveryDeliverable_PeriodisedValue>();
    }
}
