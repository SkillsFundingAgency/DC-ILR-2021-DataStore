using Autofac;
using ESFA.DC.ILR.Datastore.Modules;

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
        }
    }
}
