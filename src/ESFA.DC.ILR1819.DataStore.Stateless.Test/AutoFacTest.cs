using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using ESFA.DC.ILR1819.DataStore.Stateless.Handlers;
using ESFA.DC.JobContext;
using ESFA.DC.JobContext.Interface;
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
                    new ITopicItem[] { new TopicItem("SubscriptionName", "SubscriptionSqlFilterValue", new List<ITaskItem>()) },
                    0,
                    DateTime.UtcNow);
            jobContextMessage.KeyValuePairs[JobContextMessageKey.UkPrn] = 123;
            jobContextMessage.KeyValuePairs[JobContextMessageKey.Filename] = "ILR.xml";

            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            ContainerBuilder containerBuilder = Program.BuildContainer(new TestConfigurationHelper());

            IContainer c = containerBuilder.Build();
            using (var lifeTime = c.BeginLifetimeScope())
            {
                var messageHandler = lifeTime.Resolve<IMessageHandler>();
                bool ret = await messageHandler.Handle(jobContextMessage, cts.Token);
            }
        }
    }
}
