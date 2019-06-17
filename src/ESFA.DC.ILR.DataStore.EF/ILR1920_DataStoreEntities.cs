using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class ILR1920_DataStoreEntities : DbContext
    {
        public ILR1920_DataStoreEntities()
        {
        }

        public ILR1920_DataStoreEntities(DbContextOptions<ILR1920_DataStoreEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<ALB_Learner> ALB_Learners { get; set; }
        public virtual DbSet<ALB_Learner_Period> ALB_Learner_Periods { get; set; }
        public virtual DbSet<ALB_Learner_PeriodisedValue> ALB_Learner_PeriodisedValues { get; set; }
        public virtual DbSet<ALB_LearningDelivery> ALB_LearningDeliveries { get; set; }
        public virtual DbSet<ALB_LearningDelivery_Period> ALB_LearningDelivery_Periods { get; set; }
        public virtual DbSet<ALB_LearningDelivery_PeriodisedValue> ALB_LearningDelivery_PeriodisedValues { get; set; }
        public virtual DbSet<ALB_global> ALB_globals { get; set; }
        public virtual DbSet<DV_Learner> DV_Learners { get; set; }
        public virtual DbSet<DV_LearningDelivery> DV_LearningDeliveries { get; set; }
        public virtual DbSet<DV_global> DV_globals { get; set; }
        public virtual DbSet<ESFVAL_ValidationError> ESFVAL_ValidationErrors { get; set; }
        public virtual DbSet<ESFVAL_global> ESFVAL_globals { get; set; }
        public virtual DbSet<ESF_DPOutcome> ESF_DPOutcomes { get; set; }
        public virtual DbSet<ESF_Learner> ESF_Learners { get; set; }
        public virtual DbSet<ESF_LearningDelivery> ESF_LearningDeliveries { get; set; }
        public virtual DbSet<ESF_LearningDeliveryDeliverable> ESF_LearningDeliveryDeliverables { get; set; }
        public virtual DbSet<ESF_LearningDeliveryDeliverable_Period> ESF_LearningDeliveryDeliverable_Periods { get; set; }
        public virtual DbSet<ESF_LearningDeliveryDeliverable_PeriodisedValue> ESF_LearningDeliveryDeliverable_PeriodisedValues { get; set; }
        public virtual DbSet<ESF_global> ESF_globals { get; set; }
        public virtual DbSet<FM25_FM35_Learner_Period> FM25_FM35_Learner_Periods { get; set; }
        public virtual DbSet<FM25_FM35_Learner_PeriodisedValue> FM25_FM35_Learner_PeriodisedValues { get; set; }
        public virtual DbSet<FM25_FM35_global> FM25_FM35_globals { get; set; }
        public virtual DbSet<FM25_Learner> FM25_Learners { get; set; }
        public virtual DbSet<FM25_global> FM25_globals { get; set; }
        public virtual DbSet<FM35_Learner> FM35_Learners { get; set; }
        public virtual DbSet<FM35_LearningDelivery> FM35_LearningDeliveries { get; set; }
        public virtual DbSet<FM35_LearningDelivery_Period> FM35_LearningDelivery_Periods { get; set; }
        public virtual DbSet<FM35_LearningDelivery_PeriodisedValue> FM35_LearningDelivery_PeriodisedValues { get; set; }
        public virtual DbSet<FM35_global> FM35_globals { get; set; }
        public virtual DbSet<FileDetail> FileDetails { get; set; }
        public virtual DbSet<ProcessingData> ProcessingDatas { get; set; }
        public virtual DbSet<TBL_Learner> TBL_Learners { get; set; }
        public virtual DbSet<TBL_LearningDelivery> TBL_LearningDeliveries { get; set; }
        public virtual DbSet<TBL_LearningDelivery_Period> TBL_LearningDelivery_Periods { get; set; }
        public virtual DbSet<TBL_LearningDelivery_PeriodisedValue> TBL_LearningDelivery_PeriodisedValues { get; set; }
        public virtual DbSet<TBL_global> TBL_globals { get; set; }
        public virtual DbSet<VALDP_ValidationError> VALDP_ValidationErrors { get; set; }
        public virtual DbSet<VALDP_global> VALDP_globals { get; set; }
        public virtual DbSet<VALFD_ValidationError> VALFD_ValidationErrors { get; set; }
        public virtual DbSet<VAL_Learner> VAL_Learners { get; set; }
        public virtual DbSet<VAL_LearningDelivery> VAL_LearningDeliveries { get; set; }
        public virtual DbSet<VAL_ValidationError> VAL_ValidationErrors { get; set; }
        public virtual DbSet<VAL_global> VAL_globals { get; set; }
        public virtual DbSet<ValidationError> ValidationErrors { get; set; }
        public virtual DbSet<VersionInfo> VersionInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\;Database=ILR1920_DataStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<ALB_Learner>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber })
                    .HasName("PK__ALB_Lear__2770A727859139E8");

                entity.ToTable("ALB_Learner", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.UKPRNNavigation)
                    .WithMany(p => p.ALB_Learners)
                    .HasForeignKey(d => d.UKPRN)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALBLearner_ALBglobal");
            });

            modelBuilder.Entity<ALB_Learner_Period>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.Period })
                    .HasName("PK__ALB_Lear__7066D5F5B9321A6C");

                entity.ToTable("ALB_Learner_Period", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.ALB_Learner)
                    .WithMany(p => p.ALB_Learner_Periods)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALBLearnerPeriod_ALBLearner");
            });

            modelBuilder.Entity<ALB_Learner_PeriodisedValue>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AttributeName })
                    .HasName("PK__ALB_Lear__08C04CF89D28F1D6");

                entity.ToTable("ALB_Learner_PeriodisedValues", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AttributeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Period_1).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_10).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_11).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_12).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_2).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_3).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_4).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_5).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_6).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_7).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_8).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_9).HasColumnType("decimal(15, 5)");

                entity.HasOne(d => d.ALB_Learner)
                    .WithMany(p => p.ALB_Learner_PeriodisedValues)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALBLearnerPeriodisedValues_ALBLearner");
            });

            modelBuilder.Entity<ALB_LearningDelivery>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber })
                    .HasName("PK__ALB_Lear__0C29443A34B78233");

                entity.ToTable("ALB_LearningDelivery", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ApplicFactDate).HasColumnType("date");

                entity.Property(e => e.ApplicProgWeightFact)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AreaCostFactAdj).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.AreaCostInstalment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.FundLine)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LiabilityDate).HasColumnType("date");

                entity.Property(e => e.WeightedRate).HasColumnType("decimal(12, 5)");

                entity.HasOne(d => d.ALB_Learner)
                    .WithMany(p => p.ALB_LearningDeliveries)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALBLearningDelivery_ALBLearner");
            });

            modelBuilder.Entity<ALB_LearningDelivery_Period>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.Period })
                    .HasName("PK__ALB_Lear__2958231787397DD3");

                entity.ToTable("ALB_LearningDelivery_Period", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ALBSupportPayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.AreaUpliftBalPayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.AreaUpliftOnProgPayment).HasColumnType("decimal(12, 5)");

                entity.HasOne(d => d.ALB_LearningDelivery)
                    .WithMany(p => p.ALB_LearningDelivery_Periods)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALBLearningDeliveryPeriod_ALBLearningDelivery");
            });

            modelBuilder.Entity<ALB_LearningDelivery_PeriodisedValue>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.AttributeName })
                    .HasName("PK__ALB_Lear__FED24A8734FF6315");

                entity.ToTable("ALB_LearningDelivery_PeriodisedValues", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AttributeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Period_1).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_10).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_11).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_12).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_2).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_3).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_4).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_5).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_6).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_7).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_8).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_9).HasColumnType("decimal(15, 5)");

                entity.HasOne(d => d.ALB_LearningDelivery)
                    .WithMany(p => p.ALB_LearningDelivery_PeriodisedValues)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALBLearningDeliveryPeriodisedValues_ALBLearningDelivery");
            });

            modelBuilder.Entity<ALB_global>(entity =>
            {
                entity.HasKey(e => e.UKPRN)
                    .HasName("PK__ALB_glob__50F26B71A47FC043");

                entity.ToTable("ALB_global", "Rulebase");

                entity.Property(e => e.UKPRN).ValueGeneratedNever();

                entity.Property(e => e.LARSVersion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostcodeAreaCostVersion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RulebaseVersion)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DV_Learner>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber })
                    .HasName("PK__DV_Learn__2770A727963D06C0");

                entity.ToTable("DV_Learner", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Learn_Uplift1516EFA).HasColumnType("decimal(6, 5)");

                entity.Property(e => e.Learn_Uplift1516SFA).HasColumnType("decimal(6, 5)");

                entity.HasOne(d => d.UKPRNNavigation)
                    .WithMany(p => p.DV_Learners)
                    .HasForeignKey(d => d.UKPRN)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DVLearner_DVglobal");
            });

            modelBuilder.Entity<DV_LearningDelivery>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber })
                    .HasName("PK__DV_Learn__0C29443A404ED354");

                entity.ToTable("DV_LearningDelivery", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.LearnDel_AcMonthYTD)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.LearnDel_AccToAppEmpDate).HasColumnType("date");

                entity.Property(e => e.LearnDel_AchFullLevel2Pct).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.LearnDel_AchFullLevel3Pct).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.LearnDel_CompleteFullLevel2Pct).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.LearnDel_CompleteFullLevel3Pct).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.LearnDel_EmpDateBeforeFDL).HasColumnType("date");

                entity.Property(e => e.LearnDel_EmpDatePriorFDL).HasColumnType("date");

                entity.Property(e => e.LearnDel_FullLevel2AchPct).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.LearnDel_FullLevel2ContPct).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.LearnDel_FullLevel3AchPct).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.LearnDel_FullLevel3ContPct).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.LearnDel_FundingLineType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnDel_IYActEndDate).HasColumnType("date");

                entity.Property(e => e.LearnDel_IYPlanEndDate).HasColumnType("date");

                entity.Property(e => e.LearnDel_IYStartDate).HasColumnType("date");

                entity.Property(e => e.LearnDel_LastEmpDate).HasColumnType("date");

                entity.Property(e => e.LearnDel_OrigStartDate).HasColumnType("date");

                entity.Property(e => e.LearnDel_ProgStartDate).HasColumnType("date");

                entity.Property(e => e.LearnDel_SecSubAreaTier1)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.LearnDel_SecSubAreaTier2)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.LearnDel_WorkplaceLocPostcode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Prog_ActEndDate).HasColumnType("date");

                entity.HasOne(d => d.DV_Learner)
                    .WithMany(p => p.DV_LearningDeliveries)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DVLearningDelivery_DVLearner");
            });

            modelBuilder.Entity<DV_global>(entity =>
            {
                entity.HasKey(e => e.UKPRN);

                entity.ToTable("DV_global", "Rulebase");

                entity.Property(e => e.UKPRN).ValueGeneratedNever();

                entity.Property(e => e.RulebaseVersion)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ESFVAL_ValidationError>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.AimSeqNumber, e.LearnRefNumber });

                entity.ToTable("ESFVAL_ValidationError", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorString)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.FieldValues)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.RuleId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ESFVAL_global>(entity =>
            {
                entity.HasKey(e => e.UKPRN);

                entity.ToTable("ESFVAL_global", "Rulebase");

                entity.Property(e => e.UKPRN).ValueGeneratedNever();

                entity.Property(e => e.RulebaseVersion)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ESF_DPOutcome>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.OutCode, e.OutType, e.OutStartDate })
                    .HasName("PK__ESF_DPOu__1D621D2981BF8F66");

                entity.ToTable("ESF_DPOutcome", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.OutType)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.OutStartDate).HasColumnType("date");

                entity.Property(e => e.OutcomeDateForProgression).HasColumnType("date");

                entity.Property(e => e.ProgressionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ESF_Learner>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber })
                    .HasName("PK__ESF_Lear__2770A7272A1E05DC");

                entity.ToTable("ESF_Learner", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.UKPRNNavigation)
                    .WithMany(p => p.ESF_Learners)
                    .HasForeignKey(d => d.UKPRN)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESFLearner_ESFglobal");
            });

            modelBuilder.Entity<ESF_LearningDelivery>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber })
                    .HasName("PK__ESF_Lear__0C29443A78B01647");

                entity.ToTable("ESF_LearningDelivery", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AdjustedAreaCostFactor).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.AdjustedPremiumFactor).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.AdjustedStartDate).HasColumnType("date");

                entity.Property(e => e.AimClassification)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AimValue).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.ApplicWeightFundRate).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.EligibleProgressionOutcomeType)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.EligibleProgressionOutomeStartDate).HasColumnType("date");

                entity.Property(e => e.LARSWeightedRate).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.LDESFEngagementStartDate).HasColumnType("date");

                entity.Property(e => e.LatestPossibleStartDate).HasColumnType("date");

                entity.Property(e => e.ProgressionEndDate).HasColumnType("date");

                entity.Property(e => e.WeightedRateFromESOL).HasColumnType("decimal(10, 5)");

                entity.HasOne(d => d.ESF_Learner)
                    .WithMany(p => p.ESF_LearningDeliveries)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESFLearningDelivery_ESFLearner");
            });

            modelBuilder.Entity<ESF_LearningDeliveryDeliverable>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.DeliverableCode })
                    .HasName("PK__ESF_Lear__C21F732AE27361CB");

                entity.ToTable("ESF_LearningDeliveryDeliverable", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DeliverableCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DeliverableUnitCost).HasColumnType("decimal(15, 5)");

                entity.HasOne(d => d.ESF_LearningDelivery)
                    .WithMany(p => p.ESF_LearningDeliveryDeliverables)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESFLearningDeliveryDeliverable_ESFLearningDelivery");
            });

            modelBuilder.Entity<ESF_LearningDeliveryDeliverable_Period>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.DeliverableCode, e.Period })
                    .HasName("PK__ESF_Lear__10486558CB361A01");

                entity.ToTable("ESF_LearningDeliveryDeliverable_Period", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DeliverableCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.AchievementEarnings).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.AdditionalProgCostEarnings).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.ProgressionEarnings).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.StartEarnings).HasColumnType("decimal(15, 5)");

                entity.HasOne(d => d.ESF_LearningDelivery)
                    .WithMany(p => p.ESF_LearningDeliveryDeliverable_Periods)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESFLearningDeliveryDeliverablePeriod_ESFLearningDelivery");
            });

            modelBuilder.Entity<ESF_LearningDeliveryDeliverable_PeriodisedValue>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.DeliverableCode, e.AttributeName })
                    .HasName("PK__ESF_Lear__1D30C3C1079B1064");

                entity.ToTable("ESF_LearningDeliveryDeliverable_PeriodisedValues", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DeliverableCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.AttributeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Period_1).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_10).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_11).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_12).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_2).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_3).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_4).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_5).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_6).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_7).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_8).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_9).HasColumnType("decimal(15, 5)");

                entity.HasOne(d => d.ESF_LearningDeliveryDeliverable)
                    .WithMany(p => p.ESF_LearningDeliveryDeliverable_PeriodisedValues)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber, d.DeliverableCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESFLearningDeliveryDeliverablePeriodisedValues_ESFLearningDelivery");
            });

            modelBuilder.Entity<ESF_global>(entity =>
            {
                entity.HasKey(e => e.UKPRN);

                entity.ToTable("ESF_global", "Rulebase");

                entity.Property(e => e.UKPRN).ValueGeneratedNever();

                entity.Property(e => e.RulebaseVersion)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FM25_FM35_Learner_Period>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.Period })
                    .HasName("PK__FM25_FM3__7066D5F5B3264245");

                entity.ToTable("FM25_FM35_Learner_Period", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.LnrOnProgPay).HasColumnType("decimal(15, 5)");

                entity.HasOne(d => d.UKPRNNavigation)
                    .WithMany(p => p.FM25_FM35_Learner_Periods)
                    .HasForeignKey(d => d.UKPRN)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FM25FM35LearnerPeriod_FM25FM35global");

                entity.HasOne(d => d.FM25_Learner)
                    .WithMany(p => p.FM25_FM35_Learner_Periods)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FM25_FM35_Learner_Period_FM25_Learner");
            });

            modelBuilder.Entity<FM25_FM35_Learner_PeriodisedValue>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AttributeName })
                    .HasName("PK__FM25_FM3__08C04CF8A6FADEFE");

                entity.ToTable("FM25_FM35_Learner_PeriodisedValues", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AttributeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Period_1).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_10).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_11).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_12).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_2).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_3).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_4).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_5).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_6).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_7).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_8).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_9).HasColumnType("decimal(15, 5)");

                entity.HasOne(d => d.UKPRNNavigation)
                    .WithMany(p => p.FM25_FM35_Learner_PeriodisedValues)
                    .HasForeignKey(d => d.UKPRN)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FM25FM35LearnerPeriodisedValues_FM25FM35global");

                entity.HasOne(d => d.FM25_Learner)
                    .WithMany(p => p.FM25_FM35_Learner_PeriodisedValues)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FM25_FM35_Learner_PeriodisedValues_FM25_Learner");
            });

            modelBuilder.Entity<FM25_FM35_global>(entity =>
            {
                entity.HasKey(e => e.UKPRN)
                    .HasName("PK__FM25_FM3__50F26B71DCEE4EB8");

                entity.ToTable("FM25_FM35_global", "Rulebase");

                entity.Property(e => e.UKPRN).ValueGeneratedNever();

                entity.Property(e => e.RulebaseVersion)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FM25_Learner>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber })
                    .HasName("PK__FM25_Lea__2770A72720BB553A");

                entity.ToTable("FM25_Learner", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AreaCostFact1618Hist).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.Block1DisadvUpliftNew).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.Block2DisadvElementsNew).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.ConditionOfFundingEnglish)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ConditionOfFundingMaths)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullTimeEquiv).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.FundLine)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnerActEndDate).HasColumnType("date");

                entity.Property(e => e.LearnerPlanEndDate).HasColumnType("date");

                entity.Property(e => e.LearnerStartDate).HasColumnType("date");

                entity.Property(e => e.NatRate).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.OnProgPayment).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.ProgWeightHist).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.ProgWeightNew).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.PrvDisadvPropnHist).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.PrvHistLrgProgPropn).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.PrvRetentFactHist).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.RateBand)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RetentNew).HasColumnType("decimal(10, 5)");

                entity.HasOne(d => d.UKPRNNavigation)
                    .WithMany(p => p.FM25_Learners)
                    .HasForeignKey(d => d.UKPRN)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FM25Learner_FM25global");
            });

            modelBuilder.Entity<FM25_global>(entity =>
            {
                entity.HasKey(e => e.UKPRN)
                    .HasName("PK__FM25_glo__50F26B713796E9BE");

                entity.ToTable("FM25_global", "Rulebase");

                entity.Property(e => e.UKPRN).ValueGeneratedNever();

                entity.Property(e => e.LARSVersion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrgVersion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostcodeDisadvantageVersion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RulebaseVersion)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FM35_Learner>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber })
                    .HasName("PK__FM35_Lea__2770A7272047F6CE");

                entity.ToTable("FM35_Learner", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.UKPRNNavigation)
                    .WithMany(p => p.FM35_Learners)
                    .HasForeignKey(d => d.UKPRN)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FM35Learner_FM35global");
            });

            modelBuilder.Entity<FM35_LearningDelivery>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber });

                entity.ToTable("FM35_LearningDelivery", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AchApplicDate).HasColumnType("date");

                entity.Property(e => e.AchPayTransHeldBack).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.AchieveElement).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.AchievePayPctPreTrans).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.AdjLearnStartDate).HasColumnType("date");

                entity.Property(e => e.AimValue).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.AppAdjLearnStartDate).HasColumnType("date");

                entity.Property(e => e.AppAgeFact).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.AppFuncSkill1618AdjFact).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.AppLearnStartDate).HasColumnType("date");

                entity.Property(e => e.ApplicEmpFactDate).HasColumnType("date");

                entity.Property(e => e.ApplicFactDate).HasColumnType("date");

                entity.Property(e => e.ApplicFundRateDate).HasColumnType("date");

                entity.Property(e => e.ApplicProgWeightFact)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ApplicUnweightFundRate).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.ApplicWeightFundRate).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.AreaCostFactAdj).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.BaseValueUnweight).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.CapFactor).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.DisUpFactAdj).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.EmpOutcomePctHeldBackTrans).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.EmpOutcomePctPreTrans).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.FundLine)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LTRCUpliftFctr).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.LargeEmployerFM35Fctr).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.LargeEmployerStatusDate).HasColumnType("date");

                entity.Property(e => e.LearnDelFundOrgCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NonGovCont).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.OnProgPayPctPreTrans).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.PropFundRemain).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.PropFundRemainAch).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.SpecResUplift).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.StartPropTrans).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.TrnAdjLearnStartDate).HasColumnType("date");

                entity.Property(e => e.UnWeightedRateFromESOL).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.UnweightedRateFromLARS).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.WeightedRateFromESOL).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.WeightedRateFromLARS).HasColumnType("decimal(10, 5)");

                entity.HasOne(d => d.FM35_Learner)
                    .WithMany(p => p.FM35_LearningDeliveries)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FM35LearningDelivery_FM35Learner");
            });

            modelBuilder.Entity<FM35_LearningDelivery_Period>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.Period });

                entity.ToTable("FM35_LearningDelivery_Period", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AchievePayPct).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.AchievePayPctTrans).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.AchievePayment).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.BalancePayment).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.BalancePaymentUncapped).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.BalancePct).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.BalancePctTrans).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.EmpOutcomePay).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.EmpOutcomePct).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.EmpOutcomePctTrans).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.LearnSuppFundCash).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.OnProgPayPct).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.OnProgPayPctTrans).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.OnProgPayment).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.OnProgPaymentUncapped).HasColumnType("decimal(10, 5)");

                entity.HasOne(d => d.FM35_LearningDelivery)
                    .WithMany(p => p.FM35_LearningDelivery_Periods)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FM35LearningDeliveryPeriod_FM35LearningDelivery");
            });

            modelBuilder.Entity<FM35_LearningDelivery_PeriodisedValue>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.AttributeName });

                entity.ToTable("FM35_LearningDelivery_PeriodisedValues", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AttributeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Period_1).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_10).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_11).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_12).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_2).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_3).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_4).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_5).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_6).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_7).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_8).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_9).HasColumnType("decimal(15, 5)");

                entity.HasOne(d => d.FM35_LearningDelivery)
                    .WithMany(p => p.FM35_LearningDelivery_PeriodisedValues)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FM35LearningDeliveryPeriodisedValues_FM35LearningDelivery");
            });

            modelBuilder.Entity<FM35_global>(entity =>
            {
                entity.HasKey(e => e.UKPRN)
                    .HasName("PK_FM35_Global");

                entity.ToTable("FM35_global", "Rulebase");

                entity.Property(e => e.UKPRN).ValueGeneratedNever();

                entity.Property(e => e.CurFundYr)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.LARSVersion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrgVersion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostcodeDisadvantageVersion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RulebaseVersion)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FileDetail>(entity =>
            {
                entity.HasIndex(e => new { e.UKPRN, e.Filename, e.Success })
                    .HasName("PK_dbo.FileDetails")
                    .IsUnique();

                entity.Property(e => e.Filename).HasMaxLength(50);

                entity.Property(e => e.SubmittedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProcessingData>(entity =>
            {
                entity.ToTable("ProcessingData");

                entity.Property(e => e.ExecutionTime)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ProcessingStep)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TBL_Learner>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber })
                    .HasName("PK__TBL_Lear__2770A727ECA0F03B");

                entity.ToTable("TBL_Learner", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.UKPRNNavigation)
                    .WithMany(p => p.TBL_Learners)
                    .HasForeignKey(d => d.UKPRN)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBLLearner_TBLglobal");
            });

            modelBuilder.Entity<TBL_LearningDelivery>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber })
                    .HasName("PK__TBL_Lear__0C29443A97F3D8C5");

                entity.ToTable("TBL_LearningDelivery", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AchApplicDate).HasColumnType("date");

                entity.Property(e => e.AchPayment).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.AchievementApplicVal).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.AdjProgStartDate).HasColumnType("date");

                entity.Property(e => e.AdjStartDate).HasColumnType("date");

                entity.Property(e => e.ApplicFundValDate).HasColumnType("date");

                entity.Property(e => e.CombinedAdjProp).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.CoreGovContPayment).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.CoreGovContUncapped).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.FundLine)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LearnSuppFundCash).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.MathEngAimValue).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.MathEngBalPayment).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.MathEngOnProgPayment).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.ProgStandardStartDate).HasColumnType("date");

                entity.Property(e => e.SmallBusApplicVal).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.SmallBusPayment).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.SmallBusThresholdDate).HasColumnType("date");

                entity.Property(e => e.YoungAppApplicVal).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.YoungAppFirstPayment).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.YoungAppFirstThresholdDate).HasColumnType("date");

                entity.Property(e => e.YoungAppPayment).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.YoungAppSecondPayment).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.YoungAppSecondThresholdDate).HasColumnType("date");

                entity.HasOne(d => d.TBL_Learner)
                    .WithMany(p => p.TBL_LearningDeliveries)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBLLearningDelivery_TBLLearner");
            });

            modelBuilder.Entity<TBL_LearningDelivery_Period>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.Period })
                    .HasName("PK__TBL_Lear__29582317BB418F35");

                entity.ToTable("TBL_LearningDelivery_Period", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AchPayment).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.CoreGovContPayment).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.CoreGovContUncapped).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.LearnSuppFundCash).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.MathEngBalPayment).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.MathEngBalPct).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.MathEngOnProgPayment).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.MathEngOnProgPct).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.SmallBusPayment).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.YoungAppFirstPayment).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.YoungAppPayment).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.YoungAppSecondPayment).HasColumnType("decimal(15, 5)");

                entity.HasOne(d => d.TBL_LearningDelivery)
                    .WithMany(p => p.TBL_LearningDelivery_Periods)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBLLearningDeliveryPeriod_TBLLearningDelivery");
            });

            modelBuilder.Entity<TBL_LearningDelivery_PeriodisedValue>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.AttributeName })
                    .HasName("PK__TBL_Lear__FED24A8783EA65B0");

                entity.ToTable("TBL_LearningDelivery_PeriodisedValues", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AttributeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Period_1).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_10).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_11).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_12).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_2).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_3).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_4).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_5).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_6).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_7).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_8).HasColumnType("decimal(15, 5)");

                entity.Property(e => e.Period_9).HasColumnType("decimal(15, 5)");

                entity.HasOne(d => d.TBL_LearningDelivery)
                    .WithMany(p => p.TBL_LearningDelivery_PeriodisedValues)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBLLearningDeliveryPeriodisedValues_TBLLearningDelivery");
            });

            modelBuilder.Entity<TBL_global>(entity =>
            {
                entity.HasKey(e => e.UKPRN)
                    .HasName("PK__TBL_glob__50F26B71F116D561");

                entity.ToTable("TBL_global", "Rulebase");

                entity.Property(e => e.UKPRN).ValueGeneratedNever();

                entity.Property(e => e.CurFundYr)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LARSVersion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RulebaseVersion)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VALDP_ValidationError>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber });

                entity.ToTable("VALDP_ValidationError", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorString)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.FieldValues)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.RuleId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VALDP_global>(entity =>
            {
                entity.HasKey(e => e.UKPRN)
                    .HasName("PK__VALDP_gl__50F26B717F0AE6FC");

                entity.ToTable("VALDP_global", "Rulebase");

                entity.Property(e => e.UKPRN).ValueGeneratedNever();

                entity.Property(e => e.OrgVersion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RulebaseVersion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ULNVersion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VALFD_ValidationError>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.AimSeqNumber, e.LearnRefNumber });

                entity.ToTable("VALFD_ValidationError", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorString)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.FieldValues)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.RuleId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VAL_Learner>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber })
                    .HasName("PK__VAL_Lear__2770A727B3D50080");

                entity.ToTable("VAL_Learner", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.UKPRNNavigation)
                    .WithMany(p => p.VAL_Learners)
                    .HasForeignKey(d => d.UKPRN)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VALLearner_VALglobal");
            });

            modelBuilder.Entity<VAL_LearningDelivery>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.AimSeqNumber })
                    .HasName("PK__VAL_Lear__E56C5AA36F14A489");

                entity.ToTable("VAL_LearningDelivery", "Rulebase");
            });

            modelBuilder.Entity<VAL_ValidationError>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.AimSeqNumber, e.LearnRefNumber });

                entity.ToTable("VAL_ValidationError", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorString)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.FieldValues)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.RuleId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VAL_global>(entity =>
            {
                entity.HasKey(e => e.UKPRN)
                    .HasName("PK__VAL_glob__50F26B719375A0DA");

                entity.ToTable("VAL_global", "Rulebase");

                entity.Property(e => e.UKPRN).ValueGeneratedNever();

                entity.Property(e => e.EmployerVersion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LARSVersion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrgVersion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostcodeVersion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RulebaseVersion)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ValidationError>(entity =>
            {
                entity.ToTable("ValidationError");

                entity.HasIndex(e => e.UKPRN)
                    .HasName("IX_ValidationError");

                entity.Property(e => e.FieldValues).HasMaxLength(2000);

                entity.Property(e => e.LearnAimRef)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RuleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SWSupAimID)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Severity)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VersionInfo>(entity =>
            {
                entity.HasKey(e => e.Version);

                entity.ToTable("VersionInfo");

                entity.Property(e => e.Version).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");
            });
        }
    }
}
