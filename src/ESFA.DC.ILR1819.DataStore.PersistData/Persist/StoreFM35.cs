using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.Model;
using ESFA.DC.ILR1819.DataStore.PersistData.Abstract;
using ESFA.DC.ILR1819.DataStore.PersistData.Constants;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public class StoreFM35 : IStoreService<FM35Global>
    {
        private readonly IFM35Mapper _fm35Mapper;
        private readonly IBulkInsert _bulkInsert;

        public StoreFM35()
        {
        }

        public StoreFM35(IFM35Mapper fm35Mapper, IBulkInsert bulkInsert)
        {
            _bulkInsert = bulkInsert;
            _fm35Mapper = fm35Mapper;
        }

        public async Task StoreAsync(SqlTransaction sqlTransaction, FM35Global fundingOutput, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            var global = new List<FM35_global> { _fm35Mapper.MapGlobal(fundingOutput) };
            var learners = _fm35Mapper.MapLearners(fundingOutput);
            var learningDeliveries = _fm35Mapper.MapLearningDeliveries(fundingOutput);
            var learningDeliveryPeriod = _fm35Mapper.MapLearningDeliveryPeriods(fundingOutput);
            var learningDeliveryPeriodisedValues = _fm35Mapper.MapLearningDeliveryPeriodisedValues(fundingOutput);

            await _bulkInsert.Insert(FM35Constants.FM35_global, global, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(FM35Constants.FM35_Learner, learners, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(FM35Constants.FM35_LearningDelivery, learningDeliveries, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(FM35Constants.FM35_LearningDelivery_Period, learningDeliveryPeriod, sqlTransaction, cancellationToken);
            await _bulkInsert.Insert(FM35Constants.FM35_LearningDelivery_PeriodisedValues, learningDeliveryPeriodisedValues, sqlTransaction, cancellationToken);
        }
    }
}
