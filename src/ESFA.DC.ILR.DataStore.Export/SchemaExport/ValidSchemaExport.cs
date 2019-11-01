using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Access;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR.DataStore.Export.Mappers;
using ESFA.DC.ILR.DataStore.Export.Mappers.Valid;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.SchemaExport
{
    public class ValidSchemaExport : AbstractSchemaExport, ISchemaExport
    {
        public ValidSchemaExport(IExport export)
            : base(new ValidMdbContext(), export)
        {
        }

        public async Task ExportAsync(IDataStoreCache dataStoreCache, OleDbConnection connection, OleDbTransaction transaction, string exportPath,
            CancellationToken cancellationToken)
        {
            await ExportTableAsync<CollectionDetail, DefaultTableClassMap<CollectionDetail>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<Learner, ValidLearnerClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearningProvider, DefaultTableClassMap<LearningProvider>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<Source, DefaultTableClassMap<Source>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<SourceFile, DefaultTableClassMap<SourceFile>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ContactPreference, DefaultTableClassMap<ContactPreference>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<EmploymentStatusMonitoring, DefaultTableClassMap<EmploymentStatusMonitoring>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearnerEmploymentStatus, ValidLearnerEmploymentStatusClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearnerFAM, ValidLearnerFAMClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearnerHE, ValidLearnerHEClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearnerHEFinancialSupport, ValidLearnerHEFinancialSupportClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearningDelivery, ValidLearningDeliveryClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearningDeliveryFAM, ValidLearningDeliveryFAMClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearningDeliveryHE, ValidLearningDeliveryHEClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<AppFinRecord, ValidAppFinRecordClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearningDeliveryWorkPlacement, ValidLearningDeliveryWorkPlacementClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LLDDandHealthProblem, ValidLLDDandHealthProblemClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ProviderSpecDeliveryMonitoring, ValidProviderSpecDeliveryMonitoringClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ProviderSpecLearnerMonitoring, ValidProviderSpecLearnerMonitoringClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearnerDestinationandProgression, ValidLearnerDestinationandProgressionClassMap>(exportPath, dataStoreCache, connection, transaction,
                cancellationToken);

            await ExportTableAsync<DPOutcome, ValidDPOutcomeClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);
        }
    }
}
