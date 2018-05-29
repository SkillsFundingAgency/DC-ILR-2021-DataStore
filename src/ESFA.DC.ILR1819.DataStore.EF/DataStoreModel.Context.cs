﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ESFA.DC.ILR1819.DataStore.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ILR1819_DataStoreEntities : DbContext
    {
        public ILR1819_DataStoreEntities()
            : base("name=ILR1819_DataStoreEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FileDetail> FileDetails { get; set; }
        public virtual DbSet<ProcessingData> ProcessingDatas { get; set; }
        public virtual DbSet<ValidationError> ValidationErrors { get; set; }
        public virtual DbSet<VersionInfo> VersionInfoes { get; set; }
        public virtual DbSet<AEC_ApprenticeshipPriceEpisode> AEC_ApprenticeshipPriceEpisode { get; set; }
        public virtual DbSet<AEC_ApprenticeshipPriceEpisode_Period> AEC_ApprenticeshipPriceEpisode_Period { get; set; }
        public virtual DbSet<AEC_ApprenticeshipPriceEpisode_PeriodisedValues> AEC_ApprenticeshipPriceEpisode_PeriodisedValues { get; set; }
        public virtual DbSet<AEC_Cases> AEC_Cases { get; set; }
        public virtual DbSet<AEC_global> AEC_global { get; set; }
        public virtual DbSet<AEC_HistoricEarningOutput> AEC_HistoricEarningOutput { get; set; }
        public virtual DbSet<AEC_LearningDelivery> AEC_LearningDelivery { get; set; }
        public virtual DbSet<AEC_LearningDelivery_Period> AEC_LearningDelivery_Period { get; set; }
        public virtual DbSet<AEC_LearningDelivery_PeriodisedTextValues> AEC_LearningDelivery_PeriodisedTextValues { get; set; }
        public virtual DbSet<AEC_LearningDelivery_PeriodisedValues> AEC_LearningDelivery_PeriodisedValues { get; set; }
        public virtual DbSet<ALB_Cases> ALB_Cases { get; set; }
        public virtual DbSet<ALB_global> ALB_global { get; set; }
        public virtual DbSet<ALB_Learner_Period> ALB_Learner_Period { get; set; }
        public virtual DbSet<ALB_Learner_PeriodisedValues> ALB_Learner_PeriodisedValues { get; set; }
        public virtual DbSet<ALB_LearningDelivery> ALB_LearningDelivery { get; set; }
        public virtual DbSet<ALB_LearningDelivery_Period> ALB_LearningDelivery_Period { get; set; }
        public virtual DbSet<ALB_LearningDelivery_PeriodisedValues> ALB_LearningDelivery_PeriodisedValues { get; set; }
        public virtual DbSet<DV_Cases> DV_Cases { get; set; }
        public virtual DbSet<DV_Learner> DV_Learner { get; set; }
        public virtual DbSet<DV_LearningDelivery> DV_LearningDelivery { get; set; }
        public virtual DbSet<EFA_SFA_Cases> EFA_SFA_Cases { get; set; }
        public virtual DbSet<EFA_SFA_global> EFA_SFA_global { get; set; }
        public virtual DbSet<EFA_SFA_Learner_Period> EFA_SFA_Learner_Period { get; set; }
        public virtual DbSet<EFA_SFA_Learner_PeriodisedValues> EFA_SFA_Learner_PeriodisedValues { get; set; }
        public virtual DbSet<ESF_Cases> ESF_Cases { get; set; }
        public virtual DbSet<ESF_DPOutcome> ESF_DPOutcome { get; set; }
        public virtual DbSet<ESF_LearningDelivery> ESF_LearningDelivery { get; set; }
        public virtual DbSet<ESF_LearningDeliveryDeliverable> ESF_LearningDeliveryDeliverable { get; set; }
        public virtual DbSet<ESF_LearningDeliveryDeliverable_Period> ESF_LearningDeliveryDeliverable_Period { get; set; }
        public virtual DbSet<ESF_LearningDeliveryDeliverable_PeriodisedValues> ESF_LearningDeliveryDeliverable_PeriodisedValues { get; set; }
        public virtual DbSet<ESFVAL_Cases> ESFVAL_Cases { get; set; }
        public virtual DbSet<ESFVAL_global> ESFVAL_global { get; set; }
        public virtual DbSet<ESFVAL_ValidationError> ESFVAL_ValidationError { get; set; }
        public virtual DbSet<FM25_Cases> FM25_Cases { get; set; }
        public virtual DbSet<FM25_global> FM25_global { get; set; }
        public virtual DbSet<FM25_Learner> FM25_Learner { get; set; }
        public virtual DbSet<FM35_Cases> FM35_Cases { get; set; }
        public virtual DbSet<FM35_global> FM35_global { get; set; }
        public virtual DbSet<FM35_LearningDelivery> FM35_LearningDelivery { get; set; }
        public virtual DbSet<FM35_LearningDelivery_Period> FM35_LearningDelivery_Period { get; set; }
        public virtual DbSet<FM35_LearningDelivery_PeriodisedValues> FM35_LearningDelivery_PeriodisedValues { get; set; }
        public virtual DbSet<TBL_Cases> TBL_Cases { get; set; }
        public virtual DbSet<TBL_global> TBL_global { get; set; }
        public virtual DbSet<TBL_LearningDelivery> TBL_LearningDelivery { get; set; }
        public virtual DbSet<TBL_LearningDelivery_Period> TBL_LearningDelivery_Period { get; set; }
        public virtual DbSet<TBL_LearningDelivery_PeriodisedValues> TBL_LearningDelivery_PeriodisedValues { get; set; }
        public virtual DbSet<VAL_Cases> VAL_Cases { get; set; }
        public virtual DbSet<VAL_global> VAL_global { get; set; }
        public virtual DbSet<VAL_Learner> VAL_Learner { get; set; }
        public virtual DbSet<VAL_LearningDelivery> VAL_LearningDelivery { get; set; }
        public virtual DbSet<VAL_ValidationError> VAL_ValidationError { get; set; }
        public virtual DbSet<VALDP_Cases> VALDP_Cases { get; set; }
        public virtual DbSet<VALDP_global> VALDP_global { get; set; }
        public virtual DbSet<VALDP_ValidationError> VALDP_ValidationError { get; set; }
        public virtual DbSet<VALFD_ValidationError> VALFD_ValidationError { get; set; }
    
        public virtual int CleanUpDataLock(Nullable<int> ukprn)
        {
            var ukprnParameter = ukprn.HasValue ?
                new ObjectParameter("ukprn", ukprn) :
                new ObjectParameter("ukprn", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CleanUpDataLock", ukprnParameter);
        }
    
        public virtual int CleanupDeds(Nullable<long> ukprn)
        {
            var ukprnParameter = ukprn.HasValue ?
                new ObjectParameter("Ukprn", ukprn) :
                new ObjectParameter("Ukprn", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CleanupDeds", ukprnParameter);
        }
    
        public virtual int CleanupDedsDatalocks(Nullable<long> ukprn)
        {
            var ukprnParameter = ukprn.HasValue ?
                new ObjectParameter("Ukprn", ukprn) :
                new ObjectParameter("Ukprn", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CleanupDedsDatalocks", ukprnParameter);
        }
    
        public virtual int DeleteExistingRecords(Nullable<int> ukprn, string fileName)
        {
            var ukprnParameter = ukprn.HasValue ?
                new ObjectParameter("ukprn", ukprn) :
                new ObjectParameter("ukprn", typeof(int));
    
            var fileNameParameter = fileName != null ?
                new ObjectParameter("fileName", fileName) :
                new ObjectParameter("fileName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteExistingRecords", ukprnParameter, fileNameParameter);
        }
    
        public virtual int UpdateFileProcessingStatusInDEDs(Nullable<int> ukprn, string fileName)
        {
            var ukprnParameter = ukprn.HasValue ?
                new ObjectParameter("ukprn", ukprn) :
                new ObjectParameter("ukprn", typeof(int));
    
            var fileNameParameter = fileName != null ?
                new ObjectParameter("fileName", fileName) :
                new ObjectParameter("fileName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateFileProcessingStatusInDEDs", ukprnParameter, fileNameParameter);
        }
    }
}