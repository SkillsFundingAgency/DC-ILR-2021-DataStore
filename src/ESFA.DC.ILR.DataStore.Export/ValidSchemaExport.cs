using System;
using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR.DataStore.Export.Mappers.Valid;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export
{
    public class ValidSchemaExport : ISchemaExport
    {
        private readonly IExport _export;
        public ValidSchemaExport(IExport export)
        {
            _export = export;
        }

        public async Task ExportAsync(IDataStoreCache dataStoreCache, OleDbConnection connection, OleDbTransaction transaction, string exportPath,
            CancellationToken cancellationToken)
        {
            await _export.ExportAsync<CollectionDetail, ValidCollectionDetailsClassMap>(TableNameConstants.ValidCollectionDetails, dataStoreCache.Get<CollectionDetail>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<Learner, ValidLearnerClassMap>(TableNameConstants.ValidLearner, dataStoreCache.Get<Learner>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LearningProvider, ValidLearningProviderClassMap>(TableNameConstants.ValidLearningProvider, dataStoreCache.Get<LearningProvider>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<Source, ValidSourceClassMap>(TableNameConstants.ValidSource, dataStoreCache.Get<Source>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<SourceFile, ValidSourceFileClassMap>(TableNameConstants.ValidSourceFile, dataStoreCache.Get<SourceFile>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ContactPreference, ValidContactPreferenceClassMap>(TableNameConstants.ValidContactPreference, dataStoreCache.Get<ContactPreference>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<EmploymentStatusMonitoring, ValidEmploymentStatusMonitoringClassMap>(TableNameConstants.ValidEmploymentStatusMonitoring, dataStoreCache.Get<EmploymentStatusMonitoring>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LearnerEmploymentStatus, ValidLearnerEmploymentStatusClassMap>(TableNameConstants.ValidLearnerEmploymentStatus, dataStoreCache.Get<LearnerEmploymentStatus>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LearnerFAM, ValidLearnerFAMClassMap>(TableNameConstants.ValidLearnerFAM, dataStoreCache.Get<LearnerFAM>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LearnerHE, ValidLearnerHEClassMap>(TableNameConstants.ValidLearnerHE, dataStoreCache.Get<LearnerHE>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LearnerHEFinancialSupport, ValidLearnerHEFinancialSupportClassMap>(TableNameConstants.ValidLearnerHEFinancialSupport, dataStoreCache.Get<LearnerHEFinancialSupport>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LearningDelivery, ValidLearningDeliveryClassMap>(TableNameConstants.ValidLearningDelivery, dataStoreCache.Get<LearningDelivery>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LearningDeliveryFAM, ValidLearningDeliveryFAMClassMap>(TableNameConstants.ValidLearningDeliveryFAM, dataStoreCache.Get<LearningDeliveryFAM>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LearningDeliveryHE, ValidLearningDeliveryHEClassMap>(TableNameConstants.ValidLearningDeliveryHE, dataStoreCache.Get<LearningDeliveryHE>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<AppFinRecord, ValidAppFinRecordClassMap>(TableNameConstants.ValidAppFinRecord, dataStoreCache.Get<AppFinRecord>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LearningDeliveryWorkPlacement, ValidLearningDeliveryWorkPlacementClassMap>(TableNameConstants.ValidLearningDeliveryWorkPlacement, dataStoreCache.Get<LearningDeliveryWorkPlacement>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LLDDandHealthProblem, ValidLLDDandHealthProblemClassMap>(TableNameConstants.ValidLLDDandHealthProblem, dataStoreCache.Get<LLDDandHealthProblem>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ProviderSpecDeliveryMonitoring, ValidProviderSpecDeliveryMonitoringClassMap>(TableNameConstants.ValidProviderSpecDeliveryMonitoring, dataStoreCache.Get<ProviderSpecDeliveryMonitoring>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ProviderSpecLearnerMonitoring, ValidProviderSpecLearnerMonitoringClassMap>(TableNameConstants.ValidProviderSpecLearnerMonitoring, dataStoreCache.Get<ProviderSpecLearnerMonitoring>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<LearnerDestinationandProgression, ValidLearnerDestinationandProgressionClassMap>(TableNameConstants.ValidLearnerDestinationAndProgression, dataStoreCache.Get<LearnerDestinationandProgression>(), exportPath, connection, transaction,
                cancellationToken);

            await _export.ExportAsync<DPOutcome, ValidDPOutcomeClassMap>(TableNameConstants.ValidDPOutcome, dataStoreCache.Get<DPOutcome>(), exportPath, connection, transaction, cancellationToken);
        }
    }
}
