using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Access;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.Export
{
    public class TransactionController : IExportTransactionController
    {
        private readonly IImmutableDictionary<string, ISchemaExport> _schemaExports;
        private readonly ILogger _logger;

        public TransactionController(IImmutableDictionary<string, ISchemaExport> schemaExports, ILogger logger)
        {
            _schemaExports = schemaExports;
            _logger = logger;
        }

        public async Task<bool> WriteAsync(IDataStoreContext dataStoreContext, IDataStoreCache cache, CancellationToken cancellationToken)
        {
            using (var connection = new OleDbConnection(string.Format(MdbConstants.MdbConnectionStringTemplate, dataStoreContext.ExportOutputLocation)))
            {
                await connection.OpenAsync(cancellationToken);

                _logger.LogInfo("Starting Export");

                foreach (var key in dataStoreContext.Tasks)
                {
                    _schemaExports.TryGetValue(key, out var export);

                    if (export == null)
                    {
                        continue;
                    }

                    await export.ExportAsync(cache, connection, dataStoreContext.ExportOutputLocation, cancellationToken);
                }

                cancellationToken.ThrowIfCancellationRequested();

                _logger.LogInfo("Finished Export");
            }

            return true;
        }
    }
}
