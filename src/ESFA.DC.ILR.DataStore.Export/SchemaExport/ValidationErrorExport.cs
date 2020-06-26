using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Access;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR.DataStore.Export.Mappers;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR2021.DataStore.EF;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.Export.SchemaExport
{
    public class ValidationErrorExport : AbstractSchemaExport, IOrderedExport
    {
        public ValidationErrorExport(IExport export, ILogger logger)
            : base(new ValidMdbContext(), export, logger, Constants.TaskExportValidationErrorTable, 3)
        {
        }

        public async Task ExportAsync(IDataStoreCache dataStoreCache, OleDbConnection connection, string exportPath,
            CancellationToken cancellationToken)
        {
            await ExportTableAsync<ValidationError, DefaultTableClassMap<ValidationError>>(exportPath, dataStoreCache, connection,  cancellationToken);
        }
    }
}
