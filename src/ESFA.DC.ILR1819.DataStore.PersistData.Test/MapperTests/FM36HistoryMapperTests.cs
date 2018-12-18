using System.Collections.Generic;
using System.IO;
using System.Linq;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.Interface.Mappers;
using ESFA.DC.ILR1819.DataStore.PersistData.Persist.Mappers;
using ESFA.DC.Serialization.Json;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test.MapperTests
{
    public class FM36HistoryMapperTests
    {
        private readonly FM36Global _fundingOutputs = new JsonSerializationService().Deserialize<FM36Global>(File.ReadAllText(@"JsonOutputs/Fm36.json"));
        private readonly int ukprn = 10033660;
        private readonly HashSet<string> learnRefNumbers = new HashSet<string> { "3DOB01" };

        [Fact]
        public void MapAppsEarningsHistory()
        {
            var returnCode = "01";
            var year = "1819";

            var mapAppsEarningsHistory = Mapper().MapAppsEarningsHistory(_fundingOutputs, returnCode, year);

            mapAppsEarningsHistory.Should().NotBeNull();
            mapAppsEarningsHistory.Count().Should().Be(1);
            mapAppsEarningsHistory.Select(a => a.UKPRN).Should().BeEquivalentTo(ukprn);
            mapAppsEarningsHistory.Select(a => a.CollectionReturnCode).Should().BeEquivalentTo("R01");
            mapAppsEarningsHistory.Select(a => a.CollectionYear).Should().BeEquivalentTo("1819");
            mapAppsEarningsHistory.Select(a => a.OnProgProgAimPaymentsInTheYear).Should().BeEquivalentTo(3000m);
            mapAppsEarningsHistory.Select(a => a.ULN).Should().BeEquivalentTo(9900278304);
            mapAppsEarningsHistory.Select(a => a.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        private FM36HistoryMapper Mapper() => new FM36HistoryMapper();
    }
}
