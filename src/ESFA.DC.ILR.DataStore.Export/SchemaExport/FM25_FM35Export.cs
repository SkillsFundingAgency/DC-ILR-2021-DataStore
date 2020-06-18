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
    public class FM25_FM35Export : AbstractSchemaExport, IOrderedExport
    {
        public FM25_FM35Export(IExport export, ILogger logger) 
            : base(new RulebaseMdbContext(), export, logger, Constants.TaskExportFM25FM35Tables, 8)
        {
        }

        public async Task ExportAsync(IDataStoreCache dataStoreCache, OleDbConnection connection, string exportPath,
            CancellationToken cancellationToken)
        {
            await ExportTableAsync<FM25_FM35_global, FM25FM35globalClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<FM25_FM35_Learner_Period, FM25FM35LearnerPeriodClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<FM25_FM35_Learner_PeriodisedValue, FM25FM35LearnerPeriodisedValuesClassMap>(exportPath, dataStoreCache, connection, cancellationToken);
        }
    }
}
