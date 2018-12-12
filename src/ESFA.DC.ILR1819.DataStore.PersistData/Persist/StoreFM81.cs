using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Mappers;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData.Constants;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public class StoreFM81 : IStoreService<FM81Global>
    {
        private readonly IFM81Mapper _fm81Mapper;
        private readonly IBulkInsert _bulkInsert;

        public StoreFM81()
        {
        }

        public StoreFM81(IFM81Mapper fm81Mapper, IBulkInsert bulkInsert)
        {
            _bulkInsert = bulkInsert;
            _fm81Mapper = fm81Mapper;
        }

        public async Task StoreAsync(SqlTransaction sqlTransaction, FM81Global fundingOutput, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            var global = new List<TBL_global> { _fm81Mapper.MapGlobal(fundingOutput) };
            var learners = _fm81Mapper.MapLearners(fundingOutput);
            var learningDeliveries = _fm81Mapper.MapLearningDeliveries(fundingOutput);
            var learningDeliveryPeriod = _fm81Mapper.MapLearningDeliveryPeriods(fundingOutput);
            var learningDeliveryPeriodisedValues = _fm81Mapper.MapLearningDeliveryPeriodisedValues(fundingOutput);

            await _bulkInsert.Insert(FM81Constants.FM81_global, global, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(FM81Constants.FM81_Learner, learners, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(FM81Constants.FM81_LearningDelivery, learningDeliveries, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(FM81Constants.FM81_LearningDelivery_Period, learningDeliveryPeriod, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(FM81Constants.FM81_LearningDelivery_PeriodisedValues, learningDeliveryPeriodisedValues, sqlTransaction, cancellationToken);
        }
    }
}
