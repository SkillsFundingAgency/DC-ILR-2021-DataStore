using Autofac;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.Stateless.Test
{
    public sealed class AutoFacTest
    {
        [Fact]
        public void TestRegistrations()
        {
            ContainerBuilder container = Program.BuildContainer(new TestConfigurationHelper());
            container.Build();
        }
    }
}
