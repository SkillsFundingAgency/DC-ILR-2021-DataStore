using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.JobContextManager.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IStoreFileDetails
    {
        Task StoreAsync(IJobContextMessage jobContextMessage, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken);
    }
}
