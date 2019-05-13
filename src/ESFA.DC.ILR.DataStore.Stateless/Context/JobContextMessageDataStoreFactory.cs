using System;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Stateless.Configuration;
using ESFA.DC.JobContextManager.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Stateless.Context
{
    public class JobContextMessageDataStoreFactory : IDataStoreContextFactory<IJobContextMessage>
    {
        private readonly PersistDataConfiguration _persistDataConfiguration;

        public JobContextMessageDataStoreFactory(PersistDataConfiguration persistDataConfiguration)
        {
            _persistDataConfiguration = persistDataConfiguration;
        }

        public IDataStoreContext Build(IJobContextMessage context)
        {
            return new DataStoreJobContextMessageContext(context, _persistDataConfiguration);
        }
    }
}
