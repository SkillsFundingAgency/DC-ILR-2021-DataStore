﻿using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Features.AttributeFilters;
using ESFA.DC.Auditing.Interface;
using ESFA.DC.DateTimeProvider.Interface;
using ESFA.DC.ILR.ValidationErrors;
using ESFA.DC.ILR.ValidationErrors.Interface;
using ESFA.DC.ILR1819.DataStore.Dto;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData;
using ESFA.DC.ILR1819.DataStore.PersistData.Builders;
using ESFA.DC.ILR1819.DataStore.PersistData.Services;
using ESFA.DC.ILR1819.DataStore.PersistData.Services.ModelServices;
using ESFA.DC.ILR1819.DataStore.PersistData.Services.Providers;
using ESFA.DC.ILR1819.DataStore.Stateless.Configuration;
using ESFA.DC.ILR1819.DataStore.Stateless.Handlers;
using ESFA.DC.ILR1819.DataStore.Stateless.Modules;
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

namespace ESFA.DC.ILR1819.DataStore.Stateless
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

            containerBuilder.RegisterType<AzureStorageKeyValuePersistenceService>()
                .Keyed<IKeyValuePersistenceService>(PersistenceStorageKeys.Blob)
                .Keyed<IKeyValuePersistenceService>(PersistenceStorageKeys.Redis)
                .As<IStreamableKeyValuePersistenceService>()
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
            containerBuilder.RegisterType<EntryPoint>()
                .WithAttributeFiltering()
                .InstancePerLifetimeScope();

            // register ValidationError service
            containerBuilder.Register(c => new ValidationErrorsService(
                c.ResolveKeyed<IKeyValuePersistenceService>(PersistenceStorageKeys.Blob),
                c.Resolve<IJsonSerializationService>(),
                c.Resolve<ILogger>())).As<IValidationErrorsService>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<JobContextManager<JobContextMessage>>().As<IJobContextManager<JobContextMessage>>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<JobContextMessage>().As<IJobContextMessage>()
                .InstancePerLifetimeScope();

            RegisterBuilders(containerBuilder);
            RegisterServices(containerBuilder);

            return containerBuilder;
        }

        private static void RegisterBuilders(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<LearnerValidDataBuilder>().As<ILearnerValidDataBuilder>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<LearnerInvalidDataBuilder>().As<ILearnerInvalidDataBuilder>()
                .InstancePerLifetimeScope();
        }

        private static void RegisterServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<StoreRuleAlb>().As<IStoreRuleAlb>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<StoreFM25>().As<IStoreFM25>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<StoreFM35>().As<IStoreFM35>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<StoreFM36>().As<IStoreFM36>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<StoreFM70>().As<IStoreFM70>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<StoreFM81>().As<IStoreFM81>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<TransactionController>().As<ITransactionController>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<ILRProviderService>().As<IILRProviderService>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<ValidLearnerProviderService>().As<IValidLearnerProviderService>()
                .WithAttributeFiltering()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<ALBProviderService>().As<IALBProviderService>()
                .WithAttributeFiltering()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<FM25ProviderService>().As<IFM25ProviderService>()
                .WithAttributeFiltering()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<FM35ProviderService>().As<IFM35ProviderService>()
                .WithAttributeFiltering()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<FM36ProviderService>().As<IFM36ProviderService>()
                .WithAttributeFiltering()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<FM70ProviderService>().As<IFM70ProviderService>()
                .WithAttributeFiltering()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<FM81ProviderService>().As<IFM81ProviderService>()
                .WithAttributeFiltering()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<ALBService>().As<IModelService>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<FM25Service>().As<IModelService>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<FM35Service>().As<IModelService>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<FM36Service>().As<IModelService>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<FM70Service>().As<IModelService>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<StoreFileDetails>().As<IStoreFileDetails>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<StoreIlr>().As<IStoreIlr>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<StoreValidationOutput>().As<IStoreValidationOutput>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<StoreClear>().As<IStoreClear>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<FM81Service>().As<IModelService>()
                .InstancePerLifetimeScope();

            containerBuilder.Register(c => new List<IModelService>(c.Resolve<IEnumerable<IModelService>>()))
                .As<IList<IModelService>>();
        }
    }
}