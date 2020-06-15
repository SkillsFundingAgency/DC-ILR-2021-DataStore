using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Access;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR2021.DataStore.EF;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.Export.SchemaExport
{
    public class TBLExport : AbstractSchemaExport, IOrderedExport
    {
        public TBLExport(IExport export, ILogger logger) 
            : base(new RulebaseMdbContext(), export, logger, Constants.TaskExportTblTables, 11)
        {
        }

        public async Task ExportAsync(IDataStoreCache dataStoreCache, OleDbConnection connection, string exportPath, CancellationToken cancellationToken)
        {
            await ExportTableAsync<TBL_global, TBLglobalClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<TBL_Learner, TBLLearnerClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<TBL_LearningDelivery, TBLLearningDeliveryClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<TBL_LearningDelivery_Period, TBLLearningDeliveryPeriodClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<TBL_LearningDelivery_PeriodisedValue, TBLLearningDeliveryPeriodsedValuesClassMap>(exportPath, dataStoreCache, connection, cancellationToken);
        }
    }
}
