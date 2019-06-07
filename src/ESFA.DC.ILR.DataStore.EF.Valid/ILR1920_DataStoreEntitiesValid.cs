using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ESFA.DC.ILR1920.DataStore.EF.Valid
{
    public partial class ILR1920_DataStoreEntitiesValid : DbContext
    {
        public ILR1920_DataStoreEntitiesValid()
        {
        }

        public ILR1920_DataStoreEntitiesValid(DbContextOptions<ILR1920_DataStoreEntitiesValid> options)
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
                optionsBuilder.UseSqlServer("Server=.\\;Database=ILR1920_DataStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<AppFinRecord>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.AFinType, e.AFinCode, e.AFinDate });

                entity.ToTable("AppFinRecord", "Valid");

                entity.HasIndex(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.AFinType })
                    .HasName("IX_Valid_AppFinRecord");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AFinType)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.AFinDate).HasColumnType("date");

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

            modelBuilder.Entity<EmploymentStatusMonitoring>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.DateEmpStatApp, e.ESMType })
                    .HasName("PK__Employme__316BBA31E20C6B31");

                entity.ToTable("EmploymentStatusMonitoring", "Valid");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DateEmpStatApp).HasColumnType("date");

                entity.Property(e => e.ESMType)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LLDDandHealthProblem>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.LLDDCat, e.LLDDandHealthProblem_ID })
                    .HasName("PK__LLDDandH__CFA94E1C9E6508D2");

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
                    .HasName("PK__Learner__2770A727590705C0");

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
                    .HasName("PK__LearnerD__2770A727B4EFC5E3");

                entity.ToTable("LearnerDestinationandProgression", "Valid");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LearnerEmploymentStatus>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.DateEmpStatApp })
                    .HasName("PK__LearnerE__7200C4BEA93CFD0C");

                entity.ToTable("LearnerEmploymentStatus", "Valid");

                entity.Property(e => e.LearnRefNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DateEmpStatApp).HasColumnType("date");

                entity.Property(e => e.AgreeId)
                    .HasMaxLength(6)
                    .IsUnicode(false);

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
                    .HasName("PK__LearnerH__2770A727016360F0");

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
                    .HasName("PK__LearnerH__09F54B72D90CAF0E");

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
                    .HasName("PK__Learning__0C29443AB454001F");

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
                    .HasName("PK__Learning__0C29443A1CF07897");

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
                    .HasName("PK__Learning__50F26B715CC61C37");

                entity.ToTable("LearningProvider", "Valid");

                entity.Property(e => e.UKPRN).ValueGeneratedNever();
            });

            modelBuilder.Entity<ProviderSpecDeliveryMonitoring>(entity =>
            {
                entity.HasKey(e => new { e.UKPRN, e.LearnRefNumber, e.AimSeqNumber, e.ProvSpecDelMonOccur })
                    .HasName("PK__Provider__9F5C5085F13B8E80");

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
                    .HasName("PK__Provider__63E551EAEB778A19");

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
        }
    }
}
