using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.DataStore.Interface
{
    public interface IBulkInsert
    {
        Task Insert<T>(string table, IEnumerable<T> source, SqlConnection sqlConnection, CancellationToken cancellationToken);
    }
}
