using System.IO;
using System.Linq;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR1819.DataStore.PersistData.Persist.Mappers;
using ESFA.DC.Serialization.Json;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test
{
    public class FM25MapperTests
    {
        private readonly FM25Global _fundingOutputs = new JsonSerializationService().Deserialize<FM25Global>(File.ReadAllText(@"JsonOutputs/FM25.json"));

        [Fact]
        public void FM25Global()
        {
            var global = Mapper().MapFM25Global(_fundingOutputs);

            global.Should().NotBeNull();
            global.UKPRN.Should().Be(10033671);
        }

        [Fact]
        public void FM25Learner()
        {
            var learners = Mapper().MapFM25Learners(_fundingOutputs);

            learners.Should().NotBeNull();
            learners.Count().Should().Be(3);
            learners.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(10033671);
            learners.Select(l => l.LearnRefNumber).Should().Contain("0Addl103", "0ContPr01", "1ContPr01");
        }

        [Fact]
        public void FM25_FM35_Global()
        {
            var global = Mapper().MapFM25_35_Global(_fundingOutputs);

            global.Should().NotBeNull();
            global.UKPRN.Should().Be(10033671);
        }

        [Fact]
        public void FM25_FM35_LearnerPeriods()
        {
            var learnerPeriods = Mapper().MapFM25_35_LearnerPeriod(_fundingOutputs);

            learnerPeriods.Should().NotBeNull();
            learnerPeriods.Count().Should().Be(36);
            learnerPeriods.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(10033671);
            learnerPeriods.Select(l => l.LearnRefNumber).Should().Contain("0Addl103", "0ContPr01", "1ContPr01");
        }

        [Fact]
        public void FM25LearningDelieryPeriodisedValues()
        {
            var lpPeriodised = Mapper().MapFM25_35_LearnerPeriodisedValues(_fundingOutputs);

            lpPeriodised.Should().NotBeNull();
            lpPeriodised.Count().Should().Be(3);
            lpPeriodised.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(10033671);
            lpPeriodised.Select(l => l.LearnRefNumber).Should().Contain("0Addl103", "0ContPr01", "1ContPr01");
        }

        private FM25Mapper Mapper() => new FM25Mapper();
    }
}
