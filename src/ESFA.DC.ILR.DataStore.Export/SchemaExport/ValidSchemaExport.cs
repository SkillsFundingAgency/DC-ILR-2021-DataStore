using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Access;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR.DataStore.Export.Mappers;
using ESFA.DC.ILR.DataStore.Export.Mappers.Valid;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR2021.DataStore.EF.Valid;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.Export.SchemaExport
{
    public class ValidOrderedExport : AbstractSchemaExport, IOrderedExport
    {
        public ValidOrderedExport(IExport export, ILogger logger)
            : base(new ValidMdbContext(), export, logger, Constants.TaskExportValidTables, 11)
        {
        }

        public async Task ExportAsync(IDataStoreCache dataStoreCache, OleDbConnection connection, string exportPath,
            CancellationToken cancellationToken)
        {
            await ExportTableAsync<CollectionDetail, DefaultTableClassMap<CollectionDetail>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<Learner, ValidLearnerClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LearningProvider, DefaultTableClassMap<LearningProvider>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<Source, DefaultTableClassMap<Source>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<SourceFile, DefaultTableClassMap<SourceFile>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ContactPreference, DefaultTableClassMap<ContactPreference>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<EmploymentStatusMonitoring, DefaultTableClassMap<EmploymentStatusMonitoring>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LearnerEmploymentStatus, ValidLearnerEmploymentStatusClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LearnerFAM, ValidLearnerFAMClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LearnerHE, ValidLearnerHEClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LearnerHEFinancialSupport, ValidLearnerHEFinancialSupportClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LearningDelivery, ValidLearningDeliveryClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LearningDeliveryFAM, ValidLearningDeliveryFAMClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LearningDeliveryHE, ValidLearningDeliveryHEClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<AppFinRecord, ValidAppFinRecordClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LearningDeliveryWorkPlacement, ValidLearningDeliveryWorkPlacementClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LLDDandHealthProblem, ValidLLDDandHealthProblemClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ProviderSpecDeliveryMonitoring, ValidProviderSpecDeliveryMonitoringClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ProviderSpecLearnerMonitoring, ValidProviderSpecLearnerMonitoringClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<LearnerDestinationandProgression, ValidLearnerDestinationandProgressionClassMap>(exportPath, dataStoreCache, connection, 
                cancellationToken);

            await ExportTableAsync<DPOutcome, ValidDPOutcomeClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);
        }
    }
}
