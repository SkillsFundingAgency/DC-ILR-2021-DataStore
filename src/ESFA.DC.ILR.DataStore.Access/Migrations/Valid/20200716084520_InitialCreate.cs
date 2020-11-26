using System;
using EntityFrameworkCore.Jet.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ESFA.DC.ILR.DataStore.Access.Migrations.Valid
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Rulebase");

            migrationBuilder.EnsureSchema(
                name: "Valid");

            migrationBuilder.CreateTable(
                name: "dbo_ValidationError",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Jet:ValueGenerationStrategy", JetValueGenerationStrategy.IdentityColumn),
                    UKPRN = table.Column<int>(nullable: true),
                    Source = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LearnAimRef = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    AimSeqNum = table.Column<long>(nullable: true),
                    SWSupAimID = table.Column<string>(type: "memo", unicode: false, maxLength: 1000, nullable: true),
                    ErrorMessage = table.Column<string>(nullable: true),
                    FieldValues = table.Column<string>(type: "memo", maxLength: 2000, nullable: true),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    RuleName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Severity = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    FileLevelError = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_ValidationError", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileDetails",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Jet:ValueGenerationStrategy", JetValueGenerationStrategy.IdentityColumn),
                    UKPRN = table.Column<int>(nullable: false),
                    Filename = table.Column<string>(maxLength: 50, nullable: true),
                    FileSizeKb = table.Column<long>(nullable: true),
                    TotalLearnersSubmitted = table.Column<int>(nullable: true),
                    TotalValidLearnersSubmitted = table.Column<int>(nullable: true),
                    TotalInvalidLearnersSubmitted = table.Column<int>(nullable: true),
                    TotalErrorCount = table.Column<int>(nullable: true),
                    TotalWarningCount = table.Column<int>(nullable: true),
                    SubmittedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Success = table.Column<bool>(nullable: true),
                    OrgName = table.Column<string>(maxLength: 255, nullable: true),
                    OrgVersion = table.Column<string>(maxLength: 50, nullable: true),
                    LarsVersion = table.Column<string>(maxLength: 50, nullable: true),
                    EmployersVersion = table.Column<string>(maxLength: 50, nullable: true),
                    PostcodesVersion = table.Column<string>(maxLength: 50, nullable: true),
                    CampusIdentifierVersion = table.Column<string>(maxLength: 50, nullable: true),
                    EasUploadDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProcessingData",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Jet:ValueGenerationStrategy", JetValueGenerationStrategy.IdentityColumn),
                    UKPRN = table.Column<int>(nullable: false),
                    FileDetailsID = table.Column<long>(nullable: false),
                    ProcessingStep = table.Column<string>(maxLength: 100, nullable: false),
                    ExecutionTime = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessingData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VersionInfo",
                columns: table => new
                {
                    Version = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersionInfo", x => x.Version);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_AEC_global",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LARSVersion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    RulebaseVersion = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Year = table.Column<string>(unicode: false, maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rulebase_AEC_global", x => x.UKPRN);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_AEC_HistoricEarningOutput",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AppIdentifierOutput = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    AppProgCompletedInTheYearOutput = table.Column<bool>(nullable: true),
                    HistoricDaysInYearOutput = table.Column<int>(nullable: true),
                    HistoricEffectiveTNPStartDateOutput = table.Column<DateTime>(type: "date", nullable: true),
                    HistoricEmpIdEndWithinYearOutput = table.Column<int>(nullable: true),
                    HistoricEmpIdStartWithinYearOutput = table.Column<int>(nullable: true),
                    HistoricFworkCodeOutput = table.Column<int>(nullable: true),
                    HistoricLearner1618AtStartOutput = table.Column<bool>(nullable: true),
                    HistoricPMRAmountOutput = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    HistoricProgrammeStartDateIgnorePathwayOutput = table.Column<DateTime>(type: "date", nullable: true),
                    HistoricProgrammeStartDateMatchPathwayOutput = table.Column<DateTime>(type: "date", nullable: true),
                    HistoricProgTypeOutput = table.Column<int>(nullable: true),
                    HistoricPwayCodeOutput = table.Column<int>(nullable: true),
                    HistoricSTDCodeOutput = table.Column<int>(nullable: true),
                    HistoricTNP1Output = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    HistoricTNP2Output = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    HistoricTNP3Output = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    HistoricTNP4Output = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    HistoricTotal1618UpliftPaymentsInTheYear = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    HistoricTotalProgAimPaymentsInTheYear = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    HistoricULNOutput = table.Column<double>(type: "double", nullable: true),
                    HistoricUptoEndDateOutput = table.Column<DateTime>(type: "date", nullable: true),
                    HistoricVirtualTNP3EndofThisYearOutput = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    HistoricVirtualTNP4EndofThisYearOutput = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    HistoricLearnDelProgEarliestACT2DateOutput = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AEC_Hist__9CDF0742E4D2441C", x => new { x.UKPRN, x.LearnRefNumber, x.AppIdentifierOutput });
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_ALB_global",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LARSVersion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    PostcodeAreaCostVersion = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    RulebaseVersion = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ALB_glob__50F26B71A83A79C7", x => x.UKPRN);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_DV_global",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    RulebaseVersion = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rulebase_DV_global", x => x.UKPRN);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_ESF_DPOutcome",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    OutCode = table.Column<int>(nullable: false),
                    OutType = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    OutStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    OutcomeDateForProgression = table.Column<DateTime>(type: "date", nullable: true),
                    PotentialESFProgressionType = table.Column<bool>(nullable: true),
                    ProgressionType = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ReachedSixMonthPoint = table.Column<bool>(nullable: true),
                    ReachedThreeMonthPoint = table.Column<bool>(nullable: true),
                    ReachedTwelveMonthPoint = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ESF_DPOu__1D621D296741BAD4", x => new { x.UKPRN, x.LearnRefNumber, x.OutCode, x.OutType, x.OutStartDate });
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_ESF_global",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    RulebaseVersion = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rulebase_ESF_global", x => x.UKPRN);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_ESFVAL_global",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    RulebaseVersion = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rulebase_ESFVAL_global", x => x.UKPRN);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_ESFVAL_ValidationError",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    AimSeqNumber = table.Column<long>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    ErrorString = table.Column<string>(type: "memo", unicode: false, maxLength: 2000, nullable: true),
                    FieldValues = table.Column<string>(type: "memo", unicode: false, maxLength: 2000, nullable: true),
                    RuleId = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rulebase_ESFVAL_ValidationError", x => new { x.UKPRN, x.AimSeqNumber, x.LearnRefNumber });
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_FM25_FM35_global",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    RulebaseVersion = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FM25_FM3__50F26B71528A48C1", x => x.UKPRN);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_FM25_global",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LARSVersion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    OrgVersion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PostcodeDisadvantageVersion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    RulebaseVersion = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FM25_glo__50F26B712170469F", x => x.UKPRN);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_FM35_global",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    CurFundYr = table.Column<string>(unicode: false, maxLength: 9, nullable: true),
                    LARSVersion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    OrgVersion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    PostcodeDisadvantageVersion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    RulebaseVersion = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FM35_Global", x => x.UKPRN);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_TBL_global",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    CurFundYr = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    LARSVersion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    RulebaseVersion = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBL_glob__50F26B71EBE63747", x => x.UKPRN);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_VAL_global",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    EmployerVersion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LARSVersion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    OrgVersion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PostcodeVersion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    RulebaseVersion = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VAL_glob__50F26B71B1C27011", x => x.UKPRN);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_VAL_LearningDelivery",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VAL_Lear__E56C5AA3B1E071EC", x => new { x.UKPRN, x.AimSeqNumber });
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_VAL_ValidationError",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    AimSeqNumber = table.Column<long>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    ErrorString = table.Column<string>(type: "memo", unicode: false, maxLength: 2000, nullable: true),
                    FieldValues = table.Column<string>(type: "memo", unicode: false, maxLength: 2000, nullable: true),
                    RuleId = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rulebase_VAL_ValidationError", x => new { x.UKPRN, x.AimSeqNumber, x.LearnRefNumber });
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_VALDP_global",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    OrgVersion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    RulebaseVersion = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    ULNVersion = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VALDP_gl__50F26B716DFF4FC0", x => x.UKPRN);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_VALDP_ValidationError",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    ErrorString = table.Column<string>(type: "memo", unicode: false, maxLength: 2000, nullable: true),
                    FieldValues = table.Column<string>(type: "memo", unicode: false, maxLength: 2000, nullable: true),
                    RuleId = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rulebase_VALDP_ValidationError", x => new { x.UKPRN, x.LearnRefNumber });
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_VALFD_ValidationError",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    AimSeqNumber = table.Column<long>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    ErrorString = table.Column<string>(type: "memo", unicode: false, maxLength: 2000, nullable: true),
                    FieldValues = table.Column<string>(type: "memo", unicode: false, maxLength: 2000, nullable: true),
                    RuleId = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rulebase_VALFD_ValidationError", x => new { x.UKPRN, x.AimSeqNumber, x.LearnRefNumber });
                });

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
                    table.PrimaryKey("PK__Employme__316BBA3120A1F4D6", x => new { x.UKPRN, x.LearnRefNumber, x.DateEmpStatApp, x.ESMType });
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
                    table.PrimaryKey("PK__Learner__2770A727B2BFB11C", x => new { x.UKPRN, x.LearnRefNumber });
                });

            migrationBuilder.CreateTable(
                name: "Valid_LearnerDestinationAndProgression",
                schema: "Valid",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    ULN = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LearnerD__2770A727F10815E3", x => new { x.UKPRN, x.LearnRefNumber });
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
                    table.PrimaryKey("PK__Learning__50F26B716E3C9C2E", x => x.UKPRN);
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
                name: "Rulebase_DV_Learner",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    Learn_3rdSector = table.Column<int>(nullable: true),
                    Learn_Active = table.Column<int>(nullable: true),
                    Learn_ActiveJan = table.Column<int>(nullable: true),
                    Learn_ActiveNov = table.Column<int>(nullable: true),
                    Learn_ActiveOct = table.Column<int>(nullable: true),
                    Learn_Age31Aug = table.Column<int>(nullable: true),
                    Learn_BasicSkill = table.Column<int>(nullable: true),
                    Learn_EmpStatFDL = table.Column<int>(nullable: true),
                    Learn_EmpStatPrior = table.Column<int>(nullable: true),
                    Learn_FirstFullLevel2 = table.Column<int>(nullable: true),
                    Learn_FirstFullLevel2Ach = table.Column<int>(nullable: true),
                    Learn_FirstFullLevel3 = table.Column<int>(nullable: true),
                    Learn_FirstFullLevel3Ach = table.Column<int>(nullable: true),
                    Learn_FullLevel2 = table.Column<int>(nullable: true),
                    Learn_FullLevel2Ach = table.Column<int>(nullable: true),
                    Learn_FullLevel3 = table.Column<int>(nullable: true),
                    Learn_FullLevel3Ach = table.Column<int>(nullable: true),
                    Learn_FundAgency = table.Column<int>(nullable: true),
                    Learn_FundingSource = table.Column<int>(nullable: true),
                    Learn_FundPrvYr = table.Column<int>(nullable: true),
                    Learn_ILAcMonth1 = table.Column<int>(nullable: true),
                    Learn_ILAcMonth10 = table.Column<int>(nullable: true),
                    Learn_ILAcMonth11 = table.Column<int>(nullable: true),
                    Learn_ILAcMonth12 = table.Column<int>(nullable: true),
                    Learn_ILAcMonth2 = table.Column<int>(nullable: true),
                    Learn_ILAcMonth3 = table.Column<int>(nullable: true),
                    Learn_ILAcMonth4 = table.Column<int>(nullable: true),
                    Learn_ILAcMonth5 = table.Column<int>(nullable: true),
                    Learn_ILAcMonth6 = table.Column<int>(nullable: true),
                    Learn_ILAcMonth7 = table.Column<int>(nullable: true),
                    Learn_ILAcMonth8 = table.Column<int>(nullable: true),
                    Learn_ILAcMonth9 = table.Column<int>(nullable: true),
                    Learn_ILCurrAcYr = table.Column<int>(nullable: true),
                    Learn_LargeEmployer = table.Column<int>(nullable: true),
                    Learn_LenEmp = table.Column<int>(nullable: true),
                    Learn_LenUnemp = table.Column<int>(nullable: true),
                    Learn_LrnAimRecords = table.Column<int>(nullable: true),
                    Learn_ModeAttPlanHrs = table.Column<int>(nullable: true),
                    Learn_NotionLev = table.Column<int>(nullable: true),
                    Learn_NotionLevV2 = table.Column<int>(nullable: true),
                    Learn_OLASS = table.Column<int>(nullable: true),
                    Learn_PrefMethContact = table.Column<int>(nullable: true),
                    Learn_PrimaryLLDD = table.Column<int>(nullable: true),
                    Learn_PriorEducationStatus = table.Column<int>(nullable: true),
                    Learn_UnempBenFDL = table.Column<int>(nullable: true),
                    Learn_UnempBenPrior = table.Column<int>(nullable: true),
                    Learn_Uplift1516EFA = table.Column<decimal>(type: "decimal(6, 5)", nullable: true),
                    Learn_Uplift1516SFA = table.Column<decimal>(type: "decimal(6, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DV_Learn__2770A727C4EB3FAE", x => new { x.UKPRN, x.LearnRefNumber });
                    table.ForeignKey(
                        name: "FK_DVLearner_DVglobal",
                        column: x => x.UKPRN,
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_DV_global",
                        principalColumn: "UKPRN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_VAL_Learner",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VAL_Lear__2770A727A3CB7E15", x => new { x.UKPRN, x.LearnRefNumber });
                    table.ForeignKey(
                        name: "VALLearner_VALglobal",
                        column: x => x.UKPRN,
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_VAL_global",
                        principalColumn: "UKPRN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_AEC_Learner",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    ULN = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AEC_Lear__2770A727DCEB32DE", x => new { x.UKPRN, x.LearnRefNumber });
                    table.ForeignKey(
                        name: "FK_AECLearner_AECglobal",
                        column: x => x.UKPRN,
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_AEC_global",
                        principalColumn: "UKPRN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AEC_Learner_ValidLearner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_ALB_Learner",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ALB_Lear__2770A727F41B74E3", x => new { x.UKPRN, x.LearnRefNumber });
                    table.ForeignKey(
                        name: "FK_ALBLearner_ALBglobal",
                        column: x => x.UKPRN,
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_ALB_global",
                        principalColumn: "UKPRN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ALB_Learner_ValidLearner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_ESF_Learner",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ESF_Lear__2770A7278C8AAC8F", x => new { x.UKPRN, x.LearnRefNumber });
                    table.ForeignKey(
                        name: "FK_ESFLearner_ESFglobal",
                        column: x => x.UKPRN,
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_ESF_global",
                        principalColumn: "UKPRN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ESF_Learner_ValidLearner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_FM25_Learner",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AcadMonthPayment = table.Column<int>(nullable: true),
                    AcadProg = table.Column<bool>(nullable: true),
                    ActualDaysILCurrYear = table.Column<int>(nullable: true),
                    AreaCostFact1618Hist = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    Block1DisadvUpliftNew = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    Block2DisadvElementsNew = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    ConditionOfFundingEnglish = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ConditionOfFundingMaths = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CoreAimSeqNumber = table.Column<int>(nullable: true),
                    FullTimeEquiv = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    FundLine = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    LearnerActEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    LearnerPlanEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    LearnerStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    NatRate = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    OnProgPayment = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    PlannedDaysILCurrYear = table.Column<int>(nullable: true),
                    ProgWeightHist = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    ProgWeightNew = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    PrvDisadvPropnHist = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    PrvHistLrgProgPropn = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    PrvRetentFactHist = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    PrvHistL3ProgMathEngProp = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    RateBand = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    RetentNew = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    StartFund = table.Column<bool>(nullable: true),
                    ThresholdDays = table.Column<int>(nullable: true),
                    TLevelStudent = table.Column<bool>(nullable: true),
                    L3MathsEnglish1Year = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    L3MathsEnglish2Year = table.Column<decimal>(type: "decimal(10, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FM25_Lea__2770A7274A393956", x => new { x.UKPRN, x.LearnRefNumber });
                    table.ForeignKey(
                        name: "FK_FM25Learner_FM25global",
                        column: x => x.UKPRN,
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_FM25_global",
                        principalColumn: "UKPRN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FM25_Learner_ValidLearner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_FM35_Learner",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FM35_Lea__2770A72792075518", x => new { x.UKPRN, x.LearnRefNumber });
                    table.ForeignKey(
                        name: "FK_FM35Learner_FM35global",
                        column: x => x.UKPRN,
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_FM35_global",
                        principalColumn: "UKPRN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FM35_Learner_ValidLearner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_TBL_Learner",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBL_Lear__2770A727E89D5C43", x => new { x.UKPRN, x.LearnRefNumber });
                    table.ForeignKey(
                        name: "FK_TBLLearner_TBLglobal",
                        column: x => x.UKPRN,
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_TBL_global",
                        principalColumn: "UKPRN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_Learner_ValidLearner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
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
                    EmpId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LearnerE__7200C4BEAFD631A4", x => new { x.UKPRN, x.LearnRefNumber, x.DateEmpStatApp });
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
                    table.PrimaryKey("PK__LearnerH__2770A7278C262906", x => new { x.UKPRN, x.LearnRefNumber });
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
                    OTJActHours = table.Column<int>(nullable: true),
                    LSDPostcode = table.Column<string>(unicode: false, maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learning__0C29443A65800720", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber });
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
                    table.PrimaryKey("PK__LLDDandH__CFA94E1CE8035EFB", x => new { x.UKPRN, x.LearnRefNumber, x.LLDDCat, x.LLDDandHealthProblem_ID });
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
                    table.PrimaryKey("PK__Provider__63E551EA11099190", x => new { x.UKPRN, x.LearnRefNumber, x.ProvSpecLearnMonOccur });
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
                name: "Rulebase_DV_LearningDelivery",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    LearnDel_AccToApp = table.Column<int>(nullable: true),
                    LearnDel_AccToAppEmpDate = table.Column<DateTime>(type: "date", nullable: true),
                    LearnDel_AccToAppEmpStat = table.Column<int>(nullable: true),
                    LearnDel_AchFullLevel2Pct = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    LearnDel_AchFullLevel3Pct = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    LearnDel_Achieved = table.Column<int>(nullable: true),
                    LearnDel_AchievedIY = table.Column<int>(nullable: true),
                    LearnDel_AcMonthYTD = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    LearnDel_ActDaysILAfterCurrAcYr = table.Column<int>(nullable: true),
                    LearnDel_ActDaysILCurrAcYr = table.Column<int>(nullable: true),
                    LearnDel_ActEndDateOnAfterJan1 = table.Column<int>(nullable: true),
                    LearnDel_ActEndDateOnAfterNov1 = table.Column<int>(nullable: true),
                    LearnDel_ActEndDateOnAfterOct1 = table.Column<int>(nullable: true),
                    LearnDel_ActiveIY = table.Column<int>(nullable: true),
                    LearnDel_ActiveJan = table.Column<int>(nullable: true),
                    LearnDel_ActiveNov = table.Column<int>(nullable: true),
                    LearnDel_ActiveOct = table.Column<int>(nullable: true),
                    LearnDel_ActTotalDaysIL = table.Column<int>(nullable: true),
                    LearnDel_AdvLoan = table.Column<int>(nullable: true),
                    LearnDel_AgeAimOrigStart = table.Column<int>(nullable: true),
                    LearnDel_AgeAtStart = table.Column<int>(nullable: true),
                    LearnDel_App = table.Column<int>(nullable: true),
                    LearnDel_App1618Fund = table.Column<int>(nullable: true),
                    LearnDel_App1925Fund = table.Column<int>(nullable: true),
                    LearnDel_AppAimType = table.Column<int>(nullable: true),
                    LearnDel_AppKnowl = table.Column<int>(nullable: true),
                    LearnDel_AppMainAim = table.Column<int>(nullable: true),
                    LearnDel_AppNonFund = table.Column<int>(nullable: true),
                    LearnDel_BasicSkills = table.Column<int>(nullable: true),
                    LearnDel_BasicSkillsParticipation = table.Column<int>(nullable: true),
                    LearnDel_BasicSkillsType = table.Column<int>(nullable: true),
                    LearnDel_CarryIn = table.Column<int>(nullable: true),
                    LearnDel_ClassRm = table.Column<int>(nullable: true),
                    LearnDel_CompAimApp = table.Column<int>(nullable: true),
                    LearnDel_CompAimProg = table.Column<int>(nullable: true),
                    LearnDel_Completed = table.Column<int>(nullable: true),
                    LearnDel_CompletedIY = table.Column<int>(nullable: true),
                    LearnDel_CompleteFullLevel2Pct = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    LearnDel_CompleteFullLevel3Pct = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    LearnDel_EFACoreAim = table.Column<int>(nullable: true),
                    LearnDel_Emp6MonthAimStart = table.Column<int>(nullable: true),
                    LearnDel_Emp6MonthProgStart = table.Column<int>(nullable: true),
                    LearnDel_EmpDateBeforeFDL = table.Column<DateTime>(type: "date", nullable: true),
                    LearnDel_EmpDatePriorFDL = table.Column<DateTime>(type: "date", nullable: true),
                    LearnDel_EmpID = table.Column<int>(nullable: true),
                    LearnDel_Employed = table.Column<int>(nullable: true),
                    LearnDel_EmpStatFDL = table.Column<int>(nullable: true),
                    LearnDel_EmpStatPrior = table.Column<int>(nullable: true),
                    LearnDel_EmpStatPriorFDL = table.Column<int>(nullable: true),
                    LearnDel_EnhanAppFund = table.Column<int>(nullable: true),
                    LearnDel_FullLevel2AchPct = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    LearnDel_FullLevel2ContPct = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    LearnDel_FullLevel3AchPct = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    LearnDel_FullLevel3ContPct = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    LearnDel_FuncSkills = table.Column<int>(nullable: true),
                    LearnDel_FundAgency = table.Column<int>(nullable: true),
                    LearnDel_FundingLineType = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    LearnDel_FundingSource = table.Column<int>(nullable: true),
                    LearnDel_FundPrvYr = table.Column<int>(nullable: true),
                    LearnDel_FundStart = table.Column<int>(nullable: true),
                    LearnDel_GCE = table.Column<int>(nullable: true),
                    LearnDel_GCSE = table.Column<int>(nullable: true),
                    LearnDel_ILAcMonth1 = table.Column<int>(nullable: true),
                    LearnDel_ILAcMonth10 = table.Column<int>(nullable: true),
                    LearnDel_ILAcMonth11 = table.Column<int>(nullable: true),
                    LearnDel_ILAcMonth12 = table.Column<int>(nullable: true),
                    LearnDel_ILAcMonth2 = table.Column<int>(nullable: true),
                    LearnDel_ILAcMonth3 = table.Column<int>(nullable: true),
                    LearnDel_ILAcMonth4 = table.Column<int>(nullable: true),
                    LearnDel_ILAcMonth5 = table.Column<int>(nullable: true),
                    LearnDel_ILAcMonth6 = table.Column<int>(nullable: true),
                    LearnDel_ILAcMonth7 = table.Column<int>(nullable: true),
                    LearnDel_ILAcMonth8 = table.Column<int>(nullable: true),
                    LearnDel_ILAcMonth9 = table.Column<int>(nullable: true),
                    LearnDel_ILCurrAcYr = table.Column<int>(nullable: true),
                    LearnDel_IYActEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    LearnDel_IYPlanEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    LearnDel_IYStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    LearnDel_KeySkills = table.Column<int>(nullable: true),
                    LearnDel_LargeEmpDiscountId = table.Column<int>(nullable: true),
                    LearnDel_LargeEmployer = table.Column<int>(nullable: true),
                    LearnDel_LastEmpDate = table.Column<DateTime>(type: "date", nullable: true),
                    LearnDel_LeaveMonth = table.Column<int>(nullable: true),
                    LearnDel_LenEmp = table.Column<int>(nullable: true),
                    LearnDel_LenUnemp = table.Column<int>(nullable: true),
                    LearnDel_LoanBursFund = table.Column<int>(nullable: true),
                    LearnDel_NotionLevel = table.Column<int>(nullable: true),
                    LearnDel_NotionLevelV2 = table.Column<int>(nullable: true),
                    LearnDel_NumHEDatasets = table.Column<int>(nullable: true),
                    LearnDel_OccupAim = table.Column<int>(nullable: true),
                    LearnDel_OLASS = table.Column<int>(nullable: true),
                    LearnDel_OLASSCom = table.Column<int>(nullable: true),
                    LearnDel_OLASSCus = table.Column<int>(nullable: true),
                    LearnDel_OrigStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    LearnDel_PlanDaysILAfterCurrAcYr = table.Column<int>(nullable: true),
                    LearnDel_PlanDaysILCurrAcYr = table.Column<int>(nullable: true),
                    LearnDel_PlanEndBeforeAug1 = table.Column<int>(nullable: true),
                    LearnDel_PlanEndOnAfterJan1 = table.Column<int>(nullable: true),
                    LearnDel_PlanEndOnAfterNov1 = table.Column<int>(nullable: true),
                    LearnDel_PlanEndOnAfterOct1 = table.Column<int>(nullable: true),
                    LearnDel_PlanTotalDaysIL = table.Column<int>(nullable: true),
                    LearnDel_PriorEducationStatus = table.Column<int>(nullable: true),
                    LearnDel_Prog = table.Column<int>(nullable: true),
                    LearnDel_ProgAimAch = table.Column<int>(nullable: true),
                    LearnDel_ProgAimApp = table.Column<int>(nullable: true),
                    LearnDel_ProgCompleted = table.Column<int>(nullable: true),
                    LearnDel_ProgCompletedIY = table.Column<int>(nullable: true),
                    LearnDel_ProgStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    LearnDel_QCF = table.Column<int>(nullable: true),
                    LearnDel_QCFCert = table.Column<int>(nullable: true),
                    LearnDel_QCFDipl = table.Column<int>(nullable: true),
                    LearnDel_QCFType = table.Column<int>(nullable: true),
                    LearnDel_RegAim = table.Column<int>(nullable: true),
                    LearnDel_SecSubAreaTier1 = table.Column<string>(unicode: false, maxLength: 3, nullable: true),
                    LearnDel_SecSubAreaTier2 = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    LearnDel_SFAApproved = table.Column<int>(nullable: true),
                    LearnDel_SourceFundEFA = table.Column<int>(nullable: true),
                    LearnDel_SourceFundSFA = table.Column<int>(nullable: true),
                    LearnDel_StartBeforeApr1 = table.Column<int>(nullable: true),
                    LearnDel_StartBeforeAug1 = table.Column<int>(nullable: true),
                    LearnDel_StartBeforeDec1 = table.Column<int>(nullable: true),
                    LearnDel_StartBeforeFeb1 = table.Column<int>(nullable: true),
                    LearnDel_StartBeforeJan1 = table.Column<int>(nullable: true),
                    LearnDel_StartBeforeJun1 = table.Column<int>(nullable: true),
                    LearnDel_StartBeforeMar1 = table.Column<int>(nullable: true),
                    LearnDel_StartBeforeMay1 = table.Column<int>(nullable: true),
                    LearnDel_StartBeforeNov1 = table.Column<int>(nullable: true),
                    LearnDel_StartBeforeOct1 = table.Column<int>(nullable: true),
                    LearnDel_StartBeforeSep1 = table.Column<int>(nullable: true),
                    LearnDel_StartIY = table.Column<int>(nullable: true),
                    LearnDel_StartJan1 = table.Column<int>(nullable: true),
                    LearnDel_StartMonth = table.Column<int>(nullable: true),
                    LearnDel_StartNov1 = table.Column<int>(nullable: true),
                    LearnDel_StartOct1 = table.Column<int>(nullable: true),
                    LearnDel_SuccRateStat = table.Column<int>(nullable: true),
                    LearnDel_TrainAimType = table.Column<int>(nullable: true),
                    LearnDel_TransferDiffProvider = table.Column<int>(nullable: true),
                    LearnDel_TransferDiffProviderGovStrat = table.Column<int>(nullable: true),
                    LearnDel_TransferProvider = table.Column<int>(nullable: true),
                    LearnDel_UfIProv = table.Column<int>(nullable: true),
                    LearnDel_UnempBenFDL = table.Column<int>(nullable: true),
                    LearnDel_UnempBenPrior = table.Column<int>(nullable: true),
                    LearnDel_Withdrawn = table.Column<int>(nullable: true),
                    LearnDel_WorkplaceLocPostcode = table.Column<string>(unicode: false, maxLength: 8, nullable: true),
                    Prog_AccToApp = table.Column<int>(nullable: true),
                    Prog_Achieved = table.Column<int>(nullable: true),
                    Prog_AchievedIY = table.Column<int>(nullable: true),
                    Prog_ActEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    Prog_ActiveIY = table.Column<int>(nullable: true),
                    Prog_AgeAtStart = table.Column<int>(nullable: true),
                    Prog_EarliestAim = table.Column<int>(nullable: true),
                    Prog_Employed = table.Column<int>(nullable: true),
                    Prog_FundPrvYr = table.Column<int>(nullable: true),
                    Prog_ILCurrAcYear = table.Column<int>(nullable: true),
                    Prog_LatestAim = table.Column<int>(nullable: true),
                    Prog_SourceFundEFA = table.Column<int>(nullable: true),
                    Prog_SourceFundSFA = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DV_Learn__0C29443A42561615", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber });
                    table.ForeignKey(
                        name: "FK_DVLearningDelivery_DVLearner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_DV_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_ALB_Learner_Period",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    Period = table.Column<int>(nullable: false),
                    ALBSeqNum = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ALB_Lear__7066D5F50E1FA010", x => new { x.UKPRN, x.LearnRefNumber, x.Period });
                    table.ForeignKey(
                        name: "FK_ALBLearnerPeriod_ALBLearner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_ALB_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_ALB_Learner_PeriodisedValues",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AttributeName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Period_1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_3 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_4 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_5 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_6 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_7 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_8 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_9 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_10 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_11 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_12 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ALB_Lear__08C04CF89C894027", x => new { x.UKPRN, x.LearnRefNumber, x.AttributeName });
                    table.ForeignKey(
                        name: "FK_ALBLearnerPeriodisedValues_ALBLearner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_ALB_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_FM25_FM35_Learner_Period",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    Period = table.Column<int>(nullable: false),
                    LnrOnProgPay = table.Column<decimal>(type: "decimal(15, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FM25_FM3__7066D5F58D55B771", x => new { x.UKPRN, x.LearnRefNumber, x.Period });
                    table.ForeignKey(
                        name: "FK_FM25FM35LearnerPeriod_FM25FM35global",
                        column: x => x.UKPRN,
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_FM25_FM35_global",
                        principalColumn: "UKPRN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FM25_FM35_Learner_Period_FM25_Learner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_FM25_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_FM25_FM35_Learner_PeriodisedValues",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AttributeName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Period_1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_3 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_4 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_5 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_6 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_7 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_8 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_9 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_10 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_11 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_12 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FM25_FM3__08C04CF854D339D5", x => new { x.UKPRN, x.LearnRefNumber, x.AttributeName });
                    table.ForeignKey(
                        name: "FK_FM25FM35LearnerPeriodisedValues_FM25FM35global",
                        column: x => x.UKPRN,
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_FM25_FM35_global",
                        principalColumn: "UKPRN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FM25_FM35_Learner_PeriodisedValues_FM25_Learner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_FM25_Learner",
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
                    table.PrimaryKey("PK__LearnerH__09F54B72E8EE3D02", x => new { x.UKPRN, x.LearnRefNumber, x.FINTYPE });
                    table.ForeignKey(
                        name: "FK_LearnerHEFinancialSupport_LearnerHE",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_LearnerHE",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_AEC_ApprenticeshipPriceEpisode",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    PriceEpisodeIdentifier = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    TNP4 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    TNP1 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    EpisodeStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    TNP2 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    TNP3 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisode1618FrameworkUpliftRemainingAmount = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisode1618FrameworkUpliftTotPrevEarnings = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisode1618FUBalValue = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisode1618FUMonthInstValue = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisode1618FUTotEarnings = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeUpperBandLimit = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodePlannedEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    PriceEpisodeActualEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    PriceEpisodeActualEndDateIncEPA = table.Column<DateTime>(type: "date", nullable: true),
                    PriceEpisodeTotalTNPPrice = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeUpperLimitAdjustment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodePlannedInstalments = table.Column<int>(nullable: true),
                    PriceEpisodeActualInstalments = table.Column<int>(nullable: true),
                    PriceEpisodeCompletionElement = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodePreviousEarnings = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeInstalmentValue = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeTotalEarnings = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeCompleted = table.Column<bool>(nullable: true),
                    PriceEpisodeRemainingTNPAmount = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeRemainingAmountWithinUpperLimit = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeCappedRemainingTNPAmount = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeExpectedTotalMonthlyValue = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeAimSeqNumber = table.Column<int>(nullable: false),
                    PriceEpisodeApplic1618FrameworkUpliftCompElement = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeFundLineType = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    EpisodeEffectiveTNPStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    PriceEpisodeFirstAdditionalPaymentThresholdDate = table.Column<DateTime>(type: "date", nullable: true),
                    PriceEpisodeSecondAdditionalPaymentThresholdDate = table.Column<DateTime>(type: "date", nullable: true),
                    PriceEpisodeContractType = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PriceEpisodePreviousEarningsSameProvider = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeTotalPMRs = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeCumulativePMRs = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeCompExemCode = table.Column<int>(nullable: true),
                    PriceEpisodeLearnerAdditionalPaymentThresholdDate = table.Column<DateTime>(type: "date", nullable: true),
                    PriceEpisodeRedStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    PriceEpisodeRedStatusCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AEC_Appr__BCF596CAE82E5CA2", x => new { x.UKPRN, x.LearnRefNumber, x.PriceEpisodeIdentifier });
                    table.ForeignKey(
                        name: "FK_AECApprenticeshipPriceEpisode_AECLearner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_AEC_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AEC_ApprenticeshipPriceEpisode_ValidLearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.PriceEpisodeAimSeqNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_AEC_LearningDelivery",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    ActualDaysIL = table.Column<int>(nullable: true),
                    ActualNumInstalm = table.Column<int>(nullable: true),
                    AdjStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    AgeAtProgStart = table.Column<int>(nullable: true),
                    AppAdjLearnStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    AppAdjLearnStartDateMatchPathway = table.Column<DateTime>(type: "date", nullable: true),
                    ApplicCompDate = table.Column<DateTime>(type: "date", nullable: true),
                    CombinedAdjProp = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Completed = table.Column<bool>(nullable: true),
                    FirstIncentiveThresholdDate = table.Column<DateTime>(type: "date", nullable: true),
                    FundStart = table.Column<bool>(nullable: true),
                    LDApplic1618FrameworkUpliftTotalActEarnings = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    LearnAimRef = table.Column<string>(unicode: false, maxLength: 8, nullable: true),
                    LearnDel1618AtStart = table.Column<bool>(nullable: true),
                    LearnDelAppAccDaysIL = table.Column<int>(nullable: true),
                    LearnDelApplicDisadvAmount = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    LearnDelApplicEmp1618Incentive = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    LearnDelApplicEmpDate = table.Column<DateTime>(type: "date", nullable: true),
                    LearnDelApplicProv1618FrameworkUplift = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    LearnDelApplicProv1618Incentive = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    LearnDelAppPrevAccDaysIL = table.Column<int>(nullable: true),
                    LearnDelDaysIL = table.Column<int>(nullable: true),
                    LearnDelDisadAmount = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    LearnDelEligDisadvPayment = table.Column<bool>(nullable: true),
                    LearnDelEmpIdFirstAdditionalPaymentThreshold = table.Column<int>(nullable: true),
                    LearnDelEmpIdSecondAdditionalPaymentThreshold = table.Column<int>(nullable: true),
                    LearnDelHistDaysThisApp = table.Column<int>(nullable: true),
                    LearnDelHistProgEarnings = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    LearnDelInitialFundLineType = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    LearnDelMathEng = table.Column<bool>(nullable: true),
                    MathEngAimValue = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    OutstandNumOnProgInstalm = table.Column<int>(nullable: true),
                    PlannedNumOnProgInstalm = table.Column<int>(nullable: true),
                    PlannedTotalDaysIL = table.Column<int>(nullable: true),
                    SecondIncentiveThresholdDate = table.Column<DateTime>(type: "date", nullable: true),
                    ThresholdDays = table.Column<int>(nullable: true),
                    LearnDelProgEarliestACT2Date = table.Column<DateTime>(type: "date", nullable: true),
                    LearnDelNonLevyProcured = table.Column<bool>(nullable: true),
                    LearnDelApplicCareLeaverIncentive = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    LearnDelHistDaysCareLeavers = table.Column<int>(nullable: true),
                    LearnDelAccDaysILCareLeavers = table.Column<int>(nullable: true),
                    LearnDelPrevAccDaysILCareLeavers = table.Column<int>(nullable: true),
                    LearnDelLearnerAddPayThresholdDate = table.Column<DateTime>(type: "date", nullable: true),
                    LearnDelRedCode = table.Column<int>(nullable: true),
                    LearnDelRedStartDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AEC_Lear__0C29443A7A5F5E02", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber });
                    table.ForeignKey(
                        name: "FK_AECLearningDelivery_AECLearner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_AEC_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AEC_LearningDelivery_ValidLearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_ALB_LearningDelivery",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    AreaCostFactAdj = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    WeightedRate = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PlannedNumOnProgInstalm = table.Column<int>(nullable: true),
                    FundStart = table.Column<bool>(nullable: true),
                    Achieved = table.Column<bool>(nullable: true),
                    ActualNumInstalm = table.Column<int>(nullable: true),
                    OutstndNumOnProgInstalm = table.Column<int>(nullable: true),
                    AreaCostInstalment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    AdvLoan = table.Column<bool>(nullable: true),
                    LoanBursAreaUplift = table.Column<bool>(nullable: true),
                    LoanBursSupp = table.Column<bool>(nullable: true),
                    FundLine = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LiabilityDate = table.Column<DateTime>(type: "date", nullable: true),
                    ApplicProgWeightFact = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    ApplicFactDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ALB_Lear__0C29443A44B4AC36", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber });
                    table.ForeignKey(
                        name: "FK_ALBLearningDelivery_ALBLearner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_ALB_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ALB_LearningDelivery_ValidLearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_ESF_LearningDelivery",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    Achieved = table.Column<bool>(nullable: true),
                    AddProgCostElig = table.Column<bool>(nullable: true),
                    AdjustedAreaCostFactor = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    AdjustedPremiumFactor = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    AdjustedStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    AimClassification = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    AimValue = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    ApplicWeightFundRate = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    EligibleProgressionOutcomeCode = table.Column<long>(nullable: true),
                    EligibleProgressionOutcomeType = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    EligibleProgressionOutomeStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    FundStart = table.Column<bool>(nullable: true),
                    LARSWeightedRate = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    LatestPossibleStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    LDESFEngagementStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    LearnDelLearnerEmpAtStart = table.Column<bool>(nullable: true),
                    PotentiallyEligibleForProgression = table.Column<bool>(nullable: true),
                    ProgressionEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    Restart = table.Column<bool>(nullable: true),
                    WeightedRateFromESOL = table.Column<decimal>(type: "decimal(10, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ESF_Lear__0C29443A14EAB3B2", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber });
                    table.ForeignKey(
                        name: "FK_ESFLearningDelivery_ESFLearner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_ESF_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ESF_LearningDelivery_ValidLearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_FM35_LearningDelivery",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    AchApplicDate = table.Column<DateTime>(type: "date", nullable: true),
                    Achieved = table.Column<bool>(nullable: true),
                    AchieveElement = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    AchievePayElig = table.Column<bool>(nullable: true),
                    AchievePayPctPreTrans = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    AchPayTransHeldBack = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    ActualDaysIL = table.Column<int>(nullable: true),
                    ActualNumInstalm = table.Column<int>(nullable: true),
                    ActualNumInstalmPreTrans = table.Column<int>(nullable: true),
                    ActualNumInstalmTrans = table.Column<int>(nullable: true),
                    AdjLearnStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    AdltLearnResp = table.Column<bool>(nullable: true),
                    AgeAimStart = table.Column<int>(nullable: true),
                    AimValue = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    AppAdjLearnStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    AppAgeFact = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    AppATAGTA = table.Column<bool>(nullable: true),
                    AppCompetency = table.Column<bool>(nullable: true),
                    AppFuncSkill = table.Column<bool>(nullable: true),
                    AppFuncSkill1618AdjFact = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    AppKnowl = table.Column<bool>(nullable: true),
                    AppLearnStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    ApplicEmpFactDate = table.Column<DateTime>(type: "date", nullable: true),
                    ApplicFactDate = table.Column<DateTime>(type: "date", nullable: true),
                    ApplicFundRateDate = table.Column<DateTime>(type: "date", nullable: true),
                    ApplicProgWeightFact = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    ApplicUnweightFundRate = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    ApplicWeightFundRate = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    AppNonFund = table.Column<bool>(nullable: true),
                    AreaCostFactAdj = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    BalInstalmPreTrans = table.Column<int>(nullable: true),
                    BaseValueUnweight = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    CapFactor = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    DisUpFactAdj = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    EmpOutcomePayElig = table.Column<bool>(nullable: true),
                    EmpOutcomePctHeldBackTrans = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    EmpOutcomePctPreTrans = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    EmpRespOth = table.Column<bool>(nullable: true),
                    ESOL = table.Column<bool>(nullable: true),
                    FullyFund = table.Column<bool>(nullable: true),
                    FundLine = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    FundStart = table.Column<bool>(nullable: true),
                    LargeEmployerID = table.Column<int>(nullable: true),
                    LargeEmployerFM35Fctr = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    LargeEmployerStatusDate = table.Column<DateTime>(type: "date", nullable: true),
                    LearnDelFundOrgCode = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LTRCUpliftFctr = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    NonGovCont = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    OLASSCustody = table.Column<bool>(nullable: true),
                    OnProgPayPctPreTrans = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    OutstndNumOnProgInstalm = table.Column<int>(nullable: true),
                    OutstndNumOnProgInstalmTrans = table.Column<int>(nullable: true),
                    PlannedNumOnProgInstalm = table.Column<int>(nullable: true),
                    PlannedNumOnProgInstalmTrans = table.Column<int>(nullable: true),
                    PlannedTotalDaysIL = table.Column<int>(nullable: true),
                    PlannedTotalDaysILPreTrans = table.Column<int>(nullable: true),
                    PropFundRemain = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    PropFundRemainAch = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    PrscHEAim = table.Column<bool>(nullable: true),
                    ReservedUpliftFactor1 = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    ReservedUpliftRate1 = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    Residential = table.Column<bool>(nullable: true),
                    Restart = table.Column<bool>(nullable: true),
                    SpecResUplift = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    StartPropTrans = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    ThresholdDays = table.Column<int>(nullable: true),
                    Traineeship = table.Column<bool>(nullable: true),
                    Trans = table.Column<bool>(nullable: true),
                    TrnAdjLearnStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    TrnWorkPlaceAim = table.Column<bool>(nullable: true),
                    TrnWorkPrepAim = table.Column<bool>(nullable: true),
                    UnWeightedRateFromESOL = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    UnweightedRateFromLARS = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    WeightedRateFromESOL = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    WeightedRateFromLARS = table.Column<decimal>(type: "decimal(10, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rulebase_FM35_LearningDelivery", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber });
                    table.ForeignKey(
                        name: "FK_FM35LearningDelivery_FM35Learner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_FM35_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FM35_LearningDelivery_ValidLearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_TBL_LearningDelivery",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    ProgStandardStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    FundLine = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    MathEngAimValue = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    PlannedNumOnProgInstalm = table.Column<int>(nullable: true),
                    LearnSuppFundCash = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    AdjProgStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    LearnSuppFund = table.Column<bool>(nullable: true),
                    AdjStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    MathEngOnProgPayment = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    InstPerPeriod = table.Column<int>(nullable: true),
                    SmallBusPayment = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    YoungAppSecondPayment = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    CoreGovContPayment = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    YoungAppEligible = table.Column<bool>(nullable: true),
                    SmallBusEligible = table.Column<bool>(nullable: true),
                    MathEngOnProgPct = table.Column<int>(nullable: true),
                    AgeStandardStart = table.Column<int>(nullable: true),
                    SmallBusThresholdDate = table.Column<DateTime>(type: "date", nullable: true),
                    YoungAppSecondThresholdDate = table.Column<DateTime>(type: "date", nullable: true),
                    EmpIdFirstDayStandard = table.Column<int>(nullable: true),
                    EmpIdFirstYoungAppDate = table.Column<int>(nullable: true),
                    EmpIdSecondYoungAppDate = table.Column<int>(nullable: true),
                    EmpIdSmallBusDate = table.Column<int>(nullable: true),
                    YoungAppFirstThresholdDate = table.Column<DateTime>(type: "date", nullable: true),
                    AchApplicDate = table.Column<DateTime>(type: "date", nullable: true),
                    AchEligible = table.Column<bool>(nullable: true),
                    Achieved = table.Column<bool>(nullable: true),
                    AchievementApplicVal = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    AchPayment = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    ActualNumInstalm = table.Column<int>(nullable: true),
                    CombinedAdjProp = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    EmpIdAchDate = table.Column<int>(nullable: true),
                    LearnDelDaysIL = table.Column<int>(nullable: true),
                    LearnDelStandardAccDaysIL = table.Column<int>(nullable: true),
                    LearnDelStandardPrevAccDaysIL = table.Column<int>(nullable: true),
                    LearnDelStandardTotalDaysIL = table.Column<int>(nullable: true),
                    ActualDaysIL = table.Column<int>(nullable: true),
                    MathEngBalPayment = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    MathEngBalPct = table.Column<long>(nullable: true),
                    MathEngLSFFundStart = table.Column<bool>(nullable: true),
                    PlannedTotalDaysIL = table.Column<int>(nullable: true),
                    MathEngLSFThresholdDays = table.Column<int>(nullable: true),
                    OutstandNumOnProgInstalm = table.Column<int>(nullable: true),
                    SmallBusApplicVal = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    SmallBusStatusFirstDayStandard = table.Column<int>(nullable: true),
                    SmallBusStatusThreshold = table.Column<int>(nullable: true),
                    YoungAppApplicVal = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    CoreGovContCapApplicVal = table.Column<long>(nullable: true),
                    CoreGovContUncapped = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    ApplicFundValDate = table.Column<DateTime>(type: "date", nullable: true),
                    YoungAppFirstPayment = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    YoungAppPayment = table.Column<decimal>(type: "decimal(15, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBL_Lear__0C29443A0EB25480", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber });
                    table.ForeignKey(
                        name: "FK_TBLLearningDelivery_TBLLearner",
                        columns: x => new { x.UKPRN, x.LearnRefNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_TBL_Learner",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_LearningDelivery_ValidLearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
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
                    table.PrimaryKey("PK__Learning__0C29443A32ADDE37", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber });
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
                    table.PrimaryKey("PK__Provider__9F5C508508BD8DA4", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber, x.ProvSpecDelMonOccur });
                    table.ForeignKey(
                        name: "FK_ProviderSpecDeliveryMonitoring_LearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Valid",
                        principalTable: "Valid_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_AEC_ApprenticeshipPriceEpisode_Period",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    PriceEpisodeIdentifier = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    Period = table.Column<int>(nullable: false),
                    PriceEpisodeApplic1618FrameworkUpliftBalancing = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeApplic1618FrameworkUpliftCompletionPayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeApplic1618FrameworkUpliftOnProgPayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeBalancePayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeBalanceValue = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeCompletionPayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeFirstDisadvantagePayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeFirstEmp1618Pay = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeFirstProv1618Pay = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeInstalmentsThisPeriod = table.Column<int>(nullable: true),
                    PriceEpisodeLevyNonPayInd = table.Column<int>(nullable: true),
                    PriceEpisodeLSFCash = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeOnProgPayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeProgFundIndMaxEmpCont = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeProgFundIndMinCoInvest = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeSecondDisadvantagePayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeSecondEmp1618Pay = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeSecondProv1618Pay = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeSFAContribPct = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeESFAContribPct = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeTotProgFunding = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    PriceEpisodeLearnerAdditionalPayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AEC_Appr__9984F1E76EEDD44E", x => new { x.UKPRN, x.LearnRefNumber, x.PriceEpisodeIdentifier, x.Period });
                    table.ForeignKey(
                        name: "FK_AECApprenticeshipPriceEpisodePeriod_AECApprenticeshipPriceEpisode",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.PriceEpisodeIdentifier },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_AEC_ApprenticeshipPriceEpisode",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "PriceEpisodeIdentifier" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_AEC_ApprenticeshipPriceEpisode_PeriodisedValues",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    PriceEpisodeIdentifier = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    AttributeName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Period_1 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_2 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_3 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_4 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_5 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_6 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_7 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_8 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_9 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_10 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_11 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_12 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AEC_Appr__4E0E98778DEB95A4", x => new { x.UKPRN, x.LearnRefNumber, x.PriceEpisodeIdentifier, x.AttributeName });
                    table.ForeignKey(
                        name: "FK_AECApprenticeshipPriceEpisodePeriodisedValues_AECApprenticeshipPriceEpisode",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.PriceEpisodeIdentifier },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_AEC_ApprenticeshipPriceEpisode",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "PriceEpisodeIdentifier" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_AEC_LearningDelivery_Period",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    DisadvFirstPayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    DisadvSecondPayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    FundLineType = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    InstPerPeriod = table.Column<int>(nullable: true),
                    LDApplic1618FrameworkUpliftBalancingPayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    LDApplic1618FrameworkUpliftCompletionPayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    LDApplic1618FrameworkUpliftOnProgPayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    LearnDelContType = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LearnDelFirstEmp1618Pay = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    LearnDelFirstProv1618Pay = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    LearnDelLevyNonPayInd = table.Column<int>(nullable: true),
                    LearnDelSecondEmp1618Pay = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    LearnDelSecondProv1618Pay = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    LearnDelSEMContWaiver = table.Column<bool>(nullable: true),
                    LearnDelSFAContribPct = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    LearnDelESFAContribPct = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    LearnSuppFund = table.Column<bool>(nullable: true),
                    LearnSuppFundCash = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    MathEngBalPayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    MathEngOnProgPayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    ProgrammeAimBalPayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    ProgrammeAimCompletionPayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    ProgrammeAimOnProgPayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    ProgrammeAimProgFundIndMaxEmpCont = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    ProgrammeAimProgFundIndMinCoInvest = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    ProgrammeAimTotProgFund = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    LearnDelLearnAddPayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AEC_Lear__295823179EF311E4", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber, x.Period });
                    table.ForeignKey(
                        name: "FK_AECLearningDeliveryPeriod_AECLearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_AEC_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_AEC_LearningDelivery_PeriodisedTextValues",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    AttributeName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Period_1 = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Period_2 = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Period_3 = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Period_4 = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Period_5 = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Period_6 = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Period_7 = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Period_8 = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Period_9 = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Period_10 = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Period_11 = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Period_12 = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AEC_Lear__FED24A8757B2D350", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber, x.AttributeName });
                    table.ForeignKey(
                        name: "FK_AECLearningDeliveryPeriodisedTextValues_AECLearningDeliveryPeriod",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_AEC_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_AEC_LearningDelivery_PeriodisedValues",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    AttributeName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Period_1 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_2 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_3 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_4 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_5 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_6 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_7 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_8 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_9 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_10 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_11 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    Period_12 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AEC_Lear__FED24A875A4DEB8C", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber, x.AttributeName });
                    table.ForeignKey(
                        name: "FK_AECLearningDeliveryPeriodisedValues_AECLearningDeliveryPeriod",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_AEC_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_ALB_LearningDelivery_Period",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    AreaUpliftOnProgPayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    AreaUpliftBalPayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    ALBCode = table.Column<int>(nullable: true),
                    ALBSupportPayment = table.Column<decimal>(type: "decimal(12, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ALB_Lear__29582317865EFC2E", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber, x.Period });
                    table.ForeignKey(
                        name: "FK_ALBLearningDeliveryPeriod_ALBLearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_ALB_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_ALB_LearningDelivery_PeriodisedValues",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    AttributeName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Period_1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_3 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_4 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_5 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_6 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_7 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_8 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_9 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_10 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_11 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_12 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ALB_Lear__FED24A87A7EF9603", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber, x.AttributeName });
                    table.ForeignKey(
                        name: "FK_ALBLearningDeliveryPeriodisedValues_ALBLearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_ALB_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_ESF_LearningDeliveryDeliverable",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    DeliverableCode = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    DeliverableUnitCost = table.Column<decimal>(type: "decimal(15, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ESF_Lear__C21F732A0F039CCC", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber, x.DeliverableCode });
                    table.ForeignKey(
                        name: "FK_ESFLearningDeliveryDeliverable_ESFLearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_ESF_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_ESF_LearningDeliveryDeliverable_Period",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    DeliverableCode = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    Period = table.Column<int>(nullable: false),
                    AchievementEarnings = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    AdditionalProgCostEarnings = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    DeliverableVolume = table.Column<long>(nullable: true),
                    ProgressionEarnings = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    ReportingVolume = table.Column<int>(nullable: true),
                    StartEarnings = table.Column<decimal>(type: "decimal(15, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ESF_Lear__10486558B088848A", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber, x.DeliverableCode, x.Period });
                    table.ForeignKey(
                        name: "FK_ESFLearningDeliveryDeliverablePeriod_ESFLearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_ESF_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_FM35_LearningDelivery_Period",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    AchievePayment = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    AchievePayPct = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    AchievePayPctTrans = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    BalancePayment = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    BalancePaymentUncapped = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    BalancePct = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    BalancePctTrans = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    EmpOutcomePay = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    EmpOutcomePct = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    EmpOutcomePctTrans = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    InstPerPeriod = table.Column<int>(nullable: true),
                    LearnSuppFund = table.Column<bool>(nullable: true),
                    LearnSuppFundCash = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    OnProgPayment = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    OnProgPaymentUncapped = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    OnProgPayPct = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    OnProgPayPctTrans = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    TransInstPerPeriod = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rulebase_FM35_LearningDelivery_Period", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber, x.Period });
                    table.ForeignKey(
                        name: "FK_FM35LearningDeliveryPeriod_FM35LearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_FM35_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_FM35_LearningDelivery_PeriodisedValues",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    AttributeName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Period_1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_3 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_4 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_5 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_6 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_7 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_8 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_9 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_10 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_11 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_12 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rulebase_FM35_LearningDelivery_PeriodisedValues", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber, x.AttributeName });
                    table.ForeignKey(
                        name: "FK_FM35LearningDeliveryPeriodisedValues_FM35LearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_FM35_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_TBL_LearningDelivery_Period",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    AchPayment = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    CoreGovContPayment = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    CoreGovContUncapped = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    InstPerPeriod = table.Column<int>(nullable: true),
                    LearnSuppFund = table.Column<bool>(nullable: true),
                    LearnSuppFundCash = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    MathEngBalPayment = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    MathEngBalPct = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    MathEngOnProgPayment = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    MathEngOnProgPct = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    SmallBusPayment = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    YoungAppFirstPayment = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    YoungAppPayment = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    YoungAppSecondPayment = table.Column<decimal>(type: "decimal(15, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBL_Lear__29582317486393F8", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber, x.Period });
                    table.ForeignKey(
                        name: "FK_TBLLearningDeliveryPeriod_TBLLearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_TBL_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_TBL_LearningDelivery_PeriodisedValues",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    AttributeName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Period_1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_3 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_4 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_5 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_6 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_7 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_8 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_9 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_10 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_11 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_12 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBL_Lear__FED24A874580EF4D", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber, x.AttributeName });
                    table.ForeignKey(
                        name: "FK_TBLLearningDeliveryPeriodisedValues_TBLLearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_TBL_LearningDelivery",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rulebase_ESF_LearningDeliveryDeliverable_PeriodisedValues",
                schema: "Rulebase",
                columns: table => new
                {
                    UKPRN = table.Column<int>(nullable: false),
                    LearnRefNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    AimSeqNumber = table.Column<int>(nullable: false),
                    DeliverableCode = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    AttributeName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Period_1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_3 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_4 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_5 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_6 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_7 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_8 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_9 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_10 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_11 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
                    Period_12 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ESF_Lear__1D30C3C17390F7A3", x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber, x.DeliverableCode, x.AttributeName });
                    table.ForeignKey(
                        name: "FK_ESFLearningDeliveryDeliverablePeriodisedValues_ESFLearningDelivery",
                        columns: x => new { x.UKPRN, x.LearnRefNumber, x.AimSeqNumber, x.DeliverableCode },
                        principalSchema: "Rulebase",
                        principalTable: "Rulebase_ESF_LearningDeliveryDeliverable",
                        principalColumns: new[] { "UKPRN", "LearnRefNumber", "AimSeqNumber", "DeliverableCode" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ValidationError",
                table: "dbo_ValidationError",
                column: "UKPRN");

            migrationBuilder.CreateIndex(
                name: "PK_dbo.FileDetails",
                table: "FileDetails",
                columns: new[] { "UKPRN", "Filename", "Success" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rulebase_AEC_ApprenticeshipPriceEpisode_UKPRN_LearnRefNumber_PriceEpisodeAimSeqNumber",
                schema: "Rulebase",
                table: "Rulebase_AEC_ApprenticeshipPriceEpisode",
                columns: new[] { "UKPRN", "LearnRefNumber", "PriceEpisodeAimSeqNumber" });

            migrationBuilder.CreateIndex(
                name: "ix_AEC_ApprenticeshipPriceEpisodePeriod",
                schema: "Rulebase",
                table: "Rulebase_AEC_ApprenticeshipPriceEpisode_Period",
                columns: new[] { "UKPRN", "LearnRefNumber", "PriceEpisodeIdentifier" });

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
                name: "dbo_ValidationError");

            migrationBuilder.DropTable(
                name: "FileDetails");

            migrationBuilder.DropTable(
                name: "ProcessingData");

            migrationBuilder.DropTable(
                name: "VersionInfo");

            migrationBuilder.DropTable(
                name: "Rulebase_AEC_ApprenticeshipPriceEpisode_Period",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_AEC_ApprenticeshipPriceEpisode_PeriodisedValues",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_AEC_HistoricEarningOutput",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_AEC_LearningDelivery_Period",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_AEC_LearningDelivery_PeriodisedTextValues",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_AEC_LearningDelivery_PeriodisedValues",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_ALB_Learner_Period",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_ALB_Learner_PeriodisedValues",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_ALB_LearningDelivery_Period",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_ALB_LearningDelivery_PeriodisedValues",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_DV_LearningDelivery",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_ESF_DPOutcome",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_ESF_LearningDeliveryDeliverable_Period",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_ESF_LearningDeliveryDeliverable_PeriodisedValues",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_ESFVAL_global",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_ESFVAL_ValidationError",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_FM25_FM35_Learner_Period",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_FM25_FM35_Learner_PeriodisedValues",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_FM35_LearningDelivery_Period",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_FM35_LearningDelivery_PeriodisedValues",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_TBL_LearningDelivery_Period",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_TBL_LearningDelivery_PeriodisedValues",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_VAL_Learner",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_VAL_LearningDelivery",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_VAL_ValidationError",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_VALDP_global",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_VALDP_ValidationError",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_VALFD_ValidationError",
                schema: "Rulebase");

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
                name: "Rulebase_AEC_ApprenticeshipPriceEpisode",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_AEC_LearningDelivery",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_ALB_LearningDelivery",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_DV_Learner",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_ESF_LearningDeliveryDeliverable",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_FM25_FM35_global",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_FM25_Learner",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_FM35_LearningDelivery",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_TBL_LearningDelivery",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_VAL_global",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Valid_LearnerDestinationAndProgression",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Valid_LearnerHE",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Rulebase_AEC_Learner",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_ALB_Learner",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_DV_global",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_ESF_LearningDelivery",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_FM25_global",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_FM35_Learner",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_TBL_Learner",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_AEC_global",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_ALB_global",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_ESF_Learner",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Valid_LearningDelivery",
                schema: "Valid");

            migrationBuilder.DropTable(
                name: "Rulebase_FM35_global",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_TBL_global",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Rulebase_ESF_global",
                schema: "Rulebase");

            migrationBuilder.DropTable(
                name: "Valid_Learner",
                schema: "Valid");
        }
    }
}
