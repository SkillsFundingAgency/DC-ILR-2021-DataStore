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
    public class DVExport : AbstractSchemaExport, IOrderedExport
    {
        public DVExport(IExport export, ILogger logger) 
            : base(new RulebaseMdbContext(), export, logger, Constants.TaskExportDVTables, 5)
        {
        }

        public async Task ExportAsync(IDataStoreCache dataStoreCache, OleDbConnection connection, string exportPath,
            CancellationToken cancellationToken)
        {
            await ExportTableAsync<DV_global, DVglobalClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<DV_Learner, DVLearnerClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<DV_LearningDelivery, DVLearningDeliveryClassMap>(exportPath, dataStoreCache, connection, cancellationToken);
        }
    }
}
