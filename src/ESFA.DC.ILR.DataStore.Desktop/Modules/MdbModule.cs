using Autofac;
using ESFA.DC.ILR.Datastore.Modules;
using ESFA.DC.ILR.DataStore.Desktop.Context;
using ESFA.DC.ILR.DataStore.Desktop.PersistData;
using ESFA.DC.ILR.DataStore.Desktop.PersistData.Mappers;
using ESFA.DC.ILR.DataStore.Export;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR.DataStore.Export.SchemaExport;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.Desktop.Interface;
using EntryPoint = ESFA.DC.ILR.DataStore.PersistData.EntryPoint;

namespace ESFA.DC.ILR.DataStore.Desktop.Modules
{
    public class MdbModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<MdbDesktopTask>().As<IDesktopTask>();
            containerBuilder.RegisterType<DataStoreContextFactory>().As<IDataStoreContextFactory<IDesktopContext>>();
            containerBuilder.RegisterType<EntryPoint>().As<IEntryPoint>();
            containerBuilder.RegisterType<MdbExport>().As<IExport>();
            containerBuilder.RegisterType<TransactionController>().As<ITransactionController>();

            containerBuilder.RegisterType<DesktopFM36HistoryMapper>().As<IFM36HistoryMapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<DesktopFM36HistoryTransaction>().As<IFM36HistoryTransaction>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<DesktopESFFundingMapper>().As<IESFFundingMapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<DesktopESFFundingTransaction>().As<IESFFundingTransaction>().InstancePerLifetimeScope();

            containerBuilder.RegisterModule<ProvidersModule>();
            containerBuilder.RegisterModule<MappersModule>();

            containerBuilder.RegisterDecorator<CsvExport, IExport>();
            containerBuilder.RegisterDecorator<ValidationErrorSeed, IExport>();

            containerBuilder.RegisterType<ValidSchemaExport>().As<ISchemaExport>();
            containerBuilder.RegisterType<InvalidSchemaExport>().As<ISchemaExport>();
            containerBuilder.RegisterType<RulebaseSchemaExport>().As<ISchemaExport>();
        }
    }
}
