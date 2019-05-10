using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Desktop.Service.Interface;
using Microsoft.SqlServer.Dac;

namespace ESFA.DC.ILR.DataStore.Desktop.Service
{
    public class ILRDatabaseDeploymentService : IDatabaseDeploymentService
    {
        public Task DeployAsync(string connectionString, CancellationToken cancellationToken)
        {
            var dacOptions = new DacDeployOptions()
            {
                BlockOnPossibleDataLoss = false,
                CreateNewDatabase = true,
            };

            var dacServiceInstance = new DacServices(connectionString);

                var assembly = Assembly.GetExecutingAssembly();
                var embeddedResources = assembly.GetManifestResourceNames();

                //using (var stream = Assembly.

                //using (DacPackage dacpac = DacPackage.Load(dacpacName))
                //{
                //    dacServiceInstance.Deploy(dacpac, databaseName, true,  dacOptions);
                //}

            return Task.CompletedTask;
        }
    }
}
