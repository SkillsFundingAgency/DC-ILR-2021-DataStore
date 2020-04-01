using System.Linq;
using ESFA.DC.ILR1920.DataStore.EF.Interface;

namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class ILR1920_DataStoreEntities : IIlr1920RulebaseContext
    {
        IQueryable<AEC_ApprenticeshipPriceEpisode> IILR1920_DataStoreEntities.AEC_ApprenticeshipPriceEpisodes => AEC_ApprenticeshipPriceEpisodes;
        IQueryable<AEC_ApprenticeshipPriceEpisode_Period> IILR1920_DataStoreEntities.AEC_ApprenticeshipPriceEpisode_Periods => AEC_ApprenticeshipPriceEpisode_Periods;
        IQueryable<AEC_ApprenticeshipPriceEpisode_PeriodisedValue> IILR1920_DataStoreEntities.AEC_ApprenticeshipPriceEpisode_PeriodisedValues => AEC_ApprenticeshipPriceEpisode_PeriodisedValues;
        IQueryable<AEC_HistoricEarningOutput> IILR1920_DataStoreEntities.AEC_HistoricEarningOutputs => AEC_HistoricEarningOutputs;
        IQueryable<AEC_Learner> IILR1920_DataStoreEntities.AEC_Learners => AEC_Learners;
        IQueryable<AEC_LearningDelivery> IILR1920_DataStoreEntities.AEC_LearningDeliveries => AEC_LearningDeliveries;
        IQueryable<AEC_LearningDelivery_Period> IILR1920_DataStoreEntities.AEC_LearningDelivery_Periods => AEC_LearningDelivery_Periods;
        IQueryable<AEC_LearningDelivery_PeriodisedTextValue> IILR1920_DataStoreEntities.AEC_LearningDelivery_PeriodisedTextValues => AEC_LearningDelivery_PeriodisedTextValues;
        IQueryable<AEC_LearningDelivery_PeriodisedValue> IILR1920_DataStoreEntities.AEC_LearningDelivery_PeriodisedValues => AEC_LearningDelivery_PeriodisedValues;
        IQueryable<AEC_global> IILR1920_DataStoreEntities.AEC_globals => AEC_globals;
        IQueryable<ALB_Learner> IILR1920_DataStoreEntities.ALB_Learners => ALB_Learners;
        IQueryable<ALB_Learner_Period> IILR1920_DataStoreEntities.ALB_Learner_Periods => ALB_Learner_Periods;
        IQueryable<ALB_Learner_PeriodisedValue> IILR1920_DataStoreEntities.ALB_Learner_PeriodisedValues => ALB_Learner_PeriodisedValues;
        IQueryable<ALB_LearningDelivery> IILR1920_DataStoreEntities.ALB_LearningDeliveries => ALB_LearningDeliveries;
        IQueryable<ALB_LearningDelivery_Period> IILR1920_DataStoreEntities.ALB_LearningDelivery_Periods => ALB_LearningDelivery_Periods;
        IQueryable<ALB_LearningDelivery_PeriodisedValue> IILR1920_DataStoreEntities.ALB_LearningDelivery_PeriodisedValues => ALB_LearningDelivery_PeriodisedValues;
        IQueryable<ALB_global> IILR1920_DataStoreEntities.ALB_globals => ALB_globals;
        IQueryable<DV_Learner> IILR1920_DataStoreEntities.DV_Learners => DV_Learners;
        IQueryable<DV_LearningDelivery> IILR1920_DataStoreEntities.DV_LearningDeliveries => DV_LearningDeliveries;
        IQueryable<DV_global> IILR1920_DataStoreEntities.DV_globals => DV_globals;
        IQueryable<ESFVAL_ValidationError> IILR1920_DataStoreEntities.ESFVAL_ValidationErrors => ESFVAL_ValidationErrors;
        IQueryable<ESFVAL_global> IILR1920_DataStoreEntities.ESFVAL_globals => ESFVAL_globals;
        IQueryable<ESF_DPOutcome> IILR1920_DataStoreEntities.ESF_DPOutcomes => ESF_DPOutcomes;
        IQueryable<ESF_Learner> IILR1920_DataStoreEntities.ESF_Learners => ESF_Learners;
        IQueryable<ESF_LearningDelivery> IILR1920_DataStoreEntities.ESF_LearningDeliveries => ESF_LearningDeliveries;
        IQueryable<ESF_LearningDeliveryDeliverable> IILR1920_DataStoreEntities.ESF_LearningDeliveryDeliverables => ESF_LearningDeliveryDeliverables;
        IQueryable<ESF_LearningDeliveryDeliverable_Period> IILR1920_DataStoreEntities.ESF_LearningDeliveryDeliverable_Periods => ESF_LearningDeliveryDeliverable_Periods;
        IQueryable<ESF_LearningDeliveryDeliverable_PeriodisedValue> IILR1920_DataStoreEntities.ESF_LearningDeliveryDeliverable_PeriodisedValues => ESF_LearningDeliveryDeliverable_PeriodisedValues;
        IQueryable<ESF_global> IILR1920_DataStoreEntities.ESF_globals => ESF_globals;
        IQueryable<FM25_FM35_Learner_Period> IILR1920_DataStoreEntities.FM25_FM35_Learner_Periods => FM25_FM35_Learner_Periods;
        IQueryable<FM25_FM35_Learner_PeriodisedValue> IILR1920_DataStoreEntities.FM25_FM35_Learner_PeriodisedValues => FM25_FM35_Learner_PeriodisedValues;
        IQueryable<FM25_FM35_global> IILR1920_DataStoreEntities.FM25_FM35_globals => FM25_FM35_globals;
        IQueryable<FM25_Learner> IILR1920_DataStoreEntities.FM25_Learners => FM25_Learners;
        IQueryable<FM25_global> IILR1920_DataStoreEntities.FM25_globals => FM25_globals;
        IQueryable<FM35_Learner> IILR1920_DataStoreEntities.FM35_Learners => FM35_Learners;
        IQueryable<FM35_LearningDelivery> IILR1920_DataStoreEntities.FM35_LearningDeliveries => FM35_LearningDeliveries;
        IQueryable<FM35_LearningDelivery_Period> IILR1920_DataStoreEntities.FM35_LearningDelivery_Periods => FM35_LearningDelivery_Periods;
        IQueryable<FM35_LearningDelivery_PeriodisedValue> IILR1920_DataStoreEntities.FM35_LearningDelivery_PeriodisedValues => FM35_LearningDelivery_PeriodisedValues;
        IQueryable<FM35_global> IILR1920_DataStoreEntities.FM35_globals => FM35_globals;
        IQueryable<FileDetail> IILR1920_DataStoreEntities.FileDetails => FileDetails;
        IQueryable<ProcessingData> IILR1920_DataStoreEntities.ProcessingDatas => ProcessingDatas;
        IQueryable<TBL_Learner> IILR1920_DataStoreEntities.TBL_Learners => TBL_Learners;
        IQueryable<TBL_LearningDelivery> IILR1920_DataStoreEntities.TBL_LearningDeliveries => TBL_LearningDeliveries;
        IQueryable<TBL_LearningDelivery_Period> IILR1920_DataStoreEntities.TBL_LearningDelivery_Periods => TBL_LearningDelivery_Periods;
        IQueryable<TBL_LearningDelivery_PeriodisedValue> IILR1920_DataStoreEntities.TBL_LearningDelivery_PeriodisedValues => TBL_LearningDelivery_PeriodisedValues;
        IQueryable<TBL_global> IILR1920_DataStoreEntities.TBL_globals => TBL_globals;
        IQueryable<VALDP_ValidationError> IILR1920_DataStoreEntities.VALDP_ValidationErrors => VALDP_ValidationErrors;
        IQueryable<VALDP_global> IILR1920_DataStoreEntities.VALDP_globals => VALDP_globals;
        IQueryable<VALFD_ValidationError> IILR1920_DataStoreEntities.VALFD_ValidationErrors => VALFD_ValidationErrors;
        IQueryable<VAL_Learner> IILR1920_DataStoreEntities.VAL_Learners => VAL_Learners;
        IQueryable<VAL_LearningDelivery> IILR1920_DataStoreEntities.VAL_LearningDeliveries => VAL_LearningDeliveries;
        IQueryable<VAL_ValidationError> IILR1920_DataStoreEntities.VAL_ValidationErrors => VAL_ValidationErrors;
        IQueryable<VAL_global> IILR1920_DataStoreEntities.VAL_globals => VAL_globals;
        IQueryable<ValidationError> IILR1920_DataStoreEntities.ValidationErrors => ValidationErrors;
        IQueryable<VersionInfo> IILR1920_DataStoreEntities.VersionInfos => VersionInfos;
    }
}
