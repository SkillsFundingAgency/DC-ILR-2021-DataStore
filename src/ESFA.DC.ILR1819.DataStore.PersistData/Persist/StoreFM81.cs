using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Model;
using ESFA.DC.ILR1819.DataStore.Model.Funding;
using ESFA.DC.ILR1819.DataStore.PersistData.Constants;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public class StoreFM81 : IStoreService<FM81Data>
    {
        private readonly IBulkInsert _bulkInsert;

        public StoreFM81(IBulkInsert bulkInsert)
        {
            _bulkInsert = bulkInsert;
        }

        public async Task StoreAsync(FM81Data model, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(FM81Constants.FM81_global, model.Globals, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM81Constants.FM81_Learner, model.Learners, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM81Constants.FM81_LearningDelivery, model.LearningDeliveries, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM81Constants.FM81_LearningDelivery_Period, model.LearningDeliveryPeriods, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM81Constants.FM81_LearningDelivery_PeriodisedValues, model.LearningDeliveryPeriodisedValues, sqlConnection, cancellationToken);
        }
    }
}
