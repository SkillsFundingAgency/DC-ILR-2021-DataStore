using Autofac;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.DataStore.PersistData;
using ESFA.DC.ILR.DataStore.PersistData.Mapper;
using ESFA.DC.ILR.DataStore.Stubs;

namespace ESFA.DC.ILR.Datastore.Modules
{
    public class MappersModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<DataStoreMapper>().As<IDataStoreMapper>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<ValidLearnerDataMapper>().As<IValidLearnerDataMapper>()
                .InstancePerLifetimeScope();
            containerBuilder.RegisterType<InvalidLearnerDataMapper>().As<IInvalidLearnerDataMapper>()
                .InstancePerLifetimeScope();
            containerBuilder.RegisterType<ValidHeaderDataMapper>().As<IValidHeaderDataMapper>()
                .InstancePerLifetimeScope();
            containerBuilder.RegisterType<InvalidHeaderDataMapper>().As<IInvalidHeaderDataMapper>()
                .InstancePerLifetimeScope();
            containerBuilder.RegisterType<ProcessingInformationDataMapper>().As<IProcessingInformationDataMapper>()
                .InstancePerLifetimeScope();

            RegisterStubServices(containerBuilder);
        }

        private void RegisterStubServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<MapperStub>()
                .As<IFM81Mapper>()
                .As<IFM70Mapper>()
                .As<IFM36Mapper>()
                .As<IFM35Mapper>()
                .As<IFM25Mapper>()
                .As<IALBMapper>()
                .As<IFM36HistoryMapper>()
                .As<IValidationDataMapper>()
                .InstancePerLifetimeScope();
        }

        private void RegisterServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<FM81Mapper>().As<IFM81Mapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM70Mapper>().As<IFM70Mapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM36Mapper>().As<IFM36Mapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM35Mapper>().As<IFM35Mapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM25Mapper>().As<IFM25Mapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ALBMapper>().As<IALBMapper>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<FM36HistoryMapper>().As<IFM36HistoryMapper>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<ValidationDataMapper>().As<IValidationDataMapper>().InstancePerLifetimeScope();
        }
    }
}
