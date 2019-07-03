using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.DataStore.Desktop.Service.Interface
{
    public interface IDatabaseDeploymentService
    {
        Task DeployAsync(string connectionString, CancellationToken cancellationToken);
    }
}
