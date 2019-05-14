using Autofac;
using ESFA.DC.DateTimeProvider.Interface;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.PersistData;

namespace ESFA.DC.ILR.Datastore.Modules
{
    public class DataStoreServicesModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<EntryPoint>().As<IEntryPoint>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<DateTimeProvider.DateTimeProvider>().As<IDateTimeProvider>();
        }
    }
}
