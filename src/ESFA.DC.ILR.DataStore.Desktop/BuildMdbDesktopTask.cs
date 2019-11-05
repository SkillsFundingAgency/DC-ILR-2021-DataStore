using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Access;
using ESFA.DC.ILR.DataStore.Desktop.Service.Interface;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.Desktop.Interface;

namespace ESFA.DC.ILR.DataStore.Desktop
{
    public class BuildMdbDesktopTask : IDesktopTask
    {
        private readonly IDataStoreContextFactory<IDesktopContext> _dataStoreContextFactory;
        private readonly IMdbDeploymentService _databaseDeploymentService;

        public BuildMdbDesktopTask(IDataStoreContextFactory<IDesktopContext> dataStoreContextFactory, IMdbDeploymentService databaseDeploymentService)
        {
            _dataStoreContextFactory = dataStoreContextFactory;
            _databaseDeploymentService = databaseDeploymentService;
        }

        public async Task<IDesktopContext> ExecuteAsync(IDesktopContext desktopContext, CancellationToken cancellationToken)
        {
            var datastoreContext = _dataStoreContextFactory.Build(desktopContext);

            await _databaseDeploymentService.DeployAsync(string.Format(MdbConstants.MdbConnectionStringTemplate, datastoreContext.ExportOutputLocation), cancellationToken);

            return desktopContext;
        }
    }
}
