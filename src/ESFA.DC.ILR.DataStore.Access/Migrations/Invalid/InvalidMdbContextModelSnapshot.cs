﻿// <auto-generated />
using System;
using ESFA.DC.ILR.DataStore.Access;
using EntityFrameworkCore.Jet.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ESFA.DC.ILR.DataStore.Access.Migrations.Invalid
{
    [DbContext(typeof(InvalidMdbContext))]
    partial class InvalidMdbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Jet:ValueGenerationStrategy", JetValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.AppFinRecord", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("AppFinRecord_Id");

                    b.Property<long?>("AFinAmount");

                    b.Property<long?>("AFinCode");

                    b.Property<DateTime?>("AFinDate")
                        .HasColumnType("date");

                    b.Property<string>("AFinType")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<long?>("AimSeqNumber");

                    b.Property<string>("LearnRefNumber")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("LearningDelivery_Id");

                    b.HasKey("UKPRN", "AppFinRecord_Id");

                    b.HasIndex("LearningDelivery_Id")
                        .HasName("IX_Parent_Invalid_AppFinRecord");

                    b.HasIndex("LearnRefNumber", "AimSeqNumber", "AFinType")
                        .HasName("IX_Invalid_AppFinRecord");

                    b.ToTable("Invalid_AppFinRecord","Invalid");
                });

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.CollectionDetail", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("CollectionDetails_Id");

                    b.Property<string>("Collection")
                        .HasMaxLength(3)
                        .IsUnicode(false);

                    b.Property<DateTime?>("FilePreparationDate")
                        .HasColumnType("date");

                    b.Property<string>("Year")
                        .HasMaxLength(4)
                        .IsUnicode(false);

                    b.HasKey("UKPRN", "CollectionDetails_Id");

                    b.ToTable("Invalid_CollectionDetails","Invalid");
                });

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.ContactPreference", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("ContactPreference_Id");

                    b.Property<long?>("ContPrefCode");

                    b.Property<string>("ContPrefType")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("LearnRefNumber")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("Learner_Id");

                    b.HasKey("UKPRN", "ContactPreference_Id");

                    b.HasIndex("Learner_Id")
                        .HasName("IX_Parent_Invalid_ContactPreference");

                    b.HasIndex("LearnRefNumber", "ContPrefType")
                        .HasName("IX_Invalid_ContactPreference");

                    b.ToTable("Invalid_ContactPreference","Invalid");
                });

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.DPOutcome", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("DPOutcome_Id");

                    b.Property<string>("LearnRefNumber")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("LearnerDestinationandProgression_Id");

                    b.Property<long?>("OutCode");

                    b.Property<DateTime?>("OutCollDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("OutEndDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("OutStartDate")
                        .HasColumnType("date");

                    b.Property<string>("OutType")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("UKPRN", "DPOutcome_Id");

                    b.HasIndex("LearnerDestinationandProgression_Id")
                        .HasName("IX_Parent_Invalid_DPOutcome");

                    b.HasIndex("LearnRefNumber", "OutType", "OutCode", "OutStartDate")
                        .HasName("IX_Invalid_DPOutcome");

                    b.ToTable("Invalid_DPOutcome","Invalid");
                });

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.EmploymentStatusMonitoring", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("EmploymentStatusMonitoring_Id");

                    b.Property<DateTime?>("DateEmpStatApp")
                        .HasColumnType("date");

                    b.Property<long?>("ESMCode");

                    b.Property<string>("ESMType")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("LearnRefNumber")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("LearnerEmploymentStatus_Id");

                    b.HasKey("UKPRN", "EmploymentStatusMonitoring_Id");

                    b.HasIndex("LearnerEmploymentStatus_Id")
                        .HasName("IX_Parent_Invalid_EmploymentStatusMonitoring");

                    b.HasIndex("LearnRefNumber", "DateEmpStatApp", "ESMType")
                        .HasName("IX_Invalid_EmploymentStatusMonitoring");

                    b.ToTable("Invalid_EmploymentStatusMonitoring","Invalid");
                });

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.LLDDandHealthProblem", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("LLDDandHealthProblem_Id");

                    b.Property<long?>("LLDDCat");

                    b.Property<string>("LearnRefNumber")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("Learner_Id");

                    b.Property<long?>("PrimaryLLDD");

                    b.HasKey("UKPRN", "LLDDandHealthProblem_Id");

                    b.HasIndex("Learner_Id")
                        .HasName("IX_Parent_Invalid_LLDDandHealthProblem");

                    b.HasIndex("LearnRefNumber", "LLDDCat")
                        .HasName("IX_Invalid_LLDDandHealthProblem");

                    b.ToTable("Invalid_LLDDandHealthProblem","Invalid");
                });

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.Learner", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("Learner_Id");

                    b.Property<long?>("ALSCost");

                    b.Property<long?>("Accom");

                    b.Property<string>("AddLine1")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<string>("AddLine2")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<string>("AddLine3")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<string>("AddLine4")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<string>("CampId")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<string>("EngGrade")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<long?>("Ethnicity");

                    b.Property<string>("FamilyName")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<string>("GivenNames")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<long?>("LLDDHealthProb");

                    b.Property<string>("LearnRefNumber")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("MathGrade")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<string>("NINumber")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<double?>("PMUKPRN")
                        .HasColumnType("double");

                    b.Property<long?>("PlanEEPHours");

                    b.Property<long?>("PlanLearnHours");

                    b.Property<string>("Postcode")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<string>("PostcodePrior")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<string>("PrevLearnRefNumber")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<double?>("PrevUKPRN")
                        .HasColumnType("double");

                    b.Property<long?>("PriorAttain");

                    b.Property<string>("Sex")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<string>("TelNo")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<double?>("ULN")
                        .HasColumnType("double");

                    b.HasKey("UKPRN", "Learner_Id");

                    b.HasIndex("LearnRefNumber")
                        .HasName("IX_Invalid_Learner");

                    b.ToTable("Invalid_Learner","Invalid");
                });

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.LearnerDestinationandProgression", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("LearnerDestinationandProgression_Id");

                    b.Property<string>("LearnRefNumber")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<double?>("ULN")
                        .HasColumnType("double");

                    b.HasKey("UKPRN", "LearnerDestinationandProgression_Id");

                    b.HasIndex("LearnRefNumber")
                        .HasName("IX_Invalid_LearnerDestinationandProgression");

                    b.ToTable("Invalid_LearnerDestinationAndProgression","Invalid");
                });

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.LearnerEmploymentStatus", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("LearnerEmploymentStatus_Id");

                    b.Property<string>("AgreeId")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<DateTime?>("DateEmpStatApp")
                        .HasColumnType("date");

                    b.Property<long?>("EmpId");

                    b.Property<long?>("EmpStat");

                    b.Property<string>("LearnRefNumber")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("Learner_Id");

                    b.HasKey("UKPRN", "LearnerEmploymentStatus_Id");

                    b.HasIndex("Learner_Id")
                        .HasName("IX_Parent_Invalid_LearnerEmploymentStatus");

                    b.HasIndex("LearnRefNumber", "DateEmpStatApp")
                        .HasName("IX_Invalid_LearnerEmploymentStatus");

                    b.ToTable("Invalid_LearnerEmploymentStatus","Invalid");
                });

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.LearnerFAM", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("LearnerFAM_Id");

                    b.Property<long?>("LearnFAMCode");

                    b.Property<string>("LearnFAMType")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<string>("LearnRefNumber")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("Learner_Id");

                    b.HasKey("UKPRN", "LearnerFAM_Id");

                    b.HasIndex("LearnRefNumber")
                        .HasName("IX_Invalid_LearnerFAM");

                    b.HasIndex("Learner_Id")
                        .HasName("IX_Parent_Invalid_LearnerFAM");

                    b.ToTable("Invalid_LearnerFAM","Invalid");
                });

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.LearnerHE", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("LearnerHE_Id");

                    b.Property<string>("LearnRefNumber")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("Learner_Id");

                    b.Property<long?>("TTACCOM");

                    b.Property<string>("UCASPERID")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.HasKey("UKPRN", "LearnerHE_Id");

                    b.HasIndex("LearnRefNumber")
                        .HasName("IX_Invalid_LearnerHE");

                    b.HasIndex("Learner_Id")
                        .HasName("IX_Parent_Invalid_LearnerHE");

                    b.ToTable("Invalid_LearnerHE","Invalid");
                });

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.LearnerHEFinancialSupport", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("LearnerHEFinancialSupport_Id");

                    b.Property<long?>("FINAMOUNT");

                    b.Property<long?>("FINTYPE");

                    b.Property<string>("LearnRefNumber")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("LearnerHE_Id");

                    b.HasKey("UKPRN", "LearnerHEFinancialSupport_Id");

                    b.HasIndex("LearnerHE_Id")
                        .HasName("IX_Parent_Invalid_LearnerHEFinancialSupport");

                    b.HasIndex("LearnRefNumber", "FINTYPE")
                        .HasName("IX_Invalid_LearnerHEFinancialSupport");

                    b.ToTable("Invalid_LearnerHEFinancialSupport","Invalid");
                });

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.LearningDelivery", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("LearningDelivery_Id");

                    b.Property<DateTime?>("AchDate")
                        .HasColumnType("date");

                    b.Property<long?>("AddHours");

                    b.Property<long?>("AimSeqNumber");

                    b.Property<long?>("AimType");

                    b.Property<long?>("CompStatus");

                    b.Property<string>("ConRefNumber")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<string>("DelLocPostCode")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<string>("EPAOrgID")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<long?>("EmpOutcome");

                    b.Property<long?>("FundModel");

                    b.Property<long?>("FworkCode");

                    b.Property<string>("LSDPostcode")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<DateTime?>("LearnActEndDate")
                        .HasColumnType("date");

                    b.Property<string>("LearnAimRef")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<DateTime?>("LearnPlanEndDate")
                        .HasColumnType("date");

                    b.Property<string>("LearnRefNumber")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<DateTime?>("LearnStartDate")
                        .HasColumnType("date");

                    b.Property<int?>("Learner_Id");

                    b.Property<DateTime?>("OrigLearnStartDate")
                        .HasColumnType("date");

                    b.Property<long?>("OtherFundAdj");

                    b.Property<string>("OutGrade")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<long?>("Outcome");

                    b.Property<long?>("PHours");

                    b.Property<long?>("PartnerUKPRN");

                    b.Property<long?>("PriorLearnFundAdj");

                    b.Property<long?>("ProgType");

                    b.Property<long?>("PwayCode");

                    b.Property<string>("SWSupAimId")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<long?>("StdCode");

                    b.Property<long?>("WithdrawReason");

                    b.HasKey("UKPRN", "LearningDelivery_Id");

                    b.HasIndex("Learner_Id")
                        .HasName("IX_Parent_Invalid_LearningDelivery");

                    b.HasIndex("LearnRefNumber", "AimSeqNumber")
                        .HasName("IX_Invalid_LearningDelivery");

                    b.ToTable("Invalid_LearningDelivery","Invalid");
                });

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.LearningDeliveryFAM", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("LearningDeliveryFAM_Id");

                    b.Property<long?>("AimSeqNumber");

                    b.Property<string>("LearnDelFAMCode")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<DateTime?>("LearnDelFAMDateFrom")
                        .HasColumnType("date");

                    b.Property<DateTime?>("LearnDelFAMDateTo")
                        .HasColumnType("date");

                    b.Property<string>("LearnDelFAMType")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("LearnRefNumber")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("LearningDelivery_Id");

                    b.HasKey("UKPRN", "LearningDeliveryFAM_Id");

                    b.HasIndex("LearningDelivery_Id")
                        .HasName("IX_Parent_Invalid_LearningDeliveryFAM");

                    b.HasIndex("LearnRefNumber", "AimSeqNumber", "LearnDelFAMType", "LearnDelFAMDateFrom")
                        .HasName("IX_Invalid_LearningDeliveryFAM");

                    b.ToTable("Invalid_LearningDeliveryFAM","Invalid");
                });

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.LearningDeliveryHE", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("LearningDeliveryHE_Id");

                    b.Property<long?>("AimSeqNumber");

                    b.Property<string>("DOMICILE")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<long?>("ELQ");

                    b.Property<long?>("FUNDCOMP");

                    b.Property<long?>("FUNDLEV");

                    b.Property<long?>("GROSSFEE");

                    b.Property<string>("HEPostCode")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<string>("LearnRefNumber")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("LearningDelivery_Id");

                    b.Property<long?>("MODESTUD");

                    b.Property<long?>("MSTUFEE");

                    b.Property<long?>("NETFEE");

                    b.Property<string>("NUMHUS")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<double?>("PCFLDCS");

                    b.Property<double?>("PCOLAB");

                    b.Property<double?>("PCSLDCS");

                    b.Property<double?>("PCTLDCS");

                    b.Property<string>("QUALENT3")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<long?>("SEC");

                    b.Property<long?>("SOC2000");

                    b.Property<long?>("SPECFEE");

                    b.Property<string>("SSN")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<double?>("STULOAD");

                    b.Property<long?>("TYPEYR");

                    b.Property<string>("UCASAPPID")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<long?>("YEARSTU");

                    b.HasKey("UKPRN", "LearningDeliveryHE_Id");

                    b.HasIndex("LearningDelivery_Id")
                        .HasName("IX_Parent_Invalid_LearningDeliveryHE");

                    b.HasIndex("LearnRefNumber", "AimSeqNumber")
                        .HasName("IX_Invalid_LearningDeliveryHE");

                    b.ToTable("Invalid_LearningDeliveryHE","Invalid");
                });

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.LearningDeliveryWorkPlacement", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("LearningDeliveryWorkPlacement_Id");

                    b.Property<long?>("AimSeqNumber");

                    b.Property<string>("LearnRefNumber")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("LearningDelivery_Id");

                    b.Property<long?>("WorkPlaceEmpId");

                    b.Property<DateTime?>("WorkPlaceEndDate")
                        .HasColumnType("date");

                    b.Property<long?>("WorkPlaceHours");

                    b.Property<long?>("WorkPlaceMode");

                    b.Property<DateTime?>("WorkPlaceStartDate")
                        .HasColumnType("date");

                    b.HasKey("UKPRN", "LearningDeliveryWorkPlacement_Id");

                    b.HasIndex("LearningDelivery_Id")
                        .HasName("IX_Parent_Invalid_LearningDeliveryWorkPlacement");

                    b.HasIndex("LearnRefNumber", "AimSeqNumber", "WorkPlaceStartDate", "WorkPlaceMode", "WorkPlaceEmpId")
                        .HasName("IX_Invalid_LearningDeliveryWorkPlacement");

                    b.ToTable("Invalid_LearningDeliveryWorkPlacement","Invalid");
                });

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.LearningProvider", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("LearningProvider_Id");

                    b.HasKey("UKPRN", "LearningProvider_Id");

                    b.HasIndex("UKPRN")
                        .HasName("IX_Invalid_LearningProvider");

                    b.ToTable("Invalid_LearningProvider","Invalid");
                });

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.ProviderSpecDeliveryMonitoring", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("ProviderSpecDeliveryMonitoring_Id");

                    b.Property<long?>("AimSeqNumber");

                    b.Property<string>("LearnRefNumber")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("LearningDelivery_Id");

                    b.Property<string>("ProvSpecDelMon")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<string>("ProvSpecDelMonOccur")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("UKPRN", "ProviderSpecDeliveryMonitoring_Id");

                    b.HasIndex("LearningDelivery_Id")
                        .HasName("IX_Parent_Invalid_ProviderSpecDeliveryMonitoring");

                    b.HasIndex("LearnRefNumber", "AimSeqNumber", "ProvSpecDelMonOccur")
                        .HasName("IX_Invalid_ProviderSpecDeliveryMonitoring");

                    b.ToTable("Invalid_ProviderSpecDeliveryMonitoring","Invalid");
                });

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.ProviderSpecLearnerMonitoring", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("ProviderSpecLearnerMonitoring_Id");

                    b.Property<string>("LearnRefNumber")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("Learner_Id");

                    b.Property<string>("ProvSpecLearnMon")
                        .HasColumnType("memo")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<string>("ProvSpecLearnMonOccur")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("UKPRN", "ProviderSpecLearnerMonitoring_Id");

                    b.HasIndex("Learner_Id")
                        .HasName("IX_Parent_Invalid_ProviderSpecLearnerMonitoring");

                    b.HasIndex("LearnRefNumber", "ProvSpecLearnMonOccur")
                        .HasName("IX_Invalid_ProviderSpecLearnerMonitoring");

                    b.ToTable("Invalid_ProviderSpecLearnerMonitoring","Invalid");
                });

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.Source", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("Source_Id");

                    b.Property<string>("ComponentSetVersion")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("ProtectiveMarking")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("ReferenceData")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Release")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("SerialNo")
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.Property<string>("SoftwarePackage")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("SoftwareSupplier")
                        .HasMaxLength(40)
                        .IsUnicode(false);

                    b.HasKey("UKPRN", "Source_Id");

                    b.ToTable("Invalid_Source","Invalid");
                });

            modelBuilder.Entity("ESFA.DC.ILR1920.DataStore.EF.Invalid.SourceFile", b =>
                {
                    b.Property<int>("UKPRN");

                    b.Property<int>("SourceFile_Id");

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FilePreparationDate")
                        .HasColumnType("date");

                    b.Property<string>("Release")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("SerialNo")
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.Property<string>("SoftwarePackage")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("SoftwareSupplier")
                        .HasMaxLength(40)
                        .IsUnicode(false);

                    b.Property<string>("SourceFileName")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("UKPRN", "SourceFile_Id");

                    b.HasIndex("SourceFileName")
                        .HasName("IX_Invalid_SourceFile");

                    b.ToTable("Invalid_SourceFile","Invalid");
                });
#pragma warning restore 612, 618
        }
    }
}
