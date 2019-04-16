using System.Collections.Generic;
using System.IO;
using System.Linq;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.PersistData.Mapper;
using ESFA.DC.Serialization.Json;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test.MapperTests
{
    public class ALBMapperTests
    {
        private readonly ALBGlobal _fundingOutputs = new JsonSerializationService().Deserialize<ALBGlobal>(File.ReadAllText(@"JsonOutputs/ALB.json"));
        private readonly int ukprn = 10033670;
        private readonly HashSet<string> learnRefNumbers = new HashSet<string> { "0ALB01", "4Addl103", "4DOB01", "0DOB02" };

        [Fact]
        public void ALBGlobal()
        {
            var global = Mapper().MapGlobals(_fundingOutputs);

            global.Should().NotBeNullOrEmpty();
            global.First().UKPRN.Should().Be(ukprn);
        }

        [Fact]
        public void ALBLearner()
        {
            var learners = Mapper().MapLearners(_fundingOutputs);

            learners.Should().NotBeNull();
            learners.Count().Should().Be(4);
            learners.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learners.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void ALBLearningDelieries()
        {
            var learningDeliveries = Mapper().MapLearningDeliveries(_fundingOutputs);

            learningDeliveries.Should().NotBeNull();
            learningDeliveries.Count().Should().Be(4);
            learningDeliveries.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learningDeliveries.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void ALBLearnerPeriodisedValues()
        {
            var learnerPeriodisedValues = Mapper().MapLearnerPeriodisedValues(_fundingOutputs);

            learnerPeriodisedValues.Should().NotBeNull();
            learnerPeriodisedValues.Count().Should().Be(4);
            learnerPeriodisedValues.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learnerPeriodisedValues.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void ALBLearnerPeriods()
        {
            var learnerPeriods = Mapper().MapLearnerPeriods(_fundingOutputs);

            learnerPeriods.Should().NotBeNull();
            learnerPeriods.Count().Should().Be(48);
            learnerPeriods.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learnerPeriods.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void ALBLearningDelieryPeriods()
        {
            var ldPeriods = Mapper().MapLearningDeliveryPeriods(_fundingOutputs);

            ldPeriods.Should().NotBeNull();
            ldPeriods.Count().Should().Be(48);
            ldPeriods.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            ldPeriods.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
            ldPeriods.Select(l => l.Period).Distinct().Should().NotContainNulls();
        }

        [Fact]
        public void ALBLearningDelieryPeriodisedValues()
        {
            var ldPeriodised = Mapper().MapLearningDeliveryPeriodisedValues(_fundingOutputs);

            ldPeriodised.Should().NotBeNull();
            ldPeriodised.Count().Should().Be(24);
            ldPeriodised.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            ldPeriodised.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        private ALBMapper Mapper() => new ALBMapper();
    }
}
