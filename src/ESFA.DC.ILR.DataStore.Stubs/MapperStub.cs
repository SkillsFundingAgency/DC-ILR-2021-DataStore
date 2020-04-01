using ESFA.DC.ILR.DataStore.Interface.Mappers;
using System.Collections.Generic;
using ESFA.DC.Data.AppsEarningsHistory.Model;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.Model.ReferenceData;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR.Model.Loose.Interface;
using ESFA.DC.ILR1920.DataStore.EF;
using ValidationError = ESFA.DC.ILR.IO.Model.Validation.ValidationError;

namespace ESFA.DC.ILR.DataStore.Stubs
{
    public class MapperStub : IFM81Mapper, IFM70Mapper, IFM25Mapper, IFM36HistoryMapper, IFM35Mapper, IFM36Mapper, IALBMapper, IValidationDataMapper, IProcessingInformationDataMapper
    {
        public void MapData(IDataStoreCache cache, FM81Global fm81Global)
        {
        }

        public IEnumerable<TBL_global> MapGlobals(FM81Global fm81Global)
        {
            return new List<TBL_global>();
        }

        public IEnumerable<TBL_Learner> MapLearners(FM81Global fm81Global)
        {
            return new List<TBL_Learner>();
        }

        public IEnumerable<TBL_LearningDelivery> MapLearningDeliveries(FM81Global fm81Global)
        {
            return new List<TBL_LearningDelivery>();
        }

        public IEnumerable<TBL_LearningDelivery_Period> MapLearningDeliveryPeriods(FM81Global fm81Global)
        {
            return new List<TBL_LearningDelivery_Period>();
        }

        public IEnumerable<TBL_LearningDelivery_PeriodisedValue> MapLearningDeliveryPeriodisedValues(FM81Global fm81Global)
        {
            return new List<TBL_LearningDelivery_PeriodisedValue>();
        }

        public void MapData(IDataStoreCache cache, FM70Global fm70Global)
        {
        }

        public IEnumerable<ESF_global> MapGlobals(FM70Global fm70Global)
        {
            return new List<ESF_global>();
        }

        public IEnumerable<ESF_Learner> MapLearners(FM70Global fm70Global)
        {
            return new List<ESF_Learner>();
        }

        public IEnumerable<ESF_DPOutcome> MapDPOutcomes(FM70Global fm70Global)
        {
            return new List<ESF_DPOutcome>();
        }

        public IEnumerable<ESF_LearningDelivery> MapLearningDeliveries(FM70Global fm70Global)
        {
            return new List<ESF_LearningDelivery>();
        }

        public IEnumerable<ESF_LearningDeliveryDeliverable> MapLearningDeliveryDeliverables(FM70Global fm70Global)
        {
            return new List<ESF_LearningDeliveryDeliverable>();
        }

        public IEnumerable<ESF_LearningDeliveryDeliverable_Period> MapLearningDeliveryDeliverablePeriods(FM70Global fm70Global)
        {
            return new List<ESF_LearningDeliveryDeliverable_Period>();
        }

        public IEnumerable<ESF_LearningDeliveryDeliverable_PeriodisedValue> MapLearningDeliveryDeliverablePeriodisedValues(FM70Global fm70Global)
        {
            return new List<ESF_LearningDeliveryDeliverable_PeriodisedValue>();
        }

        public void MapData(IDataStoreCache cache, FM25Global fm25Global)
        {
        }

        public IEnumerable<FM25_global> MapFM25Global(FM25Global fm25Global)
        {
            return new List<FM25_global>();
        }

        public IEnumerable<FM25_Learner> MapFM25Learners(FM25Global fm25Global)
        {
            return new List<FM25_Learner>();
        }

        public IEnumerable<FM25_FM35_global> MapFM25_35_Global(FM25Global fm25Global)
        {
            return new List<FM25_FM35_global>();
        }

        public IEnumerable<FM25_FM35_Learner_Period> MapFM25_35_LearnerPeriod(FM25Global fm25Global)
        {
            return new List<FM25_FM35_Learner_Period>();
        }

        public IEnumerable<FM25_FM35_Learner_PeriodisedValue> MapFM25_35_LearnerPeriodisedValues(FM25Global fm25Global)
        {
            return new List<FM25_FM35_Learner_PeriodisedValue>();
        }

        public void MapData(IDataStoreCache cache, FM36Global fm36Global, IDataStoreContext dataStoreContext)
        {
        }

        public IEnumerable<AppsEarningsHistory> MapAppsEarningsHistory(FM36Global fm36Global, string returnCode, string year)
        {
            return new List<AppsEarningsHistory>();
        }

