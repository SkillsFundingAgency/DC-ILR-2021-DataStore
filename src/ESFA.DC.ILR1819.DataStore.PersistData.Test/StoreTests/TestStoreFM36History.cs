using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ESFA.DC.Data.AppsEarningsHistory.Model;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Mappers;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData.Persist;
using ESFA.DC.ILR1819.DataStore.PersistData.Test.Abstract;
using ESFA.DC.Serialization.Json;
using Moq;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test.StoreTests
{
    [Collection("StoreData Tests")]
    public class TestStoreFM36History : AbstractFm36HistoryStoreTest<FM36Global>
    {
        private static readonly int _ukprn = 10033660;
        private static readonly FM36Global _fundingOutputs = new JsonSerializationService().Deserialize<FM36Global>(File.ReadAllText(@"JsonOutputs/Fm36.json"));
        private static readonly IStoreFM36HistoryService<FM36Global> StoreService = StoreFM36HistorySetup();

        public TestStoreFM36History()
          : base(StoreService)
        {
        }

        [Fact]
        public async Task StoreFM36History()
        {
            await StoreTestAsync(_ukprn, _fundingOutputs, "FM36_Output");
        }

        protected override void ExecuteAssertions(FM36Global outputModel, int ukprn, SqlConnection sqlConnection)
        {
            using (SqlCommand sqlCommand = new SqlCommand($"SELECT Count(1) FROM dbo.AppsEarningsHistory Where UKPRN = {ukprn} AND LearnRefNumber = '3DOB01'", sqlConnection))
            {
                Assert.Equal(outputModel.Learners.Where(l => l.LearnRefNumber == "3DOB01")?.Select(l => l.HistoricEarningOutputValues).Count() ?? 0, sqlCommand.ExecuteScalar());
            }
        }

        private static StoreFM36History StoreFM36HistorySetup()
        {
            var historyOutput = new List<AppsEarningsHistory>
            {
                new AppsEarningsHistory
                {
                    UKPRN = _ukprn,
                    CollectionReturnCode = "R01",
                    CollectionYear = "1819",
                    LatestInYear = true,
                    LearnRefNumber = "3DOB01",
                    AppIdentifier = "25-5",
                    AppProgCompletedInTheYearInput = false,
                    BalancingProgAimPaymentsInTheYear = 0.0m,
                    CompletionProgaimPaymentsInTheYear = 0.0m,
                    DaysInYear = 274,
                    HistoricEffectiveTNPStartDateInput = new System.DateTime(2018, 07, 31),
                    HistoricEmpIdEndWithinYear = 914429647,
                    HistoricEmpIdStartWithinYear = 914429647,
                    FworkCode = null,
                    HistoricLearner1618StartInput = true,
                    OnProgProgAimPaymentsInTheYear = 3000.0m,
                    HistoricPMRAmount = 0.0m,
                    ProgrammeStartDateIgnorePathway = new System.DateTime(2018, 10, 31),
                    ProgrammeStartDateMatchPathway = new System.DateTime(2018, 10, 31),
                    ProgType = 25,
                    PwayCode = null,
                    STDCode = 5,
                    HistoricTNP1Input = 10500.0m,
                    HistoricTNP2Input = 0.0m,
                    HistoricTNP3Input = 0.0m,
                    HistoricTNP4Input = 0.0m,
                    HistoricTotal1618UpliftPaymentsInTheYearInput = 0.0m,
                    TotalProgAimPaymentsInTheYear = 3000.0m,
                    ULN = 9900278304,
                    UptoEndDate = new System.DateTime(2018, 07, 31),
                    HistoricVirtualTNP3EndOfTheYearInput = 0.0m,
                    HistoricVirtualTNP4EndOfTheYearInput = 0.0m,
                    HistoricLearnDelProgEarliestACT2DateInput = new System.DateTime(2018, 10, 31),
                }
            };

            var fm36HistoryMapperMock = new Mock<IFM36HistoryMapper>();
            IBulkInsert bulkInsert = new BulkInsert();

            fm36HistoryMapperMock.Setup(fm => fm.MapAppsEarningsHistory(_fundingOutputs, It.IsAny<string>(), It.IsAny<string>())).Returns(historyOutput);

            return new StoreFM36History(fm36HistoryMapperMock.Object, bulkInsert);
        }
    }
}
