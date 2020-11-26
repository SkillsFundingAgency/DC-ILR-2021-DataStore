using Autofac;
using ESFA.DC.ILR.DataStore.Access;
using ESFA.DC.ILR.DataStore.Access.Interface;
using ESFA.DC.ILR.DataStore.Desktop.Context;
using ESFA.DC.ILR.DataStore.Desktop.Service;
using ESFA.DC.ILR.DataStore.Desktop.Service.Interface;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.Desktop.Interface;

namespace ESFA.DC.ILR.DataStore.Desktop.Modules
{
    public class BuildMdbModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<BuildMdbDesktopTask>().As<IDesktopTask>();
            containerBuilder.RegisterType<MdbDatabaseDeploymentService>().As<IMdbDeploymentService>();
            containerBuilder.RegisterType<ExportContextFactory>().As<IDataStoreContextFactory<IDesktopContext>>();

            containerBuilder.RegisterType<ValidGenerateSchema>().As<IGenerateSchema>();
            containerBuilder.RegisterType<InvalidGenerateSchema>().As<IGenerateSchema>();
        }
    }
}
