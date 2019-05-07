using System.Collections.Generic;
using System.IO;
using System.Linq;
using ESFA.DC.ILR.DataStore.PersistData.Mapper;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.Serialization.Json;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.DataStore.PersistData.Test.MapperTests
{
    public class FM36MapperTests
    {
        private readonly FM36Global _fundingOutputs = new JsonSerializationService().Deserialize<FM36Global>(File.ReadAllText(@"JsonOutputs/Fm36.json"));
        private readonly int ukprn = 10033660;
        private readonly HashSet<string> learnRefNumbers = new HashSet<string> { "3DOB01" };

        [Fact]
        public void FM36Global()
        {
            var global = Mapper().MapGlobals(_fundingOutputs);

            global.Should().NotBeEmpty();
            global.First().UKPRN.Should().Be(ukprn);
        }

        [Fact]
        public void FM36Learner()
        {
            var learners = Mapper().MapLearners(_fundingOutputs);

            learners.Should().NotBeNull();
            learners.Count().Should().Be(1);
            learners.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learners.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void FM36LearningDeliveries()
        {
            var learningDeliveries = Mapper().MapLearningDeliveries(_fundingOutputs);

            learningDeliveries.Should().NotBeNull();
            learningDeliveries.Count().Should().Be(2);
            learningDeliveries.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learningDeliveries.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void FM36LearningDelieryPeriods()
        {
            var ldPeriods = Mapper().MapLearningDeliveryPeriods(_fundingOutputs);

            ldPeriods.Should().NotBeNull();
            ldPeriods.Count().Should().Be(24);
            ldPeriods.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            ldPeriods.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
            ldPeriods.Select(l => l.Period).Distinct().Should().NotContainNulls();
        }

        [Fact]
        public void FM36LearningDelieryPeriodisedValues()
        {
            var ldPeriodised = Mapper().MapLearningDeliveryPeriodisedValues(_fundingOutputs);

            ldPeriodised.Should().NotBeNull();
            ldPeriodised.Count().Should().Be(52);
            ldPeriodised.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            ldPeriodised.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void FM36LearningDelieryPeriodisedTextValues()
        {
            var ldPeriodised = Mapper().MapLearningDeliveryPeriodisedTextValues(_fundingOutputs);

            ldPeriodised.Should().NotBeNull();
            ldPeriodised.Count().Should().Be(4);
            ldPeriodised.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            ldPeriodised.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void FM36ApprenticeshipPriceEpisodes()
        {
            var learningDeliveries = Mapper().MapPriceEpisodes(_fundingOutputs);

            learningDeliveries.Should().NotBeNull();
            learningDeliveries.Count().Should().Be(2);
            learningDeliveries.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learningDeliveries.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void FM36ApprenticeshipPriceEpisodePeriods()
        {
            var ldPeriods = Mapper().MapPriceEpisodePeriods(_fundingOutputs);

            ldPeriods.Should().NotBeNull();
            ldPeriods.Count().Should().Be(24);
            ldPeriods.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            ldPeriods.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
            ldPeriods.Select(l => l.Period).Distinct().Should().NotContainNulls();
        }

        [Fact]
        public void FM36ApprenticeshipPriceEpisodePeriodisedValues()
        {
            var ldPeriodised = Mapper().MapPriceEpisodePeriodisedValues(_fundingOutputs);

            ldPeriodised.Should().NotBeNull();
            ldPeriodised.Count().Should().Be(42);
            ldPeriodised.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            ldPeriodised.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        private FM36Mapper Mapper() => new FM36Mapper();
    }
}
