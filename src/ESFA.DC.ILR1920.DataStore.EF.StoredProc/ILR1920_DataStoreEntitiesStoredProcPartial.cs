using ESFA.DC.ILR1920.DataStore.EF.StoredProc.Interface;
using Microsoft.EntityFrameworkCore;

namespace ESFA.DC.ILR1920.DataStore.EF.StoredProc
{
    public partial class ILR1920_DataStoreEntitiesStoredProc : IILR1920StoredProcContext
    {
        public virtual DbSet<ACTCountsEntity> ActCounts { get; set; }

        public virtual DbSet<PeriodEndMetricsEntity> PeriodEndMetrics { get; set; }
    }
}
