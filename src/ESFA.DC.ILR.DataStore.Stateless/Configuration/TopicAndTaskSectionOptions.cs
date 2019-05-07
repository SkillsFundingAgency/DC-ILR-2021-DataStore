using ESFA.DC.ILR.DataStore.Interface;

namespace ESFA.DC.ILR1819.DataStore.Stateless.Configuration
{
    public sealed class TopicAndTaskSectionOptions : ITopicAndTaskSectionOptions
    {
        public string TopicValidation { get; set; }

        public string TopicFunding { get; set; }

        public string TopicDeds { get; set; }

        public string TopicReports { get; set; }

        public string TopicReports_TaskGenerateValidationReport { get; set; }

        public string TopicReports_TaskGenerateAllbOccupancyReport { get; set; }

        public string TopicReports_TaskGenerateFundingSummaryReport { get; set; }

        public string TopicDeds_TaskPersistDataToDeds { get; set; }

        public string TopicReports_TaskGenerateMainOccupancyReport { get; set; }

        public string TopicReports_TaskGenerateSummaryOfFunding1619Report { get; set; }

        public string TopicReports_TaskGenerateMathsAndEnglishReport { get; set; }
    }
}
