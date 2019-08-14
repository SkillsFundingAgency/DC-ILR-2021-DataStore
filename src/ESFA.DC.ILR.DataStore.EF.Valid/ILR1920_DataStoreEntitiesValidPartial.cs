using System.Linq;
using ESFA.DC.ILR1920.DataStore.EF.Valid.Interface;
using Microsoft.EntityFrameworkCore;

namespace ESFA.DC.ILR1920.DataStore.EF.Valid
{
    public partial class ILR1920_DataStoreEntitiesValid : IIlr1920ValidContext
    {
        IQueryable<AppFinRecord> IILR1920_DataStoreEntitiesValid.AppFinRecords => AppFinRecords;
        IQueryable<CollectionDetail> IILR1920_DataStoreEntitiesValid.CollectionDetails => CollectionDetails;
        IQueryable<ContactPreference> IILR1920_DataStoreEntitiesValid.ContactPreferences => ContactPreferences;
        IQueryable<DPOutcome> IILR1920_DataStoreEntitiesValid.DPOutcomes => DPOutcomes;
        IQueryable<EmploymentStatusMonitoring> IILR1920_DataStoreEntitiesValid.EmploymentStatusMonitorings => EmploymentStatusMonitorings;
        IQueryable<Learner> IILR1920_DataStoreEntitiesValid.Learners => Learners;
        IQueryable<LearnerDestinationandProgression> IILR1920_DataStoreEntitiesValid.LearnerDestinationandProgressions => LearnerDestinationandProgressions;
        IQueryable<LearnerEmploymentStatus> IILR1920_DataStoreEntitiesValid.LearnerEmploymentStatuses => LearnerEmploymentStatuses;
        IQueryable<LearnerFAM> IILR1920_DataStoreEntitiesValid.LearnerFAMs => LearnerFAMs;
        IQueryable<LearnerHE> IILR1920_DataStoreEntitiesValid.LearnerHEs => LearnerHEs;
        IQueryable<LearnerHEFinancialSupport> IILR1920_DataStoreEntitiesValid.LearnerHEFinancialSupports => LearnerHEFinancialSupports;
        IQueryable<LearningDelivery> IILR1920_DataStoreEntitiesValid.LearningDeliveries => LearningDeliveries;
        IQueryable<LearningDeliveryFAM> IILR1920_DataStoreEntitiesValid.LearningDeliveryFAMs => LearningDeliveryFAMs;
        IQueryable<LearningDeliveryHE> IILR1920_DataStoreEntitiesValid.LearningDeliveryHEs => LearningDeliveryHEs;
        IQueryable<LearningDeliveryWorkPlacement> IILR1920_DataStoreEntitiesValid.LearningDeliveryWorkPlacements => LearningDeliveryWorkPlacements;
        IQueryable<LearningProvider> IILR1920_DataStoreEntitiesValid.LearningProviders => LearningProviders;
        IQueryable<LLDDandHealthProblem> IILR1920_DataStoreEntitiesValid.LLDDandHealthProblems => LLDDandHealthProblems;
        IQueryable<ProviderSpecDeliveryMonitoring> IILR1920_DataStoreEntitiesValid.ProviderSpecDeliveryMonitorings => ProviderSpecDeliveryMonitorings;
        IQueryable<ProviderSpecLearnerMonitoring> IILR1920_DataStoreEntitiesValid.ProviderSpecLearnerMonitorings => ProviderSpecLearnerMonitorings;
        IQueryable<Source> IILR1920_DataStoreEntitiesValid.Sources => Sources;
        IQueryable<SourceFile> IILR1920_DataStoreEntitiesValid.SourceFiles => SourceFiles;

        // period end stored procedure output type
        public virtual DbSet<PeriodEndMetricsEntity> PeriodEndMetrics { get; set; }
    }
}
