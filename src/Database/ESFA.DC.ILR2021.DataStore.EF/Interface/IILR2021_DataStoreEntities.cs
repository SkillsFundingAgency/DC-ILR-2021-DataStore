using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ESFA.DC.ILR2021.DataStore.EF.Interface
{
    public interface IILR2021_DataStoreEntities : IDisposable
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

        DbSet<PeriodEndMetricsEntity> PeriodEndMetrics { get; set; }

        DbSet<ACTCountsEntity> ActCounts { get; set; }

        IQueryable<AEC_ApprenticeshipPriceEpisode> AEC_ApprenticeshipPriceEpisodes { get; }
        IQueryable<AEC_ApprenticeshipPriceEpisode_Period> AEC_ApprenticeshipPriceEpisode_Periods { get; }
        IQueryable<AEC_ApprenticeshipPriceEpisode_PeriodisedValue> AEC_ApprenticeshipPriceEpisode_PeriodisedValues { get; }
        IQueryable<AEC_HistoricEarningOutput> AEC_HistoricEarningOutputs { get; }
        IQueryable<AEC_Learner> AEC_Learners { get; }
        IQueryable<AEC_LearningDelivery> AEC_LearningDeliveries { get; }
        IQueryable<AEC_LearningDelivery_Period> AEC_LearningDelivery_Periods { get; }
        IQueryable<AEC_LearningDelivery_PeriodisedTextValue> AEC_LearningDelivery_PeriodisedTextValues { get; }
        IQueryable<AEC_LearningDelivery_PeriodisedValue> AEC_LearningDelivery_PeriodisedValues { get; }
        IQueryable<AEC_global> AEC_globals { get; }
        IQueryable<ALB_Learner> ALB_Learners { get; }
        IQueryable<ALB_Learner_Period> ALB_Learner_Periods { get; }
        IQueryable<ALB_Learner_PeriodisedValue> ALB_Learner_PeriodisedValues { get; }
        IQueryable<ALB_LearningDelivery> ALB_LearningDeliveries { get; }
        IQueryable<ALB_LearningDelivery_Period> ALB_LearningDelivery_Periods { get; }
        IQueryable<ALB_LearningDelivery_PeriodisedValue> ALB_LearningDelivery_PeriodisedValues { get; }
        IQueryable<ALB_global> ALB_globals { get; }
        IQueryable<DV_Learner> DV_Learners { get; }
        IQueryable<DV_LearningDelivery> DV_LearningDeliveries { get; }
        IQueryable<DV_global> DV_globals { get; }
        IQueryable<ESFVAL_ValidationError> ESFVAL_ValidationErrors { get; }
        IQueryable<ESFVAL_global> ESFVAL_globals { get; }
        IQueryable<ESF_DPOutcome> ESF_DPOutcomes { get; }
        IQueryable<ESF_Learner> ESF_Learners { get; }
        IQueryable<ESF_LearningDelivery> ESF_LearningDeliveries { get; }
        IQueryable<ESF_LearningDeliveryDeliverable> ESF_LearningDeliveryDeliverables { get; }
        IQueryable<ESF_LearningDeliveryDeliverable_Period> ESF_LearningDeliveryDeliverable_Periods { get; }
        IQueryable<ESF_LearningDeliveryDeliverable_PeriodisedValue> ESF_LearningDeliveryDeliverable_PeriodisedValues { get; }
        IQueryable<ESF_global> ESF_globals { get; }
        IQueryable<FM25_FM35_Learner_Period> FM25_FM35_Learner_Periods { get; }
        IQueryable<FM25_FM35_Learner_PeriodisedValue> FM25_FM35_Learner_PeriodisedValues { get; }
        IQueryable<FM25_FM35_global> FM25_FM35_globals { get; }
        IQueryable<FM25_Learner> FM25_Learners { get; }
        IQueryable<FM25_global> FM25_globals { get; }
        IQueryable<FM35_Learner> FM35_Learners { get; }
        IQueryable<FM35_LearningDelivery> FM35_LearningDeliveries { get; }
        IQueryable<FM35_LearningDelivery_Period> FM35_LearningDelivery_Periods { get; }
        IQueryable<FM35_LearningDelivery_PeriodisedValue> FM35_LearningDelivery_PeriodisedValues { get; }
        IQueryable<FM35_global> FM35_globals { get; }
        IQueryable<FileDetail> FileDetails { get; }
        IQueryable<ProcessingData> ProcessingDatas { get; }
        IQueryable<TBL_Learner> TBL_Learners { get; }
        IQueryable<TBL_LearningDelivery> TBL_LearningDeliveries { get; }
        IQueryable<TBL_LearningDelivery_Period> TBL_LearningDelivery_Periods { get; }
        IQueryable<TBL_LearningDelivery_PeriodisedValue> TBL_LearningDelivery_PeriodisedValues { get; }
        IQueryable<TBL_global> TBL_globals { get; }
        IQueryable<VALDP_ValidationError> VALDP_ValidationErrors { get; }
        IQueryable<VALDP_global> VALDP_globals { get; }
        IQueryable<VALFD_ValidationError> VALFD_ValidationErrors { get; }
        IQueryable<VAL_Learner> VAL_Learners { get; }
        IQueryable<VAL_LearningDelivery> VAL_LearningDeliveries { get; }
        IQueryable<VAL_ValidationError> VAL_ValidationErrors { get; }
        IQueryable<VAL_global> VAL_globals { get; }
        IQueryable<ValidationError> ValidationErrors { get; }
        IQueryable<VersionInfo> VersionInfos { get; }
    }
}
