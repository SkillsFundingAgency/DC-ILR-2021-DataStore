using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.JobContextManager.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IModelService
    {
        Task<bool> GetModel(IJobContextMessage jobContextMessage, CancellationToken cancellationToken);

        Task StoreModel(SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken);
    }
}