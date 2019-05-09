using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Funding;
using ESFA.DC.ILR.DataStore.PersistData.Constants;

namespace ESFA.DC.ILR.DataStore.PersistData.Persist
{
    public class StoreFM36 : IStoreService<FM36Data>
    {
        private readonly IBulkInsert _bulkInsert;

        public StoreFM36(IBulkInsert bulkInsert)
        {
            _bulkInsert = bulkInsert;
        }

        public async Task StoreAsync(FM36Data model, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(FM36Constants.FM36_global, model.Globals, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM36Constants.FM36_Learner, model.Learners, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM36Constants.FM36_LearningDelivery, model.LearningDeliveries, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM36Constants.FM36_LearningDelivery_Period, model.LearningDeliveryPeriods, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM36Constants.FM36_LearningDelivery_PeriodisedValues, model.LearningDeliveryPeriodisedValues, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM36Constants.FM36_LearningDelivery_PeriodisedTextValues, model.LearningDeliveryPeriodisedTextValues, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM36Constants.FM36_PriceEpisodes, model.ApprenticeshipPriceEpisodes, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM36Constants.FM36_PriceEpisode_Period, model.ApprenticeshipPriceEpisodePeriods, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM36Constants.FM36_PriceEpisode_PeriodisedValues, model.ApprenticeshipPriceEpisodePeriodisedValues, sqlConnection, cancellationToken);
        }
    }
}
