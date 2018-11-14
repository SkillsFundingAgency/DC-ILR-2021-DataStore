using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.JobContextManager.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IStoreIlr
    {
        Task StoreAsync(IJobContextMessage jobContextMessage, SqlConnection sqlConnection, SqlTransaction sqlTransaction, IMessage ilr, List<string> validLearners, CancellationToken cancellationToken);
    }
}
