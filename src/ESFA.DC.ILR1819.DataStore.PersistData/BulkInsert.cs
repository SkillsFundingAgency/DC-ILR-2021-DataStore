using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FastMember;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public sealed class BulkInsert : IDisposable
    {
        private readonly CancellationToken _cancellationToken;

        private readonly SqlBulkCopy _sqlBulkCopy;

        public BulkInsert(SqlConnection connection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
            _sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, sqlTransaction)
            {
                BatchSize = 5_000, // https://stackoverflow.com/questions/779690/what-is-the-recommended-batch-size-for-sqlbulkcopy
                BulkCopyTimeout = 600
            };
        }

        public async Task Insert<T>(string table, IList<T> source)
        {
            try
            {
                if (!source.Any())
                {
                    return;
                }

                if (_cancellationToken.IsCancellationRequested)
                {
                    return;
                }

                _sqlBulkCopy.ColumnMappings.Clear();
                var columnNames = typeof(T).GetProperties().Where(p => !p.GetMethod.IsVirtual).Select(p => p.Name).ToArray();

                using (var reader = ObjectReader.Create(source, columnNames))
                {
                    _sqlBulkCopy.DestinationTableName = table;

                    foreach (var name in columnNames)
                    {
                        _sqlBulkCopy.ColumnMappings.Add(name, name);
                    }

                    await _sqlBulkCopy.WriteToServerAsync(reader, _cancellationToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(table);
                Console.Write(ex);
                throw;
            }
        }

        public void Dispose()
        {
            ((IDisposable)_sqlBulkCopy)?.Dispose();
        }
    }
}
