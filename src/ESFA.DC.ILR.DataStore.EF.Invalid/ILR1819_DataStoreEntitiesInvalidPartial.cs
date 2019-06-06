using System.Linq;
using ESFA.DC.ILR1920.DataStore.EF.Invalid.Interface;

namespace ESFA.DC.ILR1920.DataStore.EF.Invalid
{
    public partial class ILR1819_DataStoreEntitiesInvalid : IIlr1819InvalidContext
    {
        IQueryable<AppFinRecord> IILR1819_DataStoreEntitiesInvalid.AppFinRecords => AppFinRecords;
        IQueryable<CollectionDetail> IILR1819_DataStoreEntitiesInvalid.CollectionDetails => CollectionDetails;
        IQueryable<ContactPreference> IILR1819_DataStoreEntitiesInvalid.ContactPreferences => ContactPreferences;
        IQueryable<DPOutcome> IILR1819_DataStoreEntitiesInvalid.DPOutcomes => DPOutcomes;
        IQueryable<EmploymentStatusMonitoring> IILR1819_DataStoreEntitiesInvalid.EmploymentStatusMonitorings => EmploymentStatusMonitorings;
        IQueryable<Learner> IILR1819_DataStoreEntitiesInvalid.Learners => Learners;
        IQueryable<LearnerDestinationandProgression> IILR1819_DataStoreEntitiesInvalid.LearnerDestinationandProgressions => LearnerDestinationandProgressions;
        IQueryable<LearnerEmploymentStatus> IILR1819_DataStoreEntitiesInvalid.LearnerEmploymentStatuses => LearnerEmploymentStatuses;
        IQueryable<LearnerFAM> IILR1819_DataStoreEntitiesInvalid.LearnerFAMs => LearnerFAMs;
        IQueryable<LearnerHE> IILR1819_DataStoreEntitiesInvalid.LearnerHEs => LearnerHEs;
        IQueryable<LearnerHEFinancialSupport> IILR1819_DataStoreEntitiesInvalid.LearnerHEFinancialSupports => LearnerHEFinancialSupports;
        IQueryable<LearningDelivery> IILR1819_DataStoreEntitiesInvalid.LearningDeliveries => LearningDeliveries;
        IQueryable<LearningDeliveryFAM> IILR1819_DataStoreEntitiesInvalid.LearningDeliveryFAMs => LearningDeliveryFAMs;
        IQueryable<LearningDeliveryHE> IILR1819_DataStoreEntitiesInvalid.LearningDeliveryHEs => LearningDeliveryHEs;
        IQueryable<LearningDeliveryWorkPlacement> IILR1819_DataStoreEntitiesInvalid.LearningDeliveryWorkPlacements => LearningDeliveryWorkPlacements;
        IQueryable<LearningProvider> IILR1819_DataStoreEntitiesInvalid.LearningProviders => LearningProviders;
        IQueryable<LLDDandHealthProblem> IILR1819_DataStoreEntitiesInvalid.LLDDandHealthProblems => LLDDandHealthProblems;
        IQueryable<ProviderSpecDeliveryMonitoring> IILR1819_DataStoreEntitiesInvalid.ProviderSpecDeliveryMonitorings => ProviderSpecDeliveryMonitorings;
        IQueryable<ProviderSpecLearnerMonitoring> IILR1819_DataStoreEntitiesInvalid.ProviderSpecLearnerMonitorings => ProviderSpecLearnerMonitorings;
        IQueryable<Source> IILR1819_DataStoreEntitiesInvalid.Sources => Sources;
        IQueryable<SourceFile> IILR1819_DataStoreEntitiesInvalid.SourceFiles => SourceFiles;
    }
}
