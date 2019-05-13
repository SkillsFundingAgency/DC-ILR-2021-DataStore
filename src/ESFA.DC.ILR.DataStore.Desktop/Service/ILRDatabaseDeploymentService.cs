using System.Data.SqlClient;
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
            var dacOptions = BuildDacDeployOptions();

            var databaseName = GetDatabaseNameFromInitialCatalog(connectionString);

            var dacServices = new DacServices(connectionString);

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ESFA.DC.ILR.DataStore.Desktop.Resources.ESFA.DC.ILR.DataStore.Database.dacpac"))
            {
                using (DacPackage dacPackage = DacPackage.Load(stream))
                {
                    dacServices.Deploy(dacPackage, databaseName, true, dacOptions, cancellationToken);
                }
            }

            return Task.CompletedTask;
        }

        private string GetDatabaseNameFromInitialCatalog(string connectionString)
        {
            return new SqlConnectionStringBuilder(connectionString).InitialCatalog;
        }

        private DacDeployOptions BuildDacDeployOptions()
        {
            var dacDeployOptions = new DacDeployOptions()
            {
                BlockOnPossibleDataLoss = false,
                CreateNewDatabase = true,
            };

            var defaultValue = "Default";

            dacDeployOptions.SqlCommandVariableValues.Add("BUILD_BRANCHNAME", defaultValue);
            dacDeployOptions.SqlCommandVariableValues.Add("BUILD_BUILDNUMBER", defaultValue);
            dacDeployOptions.SqlCommandVariableValues.Add("DSCIUserPassword", defaultValue);
            dacDeployOptions.SqlCommandVariableValues.Add("RELEASE_RELEASENAME", defaultValue);
            dacDeployOptions.SqlCommandVariableValues.Add("ROUserPassword", defaultValue);
            dacDeployOptions.SqlCommandVariableValues.Add("RWUserPassword", defaultValue);

            return dacDeployOptions;
        }
    }
}
