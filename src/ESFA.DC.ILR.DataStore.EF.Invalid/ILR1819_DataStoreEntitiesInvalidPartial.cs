using System.Linq;
using ESFA.DC.ILR1920.DataStore.EF.Invalid.Interface;

namespace ESFA.DC.ILR1920.DataStore.EF.Invalid
{
    public partial class ILR1819_DataStoreEntitiesInvalid : IIlr1920InvalidContext
    {
        IQueryable<AppFinRecord> IILR1920_DataStoreEntitiesInvalid.AppFinRecords => AppFinRecords;
        IQueryable<CollectionDetail> IILR1920_DataStoreEntitiesInvalid.CollectionDetails => CollectionDetails;
        IQueryable<ContactPreference> IILR1920_DataStoreEntitiesInvalid.ContactPreferences => ContactPreferences;
        IQueryable<DPOutcome> IILR1920_DataStoreEntitiesInvalid.DPOutcomes => DPOutcomes;
        IQueryable<EmploymentStatusMonitoring> IILR1920_DataStoreEntitiesInvalid.EmploymentStatusMonitorings => EmploymentStatusMonitorings;
        IQueryable<Learner> IILR1920_DataStoreEntitiesInvalid.Learners => Learners;
        IQueryable<LearnerDestinationandProgression> IILR1920_DataStoreEntitiesInvalid.LearnerDestinationandProgressions => LearnerDestinationandProgressions;
        IQueryable<LearnerEmploymentStatus> IILR1920_DataStoreEntitiesInvalid.LearnerEmploymentStatuses => LearnerEmploymentStatuses;
        IQueryable<LearnerFAM> IILR1920_DataStoreEntitiesInvalid.LearnerFAMs => LearnerFAMs;
        IQueryable<LearnerHE> IILR1920_DataStoreEntitiesInvalid.LearnerHEs => LearnerHEs;
        IQueryable<LearnerHEFinancialSupport> IILR1920_DataStoreEntitiesInvalid.LearnerHEFinancialSupports => LearnerHEFinancialSupports;
        IQueryable<LearningDelivery> IILR1920_DataStoreEntitiesInvalid.LearningDeliveries => LearningDeliveries;
        IQueryable<LearningDeliveryFAM> IILR1920_DataStoreEntitiesInvalid.LearningDeliveryFAMs => LearningDeliveryFAMs;
        IQueryable<LearningDeliveryHE> IILR1920_DataStoreEntitiesInvalid.LearningDeliveryHEs => LearningDeliveryHEs;
        IQueryable<LearningDeliveryWorkPlacement> IILR1920_DataStoreEntitiesInvalid.LearningDeliveryWorkPlacements => LearningDeliveryWorkPlacements;
        IQueryable<LearningProvider> IILR1920_DataStoreEntitiesInvalid.LearningProviders => LearningProviders;
        IQueryable<LLDDandHealthProblem> IILR1920_DataStoreEntitiesInvalid.LLDDandHealthProblems => LLDDandHealthProblems;
        IQueryable<ProviderSpecDeliveryMonitoring> IILR1920_DataStoreEntitiesInvalid.ProviderSpecDeliveryMonitorings => ProviderSpecDeliveryMonitorings;
        IQueryable<ProviderSpecLearnerMonitoring> IILR1920_DataStoreEntitiesInvalid.ProviderSpecLearnerMonitorings => ProviderSpecLearnerMonitorings;
        IQueryable<Source> IILR1920_DataStoreEntitiesInvalid.Sources => Sources;
        IQueryable<SourceFile> IILR1920_DataStoreEntitiesInvalid.SourceFiles => SourceFiles;
    }
}
