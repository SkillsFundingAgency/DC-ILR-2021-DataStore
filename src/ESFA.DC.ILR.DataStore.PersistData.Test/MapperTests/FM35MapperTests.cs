using System.Collections.Generic;
using System.IO;
using System.Linq;
using ESFA.DC.ILR.DataStore.PersistData.Mapper;
using ESFA.DC.ILR.DataStore.PersistData.Model;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR2021.DataStore.EF;
using ESFA.DC.Serialization.Json;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.DataStore.PersistData.Test.MapperTests
{
    public class FM35MapperTests
    {
        private readonly FM35Global _fundingOutputs = new JsonSerializationService().Deserialize<FM35Global>(File.ReadAllText(@"JsonOutputs/Fm35.json"));
        private readonly int ukprn = 10033672;
        private readonly HashSet<string> learnRefNumbers = new HashSet<string> { "0Accm02", "0Accm02" };

        [Fact]
        public void FM35Global()
        {
            var global = Mapper().BuildGlobals(_fundingOutputs, ukprn);

            global.Should().NotBeNullOrEmpty();
            global.First().UKPRN.Should().Be(ukprn);
        }

        [Fact]
        public void FM35Learner()
        {
            var learners = new List<FM35_Learner>();

            foreach (var learner in _fundingOutputs.Learners)
            {
                learners.Add(Mapper().BuildLearner(ukprn, learner.LearnRefNumber));
            }

            learners.Should().NotBeNull();
            learners.Count().Should().Be(2);
            learners.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learners.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void FM35LearningDeliveries()
        {
            var learningDeliveries = new List<FM35_LearningDelivery>();

            foreach (var learner in _fundingOutputs.Learners)
            {
                foreach (var learningDelivery in learner.LearningDeliveries)
                {
                    learningDeliveries.Add(Mapper().BuildLearningDelivery(learningDelivery, ukprn, learner.LearnRefNumber));
                }
            }

            learningDeliveries.Should().NotBeNull();
            learningDeliveries.Count().Should().Be(3);
            learningDeliveries.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learningDeliveries.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void FM35LearningDeliveryPeriods()
        {
            var learningDeliveryPeriodisedValues = _fundingOutputs.Learners.SelectMany(l => l.LearningDeliveries.Select(ld =>
                new FundModelLearningDeliveryPeriodisedValue<List<LearningDeliveryPeriodisedValue>>(ukprn, l.LearnRefNumber, ld.AimSeqNumber.Value, ld.LearningDeliveryPeriodisedValues)));

            var ldPeriods = Mapper().BuildLearningDeliveryPeriods(learningDeliveryPeriodisedValues);

            ldPeriods.Should().NotBeNull();
            ldPeriods.Count().Should().Be(36);
            ldPeriods.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            ldPeriods.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
            ldPeriods.Select(l => l.Period).Distinct().Should().NotContainNulls();
        }

        [Fact]
        public void FM35LearningDelieryPeriodisedValues()
        {
            var ldPeriodised = new List<FM35_LearningDelivery_PeriodisedValue>();

            var learningDeliveryPeriodisedValues = _fundingOutputs.Learners.SelectMany(l => l.LearningDeliveries.Select(ld =>
                new FundModelLearningDeliveryPeriodisedValue<List<LearningDeliveryPeriodisedValue>>(ukprn, l.LearnRefNumber, ld.AimSeqNumber.Value, ld.LearningDeliveryPeriodisedValues)));

            foreach (var periodisedValue in learningDeliveryPeriodisedValues)
            {
                foreach (var learnerPeriodisedValue in periodisedValue.LearningDeliveryPeriodisedValue)
                {
                    ldPeriodised.Add(Mapper().BuildLearningDeliveryPeriodisedValues(learnerPeriodisedValue, periodisedValue.AimSeqNumber, ukprn, periodisedValue.LearnRefNumber));
                }
            }

            ldPeriodised.Should().NotBeNull();
            ldPeriodised.Count().Should().Be(54);
            ldPeriodised.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            ldPeriodised.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        private FM35Mapper Mapper() => new FM35Mapper();
    }
}
