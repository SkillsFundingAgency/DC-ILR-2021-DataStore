using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.Data.AppsEarningsHistory.Model;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.PersistData.Constants;
using ESFA.DC.ILR1920.DataStore.EF;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.PersistData.Persist
{
    public sealed class PersistenceService : IPersistenceService
    {
        private readonly IBulkInsert _bulkInsert;

        public PersistenceService(IBulkInsert bulkInsert)
        {
            _bulkInsert = bulkInsert;
        }

        public async Task PersistValidationDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.ValidationError, dataStoreCache.Get<ValidationError>(), sqlConnection, cancellationToken);
        }

        public async Task PersistFM25DataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.FM25_global, dataStoreCache.Get<FM25_global>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM25_Learner, dataStoreCache.Get<FM25_Learner>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM25_FM35_global, dataStoreCache.Get<FM25_FM35_global>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM25_FM35_Learner_Period, dataStoreCache.Get<FM25_FM35_Learner_Period>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM25_FM35_Learner_PeriodisedValues, dataStoreCache.Get<FM25_FM35_Learner_PeriodisedValue>(), sqlConnection, cancellationToken);
        }

        public async Task PersistALBDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.ALB_global, dataStoreCache.Get<ALB_global>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ALB_Learner, dataStoreCache.Get<ALB_Learner>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ALB_Learner_Period, dataStoreCache.Get<ALB_Learner_Period>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ALB_Learner_PeriodisedValues, dataStoreCache.Get<ALB_Learner_PeriodisedValue>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ALB_LearningDelivery, dataStoreCache.Get<ALB_LearningDelivery>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ALB_LearningDelivery_Period, dataStoreCache.Get<ALB_LearningDelivery_Period>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ALB_LearningDelivery_PeriodisedValues, dataStoreCache.Get<ALB_LearningDelivery_PeriodisedValue>(), sqlConnection, cancellationToken);
        }

        public async Task PersistFM35DataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.FM35_global, dataStoreCache.Get<FM35_global>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM35_Learner, dataStoreCache.Get<FM35_Learner>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM35_LearningDelivery, dataStoreCache.Get<FM35_LearningDelivery>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM35_LearningDelivery_Period, dataStoreCache.Get<FM35_LearningDelivery_Period>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM35_LearningDelivery_PeriodisedValues, dataStoreCache.Get<FM35_LearningDelivery_PeriodisedValue>(), sqlConnection, cancellationToken);
        }

        public async Task PersistFM36DataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.FM36_global, dataStoreCache.Get<AEC_global>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM36_Learner, dataStoreCache.Get<AEC_Learner>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM36_LearningDelivery, dataStoreCache.Get<AEC_LearningDelivery>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM36_LearningDelivery_Period, dataStoreCache.Get<AEC_LearningDelivery_Period>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM36_LearningDelivery_PeriodisedValues, dataStoreCache.Get<AEC_LearningDelivery_PeriodisedValue>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM36_LearningDelivery_PeriodisedTextValues, dataStoreCache.Get<AEC_LearningDelivery_PeriodisedTextValue>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM36_PriceEpisodes, dataStoreCache.Get<AEC_ApprenticeshipPriceEpisode>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM36_PriceEpisode_Period, dataStoreCache.Get<AEC_ApprenticeshipPriceEpisode_Period>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM36_PriceEpisode_PeriodisedValues, dataStoreCache.Get<AEC_ApprenticeshipPriceEpisode_PeriodisedValue>(), sqlConnection, cancellationToken);
        }

        public async Task PersistFM81DataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.FM81_global, dataStoreCache.Get<TBL_global>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM81_Learner, dataStoreCache.Get<TBL_Learner>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM81_LearningDelivery, dataStoreCache.Get<TBL_LearningDelivery>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM81_LearningDelivery_Period, dataStoreCache.Get<TBL_LearningDelivery_Period>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM81_LearningDelivery_PeriodisedValues, dataStoreCache.Get<TBL_LearningDelivery_PeriodisedValue>(), sqlConnection, cancellationToken);
        }

        public async Task PersistFM70DataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.FM70_global, dataStoreCache.Get<ESF_global>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM70_Learner, dataStoreCache.Get<ESF_Learner>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM70_DPOutcome, dataStoreCache.Get<ESF_DPOutcome>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM70_LearningDelivery, dataStoreCache.Get<ESF_LearningDelivery>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM70_LearningDeliveryDeliverable, dataStoreCache.Get<ESF_LearningDeliveryDeliverable>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM70_LearningDeliveryDeliverable_Period, dataStoreCache.Get<ESF_LearningDeliveryDeliverable_Period>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM70_LearningDeliveryDeliverable_PeriodisedValues, dataStoreCache.Get<ESF_LearningDeliveryDeliverable_PeriodisedValue>(), sqlConnection, cancellationToken);
        }

        public async Task PersistFM36HistoryDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.AppEarnHistory, dataStoreCache.Get<AppsEarningsHistory>(), sqlConnection, cancellationToken);
        }

        public async Task PersistValidLearnerDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.ValidCollectionDetails, dataStoreCache.Get<CollectionDetail>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearningProvider, dataStoreCache.Get<LearningProvider>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidSource, dataStoreCache.Get<Source>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidSourceFile, dataStoreCache.Get<SourceFile>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidAppFinRecord, dataStoreCache.Get<AppFinRecord>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidContactPreference, dataStoreCache.Get<ContactPreference>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidEmploymentStatusMonitoring, dataStoreCache.Get<EmploymentStatusMonitoring>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearner, dataStoreCache.Get<Learner>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearnerEmploymentStatus, dataStoreCache.Get<LearnerEmploymentStatus>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearnerFAM, dataStoreCache.Get<LearnerFAM>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearnerHE, dataStoreCache.Get<LearnerHE>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearnerHEFinancialSupport, dataStoreCache.Get<LearnerHEFinancialSupport>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearningDelivery, dataStoreCache.Get<LearningDelivery>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearningDeliveryFAM, dataStoreCache.Get<LearningDeliveryFAM>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearningDeliveryHE, dataStoreCache.Get<LearningDeliveryHE>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearningDeliveryWorkPlacement, dataStoreCache.Get<LearningDeliveryWorkPlacement>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLLDDandHealthProblem, dataStoreCache.Get<LLDDandHealthProblem>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidProviderSpecDeliveryMonitoring, dataStoreCache.Get<ProviderSpecDeliveryMonitoring>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidProviderSpecLearnerMonitoring, dataStoreCache.Get<ProviderSpecLearnerMonitoring>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidDPOutcome, dataStoreCache.Get<DPOutcome>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearnerDestinationandProgression, dataStoreCache.Get<LearnerDestinationandProgression>(), sqlConnection, cancellationToken);
        }

        public async Task PersistInvalidLearnerDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.InvalidCollectionDetails, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.CollectionDetail>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearningProvider, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.LearningProvider>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidSource, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.Source>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidSourceFile, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.SourceFile>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidAppFinRecord, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.AppFinRecord>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidContactPreference, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.ContactPreference>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidEmploymentStatusMonitoring, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.EmploymentStatusMonitoring>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearner, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.Learner>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearnerEmploymentStatus, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.LearnerEmploymentStatus>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearnerFAM, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.LearnerFAM>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearnerHE, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.LearnerHE>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearnerHEFinancialSupport, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.LearnerHEFinancialSupport>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearningDelivery, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.LearningDelivery>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearningDeliveryFAM, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.LearningDeliveryFAM>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearningDeliveryHE, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.LearningDeliveryHE>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearningDeliveryWorkPlacement, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.LearningDeliveryWorkPlacement>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLLDDandHealthProblem, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.LLDDandHealthProblem>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidProviderSpecDeliveryMonitoring, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.ProviderSpecDeliveryMonitoring>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidProviderSpecLearnerMonitoring, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.ProviderSpecLearnerMonitoring>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidDPOutcome, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.DPOutcome>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearnerDestinationandProgression, dataStoreCache.Get<ILR1920.DataStore.EF.Invalid.LearnerDestinationandProgression>(), sqlConnection, cancellationToken);
        }

        public async Task PersistProcessingInformationDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            long fileDetailsId;

            using (SqlCommand sqlCommand = new SqlCommand(BuildInsertFileDetailsSql(dataStoreCache.Get<FileDetail>().Single()), sqlConnection))
            {
                fileDetailsId = (long)await sqlCommand.ExecuteScalarAsync(cancellationToken);
            }

            using (SqlCommand sqlCommand = new SqlCommand(BuildInsertProcessingDataSql(fileDetailsId, dataStoreCache.Get<ProcessingData>().Single()), sqlConnection))
            {
                await sqlCommand.ExecuteNonQueryAsync(cancellationToken);
            }
        }

        private string BuildInsertFileDetailsSql(FileDetail fileDetail)
        {
            return $"INSERT INTO [dbo].[FileDetails] ([UKPRN], [Filename], [FileSizeKb], [TotalLearnersSubmitted], [TotalValidLearnersSubmitted], [TotalInvalidLearnersSubmitted], [TotalErrorCount], [TotalWarningCount], [SubmittedTime], [Success]) output INSERTED.ID VALUES ({fileDetail.UKPRN}, '{fileDetail.Filename}', {fileDetail.FileSizeKb}, {fileDetail.TotalLearnersSubmitted}, {fileDetail.TotalValidLearnersSubmitted}, {fileDetail.TotalInvalidLearnersSubmitted}, {fileDetail.TotalErrorCount}, {fileDetail.TotalWarningCount}, '{fileDetail.SubmittedTime:yyyy/MM/dd HH:mm:ss}', 1)";
        }

        private string BuildInsertProcessingDataSql(long fileDetailsId, ProcessingData processingData)
        {
            return $"INSERT INTO [dbo].[ProcessingData] ([UKPRN], [FileDetailsID], [ProcessingStep], [ExecutionTime]) VALUES ({processingData.UKPRN}, {fileDetailsId}, '{processingData.ProcessingStep}', '{processingData.ExecutionTime}')";
        }
    }
}
