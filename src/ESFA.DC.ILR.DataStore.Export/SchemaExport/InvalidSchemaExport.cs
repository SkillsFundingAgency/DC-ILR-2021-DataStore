using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Access;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR.DataStore.Export.Mappers;
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
            await ExportTableAsync<CollectionDetail, DefaultTableClassMap<CollectionDetail>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<Learner, DefaultTableClassMap<Learner>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearningProvider, DefaultTableClassMap<LearningProvider>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<Source, DefaultTableClassMap<Source>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<SourceFile, DefaultTableClassMap<SourceFile>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ContactPreference, DefaultTableClassMap<ContactPreference>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<EmploymentStatusMonitoring, DefaultTableClassMap<EmploymentStatusMonitoring>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearnerEmploymentStatus, DefaultTableClassMap<LearnerEmploymentStatus>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearnerFAM, DefaultTableClassMap<LearnerFAM>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearnerHE, DefaultTableClassMap<LearnerHE>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearnerHEFinancialSupport, DefaultTableClassMap<LearnerHEFinancialSupport>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearningDelivery, DefaultTableClassMap<LearningDelivery>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearningDeliveryFAM, DefaultTableClassMap<LearningDeliveryFAM>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearningDeliveryHE, DefaultTableClassMap<LearningDeliveryHE>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<AppFinRecord, DefaultTableClassMap<AppFinRecord>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearningDeliveryWorkPlacement, DefaultTableClassMap<LearningDeliveryWorkPlacement>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LLDDandHealthProblem, DefaultTableClassMap<LLDDandHealthProblem>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ProviderSpecDeliveryMonitoring, DefaultTableClassMap<ProviderSpecDeliveryMonitoring>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ProviderSpecLearnerMonitoring, DefaultTableClassMap<ProviderSpecLearnerMonitoring>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<LearnerDestinationandProgression, DefaultTableClassMap<LearnerDestinationandProgression>>(exportPath, dataStoreCache, connection, transaction,
                cancellationToken);

            await ExportTableAsync<DPOutcome, DefaultTableClassMap<DPOutcome>>(exportPath, dataStoreCache, connection, transaction, cancellationToken);
        }
    }
}
