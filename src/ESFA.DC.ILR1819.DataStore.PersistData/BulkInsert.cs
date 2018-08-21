using System;
using System.Collections.Generic;
using System.Data;
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

        private readonly SqlBulkCopy sqlBulkCopy;

        public BulkInsert(SqlConnection connection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
            sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, sqlTransaction)
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

                sqlBulkCopy.ColumnMappings.Clear();
                using (ObjectReader reader = ObjectReader.Create(source))
                {
                    sqlBulkCopy.DestinationTableName = table;
                    DataTable schema = reader.GetSchemaTable();
                    for (int i = 0; i < schema.Rows.Count; i++)
                    {
                        sqlBulkCopy.ColumnMappings.Add(schema.Rows[i].ItemArray[1].ToString(), schema.Rows[i].ItemArray[1].ToString());
                    }

                    await sqlBulkCopy.WriteToServerAsync(reader, _cancellationToken);
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
            ((IDisposable)sqlBulkCopy)?.Dispose();
        }
    }
}
