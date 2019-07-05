using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;

namespace ESFA.DC.ILR.DataStore.PersistData
{
    public class DataStorePersistenceService : IDataStorePersistenceService
    {
        private readonly IStoreClear _ilrStoreClear;
        private readonly IStoreFM36HistoryClear _fm36HistoryClear;

        public DataStorePersistenceService(
            IStoreClear ilrStoreClear,
            IStoreFM36HistoryClear fm36HistoryClear)
        {
            _ilrStoreClear = ilrStoreClear;
            _fm36HistoryClear = fm36HistoryClear;
        }

        public Task ClearIlrDataAsync(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, CancellationToken cancellationToken)
            => _ilrStoreClear.ClearAsync(dataStoreContext, sqlConnection, cancellationToken);

        public Task ClearFm36HistoryDataAsync(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, CancellationToken cancellationToken)
            => _fm36HistoryClear.ClearAsync(dataStoreContext, sqlConnection, cancellationToken);
    }
}
