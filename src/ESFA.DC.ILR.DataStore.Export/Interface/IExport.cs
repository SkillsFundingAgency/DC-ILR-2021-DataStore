using System.Collections.Generic;
using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace ESFA.DC.ILR.DataStore.Export.Interface
{
    public interface IExport
    {
        Task ExportAsync<T, TClassMap>(string tableName, IEnumerable<T> source, string exportPath, OleDbConnection connection, OleDbTransaction transaction, CancellationToken cancellationToken)
            where TClassMap : ClassMap;
    }
}
