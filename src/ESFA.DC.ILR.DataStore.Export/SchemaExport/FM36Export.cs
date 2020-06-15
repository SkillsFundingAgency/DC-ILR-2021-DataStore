using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Access;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR.DataStore.Export.Mappers;
using ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR2021.DataStore.EF;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.Export.SchemaExport
{
    public class FM36Export : AbstractSchemaExport, IOrderedExport
    {
        public FM36Export(IExport export, ILogger logger) 
            : base(new RulebaseMdbContext(), export, logger, Constants.TaskExportFM36Tables, 10)
        {
        }

        public async Task ExportAsync(IDataStoreCache dataStoreCache, OleDbConnection connection, string exportPath,
            CancellationToken cancellationToken)
        {
            await ExportTableAsync<AEC_global, AECglobalClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<AEC_Learner, AECLearnerClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<AEC_LearningDelivery, AECLearningDeliveryClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<AEC_LearningDelivery_Period, AECLearningDeliveryPeriodClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<AEC_LearningDelivery_PeriodisedTextValue, AECLearningDeliveryPeriodisedTextValuesClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<AEC_LearningDelivery_PeriodisedValue, AECLearningDeliveryPeriodisedValuesClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<AEC_ApprenticeshipPriceEpisode, AECApprenticeshipPriceEpisodeClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<AEC_ApprenticeshipPriceEpisode_Period, AECApprenticeshipPriceEpisodePeriodClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<AEC_ApprenticeshipPriceEpisode_PeriodisedValue, AECApprenticeshipPriceEpisodePeriodisedValueClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<AEC_HistoricEarningOutput, DefaultTableClassMap<AEC_HistoricEarningOutput>>(exportPath, dataStoreCache, connection, cancellationToken);
        }
    }
}
