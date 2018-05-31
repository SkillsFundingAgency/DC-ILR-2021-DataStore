using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using DC.JobContextManager.Interface;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace ESFA.DC.ILR1819.DataStore.Stateless
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    public class Stateless : StatelessService
    {
        private readonly ILifetimeScope _parentliLifetimeScope;

        public Stateless(StatelessServiceContext context, ILifetimeScope parentliLifetimeScope)
            : base(context)
        {
            _parentliLifetimeScope = parentliLifetimeScope;
        }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            yield return new ServiceInstanceListener(
                context => _parentliLifetimeScope.Resolve<IJobContextManager>(),
                "DataService-SBTopicListener");
        }
    }
}
