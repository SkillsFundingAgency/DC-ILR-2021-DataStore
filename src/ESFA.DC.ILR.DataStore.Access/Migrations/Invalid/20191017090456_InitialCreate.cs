using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESFA.DC.ILR.DataStore.Access.Migrations.Invalid
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Invalid");

            migrationBuilder.CreateTable(
                name: "Invalid_AppFinRecord",
                schema: "Invalid",
                columns: table => new
                {
                    AppFinRecord_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    LearningDelivery_Id = table.Column<int>(nullable: true),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    AimSeqNumber = table.Column<long>(nullable: true),
                    AFinType = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    AFinCode = table.Column<long>(nullable: true),
                    AFinDate = table.Column<DateTime>(type: "date", nullable: true),
                    AFinAmount = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_AppFinRecord", x => new { x.UKPRN, x.AppFinRecord_Id });
                });

            migrationBuilder.CreateTable(
                name: "Invalid_CollectionDetails",
                schema: "Invalid",
                columns: table => new
                {
                    CollectionDetails_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    Collection = table.Column<string>(unicode: false, maxLength: 3, nullable: true),
                    Year = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    FilePreparationDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_CollectionDetails", x => new { x.UKPRN, x.CollectionDetails_Id });
                });

            migrationBuilder.CreateTable(
                name: "Invalid_ContactPreference",
                schema: "Invalid",
                columns: table => new
                {
                    ContactPreference_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    Learner_Id = table.Column<int>(nullable: true),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ContPrefType = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ContPrefCode = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_ContactPreference", x => new { x.UKPRN, x.ContactPreference_Id });
                });

            migrationBuilder.CreateTable(
                name: "Invalid_DPOutcome",
                schema: "Invalid",
                columns: table => new
                {
                    DPOutcome_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    LearnerDestinationandProgression_Id = table.Column<int>(nullable: true),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    OutType = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    OutCode = table.Column<long>(nullable: true),
                    OutStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    OutEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    OutCollDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_DPOutcome", x => new { x.UKPRN, x.DPOutcome_Id });
                });

            migrationBuilder.CreateTable(
                name: "Invalid_EmploymentStatusMonitoring",
                schema: "Invalid",
                columns: table => new
                {
                    EmploymentStatusMonitoring_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    LearnerEmploymentStatus_Id = table.Column<int>(nullable: true),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DateEmpStatApp = table.Column<DateTime>(type: "date", nullable: true),
                    ESMType = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ESMCode = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_EmploymentStatusMonitoring", x => new { x.UKPRN, x.EmploymentStatusMonitoring_Id });
                });

            migrationBuilder.CreateTable(
                name: "Invalid_Learner",
                schema: "Invalid",
                columns: table => new
                {
                    Learner_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    PrevLearnRefNumber = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    PrevUKPRN = table.Column<long>(nullable: true),
                    PMUKPRN = table.Column<long>(nullable: true),
                    ULN = table.Column<long>(nullable: true),
                    FamilyName = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    GivenNames = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    Ethnicity = table.Column<long>(nullable: true),
                    Sex = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    LLDDHealthProb = table.Column<long>(nullable: true),
                    NINumber = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    PriorAttain = table.Column<long>(nullable: true),
                    Accom = table.Column<long>(nullable: true),
                    ALSCost = table.Column<long>(nullable: true),
                    PlanLearnHours = table.Column<long>(nullable: true),
                    PlanEEPHours = table.Column<long>(nullable: true),
                    MathGrade = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    EngGrade = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    PostcodePrior = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    Postcode = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    AddLine1 = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    AddLine2 = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    AddLine3 = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    AddLine4 = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    TelNo = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    Email = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    CampId = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_Learner", x => new { x.UKPRN, x.Learner_Id });
                });

            migrationBuilder.CreateTable(
                name: "Invalid_LearnerDestinationAndProgression",
                schema: "Invalid",
                columns: table => new
                {
                    LearnerDestinationandProgression_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ULN = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_LearnerDestinationAndProgression", x => new { x.UKPRN, x.LearnerDestinationandProgression_Id });
                });

            migrationBuilder.CreateTable(
                name: "Invalid_LearnerEmploymentStatus",
                schema: "Invalid",
                columns: table => new
                {
                    LearnerEmploymentStatus_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    Learner_Id = table.Column<int>(nullable: true),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    EmpStat = table.Column<long>(nullable: true),
                    DateEmpStatApp = table.Column<DateTime>(type: "date", nullable: true),
                    EmpId = table.Column<long>(nullable: true),
                    AgreeId = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_LearnerEmploymentStatus", x => new { x.UKPRN, x.LearnerEmploymentStatus_Id });
                });

            migrationBuilder.CreateTable(
                name: "Invalid_LearnerFAM",
                schema: "Invalid",
                columns: table => new
                {
                    LearnerFAM_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    Learner_Id = table.Column<int>(nullable: true),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    LearnFAMType = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    LearnFAMCode = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_LearnerFAM", x => new { x.UKPRN, x.LearnerFAM_Id });
                });

            migrationBuilder.CreateTable(
                name: "Invalid_LearnerHE",
                schema: "Invalid",
                columns: table => new
                {
                    LearnerHE_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    Learner_Id = table.Column<int>(nullable: true),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    UCASPERID = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    TTACCOM = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_LearnerHE", x => new { x.UKPRN, x.LearnerHE_Id });
                });

            migrationBuilder.CreateTable(
                name: "Invalid_LearnerHEFinancialSupport",
                schema: "Invalid",
                columns: table => new
                {
                    LearnerHEFinancialSupport_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    LearnerHE_Id = table.Column<int>(nullable: true),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    FINTYPE = table.Column<long>(nullable: true),
                    FINAMOUNT = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_LearnerHEFinancialSupport", x => new { x.UKPRN, x.LearnerHEFinancialSupport_Id });
                });

            migrationBuilder.CreateTable(
                name: "Invalid_LearningDelivery",
                schema: "Invalid",
                columns: table => new
                {
                    LearningDelivery_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    Learner_Id = table.Column<int>(nullable: true),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    LearnAimRef = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    AimType = table.Column<long>(nullable: true),
                    AimSeqNumber = table.Column<long>(nullable: true),
                    LearnStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    OrigLearnStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    LearnPlanEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    FundModel = table.Column<long>(nullable: true),
                    ProgType = table.Column<long>(nullable: true),
                    FworkCode = table.Column<long>(nullable: true),
                    PwayCode = table.Column<long>(nullable: true),
                    StdCode = table.Column<long>(nullable: true),
                    PartnerUKPRN = table.Column<long>(nullable: true),
                    DelLocPostCode = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    AddHours = table.Column<long>(nullable: true),
                    PriorLearnFundAdj = table.Column<long>(nullable: true),
                    OtherFundAdj = table.Column<long>(nullable: true),
                    ConRefNumber = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    EPAOrgID = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    EmpOutcome = table.Column<long>(nullable: true),
                    CompStatus = table.Column<long>(nullable: true),
                    LearnActEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    WithdrawReason = table.Column<long>(nullable: true),
                    Outcome = table.Column<long>(nullable: true),
                    AchDate = table.Column<DateTime>(type: "date", nullable: true),
                    OutGrade = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    SWSupAimId = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    PHours = table.Column<long>(nullable: true),
                    LSDPostcode = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_LearningDelivery", x => new { x.UKPRN, x.LearningDelivery_Id });
                });

            migrationBuilder.CreateTable(
                name: "Invalid_LearningDeliveryFAM",
                schema: "Invalid",
                columns: table => new
                {
                    LearningDeliveryFAM_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    LearningDelivery_Id = table.Column<int>(nullable: true),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    AimSeqNumber = table.Column<long>(nullable: true),
                    LearnDelFAMType = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    LearnDelFAMCode = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    LearnDelFAMDateFrom = table.Column<DateTime>(type: "date", nullable: true),
                    LearnDelFAMDateTo = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_LearningDeliveryFAM", x => new { x.UKPRN, x.LearningDeliveryFAM_Id });
                });

            migrationBuilder.CreateTable(
                name: "Invalid_LearningDeliveryHE",
                schema: "Invalid",
                columns: table => new
                {
                    LearningDeliveryHE_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    LearningDelivery_Id = table.Column<int>(nullable: true),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    AimSeqNumber = table.Column<long>(nullable: true),
                    NUMHUS = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    SSN = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    QUALENT3 = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    SOC2000 = table.Column<long>(nullable: true),
                    SEC = table.Column<long>(nullable: true),
                    UCASAPPID = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    TYPEYR = table.Column<long>(nullable: true),
                    MODESTUD = table.Column<long>(nullable: true),
                    FUNDLEV = table.Column<long>(nullable: true),
                    FUNDCOMP = table.Column<long>(nullable: true),
                    STULOAD = table.Column<double>(nullable: true),
                    YEARSTU = table.Column<long>(nullable: true),
                    MSTUFEE = table.Column<long>(nullable: true),
                    PCOLAB = table.Column<double>(nullable: true),
                    PCFLDCS = table.Column<double>(nullable: true),
                    PCSLDCS = table.Column<double>(nullable: true),
                    PCTLDCS = table.Column<double>(nullable: true),
                    SPECFEE = table.Column<long>(nullable: true),
                    NETFEE = table.Column<long>(nullable: true),
                    GROSSFEE = table.Column<long>(nullable: true),
                    DOMICILE = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    ELQ = table.Column<long>(nullable: true),
                    HEPostCode = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_LearningDeliveryHE", x => new { x.UKPRN, x.LearningDeliveryHE_Id });
                });

            migrationBuilder.CreateTable(
                name: "Invalid_LearningDeliveryWorkPlacement",
                schema: "Invalid",
                columns: table => new
                {
                    LearningDeliveryWorkPlacement_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    LearningDelivery_Id = table.Column<int>(nullable: true),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    AimSeqNumber = table.Column<long>(nullable: true),
                    WorkPlaceStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    WorkPlaceEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    WorkPlaceHours = table.Column<long>(nullable: true),
                    WorkPlaceMode = table.Column<long>(nullable: true),
                    WorkPlaceEmpId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_LearningDeliveryWorkPlacement", x => new { x.UKPRN, x.LearningDeliveryWorkPlacement_Id });
                });

            migrationBuilder.CreateTable(
                name: "Invalid_LearningProvider",
                schema: "Invalid",
                columns: table => new
                {
                    LearningProvider_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_LearningProvider", x => new { x.UKPRN, x.LearningProvider_Id });
                });

            migrationBuilder.CreateTable(
                name: "Invalid_LLDDandHealtProblem",
                schema: "Invalid",
                columns: table => new
                {
                    LLDDandHealthProblem_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    Learner_Id = table.Column<int>(nullable: true),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    LLDDCat = table.Column<long>(nullable: true),
                    PrimaryLLDD = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_LLDDandHealtProblem", x => new { x.UKPRN, x.LLDDandHealthProblem_Id });
                });

            migrationBuilder.CreateTable(
                name: "Invalid_ProviderSpecDeliveryMonitoring",
                schema: "Invalid",
                columns: table => new
                {
                    ProviderSpecDeliveryMonitoring_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    LearningDelivery_Id = table.Column<int>(nullable: true),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    AimSeqNumber = table.Column<long>(nullable: true),
                    ProvSpecDelMonOccur = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ProvSpecDelMon = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_ProviderSpecDeliveryMonitoring", x => new { x.UKPRN, x.ProviderSpecDeliveryMonitoring_Id });
                });

            migrationBuilder.CreateTable(
                name: "Invalid_ProviderSpecLearnerMonitoring",
                schema: "Invalid",
                columns: table => new
                {
                    ProviderSpecLearnerMonitoring_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    Learner_Id = table.Column<int>(nullable: true),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ProvSpecLearnMonOccur = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ProvSpecLearnMon = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_ProviderSpecLearnerMonitoring", x => new { x.UKPRN, x.ProviderSpecLearnerMonitoring_Id });
                });

            migrationBuilder.CreateTable(
                name: "Invalid_Source",
                schema: "Invalid",
                columns: table => new
                {
                    Source_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    ProtectiveMarking = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    SoftwareSupplier = table.Column<string>(unicode: false, maxLength: 40, nullable: true),
                    SoftwarePackage = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Release = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    SerialNo = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReferenceData = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ComponentSetVersion = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_Source", x => new { x.UKPRN, x.Source_Id });
                });

            migrationBuilder.CreateTable(
                name: "Invalid_SourceFile",
                schema: "Invalid",
                columns: table => new
                {
                    SourceFile_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    SourceFileName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    FilePreparationDate = table.Column<DateTime>(type: "date", nullable: true),
                    SoftwareSupplier = table.Column<string>(unicode: false, maxLength: 40, nullable: true),
                    SoftwarePackage = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Release = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    SerialNo = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invalid_SourceFile", x => new { x.UKPRN, x.SourceFile_Id });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parent_Invalid_AppFinRecord",
                schema: "Invalid",
                table: "Invalid_AppFinRecord",
                column: "LearningDelivery_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invalid_AppFinRecord",
                schema: "Invalid",
                table: "Invalid_AppFinRecord",
                columns: new[] { "LearnRefNumber", "AimSeqNumber", "AFinType" });

            migrationBuilder.CreateIndex(
                name: "IX_Parent_Invalid_ContactPreference",
                schema: "Invalid",
                table: "Invalid_ContactPreference",
                column: "Learner_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invalid_ContactPreference",
                schema: "Invalid",
                table: "Invalid_ContactPreference",
                columns: new[] { "LearnRefNumber", "ContPrefType" });

            migrationBuilder.CreateIndex(
                name: "IX_Parent_Invalid_DPOutcome",
                schema: "Invalid",
                table: "Invalid_DPOutcome",
                column: "LearnerDestinationandProgression_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invalid_DPOutcome",
                schema: "Invalid",
                table: "Invalid_DPOutcome",
                columns: new[] { "LearnRefNumber", "OutType", "OutCode", "OutStartDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Parent_Invalid_EmploymentStatusMonitoring",
                schema: "Invalid",
                table: "Invalid_EmploymentStatusMonitoring",
                column: "LearnerEmploymentStatus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invalid_EmploymentStatusMonitoring",
                schema: "Invalid",
                table: "Invalid_EmploymentStatusMonitoring",
                columns: new[] { "LearnRefNumber", "DateEmpStatApp", "ESMType" });

            migrationBuilder.CreateIndex(
                name: "IX_Invalid_Learner",
                schema: "Invalid",
                table: "Invalid_Learner",
                column: "LearnRefNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Invalid_LearnerDestinationandProgression",
                schema: "Invalid",
                table: "Invalid_LearnerDestinationAndProgression",
                column: "LearnRefNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Parent_Invalid_LearnerEmploymentStatus",
                schema: "Invalid",
                table: "Invalid_LearnerEmploymentStatus",
                column: "Learner_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invalid_LearnerEmploymentStatus",
                schema: "Invalid",
                table: "Invalid_LearnerEmploymentStatus",
                columns: new[] { "LearnRefNumber", "DateEmpStatApp" });

            migrationBuilder.CreateIndex(
                name: "IX_Invalid_LearnerFAM",
                schema: "Invalid",
                table: "Invalid_LearnerFAM",
                column: "LearnRefNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Parent_Invalid_LearnerFAM",
                schema: "Invalid",
                table: "Invalid_LearnerFAM",
                column: "Learner_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invalid_LearnerHE",
                schema: "Invalid",
                table: "Invalid_LearnerHE",
                column: "LearnRefNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Parent_Invalid_LearnerHE",
                schema: "Invalid",
                table: "Invalid_LearnerHE",
                column: "Learner_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Parent_Invalid_LearnerHEFinancialSupport",
                schema: "Invalid",
                table: "Invalid_LearnerHEFinancialSupport",
                column: "LearnerHE_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invalid_LearnerHEFinancialSupport",
                schema: "Invalid",
                table: "Invalid_LearnerHEFinancialSupport",
                columns: new[] { "LearnRefNumber", "FINTYPE" });

            migrationBuilder.CreateIndex(
                name: "IX_Parent_Invalid_LearningDelivery",
                schema: "Invalid",
                table: "Invalid_LearningDelivery",
                column: "Learner_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invalid_LearningDelivery",
                schema: "Invalid",
                table: "Invalid_LearningDelivery",
                columns: new[] { "LearnRefNumber", "AimSeqNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Parent_Invalid_LearningDeliveryFAM",
                schema: "Invalid",
                table: "Invalid_LearningDeliveryFAM",
                column: "LearningDelivery_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invalid_LearningDeliveryFAM",
                schema: "Invalid",
                table: "Invalid_LearningDeliveryFAM",
                columns: new[] { "LearnRefNumber", "AimSeqNumber", "LearnDelFAMType", "LearnDelFAMDateFrom" });

            migrationBuilder.CreateIndex(
                name: "IX_Parent_Invalid_LearningDeliveryHE",
                schema: "Invalid",
                table: "Invalid_LearningDeliveryHE",
                column: "LearningDelivery_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invalid_LearningDeliveryHE",
                schema: "Invalid",
                table: "Invalid_LearningDeliveryHE",
                columns: new[] { "LearnRefNumber", "AimSeqNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Parent_Invalid_LearningDeliveryWorkPlacement",
                schema: "Invalid",
                table: "Invalid_LearningDeliveryWorkPlacement",
                column: "LearningDelivery_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invalid_LearningDeliveryWorkPlacement",
                schema: "Invalid",
                table: "Invalid_LearningDeliveryWorkPlacement",
                columns: new[] { "LearnRefNumber", "AimSeqNumber", "WorkPlaceStartDate", "WorkPlaceMode", "WorkPlaceEmpId" });

            migrationBuilder.CreateIndex(
                name: "IX_Invalid_LearningProvider",
                schema: "Invalid",
                table: "Invalid_LearningProvider",
                column: "UKPRN");

            migrationBuilder.CreateIndex(
                name: "IX_Parent_Invalid_LLDDandHealthProblem",
                schema: "Invalid",
                table: "Invalid_LLDDandHealtProblem",
                column: "Learner_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invalid_LLDDandHealthProblem",
                schema: "Invalid",
                table: "Invalid_LLDDandHealtProblem",
                columns: new[] { "LearnRefNumber", "LLDDCat" });

            migrationBuilder.CreateIndex(
                name: "IX_Parent_Invalid_ProviderSpecDeliveryMonitoring",
                schema: "Invalid",
                table: "Invalid_ProviderSpecDeliveryMonitoring",
                column: "LearningDelivery_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invalid_ProviderSpecDeliveryMonitoring",
                schema: "Invalid",
                table: "Invalid_ProviderSpecDeliveryMonitoring",
                columns: new[] { "LearnRefNumber", "AimSeqNumber", "ProvSpecDelMonOccur" });

            migrationBuilder.CreateIndex(
                name: "IX_Parent_Invalid_ProviderSpecLearnerMonitoring",
                schema: "Invalid",
                table: "Invalid_ProviderSpecLearnerMonitoring",
                column: "Learner_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invalid_ProviderSpecLearnerMonitoring",
                schema: "Invalid",
                table: "Invalid_ProviderSpecLearnerMonitoring",
                columns: new[] { "LearnRefNumber", "ProvSpecLearnMonOccur" });

            migrationBuilder.CreateIndex(
                name: "IX_Invalid_SourceFile",
                schema: "Invalid",
                table: "Invalid_SourceFile",
                column: "SourceFileName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invalid_AppFinRecord",
                schema: "Invalid");

            migrationBuilder.DropTable(
                name: "Invalid_CollectionDetails",
                schema: "Invalid");

            migrationBuilder.DropTable(
                name: "Invalid_ContactPreference",
                schema: "Invalid");

            migrationBuilder.DropTable(
                name: "Invalid_DPOutcome",
                schema: "Invalid");

            migrationBuilder.DropTable(
                name: "Invalid_EmploymentStatusMonitoring",
                schema: "Invalid");

            migrationBuilder.DropTable(
                name: "Invalid_Learner",
                schema: "Invalid");

            migrationBuilder.DropTable(
                name: "Invalid_LearnerDestinationAndProgression",
                schema: "Invalid");

            migrationBuilder.DropTable(
                name: "Invalid_LearnerEmploymentStatus",
                schema: "Invalid");

            migrationBuilder.DropTable(
                name: "Invalid_LearnerFAM",
                schema: "Invalid");

            migrationBuilder.DropTable(
                name: "Invalid_LearnerHE",
                schema: "Invalid");

            migrationBuilder.DropTable(
                name: "Invalid_LearnerHEFinancialSupport",
                schema: "Invalid");

            migrationBuilder.DropTable(
                name: "Invalid_LearningDelivery",
                schema: "Invalid");

            migrationBuilder.DropTable(
                name: "Invalid_LearningDeliveryFAM",
                schema: "Invalid");

            migrationBuilder.DropTable(
                name: "Invalid_LearningDeliveryHE",
                schema: "Invalid");

            migrationBuilder.DropTable(
                name: "Invalid_LearningDeliveryWorkPlacement",
                schema: "Invalid");

            migrationBuilder.DropTable(
                name: "Invalid_LearningProvider",
                schema: "Invalid");

            migrationBuilder.DropTable(
                name: "Invalid_LLDDandHealtProblem",
                schema: "Invalid");

            migrationBuilder.DropTable(
                name: "Invalid_ProviderSpecDeliveryMonitoring",
                schema: "Invalid");

            migrationBuilder.DropTable(
                name: "Invalid_ProviderSpecLearnerMonitoring",
                schema: "Invalid");

            migrationBuilder.DropTable(
                name: "Invalid_Source",
                schema: "Invalid");

            migrationBuilder.DropTable(
                name: "Invalid_SourceFile",
                schema: "Invalid");
        }
    }
}
