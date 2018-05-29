using System.Collections.Generic;
using ESFA.DC.DatabaseTesting.Model;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.Database.Test
{
    public sealed class SchemaDboTests : IClassFixture<DatabaseConnectionFixture>
    {
        private readonly DatabaseConnectionFixture _fixture;

        public SchemaDboTests(DatabaseConnectionFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CheckColumnFileDetails()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateBigInt("ID", 1, false),
                ExpectedColumn.CreateInt("UKPRN", 2, false),
                ExpectedColumn.CreateNvarChar("Filename", 3, true, 50),
                ExpectedColumn.CreateBigInt("FileSizeKb", 4, true),
                ExpectedColumn.CreateInt("TotalLearnersSubmitted", 5, true),
                ExpectedColumn.CreateInt("TotalValidLearnersSubmitted", 6, true),
                ExpectedColumn.CreateInt("TotalInvalidLearnersSubmitted", 7, true),
                ExpectedColumn.CreateInt("TotalErrorCount", 8, true),
                ExpectedColumn.CreateInt("TotalWarningCount", 9, true),
                ExpectedColumn.CreateDateTime("SubmittedTime", 10, true),
                ExpectedColumn.CreateBit("Success", 11, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("dbo", "FileDetails", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnProcessingData()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateBigInt("Id", 1, false),
                ExpectedColumn.CreateInt("UKPRN", 2, false),
                ExpectedColumn.CreateBigInt("FileDetailsID", 3, false),
                ExpectedColumn.CreateNvarChar("ProcessingStep", 4, false, 100),
                ExpectedColumn.CreateNvarChar("ExecutionTime", 5, false, 20)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("dbo", "ProcessingData", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnValidationError()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateBigInt("Id", 1, false),
                ExpectedColumn.CreateInt("UKPRN", 2, true),
                ExpectedColumn.CreateVarChar("Source", 3, true, 50),
                ExpectedColumn.CreateVarChar("LearnAimRef", 4, true, 1000),
                ExpectedColumn.CreateBigInt("AimSeqNum", 5, true),
                ExpectedColumn.CreateVarChar("SWSupAimID", 6, true, 1000),
                ExpectedColumn.CreateNvarChar("ErrorMessage", 7, true, -1),
                ExpectedColumn.CreateNvarChar("FieldValues", 8, true, 2000),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 9, true, 100),
                ExpectedColumn.CreateVarChar("RuleName", 10, true, 50),
                ExpectedColumn.CreateVarChar("Severity", 11, true, 2),
                ExpectedColumn.CreateInt("FileLevelError", 12, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("dbo", "ValidationError", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnVersionInfo()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("Version", 1, false),
                ExpectedColumn.CreateDate("Date", 2, false)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("dbo", "VersionInfo", expectedColumns, true);
        }
    }
}
