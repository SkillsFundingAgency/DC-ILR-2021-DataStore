using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using ESFA.DC.ILR.DataStore.Export.Export;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR.DataStore.Model.Interface;
using Microsoft.EntityFrameworkCore;

namespace ESFA.DC.ILR.DataStore.Export.SchemaExport
{
    public abstract class AbstractSchemaExport
    {
        private readonly DbContext _context;
        private readonly IExport _export;

        protected AbstractSchemaExport(DbContext context, IExport export)
        {
            _context = context;
            _export = export;
        }

        protected async Task ExportTableAsync<T, TClassMap>(string exportPath, IDataStoreCache cache, OleDbConnection connection, OleDbTransaction transaction, CancellationToken cancellationToken) where TClassMap : ClassMap<T>
        {
            await _export.ExportAsync<T, TClassMap>(_context.GetTableName<T>(), cache.Get<T>(), exportPath, connection, transaction, cancellationToken);
        }
    }
}
