using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.Export
{
    public class MdbExport : IExport
    {
        private readonly ILogger _logger;
        private readonly IFileService _fileService;
        private const string InsertStatement = "INSERT INTO [{0}] ({1}) SELECT {1} FROM [Text;FMT=CSVDelimited;DATABASE={2};HDR=YES].[{0}.csv]";
        private const string SchemaFileName = "Schema.ini";

        public MdbExport(ILogger logger, IFileService fileService)
        {
            _fileService = fileService;
            _logger = logger;
        }

        public async Task ExportAsync<T, TClassMap>(string tableName, IEnumerable<T> source, string exportPath, OleDbConnection connection,
            OleDbTransaction transaction, CancellationToken cancellationToken) where TClassMap : ClassMap
        {
            await CreateSchemaFileAsync(exportPath, tableName, cancellationToken);

            var columnNames = typeof(T).GetProperties().Where(p => !p.GetMethod.IsVirtual).Select(p => $"[{p.Name}]").OrderBy(c => c);

            var columnNamesString = string.Join(", ", columnNames);

            using (var command = new OleDbCommand(string.Format(InsertStatement, tableName, columnNamesString, exportPath), connection, transaction))
            {
                cancellationToken.ThrowIfCancellationRequested();

                await command.ExecuteNonQueryAsync(cancellationToken);
            }

            _logger.LogDebug($"Persisted into {tableName}");
        }

        private async Task CreateSchemaFileAsync(string exportPath, string tableName, CancellationToken cancellationToken)
        {
            var schemaFilePath = Path.Combine(exportPath, SchemaFileName);

            if (File.Exists(schemaFilePath))
            {
                File.Delete(schemaFilePath);
            }

            using (var writer = new StreamWriter(await _fileService.OpenWriteStreamAsync(SchemaFileName, exportPath, cancellationToken)))
            {
                await writer.WriteLineAsync($"[{tableName}.csv]");
                await writer.WriteLineAsync("ColNameHeader=True");
                await writer.WriteLineAsync("Format = CSVDelimited");
            }
        }
    }
}
