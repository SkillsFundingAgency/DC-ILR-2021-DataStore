using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.DataStore.Export.Interface;

namespace ESFA.DC.ILR.DataStore.Export
{
    public class CsvExport : IExport
    {
        private readonly IExport _decoratedExport;
        private readonly IFileService _fileService;

        public CsvExport(IExport decoratedExport, IFileService fileService)
        {
            _decoratedExport = decoratedExport;
            _fileService = fileService;
        }

        public async Task ExportAsync<T, TClassMap>(string tableName, IEnumerable<T> source, string exportPath, OleDbConnection connection, OleDbTransaction transaction, CancellationToken cancellationToken) where TClassMap : ClassMap
        {
            var configuration = GetConfiguration<TClassMap>();

            using (var writer = new StreamWriter(await _fileService.OpenWriteStreamAsync($"{tableName}.csv", exportPath, cancellationToken)))
            using (var csv = new CsvWriter(writer, configuration))
            {
                csv.Configuration.RegisterClassMap<TClassMap>();
                csv.Configuration.ShouldQuote = (field, context) => true;

                csv.WriteRecords(source);

                csv.Configuration.UnregisterClassMap<TClassMap>();
            }

            await _decoratedExport.ExportAsync<T, TClassMap>(tableName, source, exportPath, connection, transaction, cancellationToken);
        }

        private Configuration GetConfiguration<TClassMap>()
            where TClassMap : ClassMap
        {
            var configuration = new Configuration()
            {
                IgnoreReferences = true,
                ShouldQuote = (field, context) => true
            };

            configuration.RegisterClassMap<TClassMap>();
            return configuration;
        }
    }
}
