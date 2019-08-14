using Autofac;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.PersistData;
using ESFA.DC.ILR.DataStore.PersistData.Persist;
using ESFA.DC.ILR.DataStore.PersistData.Transactions;

namespace ESFA.DC.ILR.Datastore.Modules
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<BulkInsert>().As<IBulkInsert>().InstancePerDependency();
            containerBuilder.RegisterType<TransactionController>().As<ITransactionController>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ILRTransaction>().As<IILRTransaction>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<DataStorePersistenceService>().As<IDataStorePersistenceService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PersistenceService>().As<IPersistenceService>().InstancePerLifetimeScope();

            RegisterServices(containerBuilder);
        }

        private void RegisterServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<StoreClear>().As<IStoreClear>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM36HistoryClear>().As<IStoreFM36HistoryClear>().InstancePerLifetimeScope();
        }
    }
}
