using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export
{
    public class ValidationErrorSeed : IExport
    {
        private readonly IExport _mdbExport;

        public ValidationErrorSeed(IExport mdbExport)
        {
            _mdbExport = mdbExport;
        }

        public async Task ExportAsync<T, TClassMap>(string tableName, IEnumerable<T> source, string exportPath, OleDbConnection connection,
            OleDbTransaction transaction, CancellationToken cancellationToken) where TClassMap : ClassMap
        {
            if (typeof(T) == typeof(ValidationError))
            {
                var identity = 1;
                var validationErrors = ((IEnumerable<ValidationError>) source).ToList();
                foreach (var validationError in validationErrors)
                {
                    validationError.Id = identity++;
                }

                await _mdbExport.ExportAsync<T, TClassMap>(tableName, validationErrors as IEnumerable<T>, exportPath, connection, transaction, cancellationToken);
            }
            else
            {
                await _mdbExport.ExportAsync<T, TClassMap>(tableName, source, exportPath, connection, transaction, cancellationToken);
            }
        }
    }
}
