using Autofac;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.PersistData;
using ESFA.DC.ILR.DataStore.PersistData.Persist;
using ESFA.DC.ILR.DataStore.PersistData.Transactions;
using ESFA.DC.ILR.DataStore.PersistData.Transactions.ILR;

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
            RegisterTransactions(containerBuilder);
        }

        private void RegisterServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<StoreClear>().As<IStoreClear>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM36HistoryClear>().As<IStoreFM36HistoryClear>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreESFSummarisationClear>().As<IStoreESFSummarisationClear>().InstancePerLifetimeScope();
        }

        private void RegisterTransactions(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ALBTransaction>().As<ITableSetTransaction>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM25Transation>().As<ITableSetTransaction>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM35Transation>().As<ITableSetTransaction>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM36Transation>().As<ITableSetTransaction>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM70Transation>().As<ITableSetTransaction>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM81Transation>().As<ITableSetTransaction>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<InvalidTransaction>().As<ITableSetTransaction>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ValidationOutputTransation>().As<ITableSetTransaction>()
                .InstancePerLifetimeScope();
            containerBuilder.RegisterType<ValidTransaction>().As<ITableSetTransaction>().InstancePerLifetimeScope();
        }
    }
}
