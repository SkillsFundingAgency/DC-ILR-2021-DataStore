using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Access.Interface;
using ESFA.DC.ILR.DataStore.Desktop.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ESFA.DC.ILR.DataStore.Desktop.Service
{
    public class MdbDatabaseDeploymentService : IDatabaseDeploymentService
    {
        private readonly IEnumerable<IGenerateSchema> _generateSchemas;

        public MdbDatabaseDeploymentService(IEnumerable<IGenerateSchema> generateSchemas)
        {
            _generateSchemas = generateSchemas;
        }

        public async Task DeployAsync(string connectionString, CancellationToken cancellationToken)
        {
            foreach (var mdbContextGenerator in _generateSchemas)
            {
                await mdbContextGenerator.Generate(connectionString, cancellationToken);
            }
        }
    }
}
