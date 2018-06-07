using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Autofac.Features.AttributeFilters;
using Autofac.Integration.ServiceFabric;
using DC.JobContextManager;
using DC.JobContextManager.Interface;
using ESFA.DC.Auditing;
using ESFA.DC.Auditing.Dto;
using ESFA.DC.Auditing.Interface;
using ESFA.DC.ILR.ValidationErrors;
using ESFA.DC.ILR.ValidationErrors.Interface;
using ESFA.DC.ILR1819.DataStore.Dto;
using ESFA.DC.ILR1819.DataStore.PersistData;
using ESFA.DC.ILR1819.DataStore.Stateless.Configuration;
using ESFA.DC.ILR1819.DataStore.Stateless.Handlers;
using ESFA.DC.ILR1819.DataStore.Stateless.Mappers;
using ESFA.DC.ILR1819.DataStore.Stateless.Modules;
using ESFA.DC.IO.AzureStorage;
using ESFA.DC.IO.AzureStorage.Config.Interfaces;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.IO.Redis;
using ESFA.DC.IO.Redis.Config.Interfaces;
using ESFA.DC.JobContext;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Mapping.Interface;
using ESFA.DC.Queueing;
using ESFA.DC.Queueing.Interface;
using ESFA.DC.Serialization.Interfaces;
using ESFA.DC.Serialization.Json;
using ESFA.DC.Serialization.Xml;
using ESFA.DC.ServiceFabric.Helpers;

namespace ESFA.DC.ILR1819.DataStore.Stateless
{
    internal static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            try
            {
                var builder = BuildContainer();

                // Register the Autofac magic for Service Fabric support.
                builder.RegisterServiceFabricSupport();

                // Register the stateless service.
                builder.RegisterStatelessService<Stateless>("ESFA.DC.ILR1819.DataStore.StatelessType");

                using (var container = builder.Build())
                {
                    ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(Stateless).Name);

                    // Prevents this host process from terminating so services keep running.
                    Thread.Sleep(Timeout.Infinite);
                }
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
                throw;
            }
        }

        private static ContainerBuilder BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            // get ServiceBus, Azurestorage config values and register container
            var configHelper = new ConfigurationHelper();

            // register Cosmos config
            var azureRedisOptions = configHelper.GetSectionValues<RedisOptions>("RedisSection");
            containerBuilder.Register(c => new RedisKeyValuePersistenceConfig(
                    azureRedisOptions.RedisConnectionString))
                .As<IRedisKeyValuePersistenceServiceConfig>().SingleInstance();

            containerBuilder.RegisterType<RedisKeyValuePersistenceService>()
                .Keyed<IKeyValuePersistenceService>(PersistenceStorageKeys.Redis)
                .InstancePerLifetimeScope();

            // register azure blob storage service
            var azureBlobStorageOptions = configHelper.GetSectionValues<AzureStorageOptions>("AzureStorageSection");
            containerBuilder.Register(c =>
                    new AzureStorageKeyValuePersistenceConfig(
                        azureBlobStorageOptions.AzureBlobConnectionString,
                        azureBlobStorageOptions.AzureContainerReference))
                .As<IAzureStorageKeyValuePersistenceServiceConfig>().SingleInstance();

            containerBuilder.RegisterType<AzureStorageKeyValuePersistenceService>()
                .Keyed<IKeyValuePersistenceService>(PersistenceStorageKeys.Blob)
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
            containerBuilder.RegisterType<Auditor>().As<IAuditor>();

            // register Jobcontext services
            var topicConfig = new ServiceBusTopicConfig(
                serviceBusOptions.ServiceBusConnectionString,
                serviceBusOptions.TopicName,
                serviceBusOptions.DataStoreSubscriptionName,
                Environment.ProcessorCount);

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

            // register message mapper
            containerBuilder.RegisterType<JobContextMessageMapper>()
                .As<IMapper<JobContextMessage, JobContextMessage>>();

            // register MessageHandler
            containerBuilder.RegisterType<MessageHandler>().As<IMessageHandler>().InstancePerLifetimeScope();

            // register the  callback handle when a new message is received from ServiceBus
            containerBuilder.Register<Func<JobContextMessage, CancellationToken, Task<bool>>>(c =>
                c.Resolve<IMessageHandler>().Handle).InstancePerLifetimeScope();

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

            containerBuilder.RegisterType<JobContextManagerForTopics<JobContextMessage>>().As<IJobContextManager>()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<JobContextMessage>().As<IJobContextMessage>()
                .InstancePerLifetimeScope();

            return containerBuilder;
        }
    }
}
