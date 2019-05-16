using Autofac;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.File;
using ESFA.DC.ILR.DataStore.Model.Funding;
using ESFA.DC.ILR.DataStore.Model.History;
using ESFA.DC.ILR.DataStore.PersistData;
using ESFA.DC.ILR.DataStore.PersistData.Persist;
using ESFA.DC.ILR.DataStore.Stubs;

namespace ESFA.DC.ILR.Datastore.Modules
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<BulkInsert>().As<IBulkInsert>().InstancePerDependency();
            containerBuilder.RegisterType<TransactionController>().As<ITransactionController>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<DataStorePersistenceService>().As<IDataStorePersistenceService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<StoreValidHeader>().As<IStoreService<ValidHeaderData>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreInvalidHeader>().As<IStoreService<InvalidHeaderData>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreValidLearnerData>().As<IStoreService<ValidLearnerData>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreInvalidLearnerData>().As<IStoreService<InvalidLearnerData>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreProcessingInformationData>().As<IStoreService<ProcessingInformationData>>().InstancePerLifetimeScope();

            RegisterStubServices(containerBuilder);
        }

        private void RegisterStubServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<StoreServiceStub<ALBData>>().As<IStoreService<ALBData>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreServiceStub<FM25Data>>().As<IStoreService<FM25Data>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreServiceStub<FM35Data>>().As<IStoreService<FM35Data>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreServiceStub<FM36Data>>().As<IStoreService<FM36Data>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreServiceStub<FM70Data>>().As<IStoreService<FM70Data>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreServiceStub<FM81Data>>().As<IStoreService<FM81Data>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreServiceStub<FM36HistoryData>>().As<IStoreService<FM36HistoryData>>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<StoreServiceStub<ValidationData>>().As<IStoreService<ValidationData>>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<StoreClearStub>().As<IStoreClear>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreClearStub>().As<IStoreFM36HistoryClear>().InstancePerLifetimeScope();
        }

        private void RegisterServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<StoreALB>().As<IStoreService<ALBData>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM25>().As<IStoreService<FM25Data>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM35>().As<IStoreService<FM35Data>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM36>().As<IStoreService<FM36Data>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM70>().As<IStoreService<FM70Data>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM81>().As<IStoreService<FM81Data>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM36History>().As<IStoreService<FM36HistoryData>>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<StoreValidationOutput>().As<IStoreService<ValidationData>>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<StoreClear>().As<IStoreClear>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StoreFM36HistoryClear>().As<IStoreFM36HistoryClear>().InstancePerLifetimeScope();
        }
    }
}
