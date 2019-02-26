using System.Linq;

namespace ESFA.DC.ILR1819.DataStore.EF.Invalid.Interface
{
    public interface IILR1819_DataStoreEntitiesInvalid
    {
        IQueryable<AppFinRecord> AppFinRecords { get; }
        IQueryable<CollectionDetail> CollectionDetails { get; }
        IQueryable<ContactPreference> ContactPreferences { get; }
        IQueryable<Dpoutcome> Dpoutcomes { get; }
        IQueryable<EmploymentStatusMonitoring> EmploymentStatusMonitorings { get; }
        IQueryable<Learner> Learners { get; }
        IQueryable<LearnerDestinationandProgression> LearnerDestinationandProgressions { get; }
        IQueryable<LearnerEmploymentStatus> LearnerEmploymentStatuses { get; }
        IQueryable<LearnerFam> LearnerFams { get; }
        IQueryable<LearnerHe> LearnerHes { get; }
        IQueryable<LearnerHefinancialSupport> LearnerHefinancialSupports { get; }
        IQueryable<LearningDelivery> LearningDeliveries { get; }
        IQueryable<LearningDeliveryFam> LearningDeliveryFams { get; }
        IQueryable<LearningDeliveryHe> LearningDeliveryHes { get; }
        IQueryable<LearningDeliveryWorkPlacement> LearningDeliveryWorkPlacements { get; }
        IQueryable<LearningProvider> LearningProviders { get; }
        IQueryable<LlddandHealthProblem> LlddandHealthProblems { get; }
        IQueryable<ProviderSpecDeliveryMonitoring> ProviderSpecDeliveryMonitorings { get; }
        IQueryable<ProviderSpecLearnerMonitoring> ProviderSpecLearnerMonitorings { get; }
        IQueryable<Source> Sources { get; }
        IQueryable<SourceFile> SourceFiles { get; }
    }
}
