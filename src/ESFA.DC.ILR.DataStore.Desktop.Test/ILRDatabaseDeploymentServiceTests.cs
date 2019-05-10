using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Desktop.Service;
using Xunit;

namespace ESFA.DC.ILR.DataStore.Desktop.Test
{
    public class ILRDatabaseDeploymentServiceTests
    {
        [Fact]
        public async Task DeployAsync()
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder();

            connectionStringBuilder.InitialCatalog = "ILR1920";
            connectionStringBuilder.Authentication = SqlAuthenticationMethod.ActiveDirectoryIntegrated;
            connectionStringBuilder.DataSource = "(local)";

            var connectionString = connectionStringBuilder.ConnectionString;

            await NewService().DeployAsync(connectionString, CancellationToken.None);
        }

        private ILRDatabaseDeploymentService NewService()
        {
            return new ILRDatabaseDeploymentService();
        }
    }
}
