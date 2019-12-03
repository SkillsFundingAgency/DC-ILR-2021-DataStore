using Autofac;
using ESFA.DC.FileService.Config;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.Datastore.Modules;
using ESFA.DC.ILR.DataStore.PersistData.Mapper;
using ESFA.DC.ILR.DataStore.PersistData.Transactions;
using ESFA.DC.ILR.DataStore.Stateless.Configuration;
using ESFA.DC.ILR.DataStore.Stateless.Context;
using ESFA.DC.ILR.DataStore.Stateless.Handlers;
using ESFA.DC.ILR.DataStore.Stateless.Modules;
using ESFA.DC.JobContextManager.Interface;
using ESFA.DC.JobContextManager.Model;
using ESFA.DC.JobContextManager.Model.Interface;
using ESFA.DC.ServiceFabric.Common.Config.Interface;
using ESFA.DC.ServiceFabric.Common.Modules;
using ESFA.DC.Telemetry;
using ESFA.DC.Telemetry.Interfaces;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using TelemetryConfiguration = ESFA.DC.ILR.DataStore.Stateless.Configuration.TelemetryConfiguration;

namespace ESFA.DC.ILR.DataStore.Stateless
{
    public class DIComposition
    {
        public static ContainerBuilder BuildContainer(IServiceFabricConfigurationService serviceFabricConfigurationService)
        {
            var containerBuilder = new ContainerBuilder();

            var statelessServiceConfiguration = serviceFabricConfigurationService.GetConfigSectionAsStatelessServiceConfiguration();

            var persistDataConfig = serviceFabricConfigurationService.GetConfigSectionAs<PersistDataConfiguration>("DataStoreSection");
            containerBuilder.RegisterInstance(persistDataConfig).As<PersistDataConfiguration>();

            var telemetryConfig = serviceFabricConfigurationService.GetConfigSectionAs<TelemetryConfiguration>("TelemetrySection");

            containerBuilder.RegisterInstance(telemetryConfig).As<TelemetryConfiguration>();

            var versionInfo = serviceFabricConfigurationService.GetConfigSectionAs<VersionInfo>("VersionSection");
            containerBuilder.RegisterInstance(versionInfo).As<VersionInfo>();

            var ioConfiguration = serviceFabricConfigurationService.GetConfigSectionAs<IOConfiguration>("IOConfiguration");
            var azureFileServiceConfiguration = new AzureStorageFileServiceConfiguration() { ConnectionString = ioConfiguration.ConnectionString };

            containerBuilder.RegisterModule(new IOModule(azureFileServiceConfiguration, ioConfiguration));

            containerBuilder.RegisterType<JobContextMessageDataStoreFactory>().As<IDataStoreContextFactory<IJobContextMessage>>();

            containerBuilder.RegisterModule(new StatelessServiceModule(statelessServiceConfiguration));
            containerBuilder.RegisterModule<SerializationModule>();

            containerBuilder.RegisterType<MessageHandler>().As<IMessageHandler<JobContextMessage>>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<FM36HistoryMapper>().As<IFM36HistoryMapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM36HistoryTransaction>().As<IFM36HistoryTransaction>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<ESFFundingMapper>().As<IESFFundingMapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ESFFundingTransaction>().As<IESFFundingTransaction>().InstancePerLifetimeScope();

            containerBuilder.RegisterModule<DataStoreServicesModule>();
            containerBuilder.RegisterModule<MappersModule>();
            containerBuilder.RegisterModule<ProvidersModule>();
            containerBuilder.RegisterModule<PersistenceModule>();

            containerBuilder.Register((c, p) =>
            {
                return new TelemetryClient() { InstrumentationKey = telemetryConfig.InstrumentationKey };
            })
                .As<TelemetryClient>()
                .SingleInstance();

            containerBuilder.RegisterType<ApplicationInsightsTelemetry>()
                .As<ITelemetry>()
                .InstancePerLifetimeScope();

            return containerBuilder;
        }
    }
}