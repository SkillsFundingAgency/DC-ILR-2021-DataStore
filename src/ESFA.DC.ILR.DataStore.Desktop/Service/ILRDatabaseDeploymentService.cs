using System;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Desktop.Service.Interface;

namespace ESFA.DC.ILR.DataStore.Desktop.Service
{
    public class ILRDatabaseDeploymentService : IDatabaseDeploymentService
    {
        public Task DeployAsync(string connectionString, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
