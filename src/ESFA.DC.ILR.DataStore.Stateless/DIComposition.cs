using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Features.AttributeFilters;
using ESFA.DC.Auditing.Interface;
using ESFA.DC.Data.ILR.ValidationErrors.Model;
using ESFA.DC.Data.ILR.ValidationErrors.Model.Interfaces;
using ESFA.DC.DateTimeProvider.Interface;
using ESFA.DC.FileService;
using ESFA.DC.FileService.Config;
using ESFA.DC.FileService.Config.Interface;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.DataStore.Dto;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.DataStore.Model.File;
using ESFA.DC.ILR.DataStore.Model.Funding;
using ESFA.DC.ILR.DataStore.Model.History;
using ESFA.DC.ILR.DataStore.PersistData;
using ESFA.DC.ILR.DataStore.PersistData.Mapper;
using ESFA.DC.ILR.DataStore.PersistData.Persist;
using ESFA.DC.ILR.DataStore.PersistData.Providers;
using ESFA.DC.ILR.DataStore.Stateless.Configuration;
using ESFA.DC.ILR.DataStore.Stateless.Handlers;
using ESFA.DC.ILR.DataStore.Stateless.Modules;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR.Model;
using ESFA.DC.IO.AzureStorage;
using ESFA.DC.IO.AzureStorage.Config.Interfaces;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.JobContextManager;
using ESFA.DC.JobContextManager.Interface;
using ESFA.DC.JobContextManager.Model;
using ESFA.DC.JobContextManager.Model.Interface;
using ESFA.DC.JobStatus.Interface;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Mapping.Interface;
using ESFA.DC.Queueing;
using ESFA.DC.Queueing.Interface;
using ESFA.DC.Serialization.Interfaces;
using ESFA.DC.Serialization.Json;
using ESFA.DC.Serialization.Xml;
using ESFA.DC.ServiceFabric.Helpers.Interfaces;

namespace ESFA.DC.ILR.DataStore.Stateless
{
    public class DIComposition
    {
        public static ContainerBuilder BuildContainer(IConfigurationHelper configHelper)
        {
            var containerBuilder = new ContainerBuilder();

            // register azure blob storage service
            var azureBlobStorageOptions = configHelper.GetSectionValues<AzureStorageOptions>("AzureStorageSection");
            containerBuilder.Register(c =>
                    new AzureStorageKeyValuePersistenceConfig(
                        azureBlobStorageOptions.AzureBlobConnectionString,
                        azureBlobStorageOptions.AzureBlobContainerName))
                .As<IAzureStorageKeyValuePersistenceServiceConfig>().SingleInstance();

            containerBuilder.Register(c =>
                new AzureStorageFileServiceConfiguration()
                {
                    ConnectionString = azureBlobStorageOptions.AzureBlobConnectionString
                })
                .As<IAzureStorageFileServiceConfiguration>().SingleInstance();

            containerBuilder.RegisterType<AzureStorageFileService>().As<IFileService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<AzureStorageKeyValuePersistenceService>()
                .As<IKeyValuePersistenceService>()
                .InstancePerLifetimeScope();

            // register serialization
            containerBuilder.RegisterType<JsonSerializationService>()
                .As<IJsonSerializationService>();
            containerBuilder.RegisterType<XmlSerializationService>()
                .As<IXmlSerializationService>();

            // get ServiceBus, Azurestorage config values and register container
            var serviceBusOptions =
                configHelper.GetSectionValues<ServiceBusOptions>("ServiceBusSettings");
            containerBuilder.RegisterInstance(serviceBusOptions).As<ServiceBusOptions>().SingleInstance();

            // persis data options
            var persistDataConfig =
                configHelper.GetSectionValues<PersistDataConfiguration>("DataStoreSection");
            containerBuilder.RegisterInstance(persistDataConfig).As<PersistDataConfiguration>().SingleInstance();

            // Version info
            var versionInfo = configHelper.GetSectionValues<VersionInfo>("VersionSection");
            containerBuilder.RegisterInstance(versionInfo).As<VersionInfo>().SingleInstance();

            // register logger
            var loggerOptions =
                configHelper.GetSectionValues<LoggerOptions>("LoggerSection");
            containerBuilder.RegisterInstance(loggerOptions).As<LoggerOptions>().SingleInstance();
            containerBuilder.RegisterModule<LoggerModule>();

            // auditing
            var auditPublishConfig = new ServiceBusQueueConfig(
                serviceBusOptions.ServiceBusConnectionString,
                serviceBusOptions.AuditQueueName,
                Environment.ProcessorCount);
            containerBuilder.Register(c => new QueuePublishService<AuditingDto>(
                    auditPublishConfig,
                    c.Resolve<IJsonSerializationService>()))
                .As<IQueuePublishService<AuditingDto>>();

            // get job status queue config values and register container
            var jobStatusQueueOptions =
                configHelper.GetSectionValues<JobStatusQueueOptions>("JobStatusSection");
            containerBuilder.RegisterInstance(jobStatusQueueOptions).As<JobStatusQueueOptions>().SingleInstance();

            // Job Status Update Service
            var jobStatusPublishConfig = new JobStatusQueueConfig(
                jobStatusQueueOptions.JobStatusConnectionString,
                jobStatusQueueOptions.JobStatusQueueName,
                Environment.ProcessorCount);

            containerBuilder.Register(c => new QueuePublishService<JobStatusDto>(
                    jobStatusPublishConfig,
                    c.Resolve<IJsonSerializationService>()))
                .As<IQueuePublishService<JobStatusDto>>();

            // register Jobcontext services
            var topicConfig = new TopicConfiguration(
                serviceBusOptions.ServiceBusConnectionString,
                serviceBusOptions.TopicName,
                serviceBusOptions.DataStoreSubscriptionName,
                1,
                maximumCallbackTimeSpan: TimeSpan.FromMinutes(30));

            containerBuilder.Register(c =>
            {
                var topicSubscriptionSevice =
                    new TopicSubscriptionSevice<JobContextDto>(
                        topicConfig,
                        c.Resolve<IJsonSerializationService>(),
                        c.Resolve<ILogger>());
                return topicSubscriptionSevice;
            }).As<ITopicSubscriptionService<JobContextDto>>();

            containerBuilder.Register(c =>
            {
                var topicPublishSevice =
                    new TopicPublishService<JobContextDto>(
                        topicConfig,
                        c.Resolve<IJsonSerializationService>());
                return topicPublishSevice;
            }).As<ITopicPublishService<JobContextDto>>();

            containerBuilder.RegisterType<DateTimeProvider.DateTimeProvider>().As<IDateTimeProvider>().SingleInstance();

            // register message mapper
            containerBuilder.RegisterType<DefaultJobContextMessageMapper<JobContextMessage>>().As<IMapper<JobContextMessage, JobContextMessage>>();

            // register MessageHandler
            containerBuilder.RegisterType<MessageHandler>().As<IMessageHandler<JobContextMessage>>().InstancePerLifetimeScope();

            // register Entrypoint
            containerBuilder.RegisterType<EntryPoint>().As<IEntryPoint>()
                .WithAttributeFiltering()
                .InstancePerLifetimeScope();

            // register ValidationError service
            containerBuilder.Register(b => new ValidationErrors(persistDataConfig.IlrValidationErrorsConnectionString))
                .As<IValidationErrors>().InstancePerDependency();

            containerBuilder.RegisterType<JobContextManager<JobContextMessage>>().As<IJobContextManager<JobContextMessage>>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<JobContextMessage>().As<IJobContextMessage>()
                .InstancePerLifetimeScope();

            RegisterMappers(containerBuilder);
            RegisterProviders(containerBuilder);
            RegisterPersistence(containerBuilder);

            return containerBuilder;
        }

