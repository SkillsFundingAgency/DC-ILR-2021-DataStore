using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Stateless.Test.Stubs;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.JobContextManager.Interface;
using ESFA.DC.JobContextManager.Model;
using ESFA.DC.JobContextManager.Model.Interface;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.Stateless.Test
{
    public sealed class AutoFacTest
    {
        [Fact]
        public async Task TestRegistrations()
        {
            JobContextMessage jobContextMessage =
                new JobContextMessage(
                    1,
                    new ITopicItem[] { new TopicItem("SubscriptionName", new List<ITaskItem>()) },
                    0,
                    new DateTime(2018, 1, 1))
                {
                    KeyValuePairs =
                    {
                        [JobContextMessageKey.UkPrn] = 123,
                        [JobContextMessageKey.Filename] = "ILR.xml"
                    }
                };

            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            ContainerBuilder containerBuilder = DIComposition.BuildContainer(new TestConfigurationHelper());
            IContainer c;
            try
            {
                c = containerBuilder.Build();

                using (var lifeTime = c.BeginLifetimeScope())
                {
                    var messageHandler = lifeTime.Resolve<IMessageHandler<JobContextMessage>>();
                    bool ret = await messageHandler.HandleAsync(jobContextMessage, cts.Token);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [Fact]
        public void EnumerableTest()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<ModelServiceStub>().As<IFundModelService>();
            containerBuilder.RegisterType<ModelServiceStub>().As<IFundModelService>();

            var container = containerBuilder.Build();

            var modelServices = container.Resolve<IEnumerable<IFundModelService>>();

            modelServices.Should().HaveCount(2);
        }
    }
}
