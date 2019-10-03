using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Desktop.Service.Interface;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.Desktop.Interface;

namespace ESFA.DC.ILR.DataStore.Desktop
{
    public class BuildMdbDesktopTask : IDesktopTask
    {
        private readonly IDataStoreContextFactory<IDesktopContext> _dataStoreContextFactory;
        private readonly IDatabaseDeploymentService _databaseDeploymentService;

        public BuildMdbDesktopTask(IDataStoreContextFactory<IDesktopContext> dataStoreContextFactory, IDatabaseDeploymentService databaseDeploymentService)
        {
            _dataStoreContextFactory = dataStoreContextFactory;
            _databaseDeploymentService = databaseDeploymentService;
        }

        public async Task<IDesktopContext> ExecuteAsync(IDesktopContext desktopContext, CancellationToken cancellationToken)
        {
            var datastoreContext = _dataStoreContextFactory.Build(desktopContext);

            await _databaseDeploymentService.DeployAsync(datastoreContext.MdbConnectionString, cancellationToken);

            return desktopContext;
        }
    }
}
