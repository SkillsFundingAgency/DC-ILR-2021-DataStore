﻿using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Interface
{
    public interface IFM36HistoryTransaction
    {
        Task WriteFM36HistoryAsync(IDataStoreContext dataStoreContext, IDataStoreCache cache, CancellationToken cancellationToken);
    }
}