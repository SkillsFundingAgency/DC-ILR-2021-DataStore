using System.Linq;
using ESFA.DC.ILR2021.DataStore.EF.Valid.Interface;
using Microsoft.EntityFrameworkCore;

namespace ESFA.DC.ILR2021.DataStore.EF.Valid
{
    public partial class ILR2021_DataStoreEntitiesValid : IIlr2021ValidContext
    {
        IQueryable<AppFinRecord> IILR2021_DataStoreEntitiesValid.AppFinRecords => AppFinRecords;
        IQueryable<CollectionDetail> IILR2021_DataStoreEntitiesValid.CollectionDetails => CollectionDetails;
        IQueryable<ContactPreference> IILR2021_DataStoreEntitiesValid.ContactPreferences => ContactPreferences;
        IQueryable<DPOutcome> IILR2021_DataStoreEntitiesValid.DPOutcomes => DPOutcomes;
        IQueryable<EmploymentStatusMonitoring> IILR2021_DataStoreEntitiesValid.EmploymentStatusMonitorings => EmploymentStatusMonitorings;
        IQueryable<Learner> IILR2021_DataStoreEntitiesValid.Learners => Learners;
        IQueryable<LearnerDestinationandProgression> IILR2021_DataStoreEntitiesValid.LearnerDestinationandProgressions => LearnerDestinationandProgressions;
        IQueryable<LearnerEmploymentStatus> IILR2021_DataStoreEntitiesValid.LearnerEmploymentStatuses => LearnerEmploymentStatuses;
        IQueryable<LearnerFAM> IILR2021_DataStoreEntitiesValid.LearnerFAMs => LearnerFAMs;
        IQueryable<LearnerHE> IILR2021_DataStoreEntitiesValid.LearnerHEs => LearnerHEs;
        IQueryable<LearnerHEFinancialSupport> IILR2021_DataStoreEntitiesValid.LearnerHEFinancialSupports => LearnerHEFinancialSupports;
        IQueryable<LearningDelivery> IILR2021_DataStoreEntitiesValid.LearningDeliveries => LearningDeliveries;
        IQueryable<LearningDeliveryFAM> IILR2021_DataStoreEntitiesValid.LearningDeliveryFAMs => LearningDeliveryFAMs;
        IQueryable<LearningDeliveryHE> IILR2021_DataStoreEntitiesValid.LearningDeliveryHEs => LearningDeliveryHEs;
        IQueryable<LearningDeliveryWorkPlacement> IILR2021_DataStoreEntitiesValid.LearningDeliveryWorkPlacements => LearningDeliveryWorkPlacements;
        IQueryable<LearningProvider> IILR2021_DataStoreEntitiesValid.LearningProviders => LearningProviders;
        IQueryable<LLDDandHealthProblem> IILR2021_DataStoreEntitiesValid.LLDDandHealthProblems => LLDDandHealthProblems;
        IQueryable<ProviderSpecDeliveryMonitoring> IILR2021_DataStoreEntitiesValid.ProviderSpecDeliveryMonitorings => ProviderSpecDeliveryMonitorings;
        IQueryable<ProviderSpecLearnerMonitoring> IILR2021_DataStoreEntitiesValid.ProviderSpecLearnerMonitorings => ProviderSpecLearnerMonitorings;
        IQueryable<Source> IILR2021_DataStoreEntitiesValid.Sources => Sources;
        IQueryable<SourceFile> IILR2021_DataStoreEntitiesValid.SourceFiles => SourceFiles;

        // period end stored procedure output type
        public virtual DbSet<PeriodEndMetricsEntity> PeriodEndMetrics { get; set; }
        public virtual DbSet<ACTCountsEntity> ActCounts { get; set; }
    }
}
