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
        public virtual DbSet<DPOutcome> DPOutcomes { get; set; }
        public virtual DbSet<EmploymentStatusMonitoring> EmploymentStatusMonitorings { get; set; }
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
                entity.HasKey(e => new { e.UKPRN, e.AppFinRecord_Id });

                entity.ToTable("AppFinRecord", "Invalid");

                entity.HasIndex(e => e.LearningDelivery_Id)
                    .HasName("IX_Parent_Invalid_AppFinRecord");

                entity.HasIndex(e => new { e.LearnRefNumber, e.AimSeqNumber, e.AFinType })
                    .HasName("IX_Invalid_AppFinRecord");

                entity.Property(e => e.AFinDate).HasColumnType("date");

                entity.Property(e => e.AFinType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnRefNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CollectionDetail>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.CollectionDetails_Id });

                entity.ToTable("CollectionDetails", "Invalid");

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
                entity.HasKey(e => new { e.UKPRN, e.ContactPreference_Id });

                entity.ToTable("ContactPreference", "Invalid");

                entity.HasIndex(e => e.Learner_Id)
                    .HasName("IX_Parent_Invalid_ContactPreference");

                entity.HasIndex(e => new { e.LearnRefNumber, e.ContPrefType })
                    .HasName("IX_Invalid_ContactPreference");

                entity.Property(e => e.ContPrefType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DPOutcome>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.DPOutcome_Id });

                entity.ToTable("DPOutcome", "Invalid");

                entity.HasIndex(e => e.LearnerDestinationandProgression_Id)
                    .HasName("IX_Parent_Invalid_DPOutcome");

                entity.HasIndex(e => new { e.LearnRefNumber, e.OutType, e.OutCode, e.OutStartDate })
                    .HasName("IX_Invalid_DPOutcome");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OutCollDate).HasColumnType("date");

                entity.Property(e => e.OutEndDate).HasColumnType("date");

                entity.Property(e => e.OutStartDate).HasColumnType("date");

                entity.Property(e => e.OutType)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmploymentStatusMonitoring>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.EmploymentStatusMonitoring_Id });

                entity.ToTable("EmploymentStatusMonitoring", "Invalid");

                entity.HasIndex(e => e.LearnerEmploymentStatus_Id)
                    .HasName("IX_Parent_Invalid_EmploymentStatusMonitoring");

                entity.HasIndex(e => new { e.LearnRefNumber, e.DateEmpStatApp, e.ESMType })
                    .HasName("IX_Invalid_EmploymentStatusMonitoring");

                entity.Property(e => e.DateEmpStatApp).HasColumnType("date");

                entity.Property(e => e.ESMType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LLDDandHealthProblem>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LLDDandHealthProblem_Id });

                entity.ToTable("LLDDandHealthProblem", "Invalid");

                entity.HasIndex(e => e.Learner_Id)
                    .HasName("IX_Parent_Invalid_LLDDandHealthProblem");

                entity.HasIndex(e => new { e.LearnRefNumber, e.LLDDCat })
                    .HasName("IX_Invalid_LLDDandHealthProblem");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Learner>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.Learner_Id });

                entity.ToTable("Learner", "Invalid");

                entity.HasIndex(e => e.LearnRefNumber)
                    .HasName("IX_Invalid_Learner");

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

                entity.Property(e => e.MathGrade)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.NINumber)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Postcode)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PostcodePrior)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PrevLearnRefNumber)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TelNo)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LearnerDestinationandProgression>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnerDestinationandProgression_Id });

                entity.ToTable("LearnerDestinationandProgression", "Invalid");

                entity.HasIndex(e => e.LearnRefNumber)
                    .HasName("IX_Invalid_LearnerDestinationandProgression");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LearnerEmploymentStatus>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnerEmploymentStatus_Id });

                entity.ToTable("LearnerEmploymentStatus", "Invalid");

                entity.HasIndex(e => e.Learner_Id)
                    .HasName("IX_Parent_Invalid_LearnerEmploymentStatus");

                entity.HasIndex(e => new { e.LearnRefNumber, e.DateEmpStatApp })
                    .HasName("IX_Invalid_LearnerEmploymentStatus");

                entity.Property(e => e.AgreeId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateEmpStatApp).HasColumnType("date");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LearnerFAM>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnerFAM_Id });

                entity.ToTable("LearnerFAM", "Invalid");

                entity.HasIndex(e => e.LearnRefNumber)
                    .HasName("IX_Invalid_LearnerFAM");

                entity.HasIndex(e => e.Learner_Id)
                    .HasName("IX_Parent_Invalid_LearnerFAM");

                entity.Property(e => e.LearnFAMType)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LearnerHE>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnerHE_Id });

                entity.ToTable("LearnerHE", "Invalid");

                entity.HasIndex(e => e.LearnRefNumber)
                    .HasName("IX_Invalid_LearnerHE");

                entity.HasIndex(e => e.Learner_Id)
                    .HasName("IX_Parent_Invalid_LearnerHE");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UCASPERID)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LearnerHEFinancialSupport>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnerHEFinancialSupport_Id });

                entity.ToTable("LearnerHEFinancialSupport", "Invalid");

                entity.HasIndex(e => e.LearnerHE_Id)
                    .HasName("IX_Parent_Invalid_LearnerHEFinancialSupport");

                entity.HasIndex(e => new { e.LearnRefNumber, e.FINTYPE })
                    .HasName("IX_Invalid_LearnerHEFinancialSupport");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LearningDelivery>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearningDelivery_Id });

                entity.ToTable("LearningDelivery", "Invalid");

                entity.HasIndex(e => e.Learner_Id)
                    .HasName("IX_Parent_Invalid_LearningDelivery");

                entity.HasIndex(e => new { e.LearnRefNumber, e.AimSeqNumber })
                    .HasName("IX_Invalid_LearningDelivery");

                entity.Property(e => e.AchDate).HasColumnType("date");

                entity.Property(e => e.ConRefNumber)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.DelLocPostCode)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EPAOrgID)
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

                entity.Property(e => e.OrigLearnStartDate).HasColumnType("date");

                entity.Property(e => e.OutGrade)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.SWSupAimId)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LearningDeliveryFAM>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearningDeliveryFAM_Id });

                entity.ToTable("LearningDeliveryFAM", "Invalid");

                entity.HasIndex(e => e.LearningDelivery_Id)
                    .HasName("IX_Parent_Invalid_LearningDeliveryFAM");

                entity.HasIndex(e => new { e.LearnRefNumber, e.AimSeqNumber, e.LearnDelFAMType, e.LearnDelFAMDateFrom })
                    .HasName("IX_Invalid_LearningDeliveryFAM");

                entity.Property(e => e.LearnDelFAMCode)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LearnDelFAMDateFrom).HasColumnType("date");

                entity.Property(e => e.LearnDelFAMDateTo).HasColumnType("date");

                entity.Property(e => e.LearnDelFAMType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LearningDeliveryHE>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearningDeliveryHE_Id });

                entity.ToTable("LearningDeliveryHE", "Invalid");

                entity.HasIndex(e => e.LearningDelivery_Id)
                    .HasName("IX_Parent_Invalid_LearningDeliveryHE");

                entity.HasIndex(e => new { e.LearnRefNumber, e.AimSeqNumber })
                    .HasName("IX_Invalid_LearningDeliveryHE");

                entity.Property(e => e.DOMICILE)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.HEPostCode)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NUMHUS)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.QUALENT3)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.SSN)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UCASAPPID)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LearningDeliveryWorkPlacement>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearningDeliveryWorkPlacement_Id });

                entity.ToTable("LearningDeliveryWorkPlacement", "Invalid");

                entity.HasIndex(e => e.LearningDelivery_Id)
                    .HasName("IX_Parent_Invalid_LearningDeliveryWorkPlacement");

                entity.HasIndex(e => new { e.LearnRefNumber, e.AimSeqNumber, e.WorkPlaceStartDate, e.WorkPlaceMode, e.WorkPlaceEmpId })
                    .HasName("IX_Invalid_LearningDeliveryWorkPlacement");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WorkPlaceEndDate).HasColumnType("date");

                entity.Property(e => e.WorkPlaceStartDate).HasColumnType("date");
            });

            modelBuilder.Entity<LearningProvider>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearningProvider_Id });

                entity.ToTable("LearningProvider", "Invalid");

                entity.HasIndex(e => e.UKPRN)
                    .HasName("IX_Invalid_LearningProvider");
            });

            modelBuilder.Entity<ProviderSpecDeliveryMonitoring>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.ProviderSpecDeliveryMonitoring_Id });

                entity.ToTable("ProviderSpecDeliveryMonitoring", "Invalid");

                entity.HasIndex(e => e.LearningDelivery_Id)
                    .HasName("IX_Parent_Invalid_ProviderSpecDeliveryMonitoring");

                entity.HasIndex(e => new { e.LearnRefNumber, e.AimSeqNumber, e.ProvSpecDelMonOccur })
                    .HasName("IX_Invalid_ProviderSpecDeliveryMonitoring");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProvSpecDelMon)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ProvSpecDelMonOccur)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProviderSpecLearnerMonitoring>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.ProviderSpecLearnerMonitoring_Id });

                entity.ToTable("ProviderSpecLearnerMonitoring", "Invalid");

                entity.HasIndex(e => e.Learner_Id)
                    .HasName("IX_Parent_Invalid_ProviderSpecLearnerMonitoring");

                entity.HasIndex(e => new { e.LearnRefNumber, e.ProvSpecLearnMonOccur })
                    .HasName("IX_Invalid_ProviderSpecLearnerMonitoring");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProvSpecLearnMon)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ProvSpecLearnMonOccur)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Source>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.Source_Id });

                entity.ToTable("Source", "Invalid");

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
                entity.HasKey(e => new { e.UKPRN, e.SourceFile_Id });

                entity.ToTable("SourceFile", "Invalid");

                entity.HasIndex(e => e.SourceFileName)
                    .HasName("IX_Invalid_SourceFile");

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
