using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESFA.DC.ILR1819.DataStore.EF.Valid.Interface;

namespace ESFA.DC.ILR1819.DataStore.EF.Valid
{
    public partial class ILR1819_DataStoreEntitiesValid : IIlr1819ValidContext
    {
        IQueryable<AppFinRecord> IILR1819_DataStoreEntitiesValid.AppFinRecords => AppFinRecords;
        IQueryable<CollectionDetail> IILR1819_DataStoreEntitiesValid.CollectionDetails => CollectionDetails;
        IQueryable<ContactPreference> IILR1819_DataStoreEntitiesValid.ContactPreferences => ContactPreferences;
        IQueryable<DPOutcome> IILR1819_DataStoreEntitiesValid.DPOutcomes => DPOutcomes;
        IQueryable<EmploymentStatusMonitoring> IILR1819_DataStoreEntitiesValid.EmploymentStatusMonitorings => EmploymentStatusMonitorings;
        IQueryable<Learner> IILR1819_DataStoreEntitiesValid.Learners => Learners;
        IQueryable<LearnerDestinationandProgression> IILR1819_DataStoreEntitiesValid.LearnerDestinationandProgressions => LearnerDestinationandProgressions;
        IQueryable<LearnerEmploymentStatus> IILR1819_DataStoreEntitiesValid.LearnerEmploymentStatuses => LearnerEmploymentStatuses;
        IQueryable<LearnerFAM> IILR1819_DataStoreEntitiesValid.LearnerFAMs => LearnerFAMs;
        IQueryable<LearnerHE> IILR1819_DataStoreEntitiesValid.LearnerHEs => LearnerHEs;
        IQueryable<LearnerHEFinancialSupport> IILR1819_DataStoreEntitiesValid.LearnerHEFinancialSupports => LearnerHEFinancialSupports;
        IQueryable<LearningDelivery> IILR1819_DataStoreEntitiesValid.LearningDeliveries => LearningDeliveries;
        IQueryable<LearningDeliveryFAM> IILR1819_DataStoreEntitiesValid.LearningDeliveryFAMs => LearningDeliveryFAMs;
        IQueryable<LearningDeliveryHE> IILR1819_DataStoreEntitiesValid.LearningDeliveryHEs => LearningDeliveryHEs;
        IQueryable<LearningDeliveryWorkPlacement> IILR1819_DataStoreEntitiesValid.LearningDeliveryWorkPlacements => LearningDeliveryWorkPlacements;
        IQueryable<LearningProvider> IILR1819_DataStoreEntitiesValid.LearningProviders => LearningProviders;
        IQueryable<LLDDandHealthProblem> IILR1819_DataStoreEntitiesValid.LLDDandHealthProblems => LLDDandHealthProblems;
        IQueryable<ProviderSpecDeliveryMonitoring> IILR1819_DataStoreEntitiesValid.ProviderSpecDeliveryMonitorings => ProviderSpecDeliveryMonitorings;
        IQueryable<ProviderSpecLearnerMonitoring> IILR1819_DataStoreEntitiesValid.ProviderSpecLearnerMonitorings => ProviderSpecLearnerMonitorings;
        IQueryable<Source> IILR1819_DataStoreEntitiesValid.Sources => Sources;
        IQueryable<SourceFile> IILR1819_DataStoreEntitiesValid.SourceFiles => SourceFiles;
    }
}
