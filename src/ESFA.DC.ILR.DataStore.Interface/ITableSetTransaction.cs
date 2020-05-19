using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Interface
{
    public interface ITableSetTransaction
    {
        int TaskOrder { get; }

        string TaskKey { get; }

        Task WriteAsync(IDataStoreCache cache, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken);
    }
}