        private static void RegisterMappers(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<DataStoreMapper>().As<IDataStoreMapper>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<ValidLearnerDataMapper>().As<IValidLearnerDataMapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<InvalidLearnerDataMapper>().As<IInvalidLearnerDataMapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM81Mapper>().As<IFM81Mapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM70Mapper>().As<IFM70Mapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM36Mapper>().As<IFM36Mapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM35Mapper>().As<IFM35Mapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM25Mapper>().As<IFM25Mapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ALBMapper>().As<IALBMapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM36HistoryMapper>().As<IFM36HistoryMapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ValidHeaderDataMapper>().As<IValidHeaderDataMapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<InvalidHeaderDataMapper>().As<IInvalidHeaderDataMapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ProcessingInformationDataMapper>().As<IProcessingInformationDataMapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ValidationDataMapper>().As<IValidationDataMapper>().InstancePerLifetimeScope();
        }

        private static void RegisterProviders(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<DataStoreDataCacheProvider>().As<IDataStoreDataCacheProvider>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<DataStoreDataProvider>().As<IDataStoreDataProvider>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<ILRProviderService>().As<IProviderService<Message>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ValidLearnerProviderService>().As<IProviderService<List<string>>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ALBProviderService>().As<IProviderService<ALBGlobal>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM25ProviderService>().As<IProviderService<FM25Global>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM35ProviderService>().As<IProviderService<FM35Global>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM36ProviderService>().As<IProviderService<FM36Global>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM70ProviderService>().As<IProviderService<FM70Global>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM81ProviderService>().As<IProviderService<FM81Global>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ValidationErrorsProviderService>().As<IProviderService<List<ILR.IO.Model.Validation.ValidationError>>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<RulesProviderService>().As<IProviderService<List<Rule>>>().InstancePerLifetimeScope();
        }

        private static void RegisterPersistence(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<TransactionController>().As<ITransactionController>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<DataStorePersistenceService>().As<IDataStorePersistenceService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<StoreALB>().As<IStoreService<ALBData>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM25>().As<IStoreService<FM25Data>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM35>().As<IStoreService<FM35Data>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM36>().As<IStoreService<FM36Data>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM70>().As<IStoreService<FM70Data>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM81>().As<IStoreService<FM81Data>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM36History>().As<IStoreService<FM36HistoryData>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreProcessingInformationData>().As<IStoreService<ProcessingInformationData>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreValidHeader>().As<IStoreService<ValidHeaderData>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreInvalidHeader>().As<IStoreService<InvalidHeaderData>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreValidLearnerData>().As<IStoreService<ValidLearnerData>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreInvalidLearnerData>().As<IStoreService<InvalidLearnerData>>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<StoreValidationOutput>().As<IStoreService<ValidationData>>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<StoreClear>().As<IStoreClear>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM36HistoryClear>().As<IStoreFM36HistoryClear>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<BulkInsert>().As<IBulkInsert>().InstancePerDependency();
        }
    }
}