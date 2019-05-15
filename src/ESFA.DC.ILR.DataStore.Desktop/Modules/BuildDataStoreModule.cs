using Autofac;
using ESFA.DC.ILR.DataStore.Desktop.Context;
using ESFA.DC.ILR.DataStore.Desktop.Service;
using ESFA.DC.ILR.DataStore.Desktop.Service.Interface;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.Desktop.Interface;

namespace ESFA.DC.ILR.DataStore.Desktop.Modules
{
    public class BuildDataStoreModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ILRDatabaseDeploymentService>().As<IDatabaseDeploymentService>();

            containerBuilder.RegisterType<DataStoreContextFactory>().As<IDataStoreContextFactory<IDesktopContext>>();
        }
    }
}
