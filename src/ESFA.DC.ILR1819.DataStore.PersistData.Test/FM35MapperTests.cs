using System.IO;
using System.Linq;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.PersistData.Persist.Mappers;
using ESFA.DC.Serialization.Json;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test
{
    public class FM35MapperTests
    {
        private readonly FM35Global _fundingOutputs = new JsonSerializationService().Deserialize<FM35Global>(File.ReadAllText(@"JsonOutputs/Fm35.json"));

        [Fact]
        public void FM35Global()
        {
            var global = Mapper().MapGlobal(_fundingOutputs);

            global.Should().NotBeNull();
            global.UKPRN.Should().Be(10033672);
        }

        [Fact]
        public void FM35Learner()
        {
            var learners = Mapper().MapLearners(_fundingOutputs);

            learners.Should().NotBeNull();
            learners.Count().Should().Be(2);
            learners.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(10033672);
            learners.Select(l => l.LearnRefNumber).Should().Contain("0Accm02", "0Accm02");
        }

        [Fact]
        public void FM35LearningDelieries()
        {
            var learningDeliveries = Mapper().MapLearningDeliveries(_fundingOutputs);

            learningDeliveries.Should().NotBeNull();
            learningDeliveries.Count().Should().Be(3);
            learningDeliveries.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(10033672);
            learningDeliveries.Select(l => l.LearnRefNumber).Should().Contain("0Accm02", "0Accm02");
        }

        [Fact]
        public void FM35LearningDelieryPeriods()
        {
            var ldPeriods = Mapper().MapLearningDeliveryPeriods(_fundingOutputs);

            ldPeriods.Should().NotBeNull();
            ldPeriods.Count().Should().Be(36);
            ldPeriods.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(10033672);
            ldPeriods.Select(l => l.LearnRefNumber).Should().Contain("0Accm02", "0Accm02");
            ldPeriods.Select(l => l.Period).Distinct().Should().NotContainNulls();
        }

        [Fact]
        public void FM35LearningDelieryPeriodisedValues()
        {
            var ldPeriodised = Mapper().MapLearningDeliveryPeriodisedValues(_fundingOutputs);

            ldPeriodised.Should().NotBeNull();
            ldPeriodised.Count().Should().Be(54);
            ldPeriodised.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(10033672);
            ldPeriodised.Select(l => l.LearnRefNumber).Should().Contain("0Accm02", "0Accm02");
        }

        private FM35Mapper Mapper() => new FM35Mapper();
    }
}
