using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Desktop.Service.Interface;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.Desktop.Interface;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.DataStore.Desktop.Test
{
    public class BuildDataStoreDesktopTaskTests
    {
        [Fact]
        public async Task ExecuteAsync()
        {
            var ilrConnectionString = "ILR Connection String";
            var cancellationToken = CancellationToken.None;

            var desktopContextMock = new Mock<IDesktopContext>();
            var dataStoreContextFactoryMock = new Mock<IDataStoreContextFactory<IDesktopContext>>();
            var dataStoreContextMock = new Mock<IDataStoreContext>();
            var databaseDeploymentServiceMock = new Mock<IDatabaseDeploymentService>();

            dataStoreContextMock.SetupGet(c => c.IlrDatabaseConnectionString).Returns(ilrConnectionString);
            dataStoreContextFactoryMock.Setup(f => f.Build(desktopContextMock.Object)).Returns(dataStoreContextMock.Object);

            databaseDeploymentServiceMock.Setup(s => s.DeployAsync(ilrConnectionString, cancellationToken)).Returns(Task.CompletedTask).Verifiable();

            var result = await NewTask(databaseDeploymentServiceMock.Object, dataStoreContextFactoryMock.Object).ExecuteAsync(desktopContextMock.Object, cancellationToken);

            result.Should().BeSameAs(desktopContextMock.Object);

            databaseDeploymentServiceMock.VerifyAll();
        }

        private BuildDataStoreDesktopTask NewTask(IDatabaseDeploymentService databaseDeploymentService = null, IDataStoreContextFactory<IDesktopContext> dataStoreContextFactory = null)
        {
            return new BuildDataStoreDesktopTask(
                databaseDeploymentService ?? Mock.Of<IDatabaseDeploymentService>(),
                dataStoreContextFactory ?? Mock.Of<IDataStoreContextFactory<IDesktopContext>>());
        }
    }
}
