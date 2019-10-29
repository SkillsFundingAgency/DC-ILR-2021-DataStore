using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Access;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR.DataStore.Export.Mappers.Invalid;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export.SchemaExport
{
    public class InvalidSchemaExport : AbstractSchemaExport, ISchemaExport
    {
        public InvalidSchemaExport(IExport export)
            : base(new InvalidMdbContext(), export)
        {
        }

        public async Task ExportAsync(IDataStoreCache dataStoreCache, OleDbConnection connection, OleDbTransaction transaction, string exportPath,
            CancellationToken cancellationToken)
        {
            await ExportTableAsync<CollectionDetail, InvalidCollectionDetailsClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<Learner, InvalidLearnerClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearningProvider, InvalidLearningProviderClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<Source, InvalidSourceClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<SourceFile, InvalidSourceFileClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ContactPreference, InvalidContactPreferenceClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<EmploymentStatusMonitoring, InvalidEmploymentStatusMonitoringClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearnerEmploymentStatus, InvalidLearnerEmploymentStatusClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearnerFAM, InvalidLearnerFAMClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearnerHE, InvalidLearnerHEClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearnerHEFinancialSupport, InvalidLearnerHEFinancialSupportClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearningDelivery, InvalidLearningDeliveryClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearningDeliveryFAM, InvalidLearningDeliveryFAMClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearningDeliveryHE, InvalidLearningDeliveryHEClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<AppFinRecord, InvalidAppFinRecordClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearningDeliveryWorkPlacement, InvalidLearningDeliveryWorkPlacementClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LLDDandHealthProblem, InvalidLLDDandHealthProblemClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ProviderSpecDeliveryMonitoring, InvalidProviderSpecDeliveryMonitoringClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ProviderSpecLearnerMonitoring, InvalidProviderSpecLearnerMonitoringClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearnerDestinationandProgression, InvalidLearnerDestinationandProgressionClassMap>(exportPath, dataStoreCache, connection, transaction,
                cancellationToken);

            await ExportTableAsync<DPOutcome, InvalidDPOutcomeClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);
        }
    }
}
