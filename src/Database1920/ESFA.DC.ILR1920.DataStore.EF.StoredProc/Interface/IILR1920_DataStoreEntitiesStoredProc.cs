using System;
using Microsoft.EntityFrameworkCore;

namespace ESFA.DC.ILR1920.DataStore.EF.StoredProc.Interface
{
    public interface IILR1920_DataStoreEntitiesStoredProc :IDisposable
    {
        DbSet<ACTCountsEntity> ActCounts { get; set; }

        DbSet<PeriodEndMetricsEntity> PeriodEndMetrics { get; set; }
    }
}
