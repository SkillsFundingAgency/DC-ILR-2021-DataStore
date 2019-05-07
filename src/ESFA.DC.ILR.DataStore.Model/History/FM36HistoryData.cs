using System.Collections.Generic;
using ESFA.DC.Data.AppsEarningsHistory.Model;

namespace ESFA.DC.ILR1819.DataStore.Model.History
{
    public class FM36HistoryData
    {
        public ICollection<AppsEarningsHistory> AppsEarningsHistories { get; set; } = new List<AppsEarningsHistory>();
    }
}
