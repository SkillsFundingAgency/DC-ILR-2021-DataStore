using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Mappers;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData.Constants;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public class StoreFM36History : IStoreFM36HistoryService<FM36Global>
    {
        private readonly IFM36HistoryMapper _fm36HistoryMapper;
        private readonly IBulkInsert _bulkInsert;

        public StoreFM36History()
        {
        }

        public StoreFM36History(IFM36HistoryMapper fm36HistoryMapper, IBulkInsert bulkInsert)
        {
            _bulkInsert = bulkInsert;
            _fm36HistoryMapper = fm36HistoryMapper;
        }

        public async Task StoreAsync(IDataStoreContext dataStoreContext, SqlTransaction sqlTransaction, FM36Global fundingOutput, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            var appsEarningsHistories = _fm36HistoryMapper.MapAppsEarningsHistory(fundingOutput, dataStoreContext.ReturnCode, dataStoreContext.CollectionYear);

            await _bulkInsert.Insert(FM36HistoryConstants.AppEarnHistory, appsEarningsHistories, sqlTransaction, cancellationToken);
        }
    }
}
