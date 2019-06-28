using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.PersistData.Persist
{
    public sealed class PersistenceService : IPersistenceService
    {
        private readonly IBulkInsert _bulkInsert;

        public PersistenceService(IBulkInsert bulkInsert)
        {
            _bulkInsert = bulkInsert;
        }

        public async Task PersistValidationDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert("dbo.ValidationError", dataStoreCache.Get<ValidationError>(), sqlConnection, cancellationToken);
        }
    }
}
