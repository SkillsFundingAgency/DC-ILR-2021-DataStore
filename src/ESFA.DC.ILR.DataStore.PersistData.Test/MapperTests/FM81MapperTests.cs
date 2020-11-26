using System.Collections.Generic;
using System.IO;
using System.Linq;
using ESFA.DC.ILR.DataStore.PersistData.Mapper;
using ESFA.DC.ILR.DataStore.PersistData.Model;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR2021.DataStore.EF;
using ESFA.DC.Serialization.Json;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.DataStore.PersistData.Test.MapperTests
{
    public class FM81MapperTests
    {
        private readonly FM81Global _fundingOutputs = new JsonSerializationService().Deserialize<FM81Global>(File.ReadAllText(@"JsonOutputs/Fm81.json"));
        private readonly int ukprn = 10000116;
        private readonly HashSet<string> learnRefNumbers = new HashSet<string> { "5fwc01", "5fwc02", "5fwc05" };

        [Fact]
        public void FM81Global()
        {
            var global = Mapper().BuildGlobals(_fundingOutputs, ukprn);

            global.Should().NotBeEmpty();
            global.First().UKPRN.Should().Be(ukprn);
        }

        [Fact]
        public void FM81Learner()
        {
            var learners = new List<TBL_Learner>();

            foreach (var learner in _fundingOutputs.Learners)
            {
                learners.Add(Mapper().BuildLearner(ukprn, learner.LearnRefNumber));
            }

            learners.Should().NotBeNull();
            learners.Count().Should().Be(3);
            learners.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learners.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void FM81LearningDeliveries()
        {
            var learningDeliveries = new List<TBL_LearningDelivery>();

            foreach (var learner in _fundingOutputs.Learners)
            {
                foreach (var learningDelivery in learner.LearningDeliveries)
                {
                    learningDeliveries.Add(Mapper().BuildLearningDelivery(learningDelivery, ukprn, learner.LearnRefNumber));
                }
            }

            learningDeliveries.Should().NotBeNull();
            learningDeliveries.Count().Should().Be(6);
            learningDeliveries.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learningDeliveries.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void FM81LearningDeliveryPeriods()
        {
            var learningDeliveryPeriodisedValues = _fundingOutputs.Learners.SelectMany(l => l.LearningDeliveries.Select(ld =>
                new FundModelLearningDeliveryPeriodisedValue<List<LearningDeliveryPeriodisedValue>>(ukprn, l.LearnRefNumber, ld.AimSeqNumber.Value, ld.LearningDeliveryPeriodisedValues)));

            var ldPeriods = Mapper().BuildLearningDeliveryPeriods(learningDeliveryPeriodisedValues);

            ldPeriods.Should().NotBeNull();
            ldPeriods.Count().Should().Be(72);
            ldPeriods.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            ldPeriods.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
            ldPeriods.Select(l => l.Period).Distinct().Should().NotContainNulls();
        }

        [Fact]
        public void FM81LearningDeliveryPeriodisedValues()
        {
            var ldPeriodised = new List<TBL_LearningDelivery_PeriodisedValue>();

            var learningDeliveryPeriodisedValues = _fundingOutputs.Learners.SelectMany(l => l.LearningDeliveries.Select(ld =>
                new FundModelLearningDeliveryPeriodisedValue<List<LearningDeliveryPeriodisedValue>>(ukprn, l.LearnRefNumber, ld.AimSeqNumber.Value, ld.LearningDeliveryPeriodisedValues)));

            foreach (var periodisedValue in learningDeliveryPeriodisedValues)
            {
                foreach (var learnerPeriodisedValue in periodisedValue.LearningDeliveryPeriodisedValue)
                {
                    ldPeriodised.Add(Mapper().BuildLearningDeliveryPeriodisedValue(learnerPeriodisedValue, ukprn, periodisedValue.AimSeqNumber, periodisedValue.LearnRefNumber));
                }
            }

            ldPeriodised.Should().NotBeNull();
            ldPeriodised.Count().Should().Be(84);
            ldPeriodised.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            ldPeriodised.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        private FM81Mapper Mapper() => new FM81Mapper();
    }
}
