using System.Collections.Generic;
using Autofac;
using ESFA.DC.Data.ILR.ValidationErrors.Model;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.PersistData;
using ESFA.DC.ILR.DataStore.PersistData.Providers;
using ESFA.DC.ILR.DataStore.Stubs;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR.Model;

namespace ESFA.DC.ILR.Datastore.Modules
{
    public class ProvidersModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<DataStoreDataCacheProvider>().As<IDataStoreDataCacheProvider>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<DataStoreDataProvider>().As<IDataStoreDataProvider>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<ILRProviderService>().As<IProviderService<Message>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ValidLearnerProviderService>().As<IProviderService<List<string>>>().InstancePerLifetimeScope();

            RegisterStubServices(containerBuilder);
        }

        private void RegisterStubServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ProviderServiceStub>()
                    .As<IProviderService<ALBGlobal>>()
                    .As<IProviderService<FM25Global>>()
                    .As<IProviderService<FM35Global>>()
                    .As<IProviderService<FM36Global>>()
                    .As<IProviderService<FM70Global>>()
                    .As<IProviderService<FM81Global>>()
                    .As<IProviderService<List<ILR.IO.Model.Validation.ValidationError>>>()
                    .As<IProviderService<List<Rule>>>().InstancePerLifetimeScope();
        }

        private void RegisterServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ALBProviderService>().As<IProviderService<ALBGlobal>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM25ProviderService>().As<IProviderService<FM25Global>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM35ProviderService>().As<IProviderService<FM35Global>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM36ProviderService>().As<IProviderService<FM36Global>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM70ProviderService>().As<IProviderService<FM70Global>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<FM81ProviderService>().As<IProviderService<FM81Global>>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ValidationErrorsProviderService>().As<IProviderService<List<ILR.IO.Model.Validation.ValidationError>>>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<RulesProviderService>().As<IProviderService<List<Rule>>>().InstancePerLifetimeScope();
        }
    }
}
