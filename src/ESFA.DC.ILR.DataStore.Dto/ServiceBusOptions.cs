namespace ESFA.DC.ILR.DataStore.Dto
{
    public class ServiceBusOptions
    {
        public string AuditQueueName { get; set; }

        public string ServiceBusConnectionString { get; set; }

        public string TopicName { get; set; }

        public string DataStoreSubscriptionName { get; set; }
    }
}
