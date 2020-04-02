using ESFA.DC.ILR2021.DataStore.EF.StoredProc.Interface;

using Microsoft.EntityFrameworkCore;

namespace ESFA.DC.ILR2021.DataStore.EF.StoredProc
{
    public partial class ILR2021_DataStoreEntitiesStoredProc : IILR2021StoredProcContext
    {
        public virtual DbSet<ACTCountsEntity> ActCounts { get; set; }

        public virtual DbSet<PeriodEndMetricsEntity> PeriodEndMetrics { get; set; }
    }
}
