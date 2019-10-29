using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR.DataStore.Export.Mappers.dbo;
using ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export
{
    public class RulebaseSchemaExport : ISchemaExport
    {
        private readonly IExport _export;

        public RulebaseSchemaExport(IExport export)
        {
            _export = export;
        }

        public async Task ExportAsync(IDataStoreCache dataStoreCache, OleDbConnection connection, OleDbTransaction transaction, string exportPath,
            CancellationToken cancellationToken)
        {
            await _export.ExportAsync<AEC_global, AECglobalClassMap>(TableNameConstants.RulebaseAECglobal, dataStoreCache.Get<AEC_global>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<AEC_Learner, AECLearnerClassMap>(TableNameConstants.RulebaseAECLearner, dataStoreCache.Get<AEC_Learner>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<AEC_LearningDelivery, AECLearningDeliveryClassMap>(TableNameConstants.RulebaseAECLearningDelivery, dataStoreCache.Get<AEC_LearningDelivery>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<AEC_LearningDelivery_Period, AECLearningDeliveryPeriodClassMap>(TableNameConstants.RulebaseAECLearningDeliveryPeriod, dataStoreCache.Get<AEC_LearningDelivery_Period>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<AEC_LearningDelivery_PeriodisedTextValue, AECLearningDeliveryPeriodisedTextValuesClassMap>(TableNameConstants.RulebaseAECLearningDeliveryPeriodisedTextValues, dataStoreCache.Get<AEC_LearningDelivery_PeriodisedTextValue>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<AEC_LearningDelivery_PeriodisedValue, AECLearningDeliveryPeriodisedValuesClassMap>(TableNameConstants.RulebaseAECLearningDeliveryPeriodisedValues, dataStoreCache.Get<AEC_LearningDelivery_PeriodisedValue>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<AEC_ApprenticeshipPriceEpisode, AECApprenticeshipPriceEpisodeClassMap>(TableNameConstants.RulebaseAECApprenticeshipPriceEpisode, dataStoreCache.Get<AEC_ApprenticeshipPriceEpisode>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<AEC_ApprenticeshipPriceEpisode_Period, AECApprenticeshipPriceEpisodePeriodClassMap>(TableNameConstants.RulebaseAECApprenticeshipPriceEpisodePeriod, dataStoreCache.Get<AEC_ApprenticeshipPriceEpisode_Period>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<AEC_ApprenticeshipPriceEpisode_PeriodisedValue, AECApprenticeshipPriceEpisodePeriodisedValueClassMap>(TableNameConstants.RulebaseAECApprenticeshipPriceEpisodePeriodisedValues, dataStoreCache.Get<AEC_ApprenticeshipPriceEpisode_PeriodisedValue>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<AEC_HistoricEarningOutput, AECHistoricEarningOutputClassMap>(TableNameConstants.RulebaseAECHistoricEarningOutput, dataStoreCache.Get<AEC_HistoricEarningOutput>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ALB_global, ALBglobalClassMap>(TableNameConstants.RulebaseALBglobal, dataStoreCache.Get<ALB_global>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ALB_Learner, ALBLearnerClassMap>(TableNameConstants.RulebaseALBLearner, dataStoreCache.Get<ALB_Learner>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ALB_Learner_Period, ALBLearnerPeriodClassMap>(TableNameConstants.RulebaseALBLearnerPeriod, dataStoreCache.Get<ALB_Learner_Period>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ALB_Learner_PeriodisedValue, ALBLearnerPeriodisedValuesClassMap>(TableNameConstants.RulebaseALBLearnerPeriodisedValues, dataStoreCache.Get<ALB_Learner_PeriodisedValue>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ALB_LearningDelivery, ALBLearningDeliveryClassMap>(TableNameConstants.RulebaseALBLearningDelivery, dataStoreCache.Get<ALB_LearningDelivery>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ALB_LearningDelivery_Period, ALBLearningDeliveryPeriodClassMap>(TableNameConstants.RulebaseALBLearningDeliveryPeriod, dataStoreCache.Get<ALB_LearningDelivery_Period>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ALB_LearningDelivery_PeriodisedValue, ALBLearningDeliveryPeriodisedValuesClassMap>(TableNameConstants.RulebaseALBLearningDeliveryPeriodisedValues, dataStoreCache.Get<ALB_LearningDelivery_PeriodisedValue>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<DV_global, DVglobalClassMap>(TableNameConstants.RulebaseDVglobal, dataStoreCache.Get<DV_global>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<DV_Learner, DVLearnerClassMap>(TableNameConstants.RulebaseDVLearner, dataStoreCache.Get<DV_Learner>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<DV_LearningDelivery, DVLearningDeliveryClassMap>(TableNameConstants.RulebaseDVLearningDelivery, dataStoreCache.Get<DV_LearningDelivery>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ESF_global, ESFglobalClassMap>(TableNameConstants.RulebaseESFglobal, dataStoreCache.Get<ESF_global>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ESF_Learner, ESFLearnerClassMap>(TableNameConstants.RulebaseESFLearner, dataStoreCache.Get<ESF_Learner>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ESF_LearningDelivery, ESFLearningDeliveryClassMap>(TableNameConstants.RulebaseESFLearningDelivery, dataStoreCache.Get<ESF_LearningDelivery>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ESF_LearningDelivery, ESFLearningDeliveryClassMap>(TableNameConstants.RulebaseESFLearningDelivery, dataStoreCache.Get<ESF_LearningDelivery>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ESF_LearningDeliveryDeliverable, ESFLearningDeliveryDeliverableClassMap>(TableNameConstants.RulebaseESFLearningDeliveryDeliverable, dataStoreCache.Get<ESF_LearningDeliveryDeliverable>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ESF_LearningDeliveryDeliverable_Period, ESFLearningDeliveryDeliverablePeriodClassMap>(TableNameConstants.RulebaseESFLearningDeliveryDeliverablePeriod, dataStoreCache.Get<ESF_LearningDeliveryDeliverable_Period>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ESF_LearningDeliveryDeliverable_PeriodisedValue, ESFLearningDeliveryDeliverablePeriodisedValuesClassMap>(TableNameConstants.RulebaseESFLearningDeliveryDeliverablePeriodisedValues, dataStoreCache.Get<ESF_LearningDeliveryDeliverable_PeriodisedValue>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ESF_DPOutcome, ESFDPOutcomeClassMap>(TableNameConstants.RulebaseESFDPOutcome, dataStoreCache.Get<ESF_DPOutcome>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<FM25_global, FM25globalClassMap>(TableNameConstants.RulebaseFM25global, dataStoreCache.Get<FM25_global>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<FM25_Learner, FM25LearnerClassMap>(TableNameConstants.RulebaseFM25Learner, dataStoreCache.Get<FM25_Learner>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<FM35_global, FM35globalClassMap>(TableNameConstants.RulebaseFM35global, dataStoreCache.Get<FM35_global>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<FM35_Learner, FM35LearnerClassMap>(TableNameConstants.RulebaseFM35Learner, dataStoreCache.Get<FM35_Learner>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<FM35_LearningDelivery, FM35LearningDeliveryClassMap>(TableNameConstants.RulebaseFM35LearningDelivery, dataStoreCache.Get<FM35_LearningDelivery>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<FM35_LearningDelivery_Period, FM35LearningDeliveryPeriodClassMap>(TableNameConstants.RulebaseFM35LearningDeliveryPeriod, dataStoreCache.Get<FM35_LearningDelivery_Period>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<FM35_LearningDelivery_PeriodisedValue, FM35LearningDeliveryPeriodisedValuesClassMap>(TableNameConstants.RulebaseFM35LearningDeliveryPeriodisedValues, dataStoreCache.Get<FM35_LearningDelivery_PeriodisedValue>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<FM25_FM35_global, FM25FM35globalClassMap>(TableNameConstants.RulebaseFM25FM35global, dataStoreCache.Get<FM25_FM35_global>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<FM25_FM35_Learner_Period, FM25FM35LearnerPeriodClassMap>(TableNameConstants.RulebaseFM25FM35LearnerPeriod, dataStoreCache.Get<FM25_FM35_Learner_Period>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<FM25_FM35_Learner_PeriodisedValue, FM25FM35LearnerPeriodisedValuesClassMap>(TableNameConstants.RulebaseFM25FM35LearnerPeriodisedValues, dataStoreCache.Get<FM25_FM35_Learner_PeriodisedValue>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<TBL_global, TBLglobalClassMap>(TableNameConstants.RulebaseTBLglobal, dataStoreCache.Get<TBL_global>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<TBL_Learner, TBLLearnerClassMap>(TableNameConstants.RulebaseTBLLearner, dataStoreCache.Get<TBL_Learner>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<TBL_LearningDelivery, TBLLearningDeliveryClassMap>(TableNameConstants.RulebaseTBLLearningDelivery, dataStoreCache.Get<TBL_LearningDelivery>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<TBL_LearningDelivery_Period, TBLLearningDeliveryPeriodClassMap>(TableNameConstants.RulebaseTBLLearningDeliveryPeriod, dataStoreCache.Get<TBL_LearningDelivery_Period>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<TBL_LearningDelivery_PeriodisedValue, TBLLearningDeliveryPeriodsedValuesClassMap>(TableNameConstants.RulebaseTBLLearningDeliveryPeriodisedValues, dataStoreCache.Get<TBL_LearningDelivery_PeriodisedValue>(), exportPath, connection, transaction, cancellationToken);

            await _export.ExportAsync<ValidationError, ValidationErrorClassMap>(TableNameConstants.dboValidationError, dataStoreCache.Get<ValidationError>(), exportPath, connection, transaction, cancellationToken);
        }
    }
}
