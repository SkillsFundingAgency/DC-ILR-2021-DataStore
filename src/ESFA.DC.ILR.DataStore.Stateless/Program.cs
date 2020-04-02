using System;
using System.Diagnostics;
using System.Threading;
using Autofac;
using Autofac.Integration.ServiceFabric;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ServiceFabric.Common.Config;

namespace ESFA.DC.ILR.DataStore.Stateless
{
    public static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        public static void Main()
        {
            try
            {
                var builder = DIComposition.BuildContainer(new ServiceFabricConfigurationService());

                // Register the Autofac magic for Service Fabric support.
                builder.RegisterServiceFabricSupport();

                // Register the stateless service.
                builder.RegisterStatelessService<ServiceFabric.Common.Stateless>("ESFA.DC.ILR2021.DataStore.StatelessType");

                using (var container = builder.Build())
                {
                    ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(ServiceFabric.Common.Stateless).Name);

                    var entryPoint = container.Resolve<IEntryPoint>();

                    // Prevents this host process from terminating so services keep running.
                    Thread.Sleep(Timeout.Infinite);
                }
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e + Environment.NewLine + (e.InnerException?.ToString() ?? "No inner exception"));
                throw;
            }
        }
    }
}
