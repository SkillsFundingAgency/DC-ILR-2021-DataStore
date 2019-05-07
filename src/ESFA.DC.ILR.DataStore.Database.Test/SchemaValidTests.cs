using System.Collections.Generic;
using ESFA.DC.DatabaseTesting.Model;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.Database.Test
{
    public sealed class SchemaValidTests : IClassFixture<DatabaseConnectionFixture>
    {
        private readonly DatabaseConnectionFixture _fixture;

        public SchemaValidTests(DatabaseConnectionFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CheckColumnAppFinRecord()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", -1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateVarChar("AFinType", 4, false),
                ExpectedColumn.CreateInt("AFinCode", 5, false),
                ExpectedColumn.CreateDate("AFinDate", 6, false),
                ExpectedColumn.CreateInt("AFinAmount", 7, false)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "AppFinRecord", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnCollectionDetails()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("Collection", 2, false, 3),
                ExpectedColumn.CreateVarChar("Year", 3, false, 4),
                ExpectedColumn.CreateDate("FilePreparationDate", 4, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "CollectionDetails", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnContactPreference()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateVarChar("ContPrefType", 3, false, 3),
                ExpectedColumn.CreateInt("ContPrefCode", 4, false)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "ContactPreference", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnDPOutcome()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateVarChar("OutType", 3, false, 3),
                ExpectedColumn.CreateInt("OutCode", 4, false),
                ExpectedColumn.CreateDate("OutStartDate", 5, false),
                ExpectedColumn.CreateDate("OutEndDate", 6, true),
                ExpectedColumn.CreateDate("OutCollDate", 7, false)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "DPOutcome", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnEmploymentStatusMonitoring()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateDate("DateEmpStatApp", 3, false),
                ExpectedColumn.CreateVarChar("ESMType", 4, false, 3),
                ExpectedColumn.CreateInt("ESMCode", 5, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "EmploymentStatusMonitoring", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearner()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateVarChar("PrevLearnRefNumber", 3, true, 12),
                ExpectedColumn.CreateInt("PrevUKPRN", 4, true),
                ExpectedColumn.CreateInt("PMUKPRN", 5, true),
                ExpectedColumn.CreateBigInt("ULN", 6, false),
                ExpectedColumn.CreateVarChar("FamilyName", 7, true, 100),
                ExpectedColumn.CreateVarChar("GivenNames", 8, true, 100),
                ExpectedColumn.CreateDate("DateOfBirth", 9, true),
                ExpectedColumn.CreateInt("Ethnicity", 10, false),
                ExpectedColumn.CreateVarChar("Sex", 11, false, 1),
                ExpectedColumn.CreateInt("LLDDHealthProb", 12, false),
                ExpectedColumn.CreateVarChar("NINumber", 13, true, 9),
                ExpectedColumn.CreateInt("PriorAttain", 14, true),
                ExpectedColumn.CreateInt("Accom", 15, true),
                ExpectedColumn.CreateInt("ALSCost", 16, true),
                ExpectedColumn.CreateInt("PlanLearnHours", 17, true),
                ExpectedColumn.CreateInt("PlanEEPHours", 18, true),
                ExpectedColumn.CreateVarChar("MathGrade", 19, true, 4),
                ExpectedColumn.CreateVarChar("EngGrade", 20, true, 4),
                ExpectedColumn.CreateVarChar("PostcodePrior", 21, false, 8),
                ExpectedColumn.CreateVarChar("Postcode", 22, false, 8),
                ExpectedColumn.CreateVarChar("AddLine1", 23, true, 50),
                ExpectedColumn.CreateVarChar("AddLine2", 24, true, 50),
                ExpectedColumn.CreateVarChar("AddLine3", 25, true, 50),
                ExpectedColumn.CreateVarChar("AddLine4", 26, true, 50),
                ExpectedColumn.CreateVarChar("TelNo", 27, true, 18),
                ExpectedColumn.CreateVarChar("Email", 28, true, 100),
                ExpectedColumn.CreateVarChar("CampId", 29, true, 8),
                ExpectedColumn.CreateBigInt("OTJHours", 30, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "Learner", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearnerDestinationandProgression()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateBigInt("ULN", 3, false)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "LearnerDestinationandProgression", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearnerEmploymentStatus()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("EmpStat", 3, false),
                ExpectedColumn.CreateDate("DateEmpStatApp", 4, false),
                ExpectedColumn.CreateInt("EmpId", 5, true),
                ExpectedColumn.CreateVarChar("AgreeId", 6, true, 6)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "LearnerEmploymentStatus", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearnerFAM()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateVarChar("LearnFAMType", 3, false, 3),
                ExpectedColumn.CreateInt("LearnFAMCode", 4, false)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "LearnerFAM", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearnerHE()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateVarChar("UCASPERID", 3, true, 10),
                ExpectedColumn.CreateInt("TTACCOM", 4, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "LearnerHE", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearnerLearningDelivery()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateVarChar("LearnAimRef", 3, false, 8),
                ExpectedColumn.CreateInt("AimType", 4, false),
                ExpectedColumn.CreateInt("AimSeqNumber", 5, false),
                ExpectedColumn.CreateDate("LearnStartDate", 6, false),
                ExpectedColumn.CreateDate("OrigLearnStartDate", 7, true),
                ExpectedColumn.CreateDate("LearnPlanEndDate", 8, false),
                ExpectedColumn.CreateInt("FundModel", 9, false),
                ExpectedColumn.CreateInt("ProgType", 10, true),
                ExpectedColumn.CreateInt("FworkCode", 11, true),
                ExpectedColumn.CreateInt("PwayCode", 12, true),
                ExpectedColumn.CreateInt("StdCode", 13, true),
                ExpectedColumn.CreateInt("PartnerUKPRN", 14, true),
                ExpectedColumn.CreateVarChar("DelLocPostCode", 15, true, 8),
                ExpectedColumn.CreateInt("AddHours", 16, true),
                ExpectedColumn.CreateInt("PriorLearnFundAdj", 17, true),
                ExpectedColumn.CreateInt("OtherFundAdj", 18, true),
                ExpectedColumn.CreateVarChar("ConRefNumber", 19, true, 20),
                ExpectedColumn.CreateVarChar("EPAOrgID", 20, true, 7),
                ExpectedColumn.CreateInt("EmpOutcome", 21, true),
                ExpectedColumn.CreateInt("CompStatus", 22, false),
                ExpectedColumn.CreateDate("LearnActEndDate", 23, true),
                ExpectedColumn.CreateInt("WithdrawReason", 24, true),
                ExpectedColumn.CreateInt("Outcome", 25, true),
                ExpectedColumn.CreateDate("AchDate", 26, true),
                ExpectedColumn.CreateVarChar("OutGrade", 27, true, 6),
                ExpectedColumn.CreateVarChar("SWSupAimId", 28, true, 36)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "LearningDelivery", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearningDeliveryFAM()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("LearningDeliveryFAM_Id", 1, false),
                ExpectedColumn.CreateInt("UKPRN", 2, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 3, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 4, false),
                ExpectedColumn.CreateVarChar("LearnDelFAMType", 5, false, 3),
                ExpectedColumn.CreateVarChar("LearnDelFAMCode", 6, false, 5),
                ExpectedColumn.CreateDate("LearnDelFAMDateFrom", 7, true),
                ExpectedColumn.CreateDate("LearnDelFAMDateTo", 8, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "LearningDeliveryFAM", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearningDeliveryHE()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateVarChar("NUMHUS", 4, true, 20),
                ExpectedColumn.CreateVarChar("SSN", 5, true, 13),
                ExpectedColumn.CreateVarChar("QUALENT3", 6, true, 3),
                ExpectedColumn.CreateInt("SOC2000", 7, true),
                ExpectedColumn.CreateInt("SEC", 8, true),
                ExpectedColumn.CreateVarChar("UCASAPPID", 9, true, 9),
                ExpectedColumn.CreateInt("TYPEYR", 10, false),
                ExpectedColumn.CreateInt("MODESTUD", 11, false),
                ExpectedColumn.CreateInt("FUNDLEV", 12, false),
                ExpectedColumn.CreateInt("FUNDCOMP", 13, false),
                ExpectedColumn.CreateDecimal("STULOAD", 14, true, 4, 1),
                ExpectedColumn.CreateInt("YEARSTU", 15, false),
                ExpectedColumn.CreateInt("MSTUFEE", 16, false),
                ExpectedColumn.CreateDecimal("PCOLAB", 17, true, 4, 1),
                ExpectedColumn.CreateDecimal("PCFLDCS", 18, true, 4, 1),
                ExpectedColumn.CreateDecimal("PCSLDCS", 19, true, 4, 1),
                ExpectedColumn.CreateDecimal("PCTLDCS", 20, true, 4, 1),
                ExpectedColumn.CreateInt("SPECFEE", 21, false),
                ExpectedColumn.CreateInt("NETFEE", 22, true),
                ExpectedColumn.CreateInt("GROSSFEE", 23, true),
                ExpectedColumn.CreateVarChar("DOMICILE", 24, true, 2),
                ExpectedColumn.CreateInt("ELQ", 25, true),
                ExpectedColumn.CreateVarChar("HEPostCode", 26, true, 8)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "LearningDeliveryHE", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearnerHEFinancialSupport()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("FINTYPE", 3, false),
                ExpectedColumn.CreateInt("FINAMOUNT", 4, false)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "LearnerHEFinancialSupport", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearningDelivery()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateVarChar("LearnAimRef", 3, false, 8),
                ExpectedColumn.CreateInt("AimType", 4, false),
                ExpectedColumn.CreateInt("AimSeqNumber", 5, false),
                ExpectedColumn.CreateDate("LearnStartDate", 6, false),
                ExpectedColumn.CreateDate("OrigLearnStartDate", 7, true),
                ExpectedColumn.CreateDate("LearnPlanEndDate", 8, false),
                ExpectedColumn.CreateInt("FundModel", 9, false),
                ExpectedColumn.CreateInt("ProgType", 10, true),
                ExpectedColumn.CreateInt("FworkCode", 11, true),
                ExpectedColumn.CreateInt("PwayCode", 12, true),
                ExpectedColumn.CreateInt("StdCode", 13, true),
                ExpectedColumn.CreateInt("PartnerUKPRN", 14, true),
                ExpectedColumn.CreateVarChar("DelLocPostCode", 15, true, 8),
                ExpectedColumn.CreateInt("AddHours", 16, true),
                ExpectedColumn.CreateInt("PriorLearnFundAdj", 17, true),
                ExpectedColumn.CreateInt("OtherFundAdj", 18, true),
                ExpectedColumn.CreateVarChar("ConRefNumber", 19, true, 20),
                ExpectedColumn.CreateVarChar("EPAOrgID", 20, true, 7),
                ExpectedColumn.CreateInt("EmpOutcome", 21, true),
                ExpectedColumn.CreateInt("CompStatus", 22, false),
                ExpectedColumn.CreateDate("LearnActEndDate", 23, true),
                ExpectedColumn.CreateInt("WithdrawReason", 24, true),
                ExpectedColumn.CreateInt("Outcome", 25, true),
                ExpectedColumn.CreateDate("AchDate", 26, true),
                ExpectedColumn.CreateVarChar("OutGrade", 27, true, 6),
                ExpectedColumn.CreateVarChar("SWSupAimId", 28, true, 36)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "LearningDelivery", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearningDeliveryWorkPlacement()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateDate("WorkPlaceStartDate", 4, false),
                ExpectedColumn.CreateDate("WorkPlaceEndDate", 5, true),
                ExpectedColumn.CreateInt("WorkPlaceHours", 6, true),
                ExpectedColumn.CreateInt("WorkPlaceMode", 7, false),
                ExpectedColumn.CreateInt("WorkPlaceEmpId", 8, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "LearningDeliveryWorkPlacement", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLearningProvider()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "LearningProvider", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnLLDDandHealthProblem()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("LLDDCat", 3, false),
                ExpectedColumn.CreateInt("PrimaryLLDD", 4, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "LLDDandHealthProblem", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnProviderSpecDeliveryMonitoring()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateVarChar("ProvSpecDelMonOccur", 4, false, 1),
                ExpectedColumn.CreateVarChar("ProvSpecDelMon", 5, false, 20)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "ProviderSpecDeliveryMonitoring", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnProviderSpecLearnerMonitoring()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateVarChar("ProvSpecLearnMonOccur", 3, false, 1),
                ExpectedColumn.CreateVarChar("ProvSpecLearnMon", 4, false, 20)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "ProviderSpecLearnerMonitoring", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnSource()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateVarChar("ProtectiveMarking", 1, true, 30),
                ExpectedColumn.CreateInt("UKPRN", 2, false),
                ExpectedColumn.CreateVarChar("SoftwareSupplier", 3, true, 40),
                ExpectedColumn.CreateVarChar("SoftwarePackage", 4, true, 30),
                ExpectedColumn.CreateVarChar("Release", 5, true, 20),
                ExpectedColumn.CreateVarChar("SerialNo", 6, true, 2),
                ExpectedColumn.CreateDateTime("DateTime", 7, true),
                ExpectedColumn.CreateVarChar("ReferenceData", 8, true, 100),
                ExpectedColumn.CreateVarChar("ComponentSetVersion", 9, true, 20)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "Source", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnSourceFile()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("SourceFileName", 2, false, 50),
                ExpectedColumn.CreateDate("FilePreparationDate", 3, true),
                ExpectedColumn.CreateVarChar("SoftwareSupplier", 4, true, 40),
                ExpectedColumn.CreateVarChar("SoftwarePackage", 5, true, 30),
                ExpectedColumn.CreateVarChar("Release", 6, true, 20),
                ExpectedColumn.CreateVarChar("SerialNo", 7, true, 2),
                ExpectedColumn.CreateDateTime("DateTime", 8, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Valid", "SourceFile", expectedColumns, true);
        }
    }
}
