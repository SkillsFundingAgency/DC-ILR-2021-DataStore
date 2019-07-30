using Autofac;
using ESFA.DC.ILR.Datastore.Modules;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Stubs;

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

            containerBuilder.RegisterType<TransactionStub>().As<IFM36HistoryTransactionController>().InstancePerLifetimeScope();
        }
    }
}
