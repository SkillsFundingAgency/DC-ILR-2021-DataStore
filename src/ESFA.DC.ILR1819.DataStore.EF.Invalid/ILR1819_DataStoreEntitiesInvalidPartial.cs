using System.Linq;
using ESFA.DC.ILR1819.DataStore.EF.Invalid.Interface;

namespace ESFA.DC.ILR1819.DataStore.EF.Invalid
{
    public partial class ILR1819_DataStoreEntitiesInvalid : IIlr1819InvalidContext
    {
        IQueryable<AppFinRecord> IILR1819_DataStoreEntitiesInvalid.AppFinRecords => AppFinRecords;
        IQueryable<CollectionDetail> IILR1819_DataStoreEntitiesInvalid.CollectionDetails => CollectionDetails;
        IQueryable<ContactPreference> IILR1819_DataStoreEntitiesInvalid.ContactPreferences => ContactPreferences;
        IQueryable<Dpoutcome> IILR1819_DataStoreEntitiesInvalid.Dpoutcomes => Dpoutcomes;
        IQueryable<EmploymentStatusMonitoring> IILR1819_DataStoreEntitiesInvalid.EmploymentStatusMonitorings => EmploymentStatusMonitorings;
        IQueryable<Learner> IILR1819_DataStoreEntitiesInvalid.Learners => Learners;
        IQueryable<LearnerDestinationandProgression> IILR1819_DataStoreEntitiesInvalid.LearnerDestinationandProgressions => LearnerDestinationandProgressions;
        IQueryable<LearnerEmploymentStatus> IILR1819_DataStoreEntitiesInvalid.LearnerEmploymentStatuses => LearnerEmploymentStatuses;
        IQueryable<LearnerFam> IILR1819_DataStoreEntitiesInvalid.LearnerFams => LearnerFams;
        IQueryable<LearnerHe> IILR1819_DataStoreEntitiesInvalid.LearnerHes => LearnerHes;
        IQueryable<LearnerHefinancialSupport> IILR1819_DataStoreEntitiesInvalid.LearnerHefinancialSupports => LearnerHefinancialSupports;
        IQueryable<LearningDelivery> IILR1819_DataStoreEntitiesInvalid.LearningDeliveries => LearningDeliveries;
        IQueryable<LearningDeliveryFam> IILR1819_DataStoreEntitiesInvalid.LearningDeliveryFams => LearningDeliveryFams;
        IQueryable<LearningDeliveryHe> IILR1819_DataStoreEntitiesInvalid.LearningDeliveryHes => LearningDeliveryHes;
        IQueryable<LearningDeliveryWorkPlacement> IILR1819_DataStoreEntitiesInvalid.LearningDeliveryWorkPlacements => LearningDeliveryWorkPlacements;
        IQueryable<LearningProvider> IILR1819_DataStoreEntitiesInvalid.LearningProviders => LearningProviders;
        IQueryable<LlddandHealthProblem> IILR1819_DataStoreEntitiesInvalid.LlddandHealthProblems => LlddandHealthProblems;
        IQueryable<ProviderSpecDeliveryMonitoring> IILR1819_DataStoreEntitiesInvalid.ProviderSpecDeliveryMonitorings => ProviderSpecDeliveryMonitorings;
        IQueryable<ProviderSpecLearnerMonitoring> IILR1819_DataStoreEntitiesInvalid.ProviderSpecLearnerMonitorings => ProviderSpecLearnerMonitorings;
        IQueryable<Source> IILR1819_DataStoreEntitiesInvalid.Sources => Sources;
        IQueryable<SourceFile> IILR1819_DataStoreEntitiesInvalid.SourceFiles => SourceFiles;
    }
}
