using System;
using System.Collections.Generic;
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
        private readonly IEnumerable<ISchemaExport> _schemaExports;
        private readonly ILogger _logger;

        public TransactionController(IEnumerable<ISchemaExport> schemaExports, ILogger logger)
        {
            _schemaExports = schemaExports;
            _logger = logger;
        }

        public async Task<bool> WriteAsync(IDataStoreContext dataStoreContext, IDataStoreCache cache, CancellationToken cancellationToken)
        {
            using (var connection = new OleDbConnection(string.Format(MdbConstants.MdbConnectionStringTemplate, dataStoreContext.ExportOutputLocation)))
            {
                await connection.OpenAsync(cancellationToken);
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        _logger.LogInfo("Starting Export");

                        foreach (var schemaExport in _schemaExports)
                        {
                            await schemaExport.ExportAsync(cache, connection, transaction, dataStoreContext.ExportOutputLocation, cancellationToken);
                        }

                        cancellationToken.ThrowIfCancellationRequested();
                        transaction.Commit();
                        _logger.LogInfo("Finished Export");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _logger.LogError(ex.Message);
                        throw;
                    }
                }
            }

            return true;
        }
    }
}
