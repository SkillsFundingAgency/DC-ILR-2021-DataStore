using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESFA.DC.ILR.DataStore.Access.Migrations.Valid
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Valid");

            migrationBuilder.CreateTable(
                name: "Valid_CollectionDetails",
                schema: "Valid",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    Collection = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    Year = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    FilePreparationDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valid_CollectionDetails", x => new { x.UKPRN, x.Collection, x.Year });
                });

            migrationBuilder.CreateTable(
                name: "Valid_EmploymentStatusMonitoring",
                schema: "Valid",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    DateEmpStatApp = table.Column<DateTime>(type: "date", nullable: false),
                    ESMType = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    ESMCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employme__316BBA3177FA0E58", x => new { x.UKPRN, x.LearnRefNumber, x.DateEmpStatApp, x.ESMType });
                });

            migrationBuilder.CreateTable(
                name: "Valid_Learner",
                schema: "Valid",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    PrevLearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    PrevUKPRN = table.Column<int>(nullable: true),
                    PMUKPRN = table.Column<int>(nullable: true),
                    ULN = table.Column<double>(type: "double", nullable: false),
                    FamilyName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    GivenNames = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    Ethnicity = table.Column<int>(nullable: false),
                    Sex = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    LLDDHealthProb = table.Column<int>(nullable: false),
                    NINumber = table.Column<string>(unicode: false, maxLength: 9, nullable: true),
                    PriorAttain = table.Column<int>(nullable: true),
                    Accom = table.Column<int>(nullable: true),
                    ALSCost = table.Column<int>(nullable: true),
                    PlanLearnHours = table.Column<int>(nullable: true),
                    PlanEEPHours = table.Column<int>(nullable: true),
                    MathGrade = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    EngGrade = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    PostcodePrior = table.Column<string>(unicode: false, maxLength: 8, nullable: false),
                    Postcode = table.Column<string>(unicode: false, maxLength: 8, nullable: false),
                    AddLine1 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    AddLine2 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    AddLine3 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    AddLine4 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    TelNo = table.Column<string>(unicode: false, maxLength: 18, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CampId = table.Column<string>(unicode: false, maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learner__2770A7272800E247", x => new { x.UKPRN, x.LearnRefNumber });
                });

            migrationBuilder.CreateTable(
                name: "Valid_LearnerDestinationAndProgression",
                schema: "Valid",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    ULN = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LearnerD__2770A72787FC8583", x => new { x.UKPRN, x.LearnRefNumber });
                });

            migrationBuilder.CreateTable(
                name: "Valid_LearningProvider",
                schema: "Valid",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learning__50F26B71C00B9BD1", x => x.UKPRN);
                });

            migrationBuilder.CreateTable(
                name: "Valid_Source",
                schema: "Valid",
                columns: table => new
                {
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
                    table.PrimaryKey("PK_Valid_Source", x => x.UKPRN);
                });

            migrationBuilder.CreateTable(
                name: "Valid_SourceFile",
                schema: "Valid",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    SourceFileName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    FilePreparationDate = table.Column<DateTime>(type: "date", nullable: true),
                    SoftwareSupplier = table.Column<string>(unicode: false, maxLength: 40, nullable: true),
                    SoftwarePackage = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Release = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    SerialNo = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valid_SourceFile", x => new { x.UKPRN, x.SourceFileName });
                });

            migrationBuilder.CreateTable(
                name: "Valid_ContactPreference",
                schema: "Valid",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    ContPrefType = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    ContPrefCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPref", x => new { x.UKPRN, x.LearnRefNumber, x.ContPrefType, x.ContPrefCode });
                    table.ForeignKey(
                        name: "FK_ContactPreference_Learner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valid_LearnerEmploymentStatus",
                schema: "Valid",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    DateEmpStatApp = table.Column<DateTime>(type: "date", nullable: false),
                    EmpStat = table.Column<int>(nullable: false),
                    EmpId = table.Column<int>(nullable: true),
                    AgreeId = table.Column<string>(unicode: false, maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LearnerE__7200C4BE58EC6070", x => new { x.UKPRN, x.LearnRefNumber, x.DateEmpStatApp });
                    table.ForeignKey(
                        name: "FK_LearnerEmploymentStatus_Learner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valid_LearnerFAM",
                schema: "Valid",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    LearnFAMType = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    LearnFAMCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valid_LearnerFAM", x => new { x.LearnFAMCode, x.LearnFAMType, x.LearnRefNumber, x.UKPRN });
                    table.ForeignKey(
                        name: "FK_LearnerFAM_Learner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valid_LearnerHE",
                schema: "Valid",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    UCASPERID = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    TTACCOM = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LearnerH__2770A7279C7D6CB5", x => new { x.UKPRN, x.LearnRefNumber });
                    table.ForeignKey(
                        name: "FK_LearnerHE_Learner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valid_LearningDelivery",
                schema: "Valid",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    LearnAimRef = table.Column<string>(unicode: false, maxLength: 8, nullable: false),
                    AimType = table.Column<int>(nullable: false),
                    LearnStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    OrigLearnStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    LearnPlanEndDate = table.Column<DateTime>(type: "date", nullable: false),
                    FundModel = table.Column<int>(nullable: false),
                    ProgType = table.Column<int>(nullable: true),
                    FworkCode = table.Column<int>(nullable: true),
                    PwayCode = table.Column<int>(nullable: true),
                    StdCode = table.Column<int>(nullable: true),
                    PartnerUKPRN = table.Column<int>(nullable: true),
                    DelLocPostCode = table.Column<string>(unicode: false, maxLength: 8, nullable: true),
                    AddHours = table.Column<int>(nullable: true),
                    PriorLearnFundAdj = table.Column<int>(nullable: true),
                    OtherFundAdj = table.Column<int>(nullable: true),
                    ConRefNumber = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    EPAOrgID = table.Column<string>(unicode: false, maxLength: 7, nullable: true),
                    EmpOutcome = table.Column<int>(nullable: true),
                    CompStatus = table.Column<int>(nullable: false),
                    LearnActEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    WithdrawReason = table.Column<int>(nullable: true),
                    Outcome = table.Column<int>(nullable: true),
                    AchDate = table.Column<DateTime>(type: "date", nullable: true),
                    OutGrade = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    SWSupAimId = table.Column<string>(unicode: false, maxLength: 36, nullable: true),
                    PHours = table.Column<int>(nullable: true),
                    LSDPostcode = table.Column<string>(unicode: false, maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learning__0C29443A14B79EFD", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber });
                    table.ForeignKey(
                        name: "FK_LearningDelivery_Learner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valid_LLDDandHealthProblem",
                schema: "Valid",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    LLDDCat = table.Column<int>(nullable: false),
                    LLDDandHealthProblem_ID = table.Column<long>(nullable: false),
                    PrimaryLLDD = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LLDDandH__CFA94E1CDBFD452F", x => new { x.UKPRN, x.LearnRefNumber, x.LLDDCat, x.LLDDandHealthProblem_ID });
                    table.ForeignKey(
                        name: "FK_LLDDandHealthProblem_Learner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valid_ProviderSpecLearnerMonitoring",
                schema: "Valid",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    ProvSpecLearnMonOccur = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    ProvSpecLearnMon = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Provider__63E551EA945F4643", x => new { x.UKPRN, x.LearnRefNumber, x.ProvSpecLearnMonOccur });
                    table.ForeignKey(
                        name: "FK_ProviderSpecLearnerMonitoring_Learner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valid_DPOutcome",
                schema: "Valid",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    OutType = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    OutCode = table.Column<int>(nullable: false),
                    OutStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    OutCollDate = table.Column<DateTime>(type: "date", nullable: false),
                    OutEndDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valid_DPOutcome", x => new { x.UKPRN, x.LearnRefNumber, x.OutType, x.OutCode, x.OutStartDate, x.OutCollDate });
                    table.ForeignKey(
                        name: "FK_DPOutcome_LearnerDestinationandProgression",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_LearnerDestinationAndProgression",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valid_LearnerHEFinancialSupport",
                schema: "Valid",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    FINTYPE = table.Column<int>(nullable: false),
                    FINAMOUNT = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LearnerH__09F54B72FB824228", x => new { x.UKPRN, x.LearnRefNumber, x.FINTYPE });
                    table.ForeignKey(
                        name: "FK_LearnerHEFinancialSupport_LearnerHE",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_LearnerHE",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valid_AppFinRecord",
                schema: "Valid",
                columns: table => new
                {
                    AppFinRecord_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    AFinType = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    AFinCode = table.Column<int>(nullable: false),
                    AFinDate = table.Column<DateTime>(type: "date", nullable: false),
                    AFinAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valid_AppFinRecord", x => new { x.UKPRN, x.AppFinRecord_Id });
                    table.ForeignKey(
                        name: "FK_AppFinRecord_LearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valid_LearningDeliveryFAM",
                schema: "Valid",
                columns: table => new
                {
                    LearningDeliveryFAM_Id = table.Column<int>(nullable: false),
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    LearnDelFAMType = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    LearnDelFAMCode = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    LearnDelFAMDateFrom = table.Column<DateTime>(type: "date", nullable: true),
                    LearnDelFAMDateTo = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valid_LearningDeliveryFAM", x => new { x.UKPRN, x.LearningDeliveryFAM_Id });
                    table.ForeignKey(
                        name: "FK_LearningDeliveryFAM_LearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valid_LearningDeliveryHE",
                schema: "Valid",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    NUMHUS = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    SSN = table.Column<string>(unicode: false, maxLength: 13, nullable: true),
                    QUALENT3 = table.Column<string>(unicode: false, maxLength: 3, nullable: true),
                    SOC2000 = table.Column<int>(nullable: true),
                    SEC = table.Column<int>(nullable: true),
                    UCASAPPID = table.Column<string>(unicode: false, maxLength: 9, nullable: true),
                    TYPEYR = table.Column<int>(nullable: false),
                    MODESTUD = table.Column<int>(nullable: false),
                    FUNDLEV = table.Column<int>(nullable: false),
                    FUNDCOMP = table.Column<int>(nullable: false),
                    STULOAD = table.Column<decimal>(type: "decimal(4, 1)", nullable: true),
                    YEARSTU = table.Column<int>(nullable: false),
                    MSTUFEE = table.Column<int>(nullable: false),
                    PCOLAB = table.Column<decimal>(type: "decimal(4, 1)", nullable: true),
                    PCFLDCS = table.Column<decimal>(type: "decimal(4, 1)", nullable: true),
                    PCSLDCS = table.Column<decimal>(type: "decimal(4, 1)", nullable: true),
                    PCTLDCS = table.Column<decimal>(type: "decimal(4, 1)", nullable: true),
                    SPECFEE = table.Column<int>(nullable: false),
                    NETFEE = table.Column<int>(nullable: true),
                    GROSSFEE = table.Column<int>(nullable: true),
                    DOMICILE = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    ELQ = table.Column<int>(nullable: true),
                    HEPostCode = table.Column<string>(unicode: false, maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learning__0C29443A745B97AB", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber });
                    table.ForeignKey(
                        name: "FK_LearningDeliveryHE_LearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valid_LearningDeliveryWorkPlacement",
                schema: "Valid",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    WorkPlaceStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    WorkPlaceEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    WorkPlaceHours = table.Column<int>(nullable: true),
                    WorkPlaceMode = table.Column<int>(nullable: false),
                    WorkPlaceEmpId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valid_LearningDeliveryWorkPlacement", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber, x.WorkPlaceStartDate });
                    table.ForeignKey(
                        name: "FK_LearningDeliveryWorkPlacement_LearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valid_ProviderSpecDeliveryMonitoring",
                schema: "Valid",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    ProvSpecDelMonOccur = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    ProvSpecDelMon = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Provider__9F5C508501D87521", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber, x.ProvSpecDelMonOccur });
                    table.ForeignKey(
                        name: "FK_ProviderSpecDeliveryMonitoring_LearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Valid_AppFinRecord",
                schema: "Valid",
                table: "Valid_AppFinRecord",
                columns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber", "AFinType" });

            migrationBuilder.CreateIndex(
                name: "IX_Valid_ContactPreference",
                schema: "Valid",
                table: "Valid_ContactPreference",
                columns: new[] { "LearnRefNumber", "ContPrefType" });

            migrationBuilder.CreateIndex(
                name: "IX_Valid_LearnerFAM",
                schema: "Valid",
                table: "Valid_LearnerFAM",
                columns: new[] { "UKPRN", "LearnRefNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Valid_LearningDeliveryFAM",
                schema: "Valid",
                table: "Valid_LearningDeliveryFAM",
                columns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber", "LearnDelFAMType", "LearnDelFAMDateFrom" });

            migrationBuilder.CreateIndex(
                name: "IX_Valid_LearningDeliveryFAM_UKPRN_FamType",
                schema: "Valid",
                table: "Valid_LearningDeliveryFAM",
                columns: new[] { "LearnRefNumber", "AimSeqNumber", "LearnDelFAMCode", "LearnDelFAMDateFrom", "LearnDelFAMDateTo", "UKPRN", "LearnDelFAMType" });

            migrationBuilder.CreateIndex(
                name: "IX_Valid_LearningDeliveryWorkPlacement",
                schema: "Valid",
                table: "Valid_LearningDeliveryWorkPlacement",
                columns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber", "WorkPlaceStartDate", "WorkPlaceMode" });

            migrationBuilder.CreateIndex(
                name: "IX_Valid_SourceFile",
                schema: "Valid",
                table: "Valid_SourceFile",
                column: "SourceFileName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Valid_AppFinRecord",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_CollectionDetails",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_ContactPreference",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_DPOutcome",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_EmploymentStatusMonitoring",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_LearnerEmploymentStatus",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_LearnerFAM",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_LearnerHEFinancialSupport",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_LearningDeliveryFAM",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_LearningDeliveryHE",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_LearningDeliveryWorkPlacement",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_LearningProvider",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_LLDDandHealthProblem",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_ProviderSpecDeliveryMonitoring",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_ProviderSpecLearnerMonitoring",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_Source",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_SourceFile",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_LearnerDestinationAndProgression",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_LearnerHE",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_LearningDelivery",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_Learner",
                schema: "Valid");
        }
    }
}
