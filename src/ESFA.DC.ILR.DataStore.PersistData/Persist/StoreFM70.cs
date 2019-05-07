using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Funding;
using ESFA.DC.ILR1819.DataStore.PersistData.Constants;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public class StoreFM70 : IStoreService<FM70Data>
    {
        private readonly IBulkInsert _bulkInsert;

        public StoreFM70(IBulkInsert bulkInsert)
        {
            _bulkInsert = bulkInsert;
        }

        public async Task StoreAsync(FM70Data model, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(FM70Constants.FM70_global, model.Globals, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM70Constants.FM70_Learner, model.Learners, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM70Constants.FM70_DPOutcome, model.DPOutcomes, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM70Constants.FM70_LearningDelivery, model.LearningDeliveries, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM70Constants.FM70_LearningDeliveryDeliverable, model.LearningDeliveryDeliverables, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM70Constants.FM70_LearningDeliveryDeliverable_Period, model.LearningDeliveryDeliverablePeriods, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM70Constants.FM70_LearningDeliveryDeliverable_PeriodisedValues, model.LearningDeliveryDeliverablePeriodisedValues, sqlConnection, cancellationToken);
        }
    }
}
