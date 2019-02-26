using System.Linq;
using ESFA.DC.ILR1819.DataStore.EF.Interface;

namespace ESFA.DC.ILR1819.DataStore.EF
{
    public partial class ILR1819_DataStoreEntities : IIlr1819RulebaseContext
    {
        IQueryable<AecApprenticeshipPriceEpisode> IILR1819_DataStoreEntities.AecApprenticeshipPriceEpisodes => AecApprenticeshipPriceEpisodes;
        IQueryable<AecApprenticeshipPriceEpisodePeriod> IILR1819_DataStoreEntities.AecApprenticeshipPriceEpisodePeriods => AecApprenticeshipPriceEpisodePeriods;
        IQueryable<AecApprenticeshipPriceEpisodePeriodisedValue> IILR1819_DataStoreEntities.AecApprenticeshipPriceEpisodePeriodisedValues => AecApprenticeshipPriceEpisodePeriodisedValues;
        IQueryable<AecGlobal> IILR1819_DataStoreEntities.AecGlobals => AecGlobals;
        IQueryable<AecHistoricEarningOutput> IILR1819_DataStoreEntities.AecHistoricEarningOutputs => AecHistoricEarningOutputs;
        IQueryable<AecLearner> IILR1819_DataStoreEntities.AecLearners => AecLearners;
        IQueryable<AecLearningDelivery> IILR1819_DataStoreEntities.AecLearningDeliveries => AecLearningDeliveries;
        IQueryable<AecLearningDeliveryPeriod> IILR1819_DataStoreEntities.AecLearningDeliveryPeriods => AecLearningDeliveryPeriods;
        IQueryable<AecLearningDeliveryPeriodisedTextValue> IILR1819_DataStoreEntities.AecLearningDeliveryPeriodisedTextValues => AecLearningDeliveryPeriodisedTextValues;
        IQueryable<AecLearningDeliveryPeriodisedValue> IILR1819_DataStoreEntities.AecLearningDeliveryPeriodisedValues => AecLearningDeliveryPeriodisedValues;
        IQueryable<AlbGlobal> IILR1819_DataStoreEntities.AlbGlobals => AlbGlobals;
        IQueryable<AlbLearner> IILR1819_DataStoreEntities.AlbLearners => AlbLearners;
        IQueryable<AlbLearnerPeriod> IILR1819_DataStoreEntities.AlbLearnerPeriods => AlbLearnerPeriods;
        IQueryable<AlbLearnerPeriodisedValue> IILR1819_DataStoreEntities.AlbLearnerPeriodisedValues => AlbLearnerPeriodisedValues;
        IQueryable<AlbLearningDelivery> IILR1819_DataStoreEntities.AlbLearningDeliveries => AlbLearningDeliveries;
        IQueryable<AlbLearningDeliveryPeriod> IILR1819_DataStoreEntities.AlbLearningDeliveryPeriods => AlbLearningDeliveryPeriods;
        IQueryable<AlbLearningDeliveryPeriodisedValue> IILR1819_DataStoreEntities.AlbLearningDeliveryPeriodisedValues => AlbLearningDeliveryPeriodisedValues;
        IQueryable<DvGlobal> IILR1819_DataStoreEntities.DvGlobals => DvGlobals;
        IQueryable<DvLearner> IILR1819_DataStoreEntities.DvLearners => DvLearners;
        IQueryable<DvLearningDelivery> IILR1819_DataStoreEntities.DvLearningDeliveries => DvLearningDeliveries;
        IQueryable<EsfDpoutcome> IILR1819_DataStoreEntities.EsfDpoutcomes => EsfDpoutcomes;
        IQueryable<EsfGlobal> IILR1819_DataStoreEntities.EsfGlobals => EsfGlobals;
        IQueryable<EsfLearner> IILR1819_DataStoreEntities.EsfLearners => EsfLearners;
        IQueryable<EsfLearningDelivery> IILR1819_DataStoreEntities.EsfLearningDeliveries => EsfLearningDeliveries;
        IQueryable<EsfLearningDeliveryDeliverable> IILR1819_DataStoreEntities.EsfLearningDeliveryDeliverables => EsfLearningDeliveryDeliverables;
        IQueryable<EsfLearningDeliveryDeliverablePeriod> IILR1819_DataStoreEntities.EsfLearningDeliveryDeliverablePeriods => EsfLearningDeliveryDeliverablePeriods;
        IQueryable<EsfLearningDeliveryDeliverablePeriodisedValue> IILR1819_DataStoreEntities.EsfLearningDeliveryDeliverablePeriodisedValues => EsfLearningDeliveryDeliverablePeriodisedValues;
        IQueryable<EsfvalGlobal> IILR1819_DataStoreEntities.EsfvalGlobals => EsfvalGlobals;
        IQueryable<EsfvalValidationError> IILR1819_DataStoreEntities.EsfvalValidationErrors => EsfvalValidationErrors;
        IQueryable<Fm25Fm35Global> IILR1819_DataStoreEntities.Fm25Fm35Globals => Fm25Fm35Globals;
        IQueryable<Fm25Fm35LearnerPeriod> IILR1819_DataStoreEntities.Fm25Fm35LearnerPeriods => Fm25Fm35LearnerPeriods;
        IQueryable<Fm25Fm35LearnerPeriodisedValue> IILR1819_DataStoreEntities.Fm25Fm35LearnerPeriodisedValues => Fm25Fm35LearnerPeriodisedValues;
        IQueryable<Fm25Global> IILR1819_DataStoreEntities.Fm25Globals => Fm25Globals;
        IQueryable<Fm25Learner> IILR1819_DataStoreEntities.Fm25Learners => Fm25Learners;
        IQueryable<Fm35Global> IILR1819_DataStoreEntities.Fm35Globals => Fm35Globals;
        IQueryable<Fm35Learner> IILR1819_DataStoreEntities.Fm35Learners => Fm35Learners;
        IQueryable<Fm35LearningDelivery> IILR1819_DataStoreEntities.Fm35LearningDeliveries => Fm35LearningDeliveries;
        IQueryable<Fm35LearningDeliveryPeriod> IILR1819_DataStoreEntities.Fm35LearningDeliveryPeriods => Fm35LearningDeliveryPeriods;
        IQueryable<Fm35LearningDeliveryPeriodisedValue> IILR1819_DataStoreEntities.Fm35LearningDeliveryPeriodisedValues => Fm35LearningDeliveryPeriodisedValues;
        IQueryable<TblGlobal> IILR1819_DataStoreEntities.TblGlobals => TblGlobals;
        IQueryable<TblLearner> IILR1819_DataStoreEntities.TblLearners => TblLearners;
        IQueryable<TblLearningDelivery> IILR1819_DataStoreEntities.TblLearningDeliveries => TblLearningDeliveries;
        IQueryable<TblLearningDeliveryPeriod> IILR1819_DataStoreEntities.TblLearningDeliveryPeriods => TblLearningDeliveryPeriods;
        IQueryable<TblLearningDeliveryPeriodisedValue> IILR1819_DataStoreEntities.TblLearningDeliveryPeriodisedValues => TblLearningDeliveryPeriodisedValues;
        IQueryable<ValGlobal> IILR1819_DataStoreEntities.ValGlobals => ValGlobals;
        IQueryable<ValLearner> IILR1819_DataStoreEntities.ValLearners => ValLearners;
        IQueryable<ValLearningDelivery> IILR1819_DataStoreEntities.ValLearningDeliveries => ValLearningDeliveries;
        IQueryable<ValValidationError> IILR1819_DataStoreEntities.ValValidationErrors => ValValidationErrors;
        IQueryable<ValdpGlobal> IILR1819_DataStoreEntities.ValdpGlobals => ValdpGlobals;
        IQueryable<ValdpValidationError> IILR1819_DataStoreEntities.ValdpValidationErrors => ValdpValidationErrors;
        IQueryable<ValfdValidationError> IILR1819_DataStoreEntities.ValfdValidationErrors => ValfdValidationErrors;
    }
}
