using System.Linq;
using ESFA.DC.ILR2021.DataStore.EF.Interface;
using Microsoft.EntityFrameworkCore;

namespace ESFA.DC.ILR2021.DataStore.EF
{
    public partial class ILR2021_DataStoreEntities : IIlr2021Context
    {
        IQueryable<AppFinRecord> IILR2021_DataStoreEntities.AppFinRecords => AppFinRecords;
        IQueryable<CollectionDetail> IILR2021_DataStoreEntities.CollectionDetails => CollectionDetails;
        IQueryable<ContactPreference> IILR2021_DataStoreEntities.ContactPreferences => ContactPreferences;
        IQueryable<DPOutcome> IILR2021_DataStoreEntities.DPOutcomes => DPOutcomes;
        IQueryable<EmploymentStatusMonitoring> IILR2021_DataStoreEntities.EmploymentStatusMonitorings => EmploymentStatusMonitorings;
        IQueryable<Learner> IILR2021_DataStoreEntities.Learners => Learners;
        IQueryable<LearnerDestinationandProgression> IILR2021_DataStoreEntities.LearnerDestinationandProgressions => LearnerDestinationandProgressions;
        IQueryable<LearnerEmploymentStatus> IILR2021_DataStoreEntities.LearnerEmploymentStatuses => LearnerEmploymentStatuses;
        IQueryable<LearnerFAM> IILR2021_DataStoreEntities.LearnerFAMs => LearnerFAMs;
        IQueryable<LearnerHE> IILR2021_DataStoreEntities.LearnerHEs => LearnerHEs;
        IQueryable<LearnerHEFinancialSupport> IILR2021_DataStoreEntities.LearnerHEFinancialSupports => LearnerHEFinancialSupports;
        IQueryable<LearningDelivery> IILR2021_DataStoreEntities.LearningDeliveries => LearningDeliveries;
        IQueryable<LearningDeliveryFAM> IILR2021_DataStoreEntities.LearningDeliveryFAMs => LearningDeliveryFAMs;
        IQueryable<LearningDeliveryHE> IILR2021_DataStoreEntities.LearningDeliveryHEs => LearningDeliveryHEs;
        IQueryable<LearningDeliveryWorkPlacement> IILR2021_DataStoreEntities.LearningDeliveryWorkPlacements => LearningDeliveryWorkPlacements;
        IQueryable<LearningProvider> IILR2021_DataStoreEntities.LearningProviders => LearningProviders;
        IQueryable<LLDDandHealthProblem> IILR2021_DataStoreEntities.LLDDandHealthProblems => LLDDandHealthProblems;
        IQueryable<ProviderSpecDeliveryMonitoring> IILR2021_DataStoreEntities.ProviderSpecDeliveryMonitorings => ProviderSpecDeliveryMonitorings;
        IQueryable<ProviderSpecLearnerMonitoring> IILR2021_DataStoreEntities.ProviderSpecLearnerMonitorings => ProviderSpecLearnerMonitorings;
        IQueryable<Source> IILR2021_DataStoreEntities.Sources => Sources;
        IQueryable<SourceFile> IILR2021_DataStoreEntities.SourceFiles => SourceFiles;

        // period end stored procedure output type
        public virtual DbSet<PeriodEndMetricsEntity> PeriodEndMetrics { get; set; }
        public virtual DbSet<ACTCountsEntity> ActCounts { get; set; }

