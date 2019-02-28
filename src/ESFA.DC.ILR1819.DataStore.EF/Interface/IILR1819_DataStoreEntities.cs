using System;
using System.Linq;

namespace ESFA.DC.ILR1819.DataStore.EF.Interface
{
    public interface IILR1819_DataStoreEntities : IDisposable
    {
        IQueryable<FileDetail> FileDetails { get; }
        IQueryable<ProcessingDatum> ProcessingDatas { get; }
        IQueryable<ValidationError> ValidationErrors { get; }
        IQueryable<VersionInfo> VerionInfoes { get; }
        IQueryable<AecApprenticeshipPriceEpisode> AecApprenticeshipPriceEpisodes { get; }
        IQueryable<AecApprenticeshipPriceEpisodePeriod> AecApprenticeshipPriceEpisodePeriods { get; }
        IQueryable<AecApprenticeshipPriceEpisodePeriodisedValue> AecApprenticeshipPriceEpisodePeriodisedValues { get; }
        IQueryable<AecGlobal> AecGlobals { get; }
        IQueryable<AecHistoricEarningOutput> AecHistoricEarningOutputs { get; }
        IQueryable<AecLearner> AecLearners { get; }
        IQueryable<AecLearningDelivery> AecLearningDeliveries { get; }
        IQueryable<AecLearningDeliveryPeriod> AecLearningDeliveryPeriods { get; }
        IQueryable<AecLearningDeliveryPeriodisedTextValue> AecLearningDeliveryPeriodisedTextValues { get; }
        IQueryable<AecLearningDeliveryPeriodisedValue> AecLearningDeliveryPeriodisedValues { get; }
        IQueryable<AlbGlobal> AlbGlobals { get; }
        IQueryable<AlbLearner> AlbLearners { get; }
        IQueryable<AlbLearnerPeriod> AlbLearnerPeriods { get; }
        IQueryable<AlbLearnerPeriodisedValue> AlbLearnerPeriodisedValues { get; }
        IQueryable<AlbLearningDelivery> AlbLearningDeliveries { get; }
        IQueryable<AlbLearningDeliveryPeriod> AlbLearningDeliveryPeriods { get; }
        IQueryable<AlbLearningDeliveryPeriodisedValue> AlbLearningDeliveryPeriodisedValues { get; }
        IQueryable<DvGlobal> DvGlobals { get; }
        IQueryable<DvLearner> DvLearners { get; }
        IQueryable<DvLearningDelivery> DvLearningDeliveries { get; }
        IQueryable<EsfDpoutcome> EsfDpoutcomes { get; }
        IQueryable<EsfGlobal> EsfGlobals { get; }
        IQueryable<EsfLearner> EsfLearners { get; }
        IQueryable<EsfLearningDelivery> EsfLearningDeliveries { get; }
        IQueryable<EsfLearningDeliveryDeliverable> EsfLearningDeliveryDeliverables { get; }
        IQueryable<EsfLearningDeliveryDeliverablePeriod> EsfLearningDeliveryDeliverablePeriods { get; }
        IQueryable<EsfLearningDeliveryDeliverablePeriodisedValue> EsfLearningDeliveryDeliverablePeriodisedValues { get; }
        IQueryable<EsfvalGlobal> EsfvalGlobals { get; }
        IQueryable<EsfvalValidationError> EsfvalValidationErrors { get; }
        IQueryable<Fm25Fm35Global> Fm25Fm35Globals { get; }
        IQueryable<Fm25Fm35LearnerPeriod> Fm25Fm35LearnerPeriods { get; }
        IQueryable<Fm25Fm35LearnerPeriodisedValue> Fm25Fm35LearnerPeriodisedValues { get; }
        IQueryable<Fm25Global> Fm25Globals { get; }
        IQueryable<Fm25Learner> Fm25Learners { get; }
        IQueryable<Fm35Global> Fm35Globals { get; }
        IQueryable<Fm35Learner> Fm35Learners { get; }
        IQueryable<Fm35LearningDelivery> Fm35LearningDeliveries { get; }
        IQueryable<Fm35LearningDeliveryPeriod> Fm35LearningDeliveryPeriods { get; }
        IQueryable<Fm35LearningDeliveryPeriodisedValue> Fm35LearningDeliveryPeriodisedValues { get; }
        IQueryable<TblGlobal> TblGlobals { get; }
        IQueryable<TblLearner> TblLearners { get; }
        IQueryable<TblLearningDelivery> TblLearningDeliveries { get; }
        IQueryable<TblLearningDeliveryPeriod> TblLearningDeliveryPeriods { get; }
        IQueryable<TblLearningDeliveryPeriodisedValue> TblLearningDeliveryPeriodisedValues { get; }
        IQueryable<ValGlobal> ValGlobals { get; }
        IQueryable<ValLearner> ValLearners { get; }
        IQueryable<ValLearningDelivery> ValLearningDeliveries { get; }
        IQueryable<ValValidationError> ValValidationErrors { get; }
        IQueryable<ValdpGlobal> ValdpGlobals { get; }
        IQueryable<ValdpValidationError> ValdpValidationErrors { get; }
        IQueryable<ValfdValidationError> ValfdValidationErrors { get; }
    }
}
