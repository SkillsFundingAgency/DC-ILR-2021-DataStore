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
    public class FM35Export : AbstractSchemaExport, IOrderedExport
    {
        public FM35Export(IExport export, ILogger logger) 
            : base(new RulebaseMdbContext(), export, logger, Constants.TaskExportFM35Tables, 6)
        {
        }

        public async Task ExportAsync(IDataStoreCache dataStoreCache, OleDbConnection connection, string exportPath,
            CancellationToken cancellationToken)
        {
            await ExportTableAsync<FM35_global, FM35globalClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<FM35_Learner, FM35LearnerClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<FM35_LearningDelivery, FM35LearningDeliveryClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<FM35_LearningDelivery_Period, FM35LearningDeliveryPeriodClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<FM35_LearningDelivery_PeriodisedValue, FM35LearningDeliveryPeriodisedValuesClassMap>(exportPath, dataStoreCache, connection, cancellationToken);
        }
    }
}
