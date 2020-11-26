using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.OleDb;
using System.Linq;
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
        private readonly IEnumerable<IOrderedExport> _exports;
        private readonly ILogger _logger;

        public TransactionController(IEnumerable<IOrderedExport> exports, ILogger logger)
        {
            _exports = exports;
            _logger = logger;
        }

        public async Task<bool> WriteAsync(IDataStoreContext dataStoreContext, IDataStoreCache cache, CancellationToken cancellationToken)
        {
            using (var connection = new OleDbConnection(string.Format(MdbConstants.MdbConnectionStringTemplate, dataStoreContext.ExportOutputLocation)))
            {
                await connection.OpenAsync(cancellationToken);

                var exports = _exports
                    .Where(e => dataStoreContext.Tasks.Contains(e.TaskKey, StringComparer.OrdinalIgnoreCase))
                    .OrderBy(e => e.TaskOrder);

                _logger.LogInfo("Starting Export");

                foreach (var export in exports)
                {
                    await export.ExportAsync(cache, connection, dataStoreContext.ExportOutputLocation,
                        cancellationToken);
                }

                cancellationToken.ThrowIfCancellationRequested();

                _logger.LogInfo("Finished Export");
            }

            return true;
        }
    }
}
