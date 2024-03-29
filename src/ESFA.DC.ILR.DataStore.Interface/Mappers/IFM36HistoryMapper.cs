﻿using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IFM36HistoryMapper
    {
        void MapData(IDataStoreCache cache, FM36Global fm36Global, IDataStoreContext dataStoreContext);
    }
}
