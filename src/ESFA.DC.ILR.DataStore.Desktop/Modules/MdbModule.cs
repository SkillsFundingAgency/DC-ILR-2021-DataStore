using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
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

namespace ESFA.DC.ILR.DataStore.Desktop.Modules
{
    public class MdbModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<MdbDesktopTask>().As<IDesktopTask>();
            containerBuilder.RegisterType<ExportContextFactory>().As<IDataStoreContextFactory<IDesktopContext>>();
            containerBuilder.RegisterType<EntryPoint>().As<IExportEntryPoint>();
            containerBuilder.RegisterType<MdbExport>().As<IExport>();
            containerBuilder.RegisterType<TransactionController>().As<IExportTransactionController>();

            containerBuilder.RegisterType<DesktopFM36HistoryMapper>().As<IFM36HistoryMapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<DesktopFM36HistoryTransaction>().As<IFM36HistoryTransaction>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<DesktopESFFundingMapper>().As<IESFFundingMapper>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<DesktopESFFundingTransaction>().As<IESFFundingTransaction>().InstancePerLifetimeScope();

            containerBuilder.RegisterModule<ProvidersModule>();
            containerBuilder.RegisterModule<MappersModule>();

            containerBuilder.RegisterDecorator<CsvExport, IExport>();
            containerBuilder.RegisterDecorator<ValidationErrorSeed, IExport>();

            containerBuilder.RegisterType<AlbExport>().As<IOrderedExport>();
            containerBuilder.RegisterType<DVExport>().As<IOrderedExport>();
            containerBuilder.RegisterType<EsfExport>().As<IOrderedExport>();
            containerBuilder.RegisterType<FM25_FM35Export>().As<IOrderedExport>();
            containerBuilder.RegisterType<FM25Export>().As<IOrderedExport>();
            containerBuilder.RegisterType<FM35Export>().As<IOrderedExport>();
            containerBuilder.RegisterType<FM36Export>().As<IOrderedExport>();
            containerBuilder.RegisterType<InvalidOrderedExport>().As<IOrderedExport>();
            containerBuilder.RegisterType<TBLExport>().As<IOrderedExport>();
            containerBuilder.RegisterType<ValidationErrorExport>().As<IOrderedExport>();
            containerBuilder.RegisterType<ValidOrderedExport>().As<IOrderedExport>();
        }
    }
}
