using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.Desktop.Interface;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.DataStore.Desktop.Test
{
    public class DataStoreDesktopTaskTests
    {
        [Fact]
        public async Task ExecuteAsync()
        {
            var cancellationToken = CancellationToken.None;

            var desktopContextMock = new Mock<IDesktopContext>();
            var dataStoreContextFactoryMock = new Mock<IDataStoreContextFactory<IDesktopContext>>();
            var dataStoreContextMock = new Mock<IDataStoreContext>();
            var entryPointMock = new Mock<IEntryPoint>();

            dataStoreContextFactoryMock.Setup(f => f.Build(desktopContextMock.Object)).Returns(dataStoreContextMock.Object);

            entryPointMock.Setup(s => s.Callback(dataStoreContextMock.Object, cancellationToken)).Returns(Task.FromResult(true)).Verifiable();

            var result = await NewTask(entryPointMock.Object, dataStoreContextFactoryMock.Object).ExecuteAsync(desktopContextMock.Object, cancellationToken);

            result.Should().BeSameAs(desktopContextMock.Object);

            entryPointMock.VerifyAll();
        }

        private DataStoreDesktopTask NewTask(IEntryPoint entryPoint = null, IDataStoreContextFactory<IDesktopContext> dataStoreContextFactory = null)
        {
            return new DataStoreDesktopTask(
                entryPoint ?? Mock.Of<IEntryPoint>(),
                dataStoreContextFactory ?? Mock.Of<IDataStoreContextFactory<IDesktopContext>>());
        }
    }
}
