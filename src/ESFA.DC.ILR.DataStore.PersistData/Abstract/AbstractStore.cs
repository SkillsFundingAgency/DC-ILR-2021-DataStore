using ESFA.DC.ILR.DataStore.Interface;

namespace ESFA.DC.ILR.DataStore.PersistData.Abstract
{
    public abstract class AbstractStore
    {
        protected readonly IBulkInsert _bulkInsert;

        protected AbstractStore(IBulkInsert bulkInsert)
        {
            _bulkInsert = bulkInsert;
        }
    }
}
