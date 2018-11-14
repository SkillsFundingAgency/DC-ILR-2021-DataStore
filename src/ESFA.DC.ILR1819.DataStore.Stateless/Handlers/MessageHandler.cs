using System;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.PersistData;
using ESFA.DC.JobContextManager.Interface;
using ESFA.DC.JobContextManager.Model;
using ESFA.DC.JobContextManager.Model.Interface;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.Stateless.Handlers
{
    public sealed class MessageHandler : IMessageHandler<JobContextMessage>
    {
        private readonly ILifetimeScope _parentLifeTimeScope;

        private readonly StatelessServiceContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageHandler"/> class.
        /// Simple constructor for use by AutoFac testing, don't want to have to fake a @see StatelessServiceContext
        /// </summary>
        /// <param name="parentLifeTimeScope">AutoFac scope</param>
        public MessageHandler(ILifetimeScope parentLifeTimeScope)
        {
            _parentLifeTimeScope = parentLifeTimeScope;
            _context = null;
        }

        public MessageHandler(ILifetimeScope parentLifeTimeScope, StatelessServiceContext context)
        {
            _parentLifeTimeScope = parentLifeTimeScope;
            _context = context;
        }

        public async Task<bool> HandleAsync(JobContextMessage jobContextMessage, CancellationToken cancellationToken)
        {
            ILogger logme = null;
            try
            {
                using (var childLifeTimeScope = _parentLifeTimeScope.BeginLifetimeScope())
                {
                    var executionContext = (Logging.ExecutionContext)childLifeTimeScope.Resolve<IExecutionContext>();
                    executionContext.JobId = jobContextMessage.JobId.ToString();
                    var logger = childLifeTimeScope.Resolve<ILogger>();
                    logme = logger;
                    logger.LogDebug("Started Data Store");

                    IEntryPoint entryPoint;
                    try
                    {
                        entryPoint = childLifeTimeScope.Resolve<IEntryPoint>();
                        logger.LogDebug("Resolved Entry Point");
                    }
                    catch (Exception exception)
                    {
                        logger.LogError("Entry Point Resolution Failure", exception);
                        throw;
                    }

                    var result = await entryPoint.Callback(jobContextMessage, cancellationToken);

                    logger.LogDebug("Completed Data Store");

                    return result;
                }
            }
            catch (OutOfMemoryException oom)
            {
                Environment.FailFast("Data Store Out Of Memory", oom);
                throw;
            }
            catch (Exception ex)
            {
                logme.LogError("DataStore.MessageHandler", ex);
                ServiceEventSource.Current.ServiceMessage(_context, "Exception-{0}", ex.ToString());
                throw;
            }
        }
    }
}
