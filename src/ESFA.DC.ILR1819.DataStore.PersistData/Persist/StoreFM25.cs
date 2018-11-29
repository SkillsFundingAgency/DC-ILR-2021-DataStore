using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Mappers;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData.Constants;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public class StoreFM25 : IStoreService<FM25Global>
    {
        private readonly IFM25Mapper _fm25Mapper;
        private readonly IBulkInsert _bulkInsert;

        public StoreFM25()
        {
        }

        public StoreFM25(IFM25Mapper fm25Mapper, IBulkInsert bulkInsert)
        {
            _bulkInsert = bulkInsert;
            _fm25Mapper = fm25Mapper;
        }

        public async Task StoreAsync(SqlTransaction sqlTransaction, FM25Global fundingOutput, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            var global = new List<FM25_global> { _fm25Mapper.MapFM25Global(fundingOutput) };
            var learners = _fm25Mapper.MapFM25Learners(fundingOutput);
            var fm25_35global = new List<FM25_FM35_global> { _fm25Mapper.MapFM25_35_Global(fundingOutput) };
            var fm25_35learnerPeriod = _fm25Mapper.MapFM25_35_LearnerPeriod(fundingOutput);
            var fm25_35learnerPeriodisedValues = _fm25Mapper.MapFM25_35_LearnerPeriodisedValues(fundingOutput);

            await _bulkInsert.Insert(FM25Constants.FM25_global, global, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(FM25Constants.FM25_Learner, learners, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(FM25Constants.FM25_FM35_global, fm25_35global, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(FM25Constants.FM25_FM35_Learner_Period, fm25_35learnerPeriod, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(FM25Constants.FM25_FM35_Learner_PeriodisedValues, fm25_35learnerPeriodisedValues, sqlTransaction, cancellationToken);
        }
    }
}
