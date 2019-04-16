using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Model.History;
using ESFA.DC.ILR1819.DataStore.PersistData.Constants;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public class StoreFM36History : IStoreService<FM36HistoryData>
    {
        private readonly IBulkInsert _bulkInsert;

        public StoreFM36History(IBulkInsert bulkInsert)
        {
            _bulkInsert = bulkInsert;
        }

        public async Task StoreAsync(FM36HistoryData model, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await _bulkInsert.Insert(FM36HistoryConstants.AppEarnHistory,  model.AppsEarningsHistories, sqlConnection, cancellationToken);
        }
    }
}
