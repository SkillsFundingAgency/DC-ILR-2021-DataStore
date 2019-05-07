using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Funding;
using ESFA.DC.ILR1819.DataStore.PersistData.Constants;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public class StoreFM25 : IStoreService<FM25Data>
    {
        private readonly IBulkInsert _bulkInsert;

        public StoreFM25(IBulkInsert bulkInsert)
        {
            _bulkInsert = bulkInsert;
        }

        public async Task StoreAsync(FM25Data model, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(FM25Constants.FM25_global, model.Globals, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM25Constants.FM25_Learner, model.Learners, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM25Constants.FM25_FM35_global, model.Fm25Fm35Globals, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM25Constants.FM25_FM35_Learner_Period, model.Fm25Fm35LearnerPeriods, sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM25Constants.FM25_FM35_Learner_PeriodisedValues, model.Fm25Fm35LearnerPeriodisedValues, sqlConnection, cancellationToken);
        }
    }
}
