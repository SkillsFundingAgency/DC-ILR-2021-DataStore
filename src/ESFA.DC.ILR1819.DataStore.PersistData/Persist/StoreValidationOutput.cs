using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Model.File;
using ESFA.DC.ILR1819.DataStore.PersistData.Abstract;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public sealed class StoreValidationOutput : AbstractStore, IStoreService<ValidationData>
    {
        public StoreValidationOutput(IBulkInsert bulkInsert)
            : base(bulkInsert)
        {
        }

        public async Task StoreAsync(ValidationData model, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert("dbo.ValidationError", model.ValidationErrors, sqlConnection, cancellationToken);
        }
    }
}
