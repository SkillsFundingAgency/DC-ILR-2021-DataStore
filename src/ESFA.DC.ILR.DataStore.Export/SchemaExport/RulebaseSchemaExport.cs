using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Access;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR.DataStore.Export.Mappers;
using ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR1920.DataStore.EF;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.Export.SchemaExport
{
    public class RulebaseSchemaExport : AbstractSchemaExport, ISchemaExport
    {
        public RulebaseSchemaExport(IExport export, ILogger logger)
            : base(new RulebaseMdbContext(), export, logger)
        {
        }

        public async Task ExportAsync(IDataStoreCache dataStoreCache, OleDbConnection connection, string exportPath,
            CancellationToken cancellationToken)
        {
            await ExportTableAsync<AEC_global, AECglobalClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<AEC_Learner, AECLearnerClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<AEC_LearningDelivery, AECLearningDeliveryClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<AEC_LearningDelivery_Period, AECLearningDeliveryPeriodClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<AEC_LearningDelivery_PeriodisedTextValue, AECLearningDeliveryPeriodisedTextValuesClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<AEC_LearningDelivery_PeriodisedValue, AECLearningDeliveryPeriodisedValuesClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<AEC_ApprenticeshipPriceEpisode, AECApprenticeshipPriceEpisodeClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<AEC_ApprenticeshipPriceEpisode_Period, AECApprenticeshipPriceEpisodePeriodClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<AEC_ApprenticeshipPriceEpisode_PeriodisedValue, AECApprenticeshipPriceEpisodePeriodisedValueClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<AEC_HistoricEarningOutput, DefaultTableClassMap<AEC_HistoricEarningOutput>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ALB_global, ALBglobalClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ALB_Learner, ALBLearnerClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ALB_Learner_Period, ALBLearnerPeriodClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ALB_Learner_PeriodisedValue, ALBLearnerPeriodisedValuesClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ALB_LearningDelivery, ALBLearningDeliveryClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ALB_LearningDelivery_Period, ALBLearningDeliveryPeriodClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ALB_LearningDelivery_PeriodisedValue, ALBLearningDeliveryPeriodisedValuesClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<DV_global, DVglobalClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<DV_Learner, DVLearnerClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<DV_LearningDelivery, DVLearningDeliveryClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ESF_global, ESFglobalClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ESF_Learner, ESFLearnerClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ESF_LearningDelivery, ESFLearningDeliveryClassMap>( exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ESF_LearningDelivery, ESFLearningDeliveryClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ESF_LearningDeliveryDeliverable, ESFLearningDeliveryDeliverableClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ESF_LearningDeliveryDeliverable_Period, ESFLearningDeliveryDeliverablePeriodClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ESF_LearningDeliveryDeliverable_PeriodisedValue, ESFLearningDeliveryDeliverablePeriodisedValuesClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ESF_DPOutcome, DefaultTableClassMap<ESF_DPOutcome>>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<FM25_global, FM25globalClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<FM25_Learner, FM25LearnerClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<FM35_global, FM35globalClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<FM35_Learner, FM35LearnerClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<FM35_LearningDelivery, FM35LearningDeliveryClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<FM35_LearningDelivery_Period, FM35LearningDeliveryPeriodClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<FM35_LearningDelivery_PeriodisedValue, FM35LearningDeliveryPeriodisedValuesClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<FM25_FM35_global, FM25FM35globalClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<FM25_FM35_Learner_Period, FM25FM35LearnerPeriodClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<FM25_FM35_Learner_PeriodisedValue, FM25FM35LearnerPeriodisedValuesClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<TBL_global, TBLglobalClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<TBL_Learner, TBLLearnerClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<TBL_LearningDelivery, TBLLearningDeliveryClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<TBL_LearningDelivery_Period, TBLLearningDeliveryPeriodClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<TBL_LearningDelivery_PeriodisedValue, TBLLearningDeliveryPeriodsedValuesClassMap>(exportPath, dataStoreCache, connection,  cancellationToken);

            await ExportTableAsync<ValidationError, DefaultTableClassMap<ValidationError>>(exportPath, dataStoreCache, connection,  cancellationToken);
        }
    }
}
