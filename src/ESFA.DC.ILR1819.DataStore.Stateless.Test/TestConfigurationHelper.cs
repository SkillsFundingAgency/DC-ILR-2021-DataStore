using ESFA.DC.ILR1819.DataStore.Dto;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Stateless.Configuration;
using ESFA.DC.ServiceFabric.Helpers.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.Stateless.Test
{
    public sealed class TestConfigurationHelper : IConfigurationHelper
    {
        public T GetSectionValues<T>(string sectionName)
        {
            switch (sectionName)
            {
                case "DataStoreSection":
                    return (T)(object)new PersistDataConfiguration()
                    {
                        ILRDataStoreConnectionString = "Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;",
                        AppEarnHistoryDataStoreConnectionString = "Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;"
                    };
                case "RedisSection":
                    return (T)(object)new RedisOptions();
                case "TopicAndTaskSection":
                    return (T)GetTopicsAndTasks();
                case "AzureStorageSection":
                    return (T)(object)new AzureStorageOptions()
                    {
                        AzureBlobConnectionString = "AzureBlobConnectionString",
                        AzureBlobContainerName = "AzureBlobContainerName"
                    };
                case "ServiceBusSettings":
                    return (T)(object)new ServiceBusOptions()
                    {
                        AuditQueueName = "AuditQueueName",
                        ServiceBusConnectionString = "ServiceBusConnectionString",
                        TopicName = "TopicName",
                        DataStoreSubscriptionName = "DataStore"
                    };
                case "VersionSection":
                    return (T)(object)new VersionInfo()
                    {
                        ServiceReleaseVersion = "ServiceReleaseVersion"
                    };
                case "LoggerSection":
                    return (T)(object)new LoggerOptions
                    {
                        LoggerConnectionstring = "Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;"
                    };
                case "JobStatusSection":
                    return (T)(object)new JobStatusQueueOptions();
            }

            return default(T);
        }

        public static ITopicAndTaskSectionOptions GetTopicsAndTasks()
        {
            return new TopicAndTaskSectionOptions()
            {
                TopicReports_TaskGenerateAllbOccupancyReport = "TopicReports_TaskGenerateAllbOccupancyReport",
                TopicReports_TaskGenerateValidationReport = "TopicReports_TaskGenerateValidationReport",
                TopicReports_TaskGenerateFundingSummaryReport = "TopicReports_TaskGenerateFundingSummaryReport",
                TopicDeds = "TopicDeds",
                TopicDeds_TaskPersistDataToDeds = "TopicDeds_TaskPersistDataToDeds",
                TopicFunding = "TopicFunding",
                TopicReports = "TopicReports",
                TopicReports_TaskGenerateMainOccupancyReport = "TopicReports_TaskGenerateMainOccupancyReport",
                TopicReports_TaskGenerateSummaryOfFunding1619Report = "TopicReports_TaskGenerateSummaryOfFunding1619Report",
                TopicValidation = "TopicValidation",
                TopicReports_TaskGenerateMathsAndEnglishReport = "TopicReports_TaskGenerateMathsAndEnglishReport"
            };
        }
    }
}
