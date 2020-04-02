using System.Linq;
using ESFA.DC.ILR2021.DataStore.EF.Invalid.Interface;

namespace ESFA.DC.ILR2021.DataStore.EF.Invalid
{
    public partial class ILR2021_DataStoreEntitiesInvalid : IIlr2021InvalidContext
    {
        IQueryable<AppFinRecord> IILR2021_DataStoreEntitiesInvalid.AppFinRecords => AppFinRecords;
        IQueryable<CollectionDetail> IILR2021_DataStoreEntitiesInvalid.CollectionDetails => CollectionDetails;
        IQueryable<ContactPreference> IILR2021_DataStoreEntitiesInvalid.ContactPreferences => ContactPreferences;
        IQueryable<DPOutcome> IILR2021_DataStoreEntitiesInvalid.DPOutcomes => DPOutcomes;
        IQueryable<EmploymentStatusMonitoring> IILR2021_DataStoreEntitiesInvalid.EmploymentStatusMonitorings => EmploymentStatusMonitorings;
        IQueryable<Learner> IILR2021_DataStoreEntitiesInvalid.Learners => Learners;
        IQueryable<LearnerDestinationandProgression> IILR2021_DataStoreEntitiesInvalid.LearnerDestinationandProgressions => LearnerDestinationandProgressions;
        IQueryable<LearnerEmploymentStatus> IILR2021_DataStoreEntitiesInvalid.LearnerEmploymentStatuses => LearnerEmploymentStatuses;
        IQueryable<LearnerFAM> IILR2021_DataStoreEntitiesInvalid.LearnerFAMs => LearnerFAMs;
        IQueryable<LearnerHE> IILR2021_DataStoreEntitiesInvalid.LearnerHEs => LearnerHEs;
        IQueryable<LearnerHEFinancialSupport> IILR2021_DataStoreEntitiesInvalid.LearnerHEFinancialSupports => LearnerHEFinancialSupports;
        IQueryable<LearningDelivery> IILR2021_DataStoreEntitiesInvalid.LearningDeliveries => LearningDeliveries;
        IQueryable<LearningDeliveryFAM> IILR2021_DataStoreEntitiesInvalid.LearningDeliveryFAMs => LearningDeliveryFAMs;
        IQueryable<LearningDeliveryHE> IILR2021_DataStoreEntitiesInvalid.LearningDeliveryHEs => LearningDeliveryHEs;
        IQueryable<LearningDeliveryWorkPlacement> IILR2021_DataStoreEntitiesInvalid.LearningDeliveryWorkPlacements => LearningDeliveryWorkPlacements;
        IQueryable<LearningProvider> IILR2021_DataStoreEntitiesInvalid.LearningProviders => LearningProviders;
        IQueryable<LLDDandHealthProblem> IILR2021_DataStoreEntitiesInvalid.LLDDandHealthProblems => LLDDandHealthProblems;
        IQueryable<ProviderSpecDeliveryMonitoring> IILR2021_DataStoreEntitiesInvalid.ProviderSpecDeliveryMonitorings => ProviderSpecDeliveryMonitorings;
        IQueryable<ProviderSpecLearnerMonitoring> IILR2021_DataStoreEntitiesInvalid.ProviderSpecLearnerMonitorings => ProviderSpecLearnerMonitorings;
        IQueryable<Source> IILR2021_DataStoreEntitiesInvalid.Sources => Sources;
        IQueryable<SourceFile> IILR2021_DataStoreEntitiesInvalid.SourceFiles => SourceFiles;
    }
}
