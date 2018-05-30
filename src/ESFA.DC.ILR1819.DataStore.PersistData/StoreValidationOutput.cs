using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public sealed class StoreValidationOutput : IStoreValidationOutput
    {
        private readonly SqlConnection _connection;

        private readonly SqlTransaction _transaction;

        public StoreValidationOutput(
            SqlConnection connection,
            SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public async Task StoreAsync(int ukPrn, CancellationToken cancellationToken)
        {
            ValidationError validationError = new ValidationError
            {
                UKPRN = ukPrn,
                SWSupAimID = "Unknown",
                FileLevelError = 1
            };

            using (BulkInsert bulkInsert = new BulkInsert(_connection, _transaction, cancellationToken))
            {
                await bulkInsert.Insert("dbo.ValidationError", new List<ValidationError> { validationError });
            }
        }
    }
}
