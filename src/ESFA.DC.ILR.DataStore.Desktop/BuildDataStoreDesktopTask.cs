using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Desktop.Service.Interface;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.Desktop.Interface;

namespace ESFA.DC.ILR.DataStore.Desktop
{
    public class BuildDataStoreDesktopTask : IDesktopTask
    {
        private readonly IDatabaseDeploymentService _databaseDeploymentService;
        private readonly IDataStoreContextFactory<IDesktopContext> _dataStoreContextFactory;

        public BuildDataStoreDesktopTask(IDatabaseDeploymentService databaseDeploymentService, IDataStoreContextFactory<IDesktopContext> dataStoreContextFactory)
        {
            _databaseDeploymentService = databaseDeploymentService;
            _dataStoreContextFactory = dataStoreContextFactory;
        }

        public async Task<IDesktopContext> ExecuteAsync(IDesktopContext desktopContext, CancellationToken cancellationToken)
        {
            var dataStoreContext = _dataStoreContextFactory.Build(desktopContext);

            await _databaseDeploymentService.DeployAsync(dataStoreContext.IlrDatabaseConnectionString, cancellationToken);

            return desktopContext;
        }
    }
}
