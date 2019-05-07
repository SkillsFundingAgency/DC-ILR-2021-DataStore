using System.Collections.Generic;
using ESFA.DC.Data.AppsEarningsHistory.Model;
using ESFA.DC.ILR.DataStore.Model.History;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IFM36HistoryMapper
    {
        FM36HistoryData MapData(FM36Global fm36Global, IDataStoreContext dataStoreContext);

        IEnumerable<AppsEarningsHistory> MapAppsEarningsHistory(FM36Global fm36Global, string returnCode, string year);
    }
}
