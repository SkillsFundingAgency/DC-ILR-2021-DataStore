using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Access;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR.DataStore.Export.Mappers;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR2021.DataStore.EF.Invalid;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.Export.SchemaExport
{
    public class InvalidOrderedExport : AbstractSchemaExport, IOrderedExport
    {
        public InvalidOrderedExport(IExport export, ILogger logger)
            : base(new InvalidMdbContext(), export, logger, Constants.TaskExportInvalidTables, 2)
        {
        }

        public async Task ExportAsync(IDataStoreCache dataStoreCache, OleDbConnection connection, string exportPath,
            CancellationToken cancellationToken)
        {
            await ExportTableAsync<CollectionDetail, DefaultTableClassMap<CollectionDetail>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<Learner, DefaultTableClassMap<Learner>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LearningProvider, DefaultTableClassMap<LearningProvider>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<Source, DefaultTableClassMap<Source>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<SourceFile, DefaultTableClassMap<SourceFile>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ContactPreference, DefaultTableClassMap<ContactPreference>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<EmploymentStatusMonitoring, DefaultTableClassMap<EmploymentStatusMonitoring>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LearnerEmploymentStatus, DefaultTableClassMap<LearnerEmploymentStatus>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LearnerFAM, DefaultTableClassMap<LearnerFAM>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LearnerHE, DefaultTableClassMap<LearnerHE>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LearnerHEFinancialSupport, DefaultTableClassMap<LearnerHEFinancialSupport>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LearningDelivery, DefaultTableClassMap<LearningDelivery>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LearningDeliveryFAM, DefaultTableClassMap<LearningDeliveryFAM>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LearningDeliveryHE, DefaultTableClassMap<LearningDeliveryHE>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<AppFinRecord, DefaultTableClassMap<AppFinRecord>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LearningDeliveryWorkPlacement, DefaultTableClassMap<LearningDeliveryWorkPlacement>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LLDDandHealthProblem, DefaultTableClassMap<LLDDandHealthProblem>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ProviderSpecDeliveryMonitoring, DefaultTableClassMap<ProviderSpecDeliveryMonitoring>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ProviderSpecLearnerMonitoring, DefaultTableClassMap<ProviderSpecLearnerMonitoring>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LearnerDestinationandProgression, DefaultTableClassMap<LearnerDestinationandProgression>>(exportPath, dataStoreCache, connection, 
                cancellationToken);

            await ExportTableAsync<DPOutcome, DefaultTableClassMap<DPOutcome>>(exportPath, dataStoreCache, connection,  cancellationToken);
        }
    }
}
