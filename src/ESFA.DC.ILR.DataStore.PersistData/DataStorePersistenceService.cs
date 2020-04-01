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
        private readonly IStoreESFSummarisationClear _esfSummarisationClear;

        public DataStorePersistenceService(
            IStoreClear ilrStoreClear,
            IStoreFM36HistoryClear fm36HistoryClear,
            IStoreESFSummarisationClear esfSummarisationClear)
        {
            _ilrStoreClear = ilrStoreClear;
            _fm36HistoryClear = fm36HistoryClear;
            _esfSummarisationClear = esfSummarisationClear;
        }

        public Task ClearIlrDataAsync(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
            => _ilrStoreClear.ClearAsync(dataStoreContext, sqlConnection, sqlTransaction, cancellationToken);

        public Task ClearFm36HistoryDataAsync(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
            => _fm36HistoryClear.ClearAsync(dataStoreContext, sqlConnection, sqlTransaction, cancellationToken);

        public Task ClearEsfSummarisationDataAsync(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken)
            => _esfSummarisationClear.ClearAsync(dataStoreContext, sqlConnection, sqlTransaction, cancellationToken);
    }
}
