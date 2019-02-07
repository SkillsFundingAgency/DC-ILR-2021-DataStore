using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Mappers;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData.Constants;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public sealed class StoreALB : IStoreService<ALBGlobal>
    {
        private readonly IALBMapper _albMapper;
        private readonly IBulkInsert _bulkInsert;

        public StoreALB()
        {
        }

        public StoreALB(IALBMapper albMapper, IBulkInsert bulkInsert)
        {
            _bulkInsert = bulkInsert;
            _albMapper = albMapper;
        }

        public async Task StoreAsync(SqlConnection sqlConnection, ALBGlobal fundingOutput, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            var global = new List<ALB_global> { _albMapper.MapGlobal(fundingOutput) };
            var learners = _albMapper.MapLearners(fundingOutput);
            var learnerPeriods = _albMapper.MapLearnerPeriods(fundingOutput);
            var learnerPeriodisedValues = _albMapper.MapLearnerPeriodisedValues(fundingOutput);
            var learningDeliveries = _albMapper.MapLearningDeliveries(fundingOutput);
            var learningDeliveryPeriod = _albMapper.MapLearningDeliveryPeriods(fundingOutput);
            var learningDeliveryPeriodisedValues = _albMapper.MapLearningDeliveryPeriodisedValues(fundingOutput);

            await _bulkInsert.Insert(ALBConstants.ALB_global, global, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(ALBConstants.ALB_Learner, learners, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(ALBConstants.ALB_Learner_Period, learnerPeriods, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(ALBConstants.ALB_Learner_PeriodisedValues, learnerPeriodisedValues, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(ALBConstants.ALB_LearningDelivery, learningDeliveries, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(ALBConstants.ALB_LearningDelivery_Period, learningDeliveryPeriod, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(ALBConstants.ALB_LearningDelivery_PeriodisedValues, learningDeliveryPeriodisedValues, sqlConnection, cancellationToken);
        }
    }
}
