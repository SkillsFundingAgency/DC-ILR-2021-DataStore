using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.File;
using ESFA.DC.ILR1819.DataStore.PersistData.Abstract;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public class StoreValidHeader : AbstractStore,  IStoreService<ValidHeaderData>
    {
        public StoreValidHeader(IBulkInsert bulkInsert)
            : base(bulkInsert)
        {
        }

        public async Task StoreAsync(ValidHeaderData model, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert("Valid.CollectionDetails", model.CollectionDetails, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.LearningProvider", model.LearningProviders, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.Source", model.Sources, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Valid.SourceFile", model.SourceFiles, sqlConnection, cancellationToken);
        }
    }
}
