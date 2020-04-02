using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.Data.AppsEarningsHistory.Model;
using ESFA.DC.ESF.FundingData.Database.EF;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.PersistData.Constants;
using ESFA.DC.ILR.DataStore.PersistData.Helpers;
using ESFA.DC.ILR2021.DataStore.EF;
using ESFA.DC.ILR2021.DataStore.EF.Valid;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Telemetry.Interfaces;

namespace ESFA.DC.ILR.DataStore.PersistData.Persist
{
    public sealed class PersistenceService : IPersistenceService
    {
        private readonly IBulkInsert _bulkInsert;
        private readonly ITelemetry _telemetry;
        private readonly ILogger _logger;

        public PersistenceService(IBulkInsert bulkInsert, ILogger logger, ITelemetry telemetry)
        {
            _bulkInsert = bulkInsert;
            _logger = logger;
            _telemetry = telemetry;
        }

        public async Task PersistValidationDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.ValidationError, dataStoreCache.Get<ValidationError>(), sqlConnection, sqlTransaction, cancellationToken);
        }

        public async Task PersistFM25DataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.FM25_global, dataStoreCache.Get<FM25_global>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM25_Learner, dataStoreCache.Get<FM25_Learner>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM25_FM35_global, dataStoreCache.Get<FM25_FM35_global>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM25_FM35_Learner_Period, dataStoreCache.Get<FM25_FM35_Learner_Period>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM25_FM35_Learner_PeriodisedValues, dataStoreCache.Get<FM25_FM35_Learner_PeriodisedValue>(), sqlConnection, sqlTransaction, cancellationToken);
        }

        public async Task PersistALBDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.ALB_global, dataStoreCache.Get<ALB_global>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ALB_Learner, dataStoreCache.Get<ALB_Learner>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ALB_Learner_Period, dataStoreCache.Get<ALB_Learner_Period>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ALB_Learner_PeriodisedValues, dataStoreCache.Get<ALB_Learner_PeriodisedValue>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ALB_LearningDelivery, dataStoreCache.Get<ALB_LearningDelivery>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ALB_LearningDelivery_Period, dataStoreCache.Get<ALB_LearningDelivery_Period>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ALB_LearningDelivery_PeriodisedValues, dataStoreCache.Get<ALB_LearningDelivery_PeriodisedValue>(), sqlConnection, sqlTransaction, cancellationToken);
        }

        public async Task PersistFM35DataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.FM35_global, dataStoreCache.Get<FM35_global>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM35_Learner, dataStoreCache.Get<FM35_Learner>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM35_LearningDelivery, dataStoreCache.Get<FM35_LearningDelivery>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM35_LearningDelivery_Period, dataStoreCache.Get<FM35_LearningDelivery_Period>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM35_LearningDelivery_PeriodisedValues, dataStoreCache.Get<FM35_LearningDelivery_PeriodisedValue>(), sqlConnection, sqlTransaction, cancellationToken);
        }

        public async Task PersistFM36DataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.FM36_global, dataStoreCache.Get<AEC_global>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM36_Learner, dataStoreCache.Get<AEC_Learner>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM36_LearningDelivery, dataStoreCache.Get<AEC_LearningDelivery>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM36_LearningDelivery_Period, dataStoreCache.Get<AEC_LearningDelivery_Period>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM36_LearningDelivery_PeriodisedValues, dataStoreCache.Get<AEC_LearningDelivery_PeriodisedValue>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM36_LearningDelivery_PeriodisedTextValues, dataStoreCache.Get<AEC_LearningDelivery_PeriodisedTextValue>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM36_PriceEpisodes, dataStoreCache.Get<AEC_ApprenticeshipPriceEpisode>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM36_PriceEpisode_Period, dataStoreCache.Get<AEC_ApprenticeshipPriceEpisode_Period>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM36_PriceEpisode_PeriodisedValues, dataStoreCache.Get<AEC_ApprenticeshipPriceEpisode_PeriodisedValue>(), sqlConnection, sqlTransaction, cancellationToken);
        }

        public async Task PersistFM81DataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.FM81_global, dataStoreCache.Get<TBL_global>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM81_Learner, dataStoreCache.Get<TBL_Learner>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM81_LearningDelivery, dataStoreCache.Get<TBL_LearningDelivery>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM81_LearningDelivery_Period, dataStoreCache.Get<TBL_LearningDelivery_Period>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM81_LearningDelivery_PeriodisedValues, dataStoreCache.Get<TBL_LearningDelivery_PeriodisedValue>(), sqlConnection, sqlTransaction, cancellationToken);
        }

        public async Task PersistFM70DataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.FM70_global, dataStoreCache.Get<ESF_global>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM70_Learner, dataStoreCache.Get<ESF_Learner>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM70_DPOutcome, dataStoreCache.Get<ESF_DPOutcome>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM70_LearningDelivery, dataStoreCache.Get<ESF_LearningDelivery>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM70_LearningDeliveryDeliverable, dataStoreCache.Get<ESF_LearningDeliveryDeliverable>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM70_LearningDeliveryDeliverable_Period, dataStoreCache.Get<ESF_LearningDeliveryDeliverable_Period>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.FM70_LearningDeliveryDeliverable_PeriodisedValues, dataStoreCache.Get<ESF_LearningDeliveryDeliverable_PeriodisedValue>(), sqlConnection, sqlTransaction, cancellationToken);
        }

        public async Task PersistFM36HistoryDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.AppEarnHistory, dataStoreCache.Get<AppsEarningsHistory>(), sqlConnection, sqlTransaction, cancellationToken);
        }

        public async Task PersistValidLearnerDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.ValidCollectionDetails, dataStoreCache.Get<CollectionDetail>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearningProvider, dataStoreCache.Get<LearningProvider>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidSource, dataStoreCache.Get<Source>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidSourceFile, dataStoreCache.Get<SourceFile>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidAppFinRecord, dataStoreCache.Get<AppFinRecord>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidContactPreference, dataStoreCache.Get<ContactPreference>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidEmploymentStatusMonitoring, dataStoreCache.Get<EmploymentStatusMonitoring>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearner, dataStoreCache.Get<Learner>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearnerEmploymentStatus, dataStoreCache.Get<LearnerEmploymentStatus>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearnerFAM, dataStoreCache.Get<LearnerFAM>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearnerHE, dataStoreCache.Get<LearnerHE>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearnerHEFinancialSupport, dataStoreCache.Get<LearnerHEFinancialSupport>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearningDelivery, dataStoreCache.Get<LearningDelivery>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearningDeliveryFAM, dataStoreCache.Get<LearningDeliveryFAM>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearningDeliveryHE, dataStoreCache.Get<LearningDeliveryHE>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearningDeliveryWorkPlacement, dataStoreCache.Get<LearningDeliveryWorkPlacement>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLLDDandHealthProblem, dataStoreCache.Get<LLDDandHealthProblem>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidProviderSpecDeliveryMonitoring, dataStoreCache.Get<ProviderSpecDeliveryMonitoring>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidProviderSpecLearnerMonitoring, dataStoreCache.Get<ProviderSpecLearnerMonitoring>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidDPOutcome, dataStoreCache.Get<DPOutcome>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.ValidLearnerDestinationandProgression, dataStoreCache.Get<LearnerDestinationandProgression>(), sqlConnection, sqlTransaction, cancellationToken);
        }

        public async Task PersistInvalidLearnerDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.InvalidCollectionDetails, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.CollectionDetail>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearningProvider, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.LearningProvider>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidSource, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.Source>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidSourceFile, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.SourceFile>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidAppFinRecord, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.AppFinRecord>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidContactPreference, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.ContactPreference>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidEmploymentStatusMonitoring, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.EmploymentStatusMonitoring>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearner, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.Learner>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearnerEmploymentStatus, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.LearnerEmploymentStatus>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearnerFAM, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.LearnerFAM>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearnerHE, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.LearnerHE>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearnerHEFinancialSupport, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.LearnerHEFinancialSupport>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearningDelivery, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.LearningDelivery>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearningDeliveryFAM, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.LearningDeliveryFAM>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearningDeliveryHE, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.LearningDeliveryHE>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearningDeliveryWorkPlacement, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.LearningDeliveryWorkPlacement>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLLDDandHealthProblem, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.LLDDandHealthProblem>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidProviderSpecDeliveryMonitoring, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.ProviderSpecDeliveryMonitoring>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidProviderSpecLearnerMonitoring, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.ProviderSpecLearnerMonitoring>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidDPOutcome, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.DPOutcome>(), sqlConnection, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(TableNameConstants.InvalidLearnerDestinationandProgression, dataStoreCache.Get<ILR2021.DataStore.EF.Invalid.LearnerDestinationandProgression>(), sqlConnection, sqlTransaction, cancellationToken);
        }

        public async Task PersistProcessingInformationDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            long fileDetailsId;

            var fileDetails = dataStoreCache.Get<FileDetail>().Single();

            SendTelemetry(fileDetails);

            using (SqlCommand sqlCommand = new SqlCommand(BuildInsertFileDetailsSql(), sqlConnection, sqlTransaction))
            {
                sqlCommand.Parameters.AddWithNullableValue("@UKPRN", fileDetails.UKPRN);
                sqlCommand.Parameters.AddWithNullableValue("@FileName", fileDetails.Filename);
                sqlCommand.Parameters.AddWithNullableValue("@FileSizeKb", fileDetails.FileSizeKb);
                sqlCommand.Parameters.AddWithNullableValue("@TotalLearnersSubmitted", fileDetails.TotalLearnersSubmitted);
                sqlCommand.Parameters.AddWithNullableValue("@TotalValidLearnersSubmitted", fileDetails.TotalValidLearnersSubmitted);
                sqlCommand.Parameters.AddWithNullableValue("@TotalInvalidLearnersSubmitted", fileDetails.TotalInvalidLearnersSubmitted);
                sqlCommand.Parameters.AddWithNullableValue("@TotalErrorCount", fileDetails.TotalErrorCount);
                sqlCommand.Parameters.AddWithNullableValue("@TotalWarningCount", fileDetails.TotalWarningCount);
                sqlCommand.Parameters.AddWithNullableValue("@SubmittedTime", fileDetails.SubmittedTime);
                sqlCommand.Parameters.AddWithNullableValue("@Success", fileDetails.Success);
                sqlCommand.Parameters.AddWithNullableValue("@OrgName", fileDetails.OrgName);
                sqlCommand.Parameters.AddWithNullableValue("@OrgVersion", fileDetails.OrgVersion);
                sqlCommand.Parameters.AddWithNullableValue("@LarsVersion", fileDetails.LarsVersion);
                sqlCommand.Parameters.AddWithNullableValue("@EmployersVersion", fileDetails.EmployersVersion);
                sqlCommand.Parameters.AddWithNullableValue("@PostcodesVersion", fileDetails.PostcodesVersion);
                sqlCommand.Parameters.AddWithNullableValue("@CampusIdentifierVersion", fileDetails.CampusIdentifierVersion);
                sqlCommand.Parameters.AddWithNullableValue("@EasUploadDateTime", fileDetails.EasUploadDateTime);

                fileDetailsId = (long)await sqlCommand.ExecuteScalarAsync(cancellationToken);
            }

            using (SqlCommand sqlCommand = new SqlCommand(BuildInsertProcessingDataSql(fileDetailsId, dataStoreCache.Get<ProcessingData>().Single()), sqlConnection, sqlTransaction))
            {
                await sqlCommand.ExecuteNonQueryAsync(cancellationToken);
            }
        }

        private void SendTelemetry(FileDetail fileDetails)
        {
            _telemetry.TrackEvent("ILR.JobFileDetails",
                new Dictionary<string, string>
                {
                    { "Ukprn", fileDetails.UKPRN.ToString() },
                    { "FileSizeKb", fileDetails.FileSizeKb.ToString() }
                },
                new Dictionary<string, double>
                {
                    { "ILR.TotalLearnersSubmitted", (double)fileDetails.TotalLearnersSubmitted },
                    { "ILR.TotalValidLearnersSubmitted", (double)fileDetails.TotalValidLearnersSubmitted },
                    { "ILR.TotalInvalidLearnersSubmitted", (double)fileDetails.TotalInvalidLearnersSubmitted },
                    { "ILR.TotalErrorCount", (double)fileDetails.TotalErrorCount },
                    { "ILR.TotalWarningCount", (double)fileDetails.TotalWarningCount }
                }
            );
        }

        public async Task PersistESFSummarisationDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.ESF_FundingData, dataStoreCache.Get<ESFFundingData>(), sqlConnection, sqlTransaction, cancellationToken);
        }

        public async Task PersistESFLatestProviderSubmissionAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(TableNameConstants.ESF_LatestProviderSubmission, dataStoreCache.Get<LatestProviderSubmission>(), sqlConnection, sqlTransaction, cancellationToken);
        }

        private string BuildInsertFileDetailsSql()
        {
            return @"INSERT INTO [dbo].[FileDetails]
                   ([UKPRN], [Filename], [FileSizeKb], [TotalLearnersSubmitted], [TotalValidLearnersSubmitted], [TotalInvalidLearnersSubmitted], [TotalErrorCount], [TotalWarningCount], [SubmittedTime], [Success], [OrgName], [OrgVersion], [LarsVersion], [EmployersVersion], [PostcodesVersion], [CampusIdentifierVersion], [EasUploadDateTime]) output INSERTED.ID
                   VALUES (@UKPRN, @FileName, @FileSizeKb, @TotalLearnersSubmitted, @TotalValidLearnersSubmitted, @TotalInvalidLearnersSubmitted, @TotalErrorCount, @TotalWarningCount, @SubmittedTime, @Success, @OrgName, @OrgVersion, @LarsVersion, @EmployersVersion, @PostcodesVersion, @CampusIdentifierVersion, @EasUploadDateTime)";
        }

        private string BuildInsertProcessingDataSql(long fileDetailsId, ProcessingData processingData)
        {
            return $"INSERT INTO [dbo].[ProcessingData] ([UKPRN], [FileDetailsID], [ProcessingStep], [ExecutionTime]) VALUES ({processingData.UKPRN}, {fileDetailsId}, '{processingData.ProcessingStep}', '{processingData.ExecutionTime}')";
        }
    }
}
