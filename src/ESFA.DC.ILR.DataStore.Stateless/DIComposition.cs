using Autofac;
using ESFA.DC.FileService.Config;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.Datastore.Modules;
using ESFA.DC.ILR.DataStore.PersistData;
using ESFA.DC.ILR.DataStore.Stateless.Configuration;
using ESFA.DC.ILR.DataStore.Stateless.Context;
using ESFA.DC.ILR.DataStore.Stateless.Handlers;
using ESFA.DC.ILR.DataStore.Stateless.Modules;
using ESFA.DC.JobContextManager.Interface;
using ESFA.DC.JobContextManager.Model;
using ESFA.DC.JobContextManager.Model.Interface;
using ESFA.DC.ServiceFabric.Common.Config.Interface;
using ESFA.DC.ServiceFabric.Common.Modules;

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

            var versionInfo = serviceFabricConfigurationService.GetConfigSectionAs<VersionInfo>("VersionSection");
            containerBuilder.RegisterInstance(versionInfo).As<VersionInfo>();

            var ioConfiguration = serviceFabricConfigurationService.GetConfigSectionAs<IOConfiguration>("IOConfiguration");
            var azureFileServiceConfiguration = new AzureStorageFileServiceConfiguration() { ConnectionString = ioConfiguration.ConnectionString };

            containerBuilder.RegisterModule(new IOModule(azureFileServiceConfiguration, ioConfiguration));

            containerBuilder.RegisterType<JobContextMessageDataStoreFactory>().As<IDataStoreContextFactory<IJobContextMessage>>();

            containerBuilder.RegisterModule(new StatelessServiceModule(statelessServiceConfiguration));
            containerBuilder.RegisterModule<SerializationModule>();

            containerBuilder.RegisterType<MessageHandler>().As<IMessageHandler<JobContextMessage>>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<FM36HistoryTransactionController>().As<IFM36HistoryTransactionController>().InstancePerLifetimeScope();

            containerBuilder.RegisterModule<DataStoreServicesModule>();
            containerBuilder.RegisterModule<MappersModule>();
            containerBuilder.RegisterModule<ProvidersModule>();
            containerBuilder.RegisterModule<PersistenceModule>();

            return containerBuilder;
        }
    }
}