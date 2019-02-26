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
        IQueryable<Dpoutcome> IILR1819_DataStoreEntitiesValid.Dpoutcomes => Dpoutcomes;
        IQueryable<EmploymentStatusMonitoring> IILR1819_DataStoreEntitiesValid.EmploymentStatusMonitorings => EmploymentStatusMonitorings;
        IQueryable<Learner> IILR1819_DataStoreEntitiesValid.Learners => Learners;
        IQueryable<LearnerDestinationandProgression> IILR1819_DataStoreEntitiesValid.LearnerDestinationandProgressions => LearnerDestinationandProgressions;
        IQueryable<LearnerEmploymentStatus> IILR1819_DataStoreEntitiesValid.LearnerEmploymentStatuses => LearnerEmploymentStatuses;
        IQueryable<LearnerFam> IILR1819_DataStoreEntitiesValid.LearnerFams => LearnerFams;
        IQueryable<LearnerHe> IILR1819_DataStoreEntitiesValid.LearnerHes => LearnerHes;
        IQueryable<LearnerHefinancialSupport> IILR1819_DataStoreEntitiesValid.LearnerHefinancialSupports => LearnerHefinancialSupports;
        IQueryable<LearningDelivery> IILR1819_DataStoreEntitiesValid.LearningDeliveries => LearningDeliveries;
        IQueryable<LearningDeliveryFam> IILR1819_DataStoreEntitiesValid.LearningDeliveryFams => LearningDeliveryFams;
        IQueryable<LearningDeliveryHe> IILR1819_DataStoreEntitiesValid.LearningDeliveryHes => LearningDeliveryHes;
        IQueryable<LearningDeliveryWorkPlacement> IILR1819_DataStoreEntitiesValid.LearningDeliveryWorkPlacements => LearningDeliveryWorkPlacements;
        IQueryable<LearningProvider> IILR1819_DataStoreEntitiesValid.LearningProviders => LearningProviders;
        IQueryable<LlddandHealthProblem> IILR1819_DataStoreEntitiesValid.LlddandHealthProblems => LlddandHealthProblems;
        IQueryable<ProviderSpecDeliveryMonitoring> IILR1819_DataStoreEntitiesValid.ProviderSpecDeliveryMonitorings => ProviderSpecDeliveryMonitorings;
        IQueryable<ProviderSpecLearnerMonitoring> IILR1819_DataStoreEntitiesValid.ProviderSpecLearnerMonitorings => ProviderSpecLearnerMonitorings;
        IQueryable<Source> IILR1819_DataStoreEntitiesValid.Sources => Sources;
        IQueryable<SourceFile> IILR1819_DataStoreEntitiesValid.SourceFiles => SourceFiles;
    }
}
