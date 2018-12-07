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
    public class StoreFM36 : IStoreService<FM36Global>
    {
        private readonly IFM36Mapper _fm36Mapper;
        private readonly IBulkInsert _bulkInsert;

        public StoreFM36()
        {
        }

        public StoreFM36(IFM36Mapper fm36Mapper, IBulkInsert bulkInsert)
        {
            _bulkInsert = bulkInsert;
            _fm36Mapper = fm36Mapper;
        }

        public async Task StoreAsync(SqlTransaction sqlTransaction, FM36Global fundingOutput, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            var global = new List<AEC_global> { _fm36Mapper.MapGlobal(fundingOutput) };
            var learners = _fm36Mapper.MapLearners(fundingOutput);
            var learningDeliveries = _fm36Mapper.MapLearningDeliveries(fundingOutput);
            var learningDeliveryPeriod = _fm36Mapper.MapLearningDeliveryPeriods(fundingOutput);
            var learningDeliveryPeriodisedValues = _fm36Mapper.MapLearningDeliveryPeriodisedValues(fundingOutput);
            var priceEpisodes = _fm36Mapper.MapPriceEpisodes(fundingOutput);
            var priceEpisodePeriod = _fm36Mapper.MapPriceEpisodePeriods(fundingOutput);
            var priceEpisodePeriodisedValues = _fm36Mapper.MapPriceEpisodePeriodisedValues(fundingOutput);

            await _bulkInsert.Insert(FM36Constants.FM36_global, global, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(FM36Constants.FM36_Learner, learners, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(FM36Constants.FM36_LearningDelivery, learningDeliveries, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(FM36Constants.FM36_LearningDelivery_Period, learningDeliveryPeriod, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(FM36Constants.FM36_LearningDelivery_PeriodisedValues, learningDeliveryPeriodisedValues, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(FM36Constants.FM36_PriceEpisodes, priceEpisodes, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(FM36Constants.FM36_PriceEpisode_Period, priceEpisodePeriod, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(FM36Constants.FM36_PriceEpisode_PeriodisedValues, priceEpisodePeriodisedValues, sqlTransaction, cancellationToken);
        }
    }
}
