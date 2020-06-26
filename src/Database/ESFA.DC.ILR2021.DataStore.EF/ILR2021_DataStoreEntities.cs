using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ESFA.DC.ILR2021.DataStore.EF
{
    public partial class ILR2021_DataStoreEntities : DbContext
    {
        public ILR2021_DataStoreEntities()
        {
        }

        public ILR2021_DataStoreEntities(DbContextOptions<ILR2021_DataStoreEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<AEC_ApprenticeshipPriceEpisode> AEC_ApprenticeshipPriceEpisodes { get; set; }
        public virtual DbSet<AEC_ApprenticeshipPriceEpisode_Period> AEC_ApprenticeshipPriceEpisode_Periods { get; set; }
        public virtual DbSet<AEC_ApprenticeshipPriceEpisode_PeriodisedValue> AEC_ApprenticeshipPriceEpisode_PeriodisedValues { get; set; }
        public virtual DbSet<AEC_HistoricEarningOutput> AEC_HistoricEarningOutputs { get; set; }
        public virtual DbSet<AEC_Learner> AEC_Learners { get; set; }
        public virtual DbSet<AEC_LearningDelivery> AEC_LearningDeliveries { get; set; }
        public virtual DbSet<AEC_LearningDelivery_Period> AEC_LearningDelivery_Periods { get; set; }
        public virtual DbSet<AEC_LearningDelivery_PeriodisedTextValue> AEC_LearningDelivery_PeriodisedTextValues { get; set; }
        public virtual DbSet<AEC_LearningDelivery_PeriodisedValue> AEC_LearningDelivery_PeriodisedValues { get; set; }
        public virtual DbSet<AEC_global> AEC_globals { get; set; }
        public virtual DbSet<ALB_Learner> ALB_Learners { get; set; }
        public virtual DbSet<ALB_Learner_Period> ALB_Learner_Periods { get; set; }
        public virtual DbSet<ALB_Learner_PeriodisedValue> ALB_Learner_PeriodisedValues { get; set; }
        public virtual DbSet<ALB_LearningDelivery> ALB_LearningDeliveries { get; set; }
        public virtual DbSet<ALB_LearningDelivery_Period> ALB_LearningDelivery_Periods { get; set; }
        public virtual DbSet<ALB_LearningDelivery_PeriodisedValue> ALB_LearningDelivery_PeriodisedValues { get; set; }
        public virtual DbSet<ALB_global> ALB_globals { get; set; }
        public virtual DbSet<AppFinRecord> AppFinRecords { get; set; }
        public virtual DbSet<CollectionDetail> CollectionDetails { get; set; }
        public virtual DbSet<ContactPreference> ContactPreferences { get; set; }
        public virtual DbSet<DPOutcome> DPOutcomes { get; set; }
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
        public virtual DbSet<EmploymentStatusMonitoring> EmploymentStatusMonitorings { get; set; }
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
        public virtual DbSet<LLDDandHealthProblem> LLDDandHealthProblems { get; set; }
        public virtual DbSet<Learner> Learners { get; set; }
        public virtual DbSet<LearnerDestinationandProgression> LearnerDestinationandProgressions { get; set; }
        public virtual DbSet<LearnerEmploymentStatus> LearnerEmploymentStatuses { get; set; }
        public virtual DbSet<LearnerFAM> LearnerFAMs { get; set; }
        public virtual DbSet<LearnerHE> LearnerHEs { get; set; }
        public virtual DbSet<LearnerHEFinancialSupport> LearnerHEFinancialSupports { get; set; }
        public virtual DbSet<LearningDelivery> LearningDeliveries { get; set; }
        public virtual DbSet<LearningDeliveryFAM> LearningDeliveryFAMs { get; set; }
        public virtual DbSet<LearningDeliveryHE> LearningDeliveryHEs { get; set; }
        public virtual DbSet<LearningDeliveryWorkPlacement> LearningDeliveryWorkPlacements { get; set; }
        public virtual DbSet<LearningProvider> LearningProviders { get; set; }
        public virtual DbSet<ProcessingData> ProcessingDatas { get; set; }
        public virtual DbSet<ProviderSpecDeliveryMonitoring> ProviderSpecDeliveryMonitorings { get; set; }
        public virtual DbSet<ProviderSpecLearnerMonitoring> ProviderSpecLearnerMonitorings { get; set; }
        public virtual DbSet<Source> Sources { get; set; }
        public virtual DbSet<SourceFile> SourceFiles { get; set; }
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
                optionsBuilder.UseSqlServer("Server=.\\;Database=ESFA.DC.ILR.DataStore.Database;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<AEC_ApprenticeshipPriceEpisode>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.PriceEpisodeIdentifier })
                    .HasName("PK__AEC_Appr__BCF596CA74EA3654");

                entity.ToTable("AEC_ApprenticeshipPriceEpisode", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.PriceEpisodeIdentifier)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.EpisodeEffectiveTNPStartDate).HasColumnType("date");

                entity.Property(e => e.EpisodeStartDate).HasColumnType("date");

                entity.Property(e => e.PriceEpisode1618FUBalValue).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisode1618FUMonthInstValue).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisode1618FUTotEarnings).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisode1618FrameworkUpliftRemainingAmount).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisode1618FrameworkUpliftTotPrevEarnings).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeActualEndDate).HasColumnType("date");

                entity.Property(e => e.PriceEpisodeActualEndDateIncEPA).HasColumnType("date");

                entity.Property(e => e.PriceEpisodeApplic1618FrameworkUpliftCompElement).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeCappedRemainingTNPAmount).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeCompletionElement).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeContractType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PriceEpisodeCumulativePMRs).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeExpectedTotalMonthlyValue).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeFirstAdditionalPaymentThresholdDate).HasColumnType("date");

                entity.Property(e => e.PriceEpisodeFundLineType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PriceEpisodeInstalmentValue).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeLearnerAdditionalPaymentThresholdDate).HasColumnType("date");

                entity.Property(e => e.PriceEpisodePlannedEndDate).HasColumnType("date");

                entity.Property(e => e.PriceEpisodePreviousEarnings).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodePreviousEarningsSameProvider).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeRedStartDate).HasColumnType("date");

                entity.Property(e => e.PriceEpisodeRemainingAmountWithinUpperLimit).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeRemainingTNPAmount).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeSecondAdditionalPaymentThresholdDate).HasColumnType("date");

                entity.Property(e => e.PriceEpisodeTotalEarnings).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeTotalPMRs).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeTotalTNPPrice).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeUpperBandLimit).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeUpperLimitAdjustment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.TNP1).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.TNP2).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.TNP3).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.TNP4).HasColumnType("decimal(12, 5)");

                entity.HasOne(d => d.AEC_Learner)
                    .WithMany(p => p.AEC_ApprenticeshipPriceEpisodes)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AECApprenticeshipPriceEpisode_AECLearner");

                entity.HasOne(d => d.LearningDelivery)
                    .WithMany(p => p.AEC_ApprenticeshipPriceEpisodes)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber, d.PriceEpisodeAimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AEC_ApprenticeshipPriceEpisode_ValidLearningDelivery");
            });

            modelBuilder.Entity<AEC_ApprenticeshipPriceEpisode_Period>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.PriceEpisodeIdentifier, e.Period })
                    .HasName("PK__AEC_Appr__9984F1E79E1C6EF4");

                entity.ToTable("AEC_ApprenticeshipPriceEpisode_Period", "Rulebase");

                entity.HasIndex(e => new { e.UKPRN, e.LearnRefNumber, e.PriceEpisodeIdentifier })
                    .HasName("ix_AEC_ApprenticeshipPriceEpisodePeriod");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.PriceEpisodeIdentifier)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PriceEpisodeApplic1618FrameworkUpliftBalancing).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeApplic1618FrameworkUpliftCompletionPayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeApplic1618FrameworkUpliftOnProgPayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeBalancePayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeBalanceValue).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeCompletionPayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeESFAContribPct).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeFirstDisadvantagePayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeFirstEmp1618Pay).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeFirstProv1618Pay).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeLSFCash).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeLearnerAdditionalPayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeOnProgPayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeProgFundIndMaxEmpCont).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeProgFundIndMinCoInvest).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeSFAContribPct).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeSecondDisadvantagePayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeSecondEmp1618Pay).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeSecondProv1618Pay).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.PriceEpisodeTotProgFunding).HasColumnType("decimal(12, 5)");

                entity.HasOne(d => d.AEC_ApprenticeshipPriceEpisode)
                    .WithMany(p => p.AEC_ApprenticeshipPriceEpisode_Periods)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber, d.PriceEpisodeIdentifier })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AECApprenticeshipPriceEpisodePeriod_AECApprenticeshipPriceEpisode");
            });

            modelBuilder.Entity<AEC_ApprenticeshipPriceEpisode_PeriodisedValue>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.PriceEpisodeIdentifier, e.AttributeName })
                    .HasName("PK__AEC_Appr__4E0E98770E00803A");

                entity.ToTable("AEC_ApprenticeshipPriceEpisode_PeriodisedValues", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.PriceEpisodeIdentifier)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AttributeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Period_1).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_10).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_11).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_12).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_2).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_3).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_4).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_5).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_6).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_7).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_8).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_9).HasColumnType("decimal(12, 5)");

                entity.HasOne(d => d.AEC_ApprenticeshipPriceEpisode)
                    .WithMany(p => p.AEC_ApprenticeshipPriceEpisode_PeriodisedValues)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber, d.PriceEpisodeIdentifier })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AECApprenticeshipPriceEpisodePeriodisedValues_AECApprenticeshipPriceEpisode");
            });

            modelBuilder.Entity<AEC_HistoricEarningOutput>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AppIdentifierOutput })
                    .HasName("PK__AEC_Hist__9CDF074242B4133F");

                entity.ToTable("AEC_HistoricEarningOutput", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AppIdentifierOutput)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HistoricEffectiveTNPStartDateOutput).HasColumnType("date");

                entity.Property(e => e.HistoricLearnDelProgEarliestACT2DateOutput).HasColumnType("date");

                entity.Property(e => e.HistoricPMRAmountOutput).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.HistoricProgrammeStartDateIgnorePathwayOutput).HasColumnType("date");

                entity.Property(e => e.HistoricProgrammeStartDateMatchPathwayOutput).HasColumnType("date");

                entity.Property(e => e.HistoricTNP1Output).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.HistoricTNP2Output).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.HistoricTNP3Output).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.HistoricTNP4Output).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.HistoricTotal1618UpliftPaymentsInTheYear).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.HistoricTotalProgAimPaymentsInTheYear).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.HistoricUptoEndDateOutput).HasColumnType("date");

                entity.Property(e => e.HistoricVirtualTNP3EndofThisYearOutput).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.HistoricVirtualTNP4EndofThisYearOutput).HasColumnType("decimal(12, 5)");
            });

            modelBuilder.Entity<AEC_Learner>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber })
                    .HasName("PK__AEC_Lear__2770A72798E5B85C");

                entity.ToTable("AEC_Learner", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.UKPRNNavigation)
                    .WithMany(p => p.AEC_Learners)
                    .HasForeignKey(d => d.UKPRN)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AECLearner_AECglobal");

                entity.HasOne(d => d.Learner)
                    .WithOne(p => p.AEC_Learner)
                    .HasForeignKey<AEC_Learner>(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AEC_Learner_ValidLearner");
            });

            modelBuilder.Entity<AEC_LearningDelivery>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber })
                    .HasName("PK__AEC_Lear__0C29443A4AF160DC");

                entity.ToTable("AEC_LearningDelivery", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AdjStartDate).HasColumnType("date");

                entity.Property(e => e.AppAdjLearnStartDate).HasColumnType("date");

                entity.Property(e => e.AppAdjLearnStartDateMatchPathway).HasColumnType("date");

                entity.Property(e => e.ApplicCompDate).HasColumnType("date");

                entity.Property(e => e.CombinedAdjProp).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.FirstIncentiveThresholdDate).HasColumnType("date");

                entity.Property(e => e.LDApplic1618FrameworkUpliftTotalActEarnings).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.LearnAimRef)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.LearnDelApplicCareLeaverIncentive).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.LearnDelApplicDisadvAmount).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.LearnDelApplicEmp1618Incentive).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.LearnDelApplicEmpDate).HasColumnType("date");

                entity.Property(e => e.LearnDelApplicProv1618FrameworkUplift).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.LearnDelApplicProv1618Incentive).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.LearnDelDisadAmount).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.LearnDelHistProgEarnings).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.LearnDelInitialFundLineType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnDelLearnerAddPayThresholdDate).HasColumnType("date");

                entity.Property(e => e.LearnDelProgEarliestACT2Date).HasColumnType("date");

                entity.Property(e => e.LearnDelRedStartDate).HasColumnType("date");

                entity.Property(e => e.MathEngAimValue).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.SecondIncentiveThresholdDate).HasColumnType("date");

                entity.HasOne(d => d.AEC_Learner)
                    .WithMany(p => p.AEC_LearningDeliveries)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AECLearningDelivery_AECLearner");

                entity.HasOne(d => d.LearningDelivery)
                    .WithOne(p => p.AEC_LearningDelivery)
                    .HasForeignKey<AEC_LearningDelivery>(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AEC_LearningDelivery_ValidLearningDelivery");
            });

            modelBuilder.Entity<AEC_LearningDelivery_Period>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.Period })
                    .HasName("PK__AEC_Lear__29582317751A20E5");

                entity.ToTable("AEC_LearningDelivery_Period", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DisadvFirstPayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.DisadvSecondPayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.FundLineType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LDApplic1618FrameworkUpliftBalancingPayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.LDApplic1618FrameworkUpliftCompletionPayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.LDApplic1618FrameworkUpliftOnProgPayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.LearnDelContType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LearnDelESFAContribPct).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.LearnDelFirstEmp1618Pay).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.LearnDelFirstProv1618Pay).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.LearnDelLearnAddPayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.LearnDelSFAContribPct).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.LearnDelSecondEmp1618Pay).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.LearnDelSecondProv1618Pay).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.LearnSuppFundCash).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.MathEngBalPayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.MathEngOnProgPayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.ProgrammeAimBalPayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.ProgrammeAimCompletionPayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.ProgrammeAimOnProgPayment).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.ProgrammeAimProgFundIndMaxEmpCont).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.ProgrammeAimProgFundIndMinCoInvest).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.ProgrammeAimTotProgFund).HasColumnType("decimal(12, 5)");

                entity.HasOne(d => d.AEC_LearningDelivery)
                    .WithMany(p => p.AEC_LearningDelivery_Periods)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AECLearningDeliveryPeriod_AECLearningDelivery");
            });

            modelBuilder.Entity<AEC_LearningDelivery_PeriodisedTextValue>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.AttributeName })
                    .HasName("PK__AEC_Lear__FED24A87D2508F18");

                entity.ToTable("AEC_LearningDelivery_PeriodisedTextValues", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AttributeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Period_1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Period_10)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Period_11)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Period_12)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Period_2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Period_3)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Period_4)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Period_5)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Period_6)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Period_7)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Period_8)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Period_9)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.AEC_LearningDelivery)
                    .WithMany(p => p.AEC_LearningDelivery_PeriodisedTextValues)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AECLearningDeliveryPeriodisedTextValues_AECLearningDeliveryPeriod");
            });

            modelBuilder.Entity<AEC_LearningDelivery_PeriodisedValue>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.AttributeName })
                    .HasName("PK__AEC_Lear__FED24A8719007724");

                entity.ToTable("AEC_LearningDelivery_PeriodisedValues", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AttributeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Period_1).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_10).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_11).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_12).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_2).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_3).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_4).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_5).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_6).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_7).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_8).HasColumnType("decimal(12, 5)");

                entity.Property(e => e.Period_9).HasColumnType("decimal(12, 5)");

                entity.HasOne(d => d.AEC_LearningDelivery)
                    .WithMany(p => p.AEC_LearningDelivery_PeriodisedValues)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AECLearningDeliveryPeriodisedValues_AECLearningDeliveryPeriod");
            });

            modelBuilder.Entity<AEC_global>(entity =>
            {
                entity.HasKey(e => e.UKPRN);

                entity.ToTable("AEC_global", "Rulebase");

                entity.Property(e => e.UKPRN).ValueGeneratedNever();

                entity.Property(e => e.LARSVersion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RulebaseVersion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Year)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ALB_Learner>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber })
                    .HasName("PK__ALB_Lear__2770A72751E8E8D3");

                entity.ToTable("ALB_Learner", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.UKPRNNavigation)
                    .WithMany(p => p.ALB_Learners)
                    .HasForeignKey(d => d.UKPRN)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALBLearner_ALBglobal");

                entity.HasOne(d => d.Learner)
                    .WithOne(p => p.ALB_Learner)
                    .HasForeignKey<ALB_Learner>(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALB_Learner_ValidLearner");
            });

            modelBuilder.Entity<ALB_Learner_Period>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.Period })
                    .HasName("PK__ALB_Lear__7066D5F547754035");

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
                    .HasName("PK__ALB_Lear__08C04CF82E4F6562");

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
                    .HasName("PK__ALB_Lear__0C29443A6ED065FB");

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

                entity.HasOne(d => d.LearningDelivery)
                    .WithOne(p => p.ALB_LearningDelivery)
                    .HasForeignKey<ALB_LearningDelivery>(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALB_LearningDelivery_ValidLearningDelivery");
            });

            modelBuilder.Entity<ALB_LearningDelivery_Period>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.Period })
                    .HasName("PK__ALB_Lear__29582317A07C4441");

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
                    .HasName("PK__ALB_Lear__FED24A876783F118");

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
                    .HasName("PK__ALB_glob__50F26B71A4A2E2F5");

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

            modelBuilder.Entity<AppFinRecord>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.AppFinRecord_Id });

                entity.ToTable("AppFinRecord", "Valid");

                entity.HasIndex(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.AFinType })
                    .HasName("IX_Valid_AppFinRecord");

                entity.Property(e => e.AFinDate).HasColumnType("date");

                entity.Property(e => e.AFinType)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.LearnRefNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.LearningDelivery)
                    .WithMany(p => p.AppFinRecords)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppFinRecord_LearningDelivery");
            });

            modelBuilder.Entity<CollectionDetail>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.Collection, e.Year });

                entity.ToTable("CollectionDetails", "Valid");

                entity.Property(e => e.Collection)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Year)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.FilePreparationDate).HasColumnType("date");
            });

            modelBuilder.Entity<ContactPreference>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.ContPrefType, e.ContPrefCode })
                    .HasName("PK_ContactPref");

                entity.ToTable("ContactPreference", "Valid");

                entity.HasIndex(e => new { e.LearnRefNumber, e.ContPrefType })
                    .HasName("IX_Valid_ContactPreference");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ContPrefType)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.Learner)
                    .WithMany(p => p.ContactPreferences)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactPreference_Learner");
            });

            modelBuilder.Entity<DPOutcome>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.OutType, e.OutCode, e.OutStartDate, e.OutCollDate });

                entity.ToTable("DPOutcome", "Valid");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.OutType)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.OutStartDate).HasColumnType("date");

                entity.Property(e => e.OutCollDate).HasColumnType("date");

                entity.Property(e => e.OutEndDate).HasColumnType("date");

                entity.HasOne(d => d.LearnerDestinationandProgression)
                    .WithMany(p => p.DPOutcomes)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DPOutcome_LearnerDestinationandProgression");
            });

            modelBuilder.Entity<DV_Learner>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber })
                    .HasName("PK__DV_Learn__2770A7276A81084F");

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
                    .HasName("PK__DV_Learn__0C29443A46FE28DA");

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
                    .HasName("PK__ESF_DPOu__1D621D299703F3B6");

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
                    .HasName("PK__ESF_Lear__2770A727B4BE9378");

                entity.ToTable("ESF_Learner", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.UKPRNNavigation)
                    .WithMany(p => p.ESF_Learners)
                    .HasForeignKey(d => d.UKPRN)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESFLearner_ESFglobal");

                entity.HasOne(d => d.Learner)
                    .WithOne(p => p.ESF_Learner)
                    .HasForeignKey<ESF_Learner>(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESF_Learner_ValidLearner");
            });

            modelBuilder.Entity<ESF_LearningDelivery>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber })
                    .HasName("PK__ESF_Lear__0C29443ADCB506FE");

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

                entity.HasOne(d => d.LearningDelivery)
                    .WithOne(p => p.ESF_LearningDelivery)
                    .HasForeignKey<ESF_LearningDelivery>(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESF_LearningDelivery_ValidLearningDelivery");
            });

            modelBuilder.Entity<ESF_LearningDeliveryDeliverable>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.DeliverableCode })
                    .HasName("PK__ESF_Lear__C21F732AD76123FF");

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
                    .HasName("PK__ESF_Lear__1048655811F560B4");

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
                    .HasName("PK__ESF_Lear__1D30C3C1EA3F8B72");

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

            modelBuilder.Entity<EmploymentStatusMonitoring>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.DateEmpStatApp, e.ESMType })
                    .HasName("PK__Employme__316BBA3106CD75AA");

                entity.ToTable("EmploymentStatusMonitoring", "Valid");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DateEmpStatApp).HasColumnType("date");

                entity.Property(e => e.ESMType)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FM25_FM35_Learner_Period>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.Period })
                    .HasName("PK__FM25_FM3__7066D5F54EE826EA");

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
                    .HasName("PK__FM25_FM3__08C04CF8501AA671");

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
                    .HasName("PK__FM25_FM3__50F26B718BEE3F12");

                entity.ToTable("FM25_FM35_global", "Rulebase");

                entity.Property(e => e.UKPRN).ValueGeneratedNever();

                entity.Property(e => e.RulebaseVersion)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FM25_Learner>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber })
                    .HasName("PK__FM25_Lea__2770A727FBD28EFC");

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

                entity.Property(e => e.PrvHistL3ProgMathEngProp).HasColumnType("decimal(10, 5)");

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

                entity.HasOne(d => d.Learner)
                    .WithOne(p => p.FM25_Learner)
                    .HasForeignKey<FM25_Learner>(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FM25_Learner_ValidLearner");
            });

            modelBuilder.Entity<FM25_global>(entity =>
            {
                entity.HasKey(e => e.UKPRN)
                    .HasName("PK__FM25_glo__50F26B71ED529E72");

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
                    .HasName("PK__FM35_Lea__2770A72701F1A75B");

                entity.ToTable("FM35_Learner", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.UKPRNNavigation)
                    .WithMany(p => p.FM35_Learners)
                    .HasForeignKey(d => d.UKPRN)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FM35Learner_FM35global");

                entity.HasOne(d => d.Learner)
                    .WithOne(p => p.FM35_Learner)
                    .HasForeignKey<FM35_Learner>(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FM35_Learner_ValidLearner");
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

                entity.Property(e => e.ReservedUpliftFactor1).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.ReservedUpliftRate1).HasColumnType("decimal(10, 5)");

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

                entity.HasOne(d => d.LearningDelivery)
                    .WithOne(p => p.FM35_LearningDelivery)
                    .HasForeignKey<FM35_LearningDelivery>(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FM35_LearningDelivery_ValidLearningDelivery");
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

                entity.Property(e => e.CampusIdentifierVersion).HasMaxLength(50);

                entity.Property(e => e.EasUploadDateTime).HasColumnType("datetime");

                entity.Property(e => e.EmployersVersion).HasMaxLength(50);

                entity.Property(e => e.Filename).HasMaxLength(50);

                entity.Property(e => e.LarsVersion).HasMaxLength(50);

                entity.Property(e => e.OrgName).HasMaxLength(255);

                entity.Property(e => e.OrgVersion).HasMaxLength(50);

                entity.Property(e => e.PostcodesVersion).HasMaxLength(50);

                entity.Property(e => e.SubmittedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<LLDDandHealthProblem>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.LLDDCat, e.LLDDandHealthProblem_ID })
                    .HasName("PK__LLDDandH__CFA94E1C19A54FB5");

                entity.ToTable("LLDDandHealthProblem", "Valid");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.Learner)
                    .WithMany(p => p.LLDDandHealthProblems)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LLDDandHealthProblem_Learner");
            });

            modelBuilder.Entity<Learner>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber })
                    .HasName("PK__Learner__2770A7278E02491B");

                entity.ToTable("Learner", "Valid");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AddLine1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddLine2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddLine3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddLine4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CampId)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EngGrade)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.FamilyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GivenNames)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MathGrade)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.NINumber)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.PostcodePrior)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.PrevLearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TelNo)
                    .HasMaxLength(18)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LearnerDestinationandProgression>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber })
                    .HasName("PK__LearnerD__2770A727C9AEFF3F");

                entity.ToTable("LearnerDestinationandProgression", "Valid");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LearnerEmploymentStatus>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.DateEmpStatApp })
                    .HasName("PK__LearnerE__7200C4BEFB2271E4");

                entity.ToTable("LearnerEmploymentStatus", "Valid");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DateEmpStatApp).HasColumnType("date");

                entity.HasOne(d => d.Learner)
                    .WithMany(p => p.LearnerEmploymentStatuses)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LearnerEmploymentStatus_Learner");
            });

            modelBuilder.Entity<LearnerFAM>(entity =>
            {
                entity.HasKey(e => new { e.LearnFAMCode, e.LearnFAMType, e.LearnRefNumber, e.UKPRN });

                entity.ToTable("LearnerFAM", "Valid");

                entity.HasIndex(e => new { e.UKPRN, e.LearnRefNumber })
                    .HasName("IX_Valid_LearnerFAM");

                entity.Property(e => e.LearnFAMType)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.Learner)
                    .WithMany(p => p.LearnerFAMs)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LearnerFAM_Learner");
            });

            modelBuilder.Entity<LearnerHE>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber })
                    .HasName("PK__LearnerH__2770A727B61C2A22");

                entity.ToTable("LearnerHE", "Valid");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.UCASPERID)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Learner)
                    .WithOne(p => p.LearnerHE)
                    .HasForeignKey<LearnerHE>(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LearnerHE_Learner");
            });

            modelBuilder.Entity<LearnerHEFinancialSupport>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.FINTYPE })
                    .HasName("PK__LearnerH__09F54B724E154F8E");

                entity.ToTable("LearnerHEFinancialSupport", "Valid");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.LearnerHE)
                    .WithMany(p => p.LearnerHEFinancialSupports)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LearnerHEFinancialSupport_LearnerHE");
            });

            modelBuilder.Entity<LearningDelivery>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber })
                    .HasName("PK__Learning__0C29443AF6208137");

                entity.ToTable("LearningDelivery", "Valid");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AchDate).HasColumnType("date");

                entity.Property(e => e.ConRefNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DelLocPostCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.EPAOrgID)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.LSDPostcode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.LearnActEndDate).HasColumnType("date");

                entity.Property(e => e.LearnAimRef)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.LearnPlanEndDate).HasColumnType("date");

                entity.Property(e => e.LearnStartDate).HasColumnType("date");

                entity.Property(e => e.OrigLearnStartDate).HasColumnType("date");

                entity.Property(e => e.OutGrade)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SWSupAimId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.Learner)
                    .WithMany(p => p.LearningDeliveries)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LearningDelivery_Learner");
            });

            modelBuilder.Entity<LearningDeliveryFAM>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearningDeliveryFAM_Id });

                entity.ToTable("LearningDeliveryFAM", "Valid");

                entity.HasIndex(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.LearnDelFAMType, e.LearnDelFAMDateFrom })
                    .HasName("IX_Valid_LearningDeliveryFAM");

                entity.HasIndex(e => new { e.LearnRefNumber, e.AimSeqNumber, e.LearnDelFAMCode, e.LearnDelFAMDateFrom, e.LearnDelFAMDateTo, e.UKPRN, e.LearnDelFAMType })
                    .HasName("IX_Valid_LearningDeliveryFAM_UKPRN_FamType");

                entity.Property(e => e.LearnDelFAMCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.LearnDelFAMDateFrom).HasColumnType("date");

                entity.Property(e => e.LearnDelFAMDateTo).HasColumnType("date");

                entity.Property(e => e.LearnDelFAMType)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.LearnRefNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.LearningDelivery)
                    .WithMany(p => p.LearningDeliveryFAMs)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LearningDeliveryFAM_LearningDelivery");
            });

            modelBuilder.Entity<LearningDeliveryHE>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber })
                    .HasName("PK__Learning__0C29443A079D45E9");

                entity.ToTable("LearningDeliveryHE", "Valid");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DOMICILE)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.HEPostCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.NUMHUS)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PCFLDCS).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.PCOLAB).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.PCSLDCS).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.PCTLDCS).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.QUALENT3)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.SSN)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.STULOAD).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.UCASAPPID)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.HasOne(d => d.LearningDelivery)
                    .WithOne(p => p.LearningDeliveryHE)
                    .HasForeignKey<LearningDeliveryHE>(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LearningDeliveryHE_LearningDelivery");
            });

            modelBuilder.Entity<LearningDeliveryWorkPlacement>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.WorkPlaceStartDate });

                entity.ToTable("LearningDeliveryWorkPlacement", "Valid");

                entity.HasIndex(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.WorkPlaceStartDate, e.WorkPlaceMode })
                    .HasName("IX_Valid_LearningDeliveryWorkPlacement");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.WorkPlaceStartDate).HasColumnType("date");

                entity.Property(e => e.WorkPlaceEndDate).HasColumnType("date");

                entity.HasOne(d => d.LearningDelivery)
                    .WithMany(p => p.LearningDeliveryWorkPlacements)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LearningDeliveryWorkPlacement_LearningDelivery");
            });

            modelBuilder.Entity<LearningProvider>(entity =>
            {
                entity.HasKey(e => e.UKPRN)
                    .HasName("PK__Learning__50F26B71EE934338");

                entity.ToTable("LearningProvider", "Valid");

                entity.Property(e => e.UKPRN).ValueGeneratedNever();
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

            modelBuilder.Entity<ProviderSpecDeliveryMonitoring>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.ProvSpecDelMonOccur })
                    .HasName("PK__Provider__9F5C5085C2A9C2C0");

                entity.ToTable("ProviderSpecDeliveryMonitoring", "Valid");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ProvSpecDelMonOccur)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProvSpecDelMon)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.LearningDelivery)
                    .WithMany(p => p.ProviderSpecDeliveryMonitorings)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProviderSpecDeliveryMonitoring_LearningDelivery");
            });

            modelBuilder.Entity<ProviderSpecLearnerMonitoring>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.ProvSpecLearnMonOccur })
                    .HasName("PK__Provider__63E551EAA31DE21E");

                entity.ToTable("ProviderSpecLearnerMonitoring", "Valid");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ProvSpecLearnMonOccur)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProvSpecLearnMon)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Learner)
                    .WithMany(p => p.ProviderSpecLearnerMonitorings)
                    .HasForeignKey(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProviderSpecLearnerMonitoring_Learner");
            });

            modelBuilder.Entity<Source>(entity =>
            {
                entity.HasKey(e => e.UKPRN);

                entity.ToTable("Source", "Valid");

                entity.Property(e => e.UKPRN).ValueGeneratedNever();

                entity.Property(e => e.ComponentSetVersion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.ProtectiveMarking)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenceData)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Release)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNo)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SoftwarePackage)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SoftwareSupplier)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SourceFile>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.SourceFileName });

                entity.ToTable("SourceFile", "Valid");

                entity.HasIndex(e => e.SourceFileName)
                    .HasName("IX_Valid_SourceFile");

                entity.Property(e => e.SourceFileName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.FilePreparationDate).HasColumnType("date");

                entity.Property(e => e.Release)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNo)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SoftwarePackage)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SoftwareSupplier)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TBL_Learner>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber })
                    .HasName("PK__TBL_Lear__2770A727397FC14D");

                entity.ToTable("TBL_Learner", "Rulebase");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.UKPRNNavigation)
                    .WithMany(p => p.TBL_Learners)
                    .HasForeignKey(d => d.UKPRN)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBLLearner_TBLglobal");

                entity.HasOne(d => d.Learner)
                    .WithOne(p => p.TBL_Learner)
                    .HasForeignKey<TBL_Learner>(d => new { d.UKPRN, d.LearnRefNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_Learner_ValidLearner");
            });

            modelBuilder.Entity<TBL_LearningDelivery>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber })
                    .HasName("PK__TBL_Lear__0C29443ADE73714A");

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

                entity.HasOne(d => d.LearningDelivery)
                    .WithOne(p => p.TBL_LearningDelivery)
                    .HasForeignKey<TBL_LearningDelivery>(d => new { d.UKPRN, d.LearnRefNumber, d.AimSeqNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_LearningDelivery_ValidLearningDelivery");
            });

            modelBuilder.Entity<TBL_LearningDelivery_Period>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.Period })
                    .HasName("PK__TBL_Lear__29582317BC938E50");

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
                    .HasName("PK__TBL_Lear__FED24A8759CD5B5E");

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
                    .HasName("PK__TBL_glob__50F26B71EEE43F0E");

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
                    .HasName("PK__VALDP_gl__50F26B714C3E0B1D");

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
                    .HasName("PK__VAL_Lear__2770A727BB5F51AC");

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
                    .HasName("PK__VAL_Lear__E56C5AA33AE20373");

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
                    .HasName("PK__VAL_glob__50F26B714F1841F0");

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
