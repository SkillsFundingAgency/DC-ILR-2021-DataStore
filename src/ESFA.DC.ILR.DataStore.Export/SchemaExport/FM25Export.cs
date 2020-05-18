using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR2021.DataStore.EF;
using ESFA.DC.Logging.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ESFA.DC.ILR.DataStore.Export.SchemaExport
{
    public class FM25Export : AbstractSchemaExport, IOrderedExport
    {
        public FM25Export(DbContext context, IExport export, ILogger logger) 
            : base(context, export, logger, Constants.TaskExportFM25Tables, 5)
        {
        }

        public async Task ExportAsync(IDataStoreCache dataStoreCache, OleDbConnection connection, string exportPath,
            CancellationToken cancellationToken)
        {
            await ExportTableAsync<FM25_global, FM25globalClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<FM25_Learner, FM25LearnerClassMap>(exportPath, dataStoreCache, connection, cancellationToken);
        }
    }
}
