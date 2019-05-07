using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.File;
using ESFA.DC.ILR1819.DataStore.PersistData.Abstract;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public class StoreInvalidHeader : AbstractStore,  IStoreService<InvalidHeaderData>
    {
        public StoreInvalidHeader(IBulkInsert bulkInsert)
            : base(bulkInsert)
        {
        }

        public async Task StoreAsync(InvalidHeaderData model, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            await _bulkInsert.Insert("Invalid.CollectionDetails", model.CollectionDetails, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.LearningProvider", model.LearningProviders, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.Source", model.Sources, sqlConnection, cancellationToken);
            await _bulkInsert.Insert("Invalid.SourceFile", model.SourceFiles, sqlConnection, cancellationToken);
        }
    }
}
