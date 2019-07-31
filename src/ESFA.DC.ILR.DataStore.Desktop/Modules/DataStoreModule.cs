using Autofac;
using ESFA.DC.ILR.Datastore.Modules;
using ESFA.DC.ILR.DataStore.Desktop.PersistData;
using ESFA.DC.ILR.DataStore.Desktop.PersistData.Mappers;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Interface.Mappers;

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

            containerBuilder.RegisterType<DesktopFM36HistoryMapper>().As<IFM36HistoryMapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<DesktopFM36HistoryTransactionController>().As<IFM36HistoryTransactionController>().InstancePerLifetimeScope();
        }
    }
}
