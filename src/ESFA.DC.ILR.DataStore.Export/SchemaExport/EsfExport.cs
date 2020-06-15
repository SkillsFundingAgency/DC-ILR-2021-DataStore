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
    public class EsfExport : AbstractSchemaExport, IOrderedExport
    {
        public EsfExport(IExport export, ILogger logger) 
            : base(new RulebaseMdbContext(), export, logger, Constants.TaskExportEsfTables, 6)
        {
        }

        public async Task ExportAsync(IDataStoreCache dataStoreCache, OleDbConnection connection, string exportPath,
            CancellationToken cancellationToken)
        {
            await ExportTableAsync<ESF_global, ESFglobalClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<ESF_Learner, ESFLearnerClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<ESF_LearningDelivery, ESFLearningDeliveryClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<ESF_LearningDelivery, ESFLearningDeliveryClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<ESF_LearningDeliveryDeliverable, ESFLearningDeliveryDeliverableClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<ESF_LearningDeliveryDeliverable_Period, ESFLearningDeliveryDeliverablePeriodClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<ESF_LearningDeliveryDeliverable_PeriodisedValue, ESFLearningDeliveryDeliverablePeriodisedValuesClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<ESF_DPOutcome, DefaultTableClassMap<ESF_DPOutcome>>(exportPath, dataStoreCache, connection, cancellationToken);
        }
    }
}
