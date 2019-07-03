using System;
using System.Linq;

namespace ESFA.DC.ILR1920.DataStore.EF.Valid.Interface
{
    public interface IILR1920_DataStoreEntitiesValid : IDisposable
    {
        IQueryable<AppFinRecord> AppFinRecords { get; }
        IQueryable<CollectionDetail> CollectionDetails { get; }
        IQueryable<ContactPreference> ContactPreferences { get; }
        IQueryable<DPOutcome> DPOutcomes { get; }
        IQueryable<EmploymentStatusMonitoring> EmploymentStatusMonitorings { get; }
        IQueryable<LLDDandHealthProblem> LLDDandHealthProblems { get; }
        IQueryable<Learner> Learners { get; }
        IQueryable<LearnerDestinationandProgression> LearnerDestinationandProgressions { get; }
        IQueryable<LearnerEmploymentStatus> LearnerEmploymentStatuses { get; }
        IQueryable<LearnerFAM> LearnerFAMs { get; }
        IQueryable<LearnerHE> LearnerHEs { get; }
        IQueryable<LearnerHEFinancialSupport> LearnerHEFinancialSupports { get; }
        IQueryable<LearningDelivery> LearningDeliveries { get; }
        IQueryable<LearningDeliveryFAM> LearningDeliveryFAMs { get; }
        IQueryable<LearningDeliveryHE> LearningDeliveryHEs { get; }
        IQueryable<LearningDeliveryWorkPlacement> LearningDeliveryWorkPlacements { get; }
        IQueryable<LearningProvider> LearningProviders { get; }
        IQueryable<ProviderSpecDeliveryMonitoring> ProviderSpecDeliveryMonitorings { get; }
        IQueryable<ProviderSpecLearnerMonitoring> ProviderSpecLearnerMonitorings { get; }
        IQueryable<Source> Sources { get; }
        IQueryable<SourceFile> SourceFiles { get; }
    }
}
