using System.Data.Jet;
using EntityFrameworkCore.Jet;
using ESFA.DC.ILR.DataStore.Access.ContextMutator;
using ESFA.DC.ILR2021.DataStore.EF.Invalid;
using Microsoft.EntityFrameworkCore;

namespace ESFA.DC.ILR.DataStore.Access
{
    public class InvalidMdbContext : ILR2021_DataStoreEntitiesInvalid
    {
        public InvalidMdbContext()
        {
        }

        public InvalidMdbContext(DbContextOptions<InvalidMdbContext> options)
            : base(DbContextMutator.MutateOptionsType<ILR2021_DataStoreEntitiesInvalid>(options))
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

            modelBuilder.Entity<AppFinRecord>().ToTable("Invalid_AppFinRecord");
            modelBuilder.Entity<CollectionDetail>().ToTable("Invalid_CollectionDetails");
            modelBuilder.Entity<ContactPreference>().ToTable("Invalid_ContactPreference");
            modelBuilder.Entity<DPOutcome>().ToTable("Invalid_DPOutcome");
            modelBuilder.Entity<EmploymentStatusMonitoring>().ToTable("Invalid_EmploymentStatusMonitoring");
            modelBuilder.Entity<Learner>(
                entity =>
                {
                    entity.ToTable("Invalid_Learner");
                    entity.Property(e => e.ULN).HasColumnType("double");
                    entity.Property(e => e.PrevUKPRN).HasColumnType("double");
                    entity.Property(e => e.PMUKPRN).HasColumnType("double");
                    entity.Property(e => e.PrevLearnRefNumber).HasColumnType("memo");
                    entity.Property(e => e.FamilyName).HasColumnType("memo");
                    entity.Property(e => e.GivenNames).HasColumnType("memo");
                    entity.Property(e => e.Sex).HasColumnType("memo");
                    entity.Property(e => e.NINumber).HasColumnType("memo");
                    entity.Property(e => e.MathGrade).HasColumnType("memo");
                    entity.Property(e => e.EngGrade).HasColumnType("memo");
                    entity.Property(e => e.Postcode).HasColumnType("memo");
                    entity.Property(e => e.PostcodePrior).HasColumnType("memo");
                    entity.Property(e => e.AddLine1).HasColumnType("memo");
                    entity.Property(e => e.AddLine2).HasColumnType("memo");
                    entity.Property(e => e.AddLine3).HasColumnType("memo");
                    entity.Property(e => e.AddLine4).HasColumnType("memo");
                    entity.Property(e => e.Email).HasColumnType("memo");
                    entity.Property(e => e.TelNo).HasColumnType("memo");
                    entity.Property(e => e.CampId).HasColumnType("memo");
                });

            modelBuilder.Entity<LearnerDestinationandProgression>(e =>
            {
                e.ToTable("Invalid_LearnerDestinationAndProgression");
                e.Property(p => p.ULN).HasColumnType("double");
            });

            modelBuilder.Entity<LearnerEmploymentStatus>().ToTable("Invalid_LearnerEmploymentStatus");
            modelBuilder.Entity<LearnerFAM>(
                entity =>
                {
                    entity.ToTable("Invalid_LearnerFAM");
                    entity.Property(e => e.LearnFAMType).HasColumnType("memo");
                });

            modelBuilder.Entity<LearnerHE>(
                entity =>
                {
                    entity.ToTable("Invalid_LearnerHE");
                    entity.Property(e => e.UCASPERID).HasColumnType("memo");
                });

            modelBuilder.Entity<LearnerHEFinancialSupport>().ToTable("Invalid_LearnerHEFinancialSupport");

            modelBuilder.Entity<LearningDelivery>(entity =>
            {
                entity.ToTable("Invalid_LearningDelivery");
                entity.Property(e => e.LearnAimRef).HasColumnType("memo");
                entity.Property(e => e.DelLocPostCode).HasColumnType("memo");
                entity.Property(e => e.ConRefNumber).HasColumnType("memo");
                entity.Property(e => e.EPAOrgID).HasColumnType("memo"); ;
                entity.Property(e => e.OutGrade).HasColumnType("memo");
                entity.Property(e => e.SWSupAimId).HasColumnType("memo");
                entity.Property(e => e.LSDPostcode).HasColumnType("memo");
            });

            modelBuilder.Entity<LearningDeliveryFAM>(entity =>
            {
                entity.ToTable("Invalid_LearningDeliveryFAM");
                entity.Property(e => e.LearnDelFAMCode).HasColumnType("memo");
            });

            modelBuilder.Entity<LearningDeliveryHE>(entity =>
            {
                entity.ToTable("Invalid_LearningDeliveryHE");
                entity.Property(e => e.NUMHUS).HasColumnType("memo");
                entity.Property(e => e.SSN).HasColumnType("memo");
                entity.Property(e => e.QUALENT3).HasColumnType("memo");
                entity.Property(e => e.UCASAPPID).HasColumnType("memo");
                entity.Property(e => e.DOMICILE).HasColumnType("memo");
                entity.Property(e => e.HEPostCode).HasColumnType("memo");
            });

            modelBuilder.Entity<LearningDeliveryWorkPlacement>().ToTable("Invalid_LearningDeliveryWorkPlacement");

            modelBuilder.Entity<LearningProvider>().ToTable("Invalid_LearningProvider");

            modelBuilder.Entity<LLDDandHealthProblem>().ToTable("Invalid_LLDDandHealthProblem");

            modelBuilder.Entity<ProviderSpecDeliveryMonitoring>(entity =>
            {
                entity.ToTable("Invalid_ProviderSpecDeliveryMonitoring");
                entity.Property(e => e.ProvSpecDelMon).HasColumnType("memo");
            });

            modelBuilder.Entity<ProviderSpecLearnerMonitoring>(entity =>
            {
                entity.ToTable("Invalid_ProviderSpecLearnerMonitoring");
                entity.Property(e => e.ProvSpecLearnMon).HasColumnType("memo");
            });

            modelBuilder.Entity<Source>().ToTable("Invalid_Source");

            modelBuilder.Entity<SourceFile>().ToTable("Invalid_SourceFile");
        }
    }
}
