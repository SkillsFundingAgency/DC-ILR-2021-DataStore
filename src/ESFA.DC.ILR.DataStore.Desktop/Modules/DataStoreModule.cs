using Autofac;
using ESFA.DC.ILR.DataStore.Desktop.Context;
using ESFA.DC.ILR.Datastore.Modules;
using ESFA.DC.ILR.DataStore.Desktop.PersistData;
using ESFA.DC.ILR.DataStore.Desktop.PersistData.Mappers;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.Desktop.Interface;

namespace ESFA.DC.ILR.DataStore.Desktop.Modules
{
    public class DataStoreModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<DataStoreServicesModule>();
            containerBuilder.RegisterModule<MappersModule>();
            containerBuilder.RegisterModule<ProvidersModule>();
            containerBuilder.RegisterModule<PersistenceModule>();

            containerBuilder.RegisterType<DataStoreContextFactory>().As<IDataStoreContextFactory<IDesktopContext>>();

            containerBuilder.RegisterType<DesktopFM36HistoryMapper>().As<IFM36HistoryMapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<DesktopFM36HistoryTransaction>().As<IFM36HistoryTransaction>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<DesktopESFFundingMapper>().As<IESFFundingMapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<DesktopESFFundingTransaction>().As<IESFFundingTransaction>().InstancePerLifetimeScope();
        }
    }
}
