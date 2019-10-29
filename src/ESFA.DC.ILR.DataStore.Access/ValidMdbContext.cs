using System.Data.Jet;
using EntityFrameworkCore.Jet;
using ESFA.DC.ILR.DataStore.Access.ContextMutator;
using ESFA.DC.ILR.DataStore.Access.Interface;
using ESFA.DC.ILR1920.DataStore.EF.Valid;
using Microsoft.EntityFrameworkCore;

namespace ESFA.DC.ILR.DataStore.Access
{
    public class ValidMdbContext : ILR1920_DataStoreEntitiesValid
    {
        public ValidMdbContext()
        {
        }

        public ValidMdbContext(DbContextOptions<ValidMdbContext> options)
            : base(DbContextMutator.MutateOptionsType<ILR1920_DataStoreEntitiesValid>(options))
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

            modelBuilder.Ignore<PeriodEndMetricsEntity>();
            modelBuilder.Ignore<LearnerLearningDeliveryEntity>();

            modelBuilder.Entity<AppFinRecord>().ToTable("Valid_AppFinRecord");
            modelBuilder.Entity<CollectionDetail>().ToTable("Valid_CollectionDetails");
            modelBuilder.Entity<ContactPreference>().ToTable("Valid_ContactPreference");
            modelBuilder.Entity<DPOutcome>().ToTable("Valid_DPOutcome");
            modelBuilder.Entity<EmploymentStatusMonitoring>().ToTable("Valid_EmploymentStatusMonitoring");
            modelBuilder.Entity<Learner>(e =>
            {
                e.ToTable("Valid_Learner");
                e.Property(p => p.ULN).HasColumnType("double");
            });

            modelBuilder.Entity<LearnerDestinationandProgression>().ToTable("Valid_LearnerDestinationAndProgression");
            modelBuilder.Entity<LearnerEmploymentStatus>().ToTable("Valid_LearnerEmploymentStatus");
            modelBuilder.Entity<LearnerFAM>().ToTable("Valid_LearnerFAM");
            modelBuilder.Entity<LearnerHE>().ToTable("Valid_LearnerHE");
            modelBuilder.Entity<LearnerHEFinancialSupport>().ToTable("Valid_LearnerHEFinancialSupport");
            modelBuilder.Entity<LearningDelivery>().ToTable("Valid_LearningDelivery");
            modelBuilder.Entity<LearningDeliveryFAM>().ToTable("Valid_LearningDeliveryFAM");
            modelBuilder.Entity<LearningDeliveryHE>().ToTable("Valid_LearningDeliveryHE");
            modelBuilder.Entity<LearningDeliveryWorkPlacement>().ToTable("Valid_LearningDeliveryWorkPlacement");
            modelBuilder.Entity<LearningProvider>().ToTable("Valid_LearningProvider");
            modelBuilder.Entity<LLDDandHealthProblem>().ToTable("Valid_LLDDandHealthProblem");
            modelBuilder.Entity<ProviderSpecDeliveryMonitoring>().ToTable("Valid_ProviderSpecDeliveryMonitoring");
            modelBuilder.Entity<ProviderSpecLearnerMonitoring>().ToTable("Valid_ProviderSpecLearnerMonitoring");
            modelBuilder.Entity<Source>().ToTable("Valid_Source");
            modelBuilder.Entity<SourceFile>().ToTable("Valid_SourceFile");
        }
    }
}
