using System;
using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR.DataStore.Export.Mappers.Invalid;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export
{
    public class InvalidSchemaExport : ISchemaExport
    {
        private readonly IExport _export;

        public InvalidSchemaExport(IExport export)
        {
            _export = export;
        }

        public async Task ExportAsync(IDataStoreCache dataStoreCache, OleDbConnection connection, OleDbTransaction transaction, string exportPath,
            CancellationToken cancellationToken)
        {
            await _export.ExportAsync<CollectionDetail, InvalidCollectionDetailsClassMap>(TableNameConstants.InvalidCollectionDetails, dataStoreCache.Get<CollectionDetail>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<Learner, InvalidLearnerClassMap>(TableNameConstants.InvalidLearner, dataStoreCache.Get<Learner>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LearningProvider, InvalidLearningProviderClassMap>(TableNameConstants.InvalidLearningProvider, dataStoreCache.Get<LearningProvider>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<Source, InvalidSourceClassMap>(TableNameConstants.InvalidSource, dataStoreCache.Get<Source>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<SourceFile, InvalidSourceFileClassMap>(TableNameConstants.InvalidSourceFile, dataStoreCache.Get<SourceFile>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ContactPreference, InvalidContactPreferenceClassMap>(TableNameConstants.InvalidContactPreference, dataStoreCache.Get<ContactPreference>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<EmploymentStatusMonitoring, InvalidEmploymentStatusMonitoringClassMap>(TableNameConstants.InvalidEmploymentStatusMonitoring, dataStoreCache.Get<EmploymentStatusMonitoring>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LearnerEmploymentStatus, InvalidLearnerEmploymentStatusClassMap>(TableNameConstants.InvalidLearnerEmploymentStatus, dataStoreCache.Get<LearnerEmploymentStatus>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LearnerFAM, InvalidLearnerFAMClassMap>(TableNameConstants.InvalidLearnerFAM, dataStoreCache.Get<LearnerFAM>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LearnerHE, InvalidLearnerHEClassMap>(TableNameConstants.InvalidLearnerHE, dataStoreCache.Get<LearnerHE>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LearnerHEFinancialSupport, InvalidLearnerHEFinancialSupportClassMap>(TableNameConstants.InvalidLearnerHEFinancialSupport, dataStoreCache.Get<LearnerHEFinancialSupport>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LearningDelivery, InvalidLearningDeliveryClassMap>(TableNameConstants.InvalidLearningDelivery, dataStoreCache.Get<LearningDelivery>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LearningDeliveryFAM, InvalidLearningDeliveryFAMClassMap>(TableNameConstants.InvalidLearningDeliveryFAM, dataStoreCache.Get<LearningDeliveryFAM>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LearningDeliveryHE, InvalidLearningDeliveryHEClassMap>(TableNameConstants.InvalidLearningDeliveryHE, dataStoreCache.Get<LearningDeliveryHE>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<AppFinRecord, InvalidAppFinRecordClassMap>(TableNameConstants.InvalidAppFinRecord, dataStoreCache.Get<AppFinRecord>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LearningDeliveryWorkPlacement, InvalidLearningDeliveryWorkPlacementClassMap>(TableNameConstants.InvalidLearningDeliveryWorkPlacement, dataStoreCache.Get<LearningDeliveryWorkPlacement>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LLDDandHealthProblem, InvalidLLDDandHealthProblemClassMap>(TableNameConstants.InvalidLLDDandHealthProblem, dataStoreCache.Get<LLDDandHealthProblem>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ProviderSpecDeliveryMonitoring, InvalidProviderSpecDeliveryMonitoringClassMap>(TableNameConstants.InvalidProviderSpecDeliveryMonitoring, dataStoreCache.Get<ProviderSpecDeliveryMonitoring>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ProviderSpecLearnerMonitoring, InvalidProviderSpecLearnerMonitoringClassMap>(TableNameConstants.InvalidProviderSpecLearnerMonitoring, dataStoreCache.Get<ProviderSpecLearnerMonitoring>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LearnerDestinationandProgression, InvalidLearnerDestinationandProgressionClassMap>(TableNameConstants.InvalidLearnerDestinationAndProgression, dataStoreCache.Get<LearnerDestinationandProgression>(), exportPath, connection, transaction,
                cancellationToken);

            await _export.ExportAsync<DPOutcome, InvalidDPOutcomeClassMap>(TableNameConstants.InvalidDPOutcome, dataStoreCache.Get<DPOutcome>(), exportPath, connection, transaction, cancellationToken);
        }
    }
}
