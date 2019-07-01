using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.PersistData.Constants;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.PersistData.Persist
{
    public sealed class PersistenceService : IPersistenceService
    {
        private readonly IBulkInsert _bulkInsert;

        public PersistenceService(IBulkInsert bulkInsert)
        {
            _bulkInsert = bulkInsert;
        }

        public async Task PersistValidationDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert("dbo.ValidationError", dataStoreCache.Get<ValidationError>(), sqlConnection, cancellationToken);
        }

        public async Task PersistFM25DataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert(FM25Constants.FM25_global, dataStoreCache.Get<FM25_global>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM25Constants.FM25_Learner, dataStoreCache.Get<FM25_Learner>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM25Constants.FM25_FM35_global, dataStoreCache.Get<FM25_FM35_global>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM25Constants.FM25_FM35_Learner_Period, dataStoreCache.Get<FM25_FM35_Learner_Period>(), sqlConnection, cancellationToken);
            await _bulkInsert.Insert(FM25Constants.FM25_FM35_Learner_PeriodisedValues, dataStoreCache.Get<FM25_FM35_Learner_PeriodisedValue>(), sqlConnection, cancellationToken);
        }
    }
}