        IQueryable<AEC_ApprenticeshipPriceEpisode> IILR2021_DataStoreEntities.AEC_ApprenticeshipPriceEpisodes => AEC_ApprenticeshipPriceEpisodes;
        IQueryable<AEC_ApprenticeshipPriceEpisode_Period> IILR2021_DataStoreEntities.AEC_ApprenticeshipPriceEpisode_Periods => AEC_ApprenticeshipPriceEpisode_Periods;
        IQueryable<AEC_ApprenticeshipPriceEpisode_PeriodisedValue> IILR2021_DataStoreEntities.AEC_ApprenticeshipPriceEpisode_PeriodisedValues => AEC_ApprenticeshipPriceEpisode_PeriodisedValues;
        IQueryable<AEC_HistoricEarningOutput> IILR2021_DataStoreEntities.AEC_HistoricEarningOutputs => AEC_HistoricEarningOutputs;
        IQueryable<AEC_Learner> IILR2021_DataStoreEntities.AEC_Learners => AEC_Learners;
        IQueryable<AEC_LearningDelivery> IILR2021_DataStoreEntities.AEC_LearningDeliveries => AEC_LearningDeliveries;
        IQueryable<AEC_LearningDelivery_Period> IILR2021_DataStoreEntities.AEC_LearningDelivery_Periods => AEC_LearningDelivery_Periods;
        IQueryable<AEC_LearningDelivery_PeriodisedTextValue> IILR2021_DataStoreEntities.AEC_LearningDelivery_PeriodisedTextValues => AEC_LearningDelivery_PeriodisedTextValues;
        IQueryable<AEC_LearningDelivery_PeriodisedValue> IILR2021_DataStoreEntities.AEC_LearningDelivery_PeriodisedValues => AEC_LearningDelivery_PeriodisedValues;
        IQueryable<AEC_global> IILR2021_DataStoreEntities.AEC_globals => AEC_globals;
        IQueryable<ALB_Learner> IILR2021_DataStoreEntities.ALB_Learners => ALB_Learners;
        IQueryable<ALB_Learner_Period> IILR2021_DataStoreEntities.ALB_Learner_Periods => ALB_Learner_Periods;
        IQueryable<ALB_Learner_PeriodisedValue> IILR2021_DataStoreEntities.ALB_Learner_PeriodisedValues => ALB_Learner_PeriodisedValues;
        IQueryable<ALB_LearningDelivery> IILR2021_DataStoreEntities.ALB_LearningDeliveries => ALB_LearningDeliveries;
        IQueryable<ALB_LearningDelivery_Period> IILR2021_DataStoreEntities.ALB_LearningDelivery_Periods => ALB_LearningDelivery_Periods;
        IQueryable<ALB_LearningDelivery_PeriodisedValue> IILR2021_DataStoreEntities.ALB_LearningDelivery_PeriodisedValues => ALB_LearningDelivery_PeriodisedValues;
        IQueryable<ALB_global> IILR2021_DataStoreEntities.ALB_globals => ALB_globals;
        IQueryable<DV_Learner> IILR2021_DataStoreEntities.DV_Learners => DV_Learners;
        IQueryable<DV_LearningDelivery> IILR2021_DataStoreEntities.DV_LearningDeliveries => DV_LearningDeliveries;
        IQueryable<DV_global> IILR2021_DataStoreEntities.DV_globals => DV_globals;
        IQueryable<ESFVAL_ValidationError> IILR2021_DataStoreEntities.ESFVAL_ValidationErrors => ESFVAL_ValidationErrors;
        IQueryable<ESFVAL_global> IILR2021_DataStoreEntities.ESFVAL_globals => ESFVAL_globals;
        IQueryable<ESF_DPOutcome> IILR2021_DataStoreEntities.ESF_DPOutcomes => ESF_DPOutcomes;
        IQueryable<ESF_Learner> IILR2021_DataStoreEntities.ESF_Learners => ESF_Learners;
        IQueryable<ESF_LearningDelivery> IILR2021_DataStoreEntities.ESF_LearningDeliveries => ESF_LearningDeliveries;
        IQueryable<ESF_LearningDeliveryDeliverable> IILR2021_DataStoreEntities.ESF_LearningDeliveryDeliverables => ESF_LearningDeliveryDeliverables;
        IQueryable<ESF_LearningDeliveryDeliverable_Period> IILR2021_DataStoreEntities.ESF_LearningDeliveryDeliverable_Periods => ESF_LearningDeliveryDeliverable_Periods;
        IQueryable<ESF_LearningDeliveryDeliverable_PeriodisedValue> IILR2021_DataStoreEntities.ESF_LearningDeliveryDeliverable_PeriodisedValues => ESF_LearningDeliveryDeliverable_PeriodisedValues;
        IQueryable<ESF_global> IILR2021_DataStoreEntities.ESF_globals => ESF_globals;
        IQueryable<FM25_FM35_Learner_Period> IILR2021_DataStoreEntities.FM25_FM35_Learner_Periods => FM25_FM35_Learner_Periods;
        IQueryable<FM25_FM35_Learner_PeriodisedValue> IILR2021_DataStoreEntities.FM25_FM35_Learner_PeriodisedValues => FM25_FM35_Learner_PeriodisedValues;
        IQueryable<FM25_FM35_global> IILR2021_DataStoreEntities.FM25_FM35_globals => FM25_FM35_globals;
        IQueryable<FM25_Learner> IILR2021_DataStoreEntities.FM25_Learners => FM25_Learners;
        IQueryable<FM25_global> IILR2021_DataStoreEntities.FM25_globals => FM25_globals;
        IQueryable<FM35_Learner> IILR2021_DataStoreEntities.FM35_Learners => FM35_Learners;
        IQueryable<FM35_LearningDelivery> IILR2021_DataStoreEntities.FM35_LearningDeliveries => FM35_LearningDeliveries;
        IQueryable<FM35_LearningDelivery_Period> IILR2021_DataStoreEntities.FM35_LearningDelivery_Periods => FM35_LearningDelivery_Periods;
        IQueryable<FM35_LearningDelivery_PeriodisedValue> IILR2021_DataStoreEntities.FM35_LearningDelivery_PeriodisedValues => FM35_LearningDelivery_PeriodisedValues;
        IQueryable<FM35_global> IILR2021_DataStoreEntities.FM35_globals => FM35_globals;
        IQueryable<FileDetail> IILR2021_DataStoreEntities.FileDetails => FileDetails;
        IQueryable<ProcessingData> IILR2021_DataStoreEntities.ProcessingDatas => ProcessingDatas;
        IQueryable<TBL_Learner> IILR2021_DataStoreEntities.TBL_Learners => TBL_Learners;
        IQueryable<TBL_LearningDelivery> IILR2021_DataStoreEntities.TBL_LearningDeliveries => TBL_LearningDeliveries;
        IQueryable<TBL_LearningDelivery_Period> IILR2021_DataStoreEntities.TBL_LearningDelivery_Periods => TBL_LearningDelivery_Periods;
        IQueryable<TBL_LearningDelivery_PeriodisedValue> IILR2021_DataStoreEntities.TBL_LearningDelivery_PeriodisedValues => TBL_LearningDelivery_PeriodisedValues;
        IQueryable<TBL_global> IILR2021_DataStoreEntities.TBL_globals => TBL_globals;
        IQueryable<VALDP_ValidationError> IILR2021_DataStoreEntities.VALDP_ValidationErrors => VALDP_ValidationErrors;
        IQueryable<VALDP_global> IILR2021_DataStoreEntities.VALDP_globals => VALDP_globals;
        IQueryable<VALFD_ValidationError> IILR2021_DataStoreEntities.VALFD_ValidationErrors => VALFD_ValidationErrors;
        IQueryable<VAL_Learner> IILR2021_DataStoreEntities.VAL_Learners => VAL_Learners;
        IQueryable<VAL_LearningDelivery> IILR2021_DataStoreEntities.VAL_LearningDeliveries => VAL_LearningDeliveries;
        IQueryable<VAL_ValidationError> IILR2021_DataStoreEntities.VAL_ValidationErrors => VAL_ValidationErrors;
        IQueryable<VAL_global> IILR2021_DataStoreEntities.VAL_globals => VAL_globals;
        IQueryable<ValidationError> IILR2021_DataStoreEntities.ValidationErrors => ValidationErrors;
        IQueryable<VersionInfo> IILR2021_DataStoreEntities.VersionInfos => VersionInfos;
    }
}
