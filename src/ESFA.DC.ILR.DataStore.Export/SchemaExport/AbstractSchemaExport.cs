using System;
using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using ESFA.DC.ILR.DataStore.Export.Export;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.Logging.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ESFA.DC.ILR.DataStore.Export.SchemaExport
{
    public abstract class AbstractSchemaExport
    {
        private readonly DbContext _context;
        private readonly IExport _export;
        private readonly ILogger _logger;

        public string TaskKey { get; }

        protected AbstractSchemaExport(DbContext context, IExport export, ILogger logger, string taskKey)
        {
            _context = context;
            _export = export;
            _logger = logger;
            TaskKey = taskKey;
        }

        protected async Task ExportTableAsync<T, TClassMap>(string exportPath, IDataStoreCache cache, OleDbConnection connection, CancellationToken cancellationToken) where TClassMap : ClassMap<T>
        {
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    await _export.ExportAsync<T, TClassMap>(_context.GetTableName<T>(), cache.Get<T>(), exportPath, connection, transaction, cancellationToken);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError(ex.Message);

                    throw;
                }
            }
        }
    }
}
