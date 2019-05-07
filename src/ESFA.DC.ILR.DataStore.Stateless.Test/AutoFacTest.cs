using Autofac;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.JobContextManager.Interface;
using ESFA.DC.JobContextManager.Model;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.Stateless.Test
{
    public sealed class AutoFacTest
    {
        [Fact]
        public void TestRegistrations()
        {
            ContainerBuilder containerBuilder = DIComposition.BuildContainer(new TestConfigurationHelper());

            var c = containerBuilder.Build();

            using (var lifeTime = c.BeginLifetimeScope())
            {
                var messageHandler = lifeTime.Resolve<IMessageHandler<JobContextMessage>>();
                var entryPoint = lifeTime.Resolve<IEntryPoint>();

                entryPoint.Should().NotBeNull();

                messageHandler.Should().NotBeNull();
            }
        }
    }
}
