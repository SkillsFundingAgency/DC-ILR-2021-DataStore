using System.Collections.Generic;
using ESFA.DC.Data.AppsEarningsHistory.Model;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;

namespace ESFA.DC.ILR1819.DataStore.Interface.Mappers
{
    public interface IFM36HistoryMapper
    {
        IEnumerable<AppsEarningsHistory> MapAppsEarningsHistory(FM36Global fm36Global, string returnCode, string year);
    }
}
