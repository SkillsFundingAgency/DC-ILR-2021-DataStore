using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Model;
using ESFA.DC.ILR1819.DataStore.PersistData.Constants;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public class StoreFM35 : IStoreService<FM35Data>
    {
        private readonly IBulkInsert _bulkInsert;

        public StoreFM35(IBulkInsert bulkInsert)
        {
            _bulkInsert = bulkInsert;
        }

        public async Task StoreAsync(FM35Data model, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(FM35Constants.FM35_global, model.Globals, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM35Constants.FM35_Learner, model.Learners, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM35Constants.FM35_LearningDelivery, model.LearningDeliveries, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM35Constants.FM35_LearningDelivery_Period, model.LearningDeliveryPeriods, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM35Constants.FM35_LearningDelivery_PeriodisedValues, model.LearningDeliveryPeriodisedValues, sqlConnection, cancellationToken);
        }
    }
}
