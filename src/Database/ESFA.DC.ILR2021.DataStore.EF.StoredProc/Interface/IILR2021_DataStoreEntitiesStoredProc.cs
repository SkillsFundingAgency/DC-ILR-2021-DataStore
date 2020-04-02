using System;
using Microsoft.EntityFrameworkCore;

namespace ESFA.DC.ILR2021.DataStore.EF.StoredProc.Interface
{
    public interface IILR2021_DataStoreEntitiesStoredProc : IDisposable
    {
        DbSet<ACTCountsEntity> ActCounts { get; set; }

        DbSet<PeriodEndMetricsEntity> PeriodEndMetrics { get; set; }
    }
}
