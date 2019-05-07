using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Funding;
using ESFA.DC.ILR1819.DataStore.PersistData.Constants;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public class StoreALB : IStoreService<ALBData>
    {
        private readonly IBulkInsert _bulkInsert;

        public StoreALB(IBulkInsert bulkInsert)
        {
            _bulkInsert = bulkInsert;
        }

        public async Task StoreAsync(ALBData model, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(ALBConstants.ALB_global, model.Globals, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(ALBConstants.ALB_Learner, model.Learners, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(ALBConstants.ALB_Learner_Period, model.LearnerPeriods, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(ALBConstants.ALB_Learner_PeriodisedValues, model.LearnerPeriodisedValues, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(ALBConstants.ALB_LearningDelivery, model.LearningDeliveries, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(ALBConstants.ALB_LearningDelivery_Period, model.LearningDeliveryPeriods, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(ALBConstants.ALB_LearningDelivery_PeriodisedValues, model.LearningDeliveryPeriodisedValues, sqlConnection, cancellationToken);
        }
    }
}
