using System.Collections.Generic;
using ESFA.DC.DatabaseTesting.Model;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.Database.Test
{
    public sealed class SchemaInvalidTests : IClassFixture<DatabaseConnectionFixture>
    {
        private readonly DatabaseConnectionFixture _fixture;

        public SchemaInvalidTests(DatabaseConnectionFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CheckColumnAppFinRecord()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("AppFinRecord_Id", 1, false),
                ExpectedColumn.CreateInt("UKPRN", 2, false),
                ExpectedColumn.CreateInt("LearningDelivery_Id", 3, true),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 4, false, 100),
                ExpectedColumn.CreateBigInt("AimSeqNumber", 5, false),
                ExpectedColumn.CreateVarChar("AFinType", 6, false, 100),
                ExpectedColumn.CreateBigInt("AFinCode", 7, true),
                ExpectedColumn.CreateDate("AFinDate", 8, true),
                ExpectedColumn.CreateBigInt("AFinAmount", 9, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "AppFinRecord", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnCollectionDetails()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("CollectionDetails_Id", 1, false),
                ExpectedColumn.CreateInt("UKPRN", 2, false),
                ExpectedColumn.CreateVarChar("Collection", 3, true, 3),
                ExpectedColumn.CreateVarChar("Year", 4, true, 4),
                ExpectedColumn.CreateDate("FilePreparationDate", 5, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "CollectionDetails", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnContactPreference()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("ContactPreference_Id", 1, false),
                ExpectedColumn.CreateInt("Learner_Id", 2, true),
                ExpectedColumn.CreateInt("UKPRN", 3, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 4, true, 100),
                ExpectedColumn.CreateVarChar("ContPrefType", 5, true, 100),
                ExpectedColumn.CreateBigInt("ContPrefCode", 6, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "ContactPreference", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnDPOutcome()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("DPOutcome_Id", 1, false),
                ExpectedColumn.CreateInt("UKPRN", 2, false),
                ExpectedColumn.CreateInt("LearnerDestinationandProgression_Id", 3, true),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 4, true, 100),
                ExpectedColumn.CreateVarChar("OutType", 5, true, 100),
                ExpectedColumn.CreateBigInt("OutCode", 6, true),
                ExpectedColumn.CreateDate("OutStartDate", 7, true),
                ExpectedColumn.CreateDate("OutEndDate", 8, true),
                ExpectedColumn.CreateDate("OutCollDate", 9, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "DPOutcome", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnEmploymentStatusMonitoring()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("EmploymentStatusMonitoring_Id", 1, false),
                ExpectedColumn.CreateInt("LearnerEmploymentStatus_Id", 2, true),
                ExpectedColumn.CreateInt("UKPRN", 3, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 4, true, 100),
                ExpectedColumn.CreateDate("DateEmpStatApp", 5, true),
                ExpectedColumn.CreateVarChar("ESMType", 6, true, 100),
                ExpectedColumn.CreateBigInt("ESMCode", 7, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "EmploymentStatusMonitoring", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearner()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("Learner_Id", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, true, 100),
                ExpectedColumn.CreateInt("UKPRN", 3, false),
                ExpectedColumn.CreateVarChar("PrevLearnRefNumber", 4, true, 1000),
                ExpectedColumn.CreateBigInt("PrevUKPRN", 5, true),
                ExpectedColumn.CreateBigInt("PMUKPRN", 6, true),
                ExpectedColumn.CreateBigInt("ULN", 7, true),
                ExpectedColumn.CreateVarChar("FamilyName", 8, true, 1000),
                ExpectedColumn.CreateVarChar("GivenNames", 9, true, 1000),
                ExpectedColumn.CreateDate("DateOfBirth", 10, true),
                ExpectedColumn.CreateBigInt("Ethnicity", 11, true),
                ExpectedColumn.CreateVarChar("Sex", 12, true, 1000),
                ExpectedColumn.CreateBigInt("LLDDHealthProb", 13, true),
                ExpectedColumn.CreateVarChar("NINumber", 14, true, 1000),
                ExpectedColumn.CreateBigInt("PriorAttain", 15, true),
                ExpectedColumn.CreateBigInt("Accom", 16, true),
                ExpectedColumn.CreateBigInt("ALSCost", 17, true),
                ExpectedColumn.CreateBigInt("PlanLearnHours", 18, true),
                ExpectedColumn.CreateBigInt("PlanEEPHours", 19, true),
                ExpectedColumn.CreateVarChar("MathGrade", 20, true, 1000),
                ExpectedColumn.CreateVarChar("EngGrade", 21, true, 1000),
                ExpectedColumn.CreateVarChar("PostcodePrior", 22, true, 1000),
                ExpectedColumn.CreateVarChar("Postcode", 23, true, 1000),
                ExpectedColumn.CreateVarChar("AddLine1", 24, true, 1000),
                ExpectedColumn.CreateVarChar("AddLine2", 25, true, 1000),
                ExpectedColumn.CreateVarChar("AddLine3", 26, true, 1000),
                ExpectedColumn.CreateVarChar("AddLine4", 27, true, 1000),
                ExpectedColumn.CreateVarChar("TelNo", 28, true, 1000),
                ExpectedColumn.CreateVarChar("Email", 29, true, 1000),
                ExpectedColumn.CreateVarChar("CampId", 30, true, 1000),
                ExpectedColumn.CreateBigInt("OTJHours", 31, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "Learner", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearnerDestinationandProgression()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("LearnerDestinationandProgression_Id", 1, false),
                ExpectedColumn.CreateInt("UKPRN", 2, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 3, true, 100),
                ExpectedColumn.CreateBigInt("ULN", 4, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "LearnerDestinationandProgression", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearnerEmploymentStatus()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("LearnerEmploymentStatus_Id", 1, false),
                ExpectedColumn.CreateInt("Learner_Id", 2, true),
                ExpectedColumn.CreateInt("UKPRN", 3, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 4, true, 100),
                ExpectedColumn.CreateBigInt("EmpStat", 5, true),
                ExpectedColumn.CreateDate("DateEmpStatApp", 6, true),
                ExpectedColumn.CreateBigInt("EmpId", 7, true),
                ExpectedColumn.CreateVarChar("AgreeId", 8, true, 100)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "LearnerEmploymentStatus", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearnerFAM()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("LearnerFAM_Id", 1, false),
                ExpectedColumn.CreateInt("Learner_Id", 2, true),
                ExpectedColumn.CreateInt("UKPRN", 3, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 4, true, 100),
                ExpectedColumn.CreateVarChar("LearnFAMType", 5, true, 1000),
                ExpectedColumn.CreateBigInt("LearnFAMCode", 6, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "LearnerFAM", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearnerHE()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("LearnerHE_Id", 1, false),
                ExpectedColumn.CreateInt("Learner_Id", 2, true),
                ExpectedColumn.CreateInt("UKPRN", 3, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 4, true, 100),
                ExpectedColumn.CreateVarChar("UCASPERID", 5, true, 1000),
                ExpectedColumn.CreateBigInt("TTACCOM", 6, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "LearnerHE", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearnerLearningDelivery()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("LearningDelivery_Id", 1, false),
                ExpectedColumn.CreateInt("Learner_Id", 2, true),
                ExpectedColumn.CreateInt("UKPRN", 3, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 4, true, 100),
                ExpectedColumn.CreateVarChar("LearnAimRef", 5, true, 1000),
                ExpectedColumn.CreateBigInt("AimType", 6, true),
                ExpectedColumn.CreateBigInt("AimSeqNumber", 7, true),
                ExpectedColumn.CreateDate("LearnStartDate", 8, true),
                ExpectedColumn.CreateDate("OrigLearnStartDate", 9, true),
                ExpectedColumn.CreateDate("LearnPlanEndDate", 10, true),
                ExpectedColumn.CreateBigInt("FundModel", 11, true),
                ExpectedColumn.CreateBigInt("ProgType", 12, true),
                ExpectedColumn.CreateBigInt("FworkCode", 13, true),
                ExpectedColumn.CreateBigInt("PwayCode", 14, true),
                ExpectedColumn.CreateBigInt("StdCode", 15, true),
                ExpectedColumn.CreateBigInt("PartnerUKPRN", 16, true),
                ExpectedColumn.CreateVarChar("DelLocPostCode", 17, true, 1000),
                ExpectedColumn.CreateBigInt("AddHours", 18, true),
                ExpectedColumn.CreateBigInt("PriorLearnFundAdj", 19, true),
                ExpectedColumn.CreateBigInt("OtherFundAdj", 20, true),
                ExpectedColumn.CreateVarChar("ConRefNumber", 21, true, 1000),
                ExpectedColumn.CreateVarChar("EPAOrgID", 22, true, 1000),
                ExpectedColumn.CreateBigInt("EmpOutcome", 23, true),
                ExpectedColumn.CreateBigInt("CompStatus", 24, true),
                ExpectedColumn.CreateDate("LearnActEndDate", 25, true),
                ExpectedColumn.CreateBigInt("WithdrawReason", 26, true),
                ExpectedColumn.CreateBigInt("Outcome", 27, true),
                ExpectedColumn.CreateDate("AchDate", 28, true),
                ExpectedColumn.CreateVarChar("OutGrade", 29, true, 1000),
                ExpectedColumn.CreateVarChar("SWSupAimId", 30, true, 1000)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "LearningDelivery", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearningDeliveryFAM()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("LearningDeliveryFAM_Id", 1, false),
                ExpectedColumn.CreateInt("LearningDelivery_Id", 2, true),
                ExpectedColumn.CreateInt("UKPRN", 3, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 4, true, 100),
                ExpectedColumn.CreateBigInt("AimSeqNumber", 5, true),
                ExpectedColumn.CreateVarChar("LearnDelFAMType", 6, true, 100),
                ExpectedColumn.CreateVarChar("LearnDelFAMCode", 7, true, 1000),
                ExpectedColumn.CreateDate("LearnDelFAMDateFrom", 8, true),
                ExpectedColumn.CreateDate("LearnDelFAMDateTo", 9, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "LearningDeliveryFAM", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearningDeliveryHE()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("LearningDeliveryHE_Id", 1, false),
                ExpectedColumn.CreateInt("UKPRN", 2, false),
                ExpectedColumn.CreateInt("LearningDelivery_Id", 3, true),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 4, true, 100),
                ExpectedColumn.CreateBigInt("AimSeqNumber", 5, true),
                ExpectedColumn.CreateVarChar("NUMHUS", 6, true, 1000),
                ExpectedColumn.CreateVarChar("SSN", 7, true, 1000),
                ExpectedColumn.CreateVarChar("QUALENT3", 8, true, 1000),
                ExpectedColumn.CreateBigInt("SOC2000", 9, true),
                ExpectedColumn.CreateBigInt("SEC", 10, true),
                ExpectedColumn.CreateVarChar("UCASAPPID", 11, true, 1000),
                ExpectedColumn.CreateBigInt("TYPEYR", 12, true),
                ExpectedColumn.CreateBigInt("MODESTUD", 13, true),
                ExpectedColumn.CreateBigInt("FUNDLEV", 14, true),
                ExpectedColumn.CreateBigInt("FUNDCOMP", 15, true),
                new ExpectedColumn("STULOAD", "float", true, 16, numericPrecision: 4, numericScale: 1),
                ExpectedColumn.CreateBigInt("YEARSTU", 17, true),
                ExpectedColumn.CreateBigInt("MSTUFEE", 18, true),
                new ExpectedColumn("PCOLAB", "float", true, 19, numericPrecision: 4, numericScale: 1),
                new ExpectedColumn("PCFLDCS", "float", true, 20, numericPrecision: 4, numericScale: 1),
                new ExpectedColumn("PCSLDCS", "float", true, 21, numericPrecision: 4, numericScale: 1),
                new ExpectedColumn("PCTLDCS", "float", true, 22, numericPrecision: 4, numericScale: 1),
                ExpectedColumn.CreateBigInt("SPECFEE", 23, true),
                ExpectedColumn.CreateBigInt("NETFEE", 24, true),
                ExpectedColumn.CreateBigInt("GROSSFEE", 25, true),
                ExpectedColumn.CreateVarChar("DOMICILE", 26, true, 1000),
                ExpectedColumn.CreateBigInt("ELQ", 27, true),
                ExpectedColumn.CreateVarChar("HEPostCode", 28, true, 1000)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "LearningDeliveryHE", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearnerHEFinancialSupport()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("LearnerHEFinancialSupport_Id", 1, false),
                ExpectedColumn.CreateInt("LearnerHE_Id", 2, true),
                ExpectedColumn.CreateInt("UKPRN", 3, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 4, true, 100),
                ExpectedColumn.CreateBigInt("FINTYPE", 5, true),
                ExpectedColumn.CreateBigInt("FINAMOUNT", 6, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "LearnerHEFinancialSupport", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearningDelivery()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("LearningDelivery_Id", 1, false),
                ExpectedColumn.CreateInt("Learner_Id", 2, true),
                ExpectedColumn.CreateInt("UKPRN", 3, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 4, true, 100),
                ExpectedColumn.CreateVarChar("LearnAimRef", 5, true, 1000),
                ExpectedColumn.CreateBigInt("AimType", 6, true),
                ExpectedColumn.CreateBigInt("AimSeqNumber", 7, true),
                ExpectedColumn.CreateDate("LearnStartDate", 8, true),
                ExpectedColumn.CreateDate("OrigLearnStartDate", 9, true),
                ExpectedColumn.CreateDate("LearnPlanEndDate", 10, true),
                ExpectedColumn.CreateBigInt("FundModel", 11, true),
                ExpectedColumn.CreateBigInt("ProgType", 12, true),
                ExpectedColumn.CreateBigInt("FworkCode", 13, true),
                ExpectedColumn.CreateBigInt("PwayCode", 14, true),
                ExpectedColumn.CreateBigInt("StdCode", 15, true),
                ExpectedColumn.CreateBigInt("PartnerUKPRN", 16, true),
                ExpectedColumn.CreateVarChar("DelLocPostCode", 17, true, 1000),
                ExpectedColumn.CreateBigInt("AddHours", 18, true),
                ExpectedColumn.CreateBigInt("PriorLearnFundAdj", 19, true),
                ExpectedColumn.CreateBigInt("OtherFundAdj", 20, true),
                ExpectedColumn.CreateVarChar("ConRefNumber", 21, true, 1000),
                ExpectedColumn.CreateVarChar("EPAOrgID", 22, true, 1000),
                ExpectedColumn.CreateBigInt("EmpOutcome", 23, true),
                ExpectedColumn.CreateBigInt("CompStatus", 24, true),
                ExpectedColumn.CreateDate("LearnActEndDate", 25, true),
                ExpectedColumn.CreateBigInt("WithdrawReason", 26, true),
                ExpectedColumn.CreateBigInt("Outcome", 27, true),
                ExpectedColumn.CreateDate("AchDate", 28, true),
                ExpectedColumn.CreateVarChar("OutGrade", 29, true, 1000),
                ExpectedColumn.CreateVarChar("SWSupAimId", 30, true, 1000)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "LearningDelivery", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearningDeliveryWorkPlacement()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("LearningDeliveryWorkPlacement_Id", 1, false),
                ExpectedColumn.CreateInt("LearningDelivery_Id", 2, true),
                ExpectedColumn.CreateInt("UKPRN", 3, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 4, true, 100),
                ExpectedColumn.CreateBigInt("AimSeqNumber", 5, true),
                ExpectedColumn.CreateDate("WorkPlaceStartDate", 6, true),
                ExpectedColumn.CreateDate("WorkPlaceEndDate", 7, true),
                ExpectedColumn.CreateBigInt("WorkPlaceHours", 8, true),
                ExpectedColumn.CreateBigInt("WorkPlaceMode", 9, true),
                ExpectedColumn.CreateBigInt("WorkPlaceEmpId", 10, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "LearningDeliveryWorkPlacement", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearningProvider()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("LearningProvider_Id", 1, false),
                ExpectedColumn.CreateInt("UKPRN", 2, false)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "LearningProvider", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLLDDandHealthProblem()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("LLDDandHealthProblem_Id", 1, false),
                ExpectedColumn.CreateInt("Learner_Id", 2, true),
                ExpectedColumn.CreateInt("UKPRN", 3, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 4, true, 100),
                ExpectedColumn.CreateBigInt("LLDDCat", 5, true),
                ExpectedColumn.CreateBigInt("PrimaryLLDD", 6, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "LLDDandHealthProblem", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnProviderSpecDeliveryMonitoring()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("ProviderSpecDeliveryMonitoring_Id", 1, false),
                ExpectedColumn.CreateInt("UKPRN", 2, false),
                ExpectedColumn.CreateInt("LearningDelivery_Id", 3, true),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 4, true, 100),
                ExpectedColumn.CreateBigInt("AimSeqNumber", 5, true),
                ExpectedColumn.CreateVarChar("ProvSpecDelMonOccur", 6, true, 100),
                ExpectedColumn.CreateVarChar("ProvSpecDelMon", 7, true, 1000)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "ProviderSpecDeliveryMonitoring", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnProviderSpecLearnerMonitoring()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("ProviderSpecLearnerMonitoring_Id", 1, false),
                ExpectedColumn.CreateInt("Learner_Id", 2, true),
                ExpectedColumn.CreateInt("UKPRN", 3, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 4, true, 100),
                ExpectedColumn.CreateVarChar("ProvSpecLearnMonOccur", 5, true, 100),
                ExpectedColumn.CreateVarChar("ProvSpecLearnMon", 6, true, 1000)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "ProviderSpecLearnerMonitoring", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnSource()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("Source_Id", 1, false),
                ExpectedColumn.CreateVarChar("ProtectiveMarking", 2, true, 30),
                ExpectedColumn.CreateInt("UKPRN", 3, false),
                ExpectedColumn.CreateVarChar("SoftwareSupplier", 4, true, 40),
                ExpectedColumn.CreateVarChar("SoftwarePackage", 5, true, 30),
                ExpectedColumn.CreateVarChar("Release", 6, true, 20),
                ExpectedColumn.CreateVarChar("SerialNo", 7, true, 2),
                ExpectedColumn.CreateDateTime("DateTime", 8, true),
                ExpectedColumn.CreateVarChar("ReferenceData", 9, true, 100),
                ExpectedColumn.CreateVarChar("ComponentSetVersion", 10, true, 20)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "Source", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnSourceFile()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("SourceFile_Id", 1, false),
                ExpectedColumn.CreateInt("UKPRN", 2, false),
                ExpectedColumn.CreateVarChar("SourceFileName", 3, true, 50),
                ExpectedColumn.CreateDate("FilePreparationDate", 4, true),
                ExpectedColumn.CreateVarChar("SoftwareSupplier", 5, true, 40),
                ExpectedColumn.CreateVarChar("SoftwarePackage", 6, true, 30),
                ExpectedColumn.CreateVarChar("Release", 7, true, 20),
                ExpectedColumn.CreateVarChar("SerialNo", 8, true, 2),
                ExpectedColumn.CreateDateTime("DateTime", 9, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Invalid", "SourceFile", expectedColumns, true);
        }
    }
}
