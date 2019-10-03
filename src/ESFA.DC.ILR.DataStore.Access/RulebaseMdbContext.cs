using System.Data.Jet;
using EntityFrameworkCore.Jet;
using ESFA.DC.ILR.DataStore.Access.ContextMutator;
using ESFA.DC.ILR1920.DataStore.EF;
using Microsoft.EntityFrameworkCore;

namespace ESFA.DC.ILR.DataStore.Access
{
    public class RulebaseMdbContext : ILR1920_DataStoreEntities
    {
        public RulebaseMdbContext()
        {
        }

        public RulebaseMdbContext(DbContextOptions<RulebaseMdbContext> options)
            : base(DbContextMutator.MutateOptionsType<ILR1920_DataStoreEntities>(options))
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            JetConfiguration.OleDbDefaultProvider = "Microsoft.Jet.OLEDB.4.0";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseJet(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\Data\Empty.mdb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<FileDetail>();
            modelBuilder.Ignore<ProcessingData>();
            modelBuilder.Ignore<VersionInfo>();

            modelBuilder.Entity<AEC_ApprenticeshipPriceEpisode>().ToTable("Rulebase_AEC_ApprenticeshipPriceEpisode");
            modelBuilder.Entity<AEC_ApprenticeshipPriceEpisode_Period>().ToTable("Rulebase_AEC_ApprenticeshipPriceEpisode_Period");
            modelBuilder.Entity<AEC_ApprenticeshipPriceEpisode_PeriodisedValue>().ToTable("Rulebase_AEC_ApprenticeshipPriceEpisode_PeriodisedValue");
            modelBuilder.Entity<AEC_HistoricEarningOutput>().ToTable("Rulebase_AEC_HistoricEarningOutput");
            modelBuilder.Entity<AEC_Learner>().ToTable("Rulebase_AEC_Learner");
            modelBuilder.Entity<AEC_LearningDelivery>().ToTable("Rulebase_AEC_LearningDelivery");
            modelBuilder.Entity<AEC_LearningDelivery_Period>().ToTable("Rulebase_AEC_LearningDelivery_Period");
            modelBuilder.Entity<AEC_LearningDelivery_PeriodisedTextValue>().ToTable("Rulebase_AEC_LearningDelivery_PeriodisedTextValues");
            modelBuilder.Entity<AEC_LearningDelivery_PeriodisedValue>().ToTable("Rulebase_AEC_LearningDelivery_PeriodisedValues");
            modelBuilder.Entity<AEC_global>().ToTable("Rulebase_AEC_global");

            modelBuilder.Entity<ALB_Learner>().ToTable("Rulebase_ALB_Learner");
            modelBuilder.Entity<ALB_Learner_Period>().ToTable("Rulebase_ALB_Learner_Period");
            modelBuilder.Entity<ALB_Learner_PeriodisedValue>().ToTable("Rulebase_ALB_Learner_PeriodisedValues");
            modelBuilder.Entity<ALB_LearningDelivery>().ToTable("Rulebase_ALB_LearningDelivery");
            modelBuilder.Entity<ALB_LearningDelivery_Period>().ToTable("Rulebase_ALB_LearningDelivery_Period");
            modelBuilder.Entity<ALB_LearningDelivery_PeriodisedValue>().ToTable("Rulebase_ALB_LearningDelivery_PeriodisedValues");
            modelBuilder.Entity<ALB_global>().ToTable("Rulebase_ALB_global");

            modelBuilder.Entity<DV_Learner>().ToTable("Rulebase_DV_Learner");
            modelBuilder.Entity<DV_LearningDelivery>().ToTable("Rulebase_DV_LearningDelivery");
            modelBuilder.Entity<DV_global>().ToTable("Rulebase_DV_global");

            modelBuilder.Entity<ESFVAL_ValidationError>(entity =>
            {
                entity.ToTable("Rulebase_ESFVAL_ValidationError");
                entity.Property(e => e.ErrorString).HasColumnType("memo");
                entity.Property(e => e.FieldValues).HasColumnType("memo");
            });

            modelBuilder.Entity<ESFVAL_global>().ToTable("Rulebase_ESFVAL_global");
            modelBuilder.Entity<ESF_DPOutcome>().ToTable("Rulebase_ESF_DPOutcome");
            modelBuilder.Entity<ESF_Learner>().ToTable("Rulebase_ESF_Learner");
            modelBuilder.Entity<ESF_LearningDelivery>().ToTable("Rulebase_ESF_LearningDelivery");
            modelBuilder.Entity<ESF_LearningDeliveryDeliverable>().ToTable("Rulebase_ESF_LearningDeliveryDeliverable");
            modelBuilder.Entity<ESF_LearningDeliveryDeliverable_Period>().ToTable("Rulebase_ESF_LearningDeliveryDeliverable_Period");
            modelBuilder.Entity<ESF_LearningDeliveryDeliverable_PeriodisedValue>().ToTable("Rulebase_ESF_LearningDeliveryDeliverable_PeriodisedValues");
            modelBuilder.Entity<ESF_global>().ToTable("Rulebase_ESF_global");

            modelBuilder.Entity<FM25_FM35_Learner_Period>().ToTable("Rulebase_FM25_FM35_Learner_Period");
            modelBuilder.Entity<FM25_FM35_Learner_PeriodisedValue>().ToTable("Rulebase_FM25_FM35_Learner_PeriodisedValues");
            modelBuilder.Entity<FM25_FM35_global>().ToTable("Rulebase_FM25_FM35_global");

            modelBuilder.Entity<FM25_Learner>().ToTable("Rulebase_FM25_Learner");
            modelBuilder.Entity<FM25_global>().ToTable("Rulebase_FM25_global");

            modelBuilder.Entity<FM35_Learner>().ToTable("Rulebase_FM35_Learner");
            modelBuilder.Entity<FM35_LearningDelivery>().ToTable("Rulebase_FM35_LearningDelivery");
            modelBuilder.Entity<FM35_LearningDelivery_Period>().ToTable("Rulebase_FM35_LearningDelivery_Period");
            modelBuilder.Entity<FM35_LearningDelivery_PeriodisedValue>().ToTable("Rulebase_FM35_LearningDelivery_PeriodisedValues");
            modelBuilder.Entity<FM35_global>().ToTable("Rulebase_FM35_global");

            modelBuilder.Entity<TBL_Learner>().ToTable("Rulebase_TBL_Learner");
            modelBuilder.Entity<TBL_LearningDelivery>().ToTable("Rulebase_TBL_LearningDelivery");
            modelBuilder.Entity<TBL_LearningDelivery_Period>().ToTable("Rulebase_TBL_LearningDelivery_Period");
            modelBuilder.Entity<TBL_LearningDelivery_PeriodisedValue>().ToTable("Rulebase_TBL_LearningDelivery_PeriodisedValues");
            modelBuilder.Entity<TBL_global>().ToTable("Rulebase_TBL_global");

            modelBuilder.Entity<VALDP_ValidationError>(entity =>
            {
                entity.ToTable("Rulebase_VALDP_ValidationError");
                entity.Property(e => e.ErrorString).HasColumnType("memo");
                entity.Property(e => e.FieldValues).HasColumnType("memo");
            });

            modelBuilder.Entity<VALDP_global>().ToTable("Rulebase_VALDP_global");

            modelBuilder.Entity<VALFD_ValidationError>(entity =>
            {
                entity.ToTable("Rulebase_VALFD_ValidationError");
                entity.Property(e => e.ErrorString).HasColumnType("memo");
                entity.Property(e => e.FieldValues).HasColumnType("memo");
            });

            modelBuilder.Entity<VAL_Learner>().ToTable("Rulebase_VAL_Learner");
            modelBuilder.Entity<VAL_LearningDelivery>().ToTable("Rulebase_VAL_LearningDelivery");
            modelBuilder.Entity<VAL_ValidationError>(entity =>
            {
                entity.ToTable("Rulebase_VAL_ValidationError");
                entity.Property(e => e.ErrorString).HasColumnType("memo");
                entity.Property(e => e.FieldValues).HasColumnType("memo");
            });
            modelBuilder.Entity<VAL_global>().ToTable("Rulebase_VAL_global");

            modelBuilder.Entity<ValidationError>(entity =>
            {
                entity.ToTable("dbo_ValidationError");
                entity.Property(e => e.LearnAimRef).HasColumnType("memo");
                entity.Property(e => e.SWSupAimID).HasColumnType("memo");
                entity.Property(e => e.FieldValues).HasColumnType("memo");
            });
        }
    }

}