        public void MapData(IDataStoreCache cache, FM35Global fm35Global)
        {
        }

        public IEnumerable<FM35_global> MapGlobals(FM35Global fm35Global)
        {
            return new List<FM35_global>();
        }

        public IEnumerable<FM35_Learner> MapLearners(FM35Global fm35Global)
        {
            return new List<FM35_Learner>();
        }

        public IEnumerable<FM35_LearningDelivery> MapLearningDeliveries(FM35Global fm35Global)
        {
            return new List<FM35_LearningDelivery>();
        }

        public IEnumerable<FM35_LearningDelivery_Period> MapLearningDeliveryPeriods(FM35Global fm35Global)
        {
            return new List<FM35_LearningDelivery_Period>();
        }

        public IEnumerable<FM35_LearningDelivery_PeriodisedValue> MapLearningDeliveryPeriodisedValues(FM35Global fm35Global)
        {
            return new List<FM35_LearningDelivery_PeriodisedValue>();
        }

        public void MapData(IDataStoreCache cache, FM36Global fm36Global)
        {
        }

        public IEnumerable<AEC_global> MapGlobals(FM36Global fm36Global)
        {
            return new List<AEC_global>();
        }

        public IEnumerable<AEC_Learner> MapLearners(FM36Global fm36Global)
        {
            return new List<AEC_Learner>();
        }

        public IEnumerable<AEC_LearningDelivery> MapLearningDeliveries(FM36Global fm36Global)
        {
            return new List<AEC_LearningDelivery>();
        }

        public IEnumerable<AEC_LearningDelivery_Period> MapLearningDeliveryPeriods(FM36Global fm36Global)
        {
            return new List<AEC_LearningDelivery_Period>();
        }

        public IEnumerable<AEC_LearningDelivery_PeriodisedValue> MapLearningDeliveryPeriodisedValues(FM36Global fm36Global)
        {
            return new List<AEC_LearningDelivery_PeriodisedValue>();
        }

        public IEnumerable<AEC_LearningDelivery_PeriodisedTextValue> MapLearningDeliveryPeriodisedTextValues(FM36Global fm36Global)
        {
            return new List<AEC_LearningDelivery_PeriodisedTextValue>();
        }

        public IEnumerable<AEC_ApprenticeshipPriceEpisode> MapPriceEpisodes(FM36Global fm36Global)
        {
            return new List<AEC_ApprenticeshipPriceEpisode>();
        }

        public IEnumerable<AEC_ApprenticeshipPriceEpisode_Period> MapPriceEpisodePeriods(FM36Global fm36Global)
        {
            return new List<AEC_ApprenticeshipPriceEpisode_Period>();
        }

        public IEnumerable<AEC_ApprenticeshipPriceEpisode_PeriodisedValue> MapPriceEpisodePeriodisedValues(FM36Global fm36Global)
        {
            return new List<AEC_ApprenticeshipPriceEpisode_PeriodisedValue>();
        }

        public void MapALBData(IDataStoreCache cache, ALBGlobal albGlobal)
        {
        }

        public IEnumerable<ALB_global> MapGlobals(ALBGlobal albGlobal)
        {
            return new List<ALB_global>();
        }

        public IEnumerable<ALB_Learner> MapLearners(ALBGlobal albGlobal)
        {
            return new List<ALB_Learner>();
        }

        public IEnumerable<ALB_Learner_Period> MapLearnerPeriods(ALBGlobal albGlobal)
        {
            return new List<ALB_Learner_Period>();
        }

        public IEnumerable<ALB_Learner_PeriodisedValue> MapLearnerPeriodisedValues(ALBGlobal albGlobal)
        {
            return new List<ALB_Learner_PeriodisedValue>();
        }

        public IEnumerable<ALB_LearningDelivery> MapLearningDeliveries(ALBGlobal albGlobal)
        {
            return new List<ALB_LearningDelivery>();
        }

        public IEnumerable<ALB_LearningDelivery_Period> MapLearningDeliveryPeriods(ALBGlobal albGlobal)
        {
            return new List<ALB_LearningDelivery_Period>();
        }

        public IEnumerable<ALB_LearningDelivery_PeriodisedValue> MapLearningDeliveryPeriodisedValues(ALBGlobal albGlobal)
        {
            return new List<ALB_LearningDelivery_PeriodisedValue>();
        }

        public void MapData(IDataStoreCache cache, IDataStoreContext datStoreContext, IEnumerable<ValidationError> validationErrors, IEnumerable<ValidationRule> rules, ILooseMessage message)
        {
        }

        public void MapData(IDataStoreCache cache, ReferenceDataVersions referenceDataVersions, IDataStoreContext dataStoreContext)
        {
        }
    }
}
