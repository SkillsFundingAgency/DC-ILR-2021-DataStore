using System.Collections.Generic;
using ESFA.DC.ILR1819.DataStore.EF;

namespace ESFA.DC.ILR1819.DataStore.Model
{
    public class FM25Data
    {
        public ICollection<FM25_global> Globals { get; set; } = new List<FM25_global>();

        public ICollection<FM25_Learner> Learners { get; set; } = new List<FM25_Learner>();

        public ICollection<FM25_FM35_global> Fm25Fm35Globals { get; set; } = new List<FM25_FM35_global>();

        public ICollection<FM25_FM35_Learner_Period> Fm25Fm35LearnerPeriods { get; set; } = new List<FM25_FM35_Learner_Period>();

        public ICollection<FM25_FM35_Learner_PeriodisedValues> Fm25Fm35LearnerPeriodisedValues { get; set; } = new List<FM25_FM35_Learner_PeriodisedValues>();
    }
}
