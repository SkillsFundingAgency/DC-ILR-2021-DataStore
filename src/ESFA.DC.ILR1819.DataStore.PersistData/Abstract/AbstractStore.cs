﻿using ESFA.DC.ILR1819.DataStore.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Abstract
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
