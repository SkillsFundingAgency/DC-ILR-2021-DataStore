using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ESFA.DC.ILR1819.DataStore.EF.Invalid
{
    public partial class ILR1819_DataStoreEntitiesInvalid : DbContext
    {
        public ILR1819_DataStoreEntitiesInvalid()
        {
        }

        public ILR1819_DataStoreEntitiesInvalid(DbContextOptions<ILR1819_DataStoreEntitiesInvalid> options)
            : base(options)
        {
        }

        public virtual DbSet<AppFinRecord> AppFinRecords { get; set; }
        public virtual DbSet<CollectionDetail> CollectionDetails { get; set; }
        public virtual DbSet<ContactPreference> ContactPreferences { get; set; }
        public virtual DbSet<Dpoutcome> Dpoutcomes { get; set; }
        public virtual DbSet<EmploymentStatusMonitoring> EmploymentStatusMonitorings { get; set; }
        public virtual DbSet<Learner> Learners { get; set; }
        public virtual DbSet<LearnerDestinationandProgression> LearnerDestinationandProgressions { get; set; }
        public virtual DbSet<LearnerEmploymentStatus> LearnerEmploymentStatuses { get; set; }
        public virtual DbSet<LearnerFam> LearnerFams { get; set; }
        public virtual DbSet<LearnerHe> LearnerHes { get; set; }
        public virtual DbSet<LearnerHefinancialSupport> LearnerHefinancialSupports { get; set; }
        public virtual DbSet<LearningDelivery> LearningDeliveries { get; set; }
        public virtual DbSet<LearningDeliveryFam> LearningDeliveryFams { get; set; }
        public virtual DbSet<LearningDeliveryHe> LearningDeliveryHes { get; set; }
        public virtual DbSet<LearningDeliveryWorkPlacement> LearningDeliveryWorkPlacements { get; set; }
        public virtual DbSet<LearningProvider> LearningProviders { get; set; }
        public virtual DbSet<LlddandHealthProblem> LlddandHealthProblems { get; set; }
        public virtual DbSet<ProviderSpecDeliveryMonitoring> ProviderSpecDeliveryMonitorings { get; set; }
        public virtual DbSet<ProviderSpecLearnerMonitoring> ProviderSpecLearnerMonitorings { get; set; }
        public virtual DbSet<Source> Sources { get; set; }
        public virtual DbSet<SourceFile> SourceFiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\;Database=ILR1819_DataStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<AppFinRecord>(entity =>
            {
                entity.HasKey(e => new { e.Ukprn, e.AppFinRecordId });

                entity.ToTable("AppFinRecord", "Invalid");

                entity.HasIndex(e => e.LearningDeliveryId)
                    .HasName("IX_Parent_Invalid_AppFinRecord");

                entity.HasIndex(e => new { e.LearnRefNumber, e.AimSeqNumber, e.AfinType })
                    .HasName("IX_Invalid_AppFinRecord");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.AppFinRecordId).HasColumnName("AppFinRecord_Id");

                entity.Property(e => e.AfinAmount).HasColumnName("AFinAmount");

                entity.Property(e => e.AfinCode).HasColumnName("AFinCode");

                entity.Property(e => e.AfinDate)
                    .HasColumnName("AFinDate")
                    .HasColumnType("date");

                entity.Property(e => e.AfinType)
                    .IsRequired()
                    .HasColumnName("AFinType")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnRefNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearningDeliveryId).HasColumnName("LearningDelivery_Id");
            });

            modelBuilder.Entity<CollectionDetail>(entity =>
            {
                entity.HasKey(e => new { e.Ukprn, e.CollectionDetailsId });

                entity.ToTable("CollectionDetails", "Invalid");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.CollectionDetailsId).HasColumnName("CollectionDetails_Id");

                entity.Property(e => e.Collection)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.FilePreparationDate).HasColumnType("date");

                entity.Property(e => e.Year)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContactPreference>(entity =>
            {
                entity.HasKey(e => new { e.Ukprn, e.ContactPreferenceId });

                entity.ToTable("ContactPreference", "Invalid");

                entity.HasIndex(e => e.LearnerId)
                    .HasName("IX_Parent_Invalid_ContactPreference");

                entity.HasIndex(e => new { e.LearnRefNumber, e.ContPrefType })
                    .HasName("IX_Invalid_ContactPreference");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.ContactPreferenceId).HasColumnName("ContactPreference_Id");

                entity.Property(e => e.ContPrefType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnerId).HasColumnName("Learner_Id");
            });

            modelBuilder.Entity<Dpoutcome>(entity =>
            {
                entity.HasKey(e => new { e.Ukprn, e.DpoutcomeId });

                entity.ToTable("DPOutcome", "Invalid");

                entity.HasIndex(e => e.LearnerDestinationandProgressionId)
                    .HasName("IX_Parent_Invalid_DPOutcome");

                entity.HasIndex(e => new { e.LearnRefNumber, e.OutType, e.OutCode, e.OutStartDate })
                    .HasName("IX_Invalid_DPOutcome");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.DpoutcomeId).HasColumnName("DPOutcome_Id");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnerDestinationandProgressionId).HasColumnName("LearnerDestinationandProgression_Id");

                entity.Property(e => e.OutCollDate).HasColumnType("date");

                entity.Property(e => e.OutEndDate).HasColumnType("date");

                entity.Property(e => e.OutStartDate).HasColumnType("date");

                entity.Property(e => e.OutType)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmploymentStatusMonitoring>(entity =>
            {
                entity.HasKey(e => new { e.Ukprn, e.EmploymentStatusMonitoringId });

                entity.ToTable("EmploymentStatusMonitoring", "Invalid");

                entity.HasIndex(e => e.LearnerEmploymentStatusId)
                    .HasName("IX_Parent_Invalid_EmploymentStatusMonitoring");

                entity.HasIndex(e => new { e.LearnRefNumber, e.DateEmpStatApp, e.Esmtype })
                    .HasName("IX_Invalid_EmploymentStatusMonitoring");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.EmploymentStatusMonitoringId).HasColumnName("EmploymentStatusMonitoring_Id");

                entity.Property(e => e.DateEmpStatApp).HasColumnType("date");

                entity.Property(e => e.Esmcode).HasColumnName("ESMCode");

                entity.Property(e => e.Esmtype)
                    .HasColumnName("ESMType")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnerEmploymentStatusId).HasColumnName("LearnerEmploymentStatus_Id");
            });

            modelBuilder.Entity<Learner>(entity =>
            {
                entity.HasKey(e => new { e.Ukprn, e.LearnerId });

                entity.ToTable("Learner", "Invalid");

                entity.HasIndex(e => e.LearnRefNumber)
                    .HasName("IX_Invalid_Learner");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.LearnerId).HasColumnName("Learner_Id");

                entity.Property(e => e.AddLine1)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.AddLine2)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.AddLine3)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.AddLine4)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Alscost).HasColumnName("ALSCost");

                entity.Property(e => e.CampId)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EngGrade)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.FamilyName)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.GivenNames)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LlddhealthProb).HasColumnName("LLDDHealthProb");

                entity.Property(e => e.MathGrade)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Ninumber)
                    .HasColumnName("NINumber")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Otjhours).HasColumnName("OTJHours");

                entity.Property(e => e.PlanEephours).HasColumnName("PlanEEPHours");

                entity.Property(e => e.Pmukprn).HasColumnName("PMUKPRN");

                entity.Property(e => e.Postcode)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PostcodePrior)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PrevLearnRefNumber)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PrevUkprn).HasColumnName("PrevUKPRN");

                entity.Property(e => e.Sex)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TelNo)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Uln).HasColumnName("ULN");
            });

            modelBuilder.Entity<LearnerDestinationandProgression>(entity =>
            {
                entity.HasKey(e => new { e.Ukprn, e.LearnerDestinationandProgressionId });

                entity.ToTable("LearnerDestinationandProgression", "Invalid");

                entity.HasIndex(e => e.LearnRefNumber)
                    .HasName("IX_Invalid_LearnerDestinationandProgression");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.LearnerDestinationandProgressionId).HasColumnName("LearnerDestinationandProgression_Id");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Uln).HasColumnName("ULN");
            });

            modelBuilder.Entity<LearnerEmploymentStatus>(entity =>
            {
                entity.HasKey(e => new { e.Ukprn, e.LearnerEmploymentStatusId });

                entity.ToTable("LearnerEmploymentStatus", "Invalid");

                entity.HasIndex(e => e.LearnerId)
                    .HasName("IX_Parent_Invalid_LearnerEmploymentStatus");

                entity.HasIndex(e => new { e.LearnRefNumber, e.DateEmpStatApp })
                    .HasName("IX_Invalid_LearnerEmploymentStatus");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.LearnerEmploymentStatusId).HasColumnName("LearnerEmploymentStatus_Id");

                entity.Property(e => e.AgreeId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateEmpStatApp).HasColumnType("date");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnerId).HasColumnName("Learner_Id");
            });

            modelBuilder.Entity<LearnerFam>(entity =>
            {
                entity.HasKey(e => new { e.Ukprn, e.LearnerFamId });

                entity.ToTable("LearnerFAM", "Invalid");

                entity.HasIndex(e => e.LearnRefNumber)
                    .HasName("IX_Invalid_LearnerFAM");

                entity.HasIndex(e => e.LearnerId)
                    .HasName("IX_Parent_Invalid_LearnerFAM");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.LearnerFamId).HasColumnName("LearnerFAM_Id");

                entity.Property(e => e.LearnFamcode).HasColumnName("LearnFAMCode");

                entity.Property(e => e.LearnFamtype)
                    .HasColumnName("LearnFAMType")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnerId).HasColumnName("Learner_Id");
            });

            modelBuilder.Entity<LearnerHe>(entity =>
            {
                entity.HasKey(e => new { e.Ukprn, e.LearnerHeId });

                entity.ToTable("LearnerHE", "Invalid");

                entity.HasIndex(e => e.LearnRefNumber)
                    .HasName("IX_Invalid_LearnerHE");

                entity.HasIndex(e => e.LearnerId)
                    .HasName("IX_Parent_Invalid_LearnerHE");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.LearnerHeId).HasColumnName("LearnerHE_Id");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnerId).HasColumnName("Learner_Id");

                entity.Property(e => e.Ttaccom).HasColumnName("TTACCOM");

                entity.Property(e => e.Ucasperid)
                    .HasColumnName("UCASPERID")
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LearnerHefinancialSupport>(entity =>
            {
                entity.HasKey(e => new { e.Ukprn, e.LearnerHefinancialSupportId });

                entity.ToTable("LearnerHEFinancialSupport", "Invalid");

                entity.HasIndex(e => e.LearnerHeId)
                    .HasName("IX_Parent_Invalid_LearnerHEFinancialSupport");

                entity.HasIndex(e => new { e.LearnRefNumber, e.Fintype })
                    .HasName("IX_Invalid_LearnerHEFinancialSupport");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.LearnerHefinancialSupportId).HasColumnName("LearnerHEFinancialSupport_Id");

                entity.Property(e => e.Finamount).HasColumnName("FINAMOUNT");

                entity.Property(e => e.Fintype).HasColumnName("FINTYPE");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnerHeId).HasColumnName("LearnerHE_Id");
            });

            modelBuilder.Entity<LearningDelivery>(entity =>
            {
                entity.HasKey(e => new { e.Ukprn, e.LearningDeliveryId });

                entity.ToTable("LearningDelivery", "Invalid");

                entity.HasIndex(e => e.LearnerId)
                    .HasName("IX_Parent_Invalid_LearningDelivery");

                entity.HasIndex(e => new { e.LearnRefNumber, e.AimSeqNumber })
                    .HasName("IX_Invalid_LearningDelivery");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.LearningDeliveryId).HasColumnName("LearningDelivery_Id");

                entity.Property(e => e.AchDate).HasColumnType("date");

                entity.Property(e => e.ConRefNumber)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.DelLocPostCode)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EpaorgId)
                    .HasColumnName("EPAOrgID")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LearnActEndDate).HasColumnType("date");

                entity.Property(e => e.LearnAimRef)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LearnPlanEndDate).HasColumnType("date");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnStartDate).HasColumnType("date");

                entity.Property(e => e.LearnerId).HasColumnName("Learner_Id");

                entity.Property(e => e.OrigLearnStartDate).HasColumnType("date");

                entity.Property(e => e.OutGrade)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PartnerUkprn).HasColumnName("PartnerUKPRN");

                entity.Property(e => e.SwsupAimId)
                    .HasColumnName("SWSupAimId")
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LearningDeliveryFam>(entity =>
            {
                entity.HasKey(e => new { e.Ukprn, e.LearningDeliveryFamId });

                entity.ToTable("LearningDeliveryFAM", "Invalid");

                entity.HasIndex(e => e.LearningDeliveryId)
                    .HasName("IX_Parent_Invalid_LearningDeliveryFAM");

                entity.HasIndex(e => new { e.LearnRefNumber, e.AimSeqNumber, e.LearnDelFamtype, e.LearnDelFamdateFrom })
                    .HasName("IX_Invalid_LearningDeliveryFAM");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.LearningDeliveryFamId).HasColumnName("LearningDeliveryFAM_Id");

                entity.Property(e => e.LearnDelFamcode)
                    .HasColumnName("LearnDelFAMCode")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LearnDelFamdateFrom)
                    .HasColumnName("LearnDelFAMDateFrom")
                    .HasColumnType("date");

                entity.Property(e => e.LearnDelFamdateTo)
                    .HasColumnName("LearnDelFAMDateTo")
                    .HasColumnType("date");

                entity.Property(e => e.LearnDelFamtype)
                    .HasColumnName("LearnDelFAMType")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearningDeliveryId).HasColumnName("LearningDelivery_Id");
            });

            modelBuilder.Entity<LearningDeliveryHe>(entity =>
            {
                entity.HasKey(e => new { e.Ukprn, e.LearningDeliveryHeId });

                entity.ToTable("LearningDeliveryHE", "Invalid");

                entity.HasIndex(e => e.LearningDeliveryId)
                    .HasName("IX_Parent_Invalid_LearningDeliveryHE");

                entity.HasIndex(e => new { e.LearnRefNumber, e.AimSeqNumber })
                    .HasName("IX_Invalid_LearningDeliveryHE");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.LearningDeliveryHeId).HasColumnName("LearningDeliveryHE_Id");

                entity.Property(e => e.Domicile)
                    .HasColumnName("DOMICILE")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Elq).HasColumnName("ELQ");

                entity.Property(e => e.Fundcomp).HasColumnName("FUNDCOMP");

                entity.Property(e => e.Fundlev).HasColumnName("FUNDLEV");

                entity.Property(e => e.Grossfee).HasColumnName("GROSSFEE");

                entity.Property(e => e.HepostCode)
                    .HasColumnName("HEPostCode")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearningDeliveryId).HasColumnName("LearningDelivery_Id");

                entity.Property(e => e.Modestud).HasColumnName("MODESTUD");

                entity.Property(e => e.Mstufee).HasColumnName("MSTUFEE");

                entity.Property(e => e.Netfee).HasColumnName("NETFEE");

                entity.Property(e => e.Numhus)
                    .HasColumnName("NUMHUS")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Pcfldcs).HasColumnName("PCFLDCS");

                entity.Property(e => e.Pcolab).HasColumnName("PCOLAB");

                entity.Property(e => e.Pcsldcs).HasColumnName("PCSLDCS");

                entity.Property(e => e.Pctldcs).HasColumnName("PCTLDCS");

                entity.Property(e => e.Qualent3)
                    .HasColumnName("QUALENT3")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Sec).HasColumnName("SEC");

                entity.Property(e => e.Soc2000).HasColumnName("SOC2000");

                entity.Property(e => e.Specfee).HasColumnName("SPECFEE");

                entity.Property(e => e.Ssn)
                    .HasColumnName("SSN")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Stuload).HasColumnName("STULOAD");

                entity.Property(e => e.Typeyr).HasColumnName("TYPEYR");

                entity.Property(e => e.Ucasappid)
                    .HasColumnName("UCASAPPID")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Yearstu).HasColumnName("YEARSTU");
            });

            modelBuilder.Entity<LearningDeliveryWorkPlacement>(entity =>
            {
                entity.HasKey(e => new { e.Ukprn, e.LearningDeliveryWorkPlacementId });

                entity.ToTable("LearningDeliveryWorkPlacement", "Invalid");

                entity.HasIndex(e => e.LearningDeliveryId)
                    .HasName("IX_Parent_Invalid_LearningDeliveryWorkPlacement");

                entity.HasIndex(e => new { e.LearnRefNumber, e.AimSeqNumber, e.WorkPlaceStartDate, e.WorkPlaceMode, e.WorkPlaceEmpId })
                    .HasName("IX_Invalid_LearningDeliveryWorkPlacement");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.LearningDeliveryWorkPlacementId).HasColumnName("LearningDeliveryWorkPlacement_Id");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearningDeliveryId).HasColumnName("LearningDelivery_Id");

                entity.Property(e => e.WorkPlaceEndDate).HasColumnType("date");

                entity.Property(e => e.WorkPlaceStartDate).HasColumnType("date");
            });

            modelBuilder.Entity<LearningProvider>(entity =>
            {
                entity.HasKey(e => new { e.Ukprn, e.LearningProviderId });

                entity.ToTable("LearningProvider", "Invalid");

                entity.HasIndex(e => e.Ukprn)
                    .HasName("IX_Invalid_LearningProvider");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.LearningProviderId).HasColumnName("LearningProvider_Id");
            });

            modelBuilder.Entity<LlddandHealthProblem>(entity =>
            {
                entity.HasKey(e => new { e.Ukprn, e.LlddandHealthProblemId });

                entity.ToTable("LLDDandHealthProblem", "Invalid");

                entity.HasIndex(e => e.LearnerId)
                    .HasName("IX_Parent_Invalid_LLDDandHealthProblem");

                entity.HasIndex(e => new { e.LearnRefNumber, e.Llddcat })
                    .HasName("IX_Invalid_LLDDandHealthProblem");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.LlddandHealthProblemId).HasColumnName("LLDDandHealthProblem_Id");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnerId).HasColumnName("Learner_Id");

                entity.Property(e => e.Llddcat).HasColumnName("LLDDCat");

                entity.Property(e => e.PrimaryLldd).HasColumnName("PrimaryLLDD");
            });

            modelBuilder.Entity<ProviderSpecDeliveryMonitoring>(entity =>
            {
                entity.HasKey(e => new { e.Ukprn, e.ProviderSpecDeliveryMonitoringId });

                entity.ToTable("ProviderSpecDeliveryMonitoring", "Invalid");

                entity.HasIndex(e => e.LearningDeliveryId)
                    .HasName("IX_Parent_Invalid_ProviderSpecDeliveryMonitoring");

                entity.HasIndex(e => new { e.LearnRefNumber, e.AimSeqNumber, e.ProvSpecDelMonOccur })
                    .HasName("IX_Invalid_ProviderSpecDeliveryMonitoring");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.ProviderSpecDeliveryMonitoringId).HasColumnName("ProviderSpecDeliveryMonitoring_Id");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearningDeliveryId).HasColumnName("LearningDelivery_Id");

                entity.Property(e => e.ProvSpecDelMon)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ProvSpecDelMonOccur)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProviderSpecLearnerMonitoring>(entity =>
            {
                entity.HasKey(e => new { e.Ukprn, e.ProviderSpecLearnerMonitoringId });

                entity.ToTable("ProviderSpecLearnerMonitoring", "Invalid");

                entity.HasIndex(e => e.LearnerId)
                    .HasName("IX_Parent_Invalid_ProviderSpecLearnerMonitoring");

                entity.HasIndex(e => new { e.LearnRefNumber, e.ProvSpecLearnMonOccur })
                    .HasName("IX_Invalid_ProviderSpecLearnerMonitoring");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.ProviderSpecLearnerMonitoringId).HasColumnName("ProviderSpecLearnerMonitoring_Id");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnerId).HasColumnName("Learner_Id");

                entity.Property(e => e.ProvSpecLearnMon)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ProvSpecLearnMonOccur)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Source>(entity =>
            {
                entity.HasKey(e => new { e.Ukprn, e.SourceId });

                entity.ToTable("Source", "Invalid");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.SourceId).HasColumnName("Source_Id");

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
                entity.HasKey(e => new { e.Ukprn, e.SourceFileId });

                entity.ToTable("SourceFile", "Invalid");

                entity.HasIndex(e => e.SourceFileName)
                    .HasName("IX_Invalid_SourceFile");

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");

                entity.Property(e => e.SourceFileId).HasColumnName("SourceFile_Id");

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

                entity.Property(e => e.SourceFileName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
