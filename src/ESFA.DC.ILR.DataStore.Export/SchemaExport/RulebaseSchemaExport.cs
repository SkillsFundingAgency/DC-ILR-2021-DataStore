﻿using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Access;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR.DataStore.Export.Mappers.dbo;
using ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.SchemaExport
{
    public class RulebaseSchemaExport : AbstractSchemaExport, ISchemaExport
    {
        public RulebaseSchemaExport(IExport export)
            : base(new RulebaseMdbContext(), export)
        {
        }

        public async Task ExportAsync(IDataStoreCache dataStoreCache, OleDbConnection connection, OleDbTransaction transaction, string exportPath,
            CancellationToken cancellationToken)
        {
            await ExportTableAsync<AEC_global, AECglobalClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<AEC_Learner, AECLearnerClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<AEC_LearningDelivery, AECLearningDeliveryClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<AEC_LearningDelivery_Period, AECLearningDeliveryPeriodClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<AEC_LearningDelivery_PeriodisedTextValue, AECLearningDeliveryPeriodisedTextValuesClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<AEC_LearningDelivery_PeriodisedValue, AECLearningDeliveryPeriodisedValuesClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<AEC_ApprenticeshipPriceEpisode, AECApprenticeshipPriceEpisodeClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<AEC_ApprenticeshipPriceEpisode_Period, AECApprenticeshipPriceEpisodePeriodClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<AEC_ApprenticeshipPriceEpisode_PeriodisedValue, AECApprenticeshipPriceEpisodePeriodisedValueClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<AEC_HistoricEarningOutput, AECHistoricEarningOutputClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ALB_global, ALBglobalClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ALB_Learner, ALBLearnerClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ALB_Learner_Period, ALBLearnerPeriodClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ALB_Learner_PeriodisedValue, ALBLearnerPeriodisedValuesClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ALB_LearningDelivery, ALBLearningDeliveryClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ALB_LearningDelivery_Period, ALBLearningDeliveryPeriodClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ALB_LearningDelivery_PeriodisedValue, ALBLearningDeliveryPeriodisedValuesClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<DV_global, DVglobalClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<DV_Learner, DVLearnerClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<DV_LearningDelivery, DVLearningDeliveryClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ESF_global, ESFglobalClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ESF_Learner, ESFLearnerClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ESF_LearningDelivery, ESFLearningDeliveryClassMap>( exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ESF_LearningDelivery, ESFLearningDeliveryClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ESF_LearningDeliveryDeliverable, ESFLearningDeliveryDeliverableClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ESF_LearningDeliveryDeliverable_Period, ESFLearningDeliveryDeliverablePeriodClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ESF_LearningDeliveryDeliverable_PeriodisedValue, ESFLearningDeliveryDeliverablePeriodisedValuesClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ESF_DPOutcome, ESFDPOutcomeClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<FM25_global, FM25globalClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<FM25_Learner, FM25LearnerClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<FM35_global, FM35globalClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<FM35_Learner, FM35LearnerClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<FM35_LearningDelivery, FM35LearningDeliveryClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<FM35_LearningDelivery_Period, FM35LearningDeliveryPeriodClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<FM35_LearningDelivery_PeriodisedValue, FM35LearningDeliveryPeriodisedValuesClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<FM25_FM35_global, FM25FM35globalClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<FM25_FM35_Learner_Period, FM25FM35LearnerPeriodClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<FM25_FM35_Learner_PeriodisedValue, FM25FM35LearnerPeriodisedValuesClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<TBL_global, TBLglobalClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<TBL_Learner, TBLLearnerClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<TBL_LearningDelivery, TBLLearningDeliveryClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<TBL_LearningDelivery_Period, TBLLearningDeliveryPeriodClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<TBL_LearningDelivery_PeriodisedValue, TBLLearningDeliveryPeriodsedValuesClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);

            await ExportTableAsync<ValidationError, ValidationErrorClassMap>(exportPath, dataStoreCache, connection, transaction, cancellationToken);
        }
    }
}
