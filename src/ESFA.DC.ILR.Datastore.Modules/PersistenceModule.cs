using Autofac;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.File;
using ESFA.DC.ILR.DataStore.Model.Funding;
using ESFA.DC.ILR.DataStore.Model.History;
using ESFA.DC.ILR.DataStore.PersistData;
using ESFA.DC.ILR.DataStore.PersistData.Persist;

namespace ESFA.DC.ILR.Datastore.Modules
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<TransactionController>().As<ITransactionController>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<DataStorePersistenceService>().As<IDataStorePersistenceService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<StoreALB>().As<IStoreService<ALBData>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM25>().As<IStoreService<FM25Data>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM35>().As<IStoreService<FM35Data>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM36>().As<IStoreService<FM36Data>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM70>().As<IStoreService<FM70Data>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM81>().As<IStoreService<FM81Data>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM36History>().As<IStoreService<FM36HistoryData>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreProcessingInformationData>().As<IStoreService<ProcessingInformationData>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreValidHeader>().As<IStoreService<ValidHeaderData>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreInvalidHeader>().As<IStoreService<InvalidHeaderData>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreValidLearnerData>().As<IStoreService<ValidLearnerData>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreInvalidLearnerData>().As<IStoreService<InvalidLearnerData>>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<StoreValidationOutput>().As<IStoreService<ValidationData>>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<StoreClear>().As<IStoreClear>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM36HistoryClear>().As<IStoreFM36HistoryClear>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<BulkInsert>().As<IBulkInsert>().InstancePerDependency();
        }
    }
}
