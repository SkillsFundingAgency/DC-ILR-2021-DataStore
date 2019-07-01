using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Interface
{
    public interface IPersistenceService
    {
        Task PersistValidationDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, CancellationToken cancellationToken);

        Task PersistFM25DataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, CancellationToken cancellationToken);

        Task PersistALBDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, CancellationToken cancellationToken);
    }
}
