using System.Collections.Generic;
using System.IO;
using System.Linq;
using ESFA.DC.ILR.DataStore.PersistData.Mapper;
using ESFA.DC.ILR.DataStore.PersistData.Model;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR2021.DataStore.EF;
using ESFA.DC.Serialization.Json;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.DataStore.PersistData.Test.MapperTests
{
    public class ALBMapperTests
    {
        private readonly ALBGlobal _fundingOutputs = new JsonSerializationService().Deserialize<ALBGlobal>(File.ReadAllText(@"JsonOutputs/ALB.json"));
        private readonly int ukprn = 10033670;
        private readonly HashSet<string> learnRefNumbers = new HashSet<string> { "0ALB01", "4Addl103", "4DOB01", "0DOB02" };

        [Fact]
        public void ALBGlobal()
        {
            var global = Mapper().BuildGlobals(_fundingOutputs, ukprn);

            global.Should().NotBeNullOrEmpty();
            global.First().UKPRN.Should().Be(ukprn);
        }

        [Fact]
        public void ALBLearner()
        {
            var learners = new List<ALB_Learner>();

            foreach (var learner in _fundingOutputs.Learners)
            {
                learners.Add(Mapper().BuildLearner(learner.LearnRefNumber, ukprn));
            }

            learners.Should().NotBeNull();
            learners.Count().Should().Be(4);
            learners.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learners.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void ALBLearningDelieries()
        {
            var learningDeliveries = new List<ALB_LearningDelivery>();

            foreach (var learner in _fundingOutputs.Learners)
            {
                foreach (var learningDelivery in learner.LearningDeliveries)
                {
                    learningDeliveries.Add(Mapper().BuildLearningDelivery(learningDelivery, ukprn, learner.LearnRefNumber));
                }
            }

            learningDeliveries.Should().NotBeNull();
            learningDeliveries.Count().Should().Be(4);
            learningDeliveries.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learningDeliveries.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void ALBLearnerPeriodisedValues()
        {
            var learnerPeriodisedValues = new List<ALB_Learner_PeriodisedValue>();

            var periodisedValues = _fundingOutputs.Learners.Select(l => new FundModelLearnerPeriodisedValue<List<LearnerPeriodisedValue>>(ukprn, l.LearnRefNumber, l.LearnerPeriodisedValues));

            foreach (var periodisedValue in periodisedValues)
            {
                foreach (var learnerPeriodisedValue in periodisedValue.LearnerPeriodisedValue)
                {
                    learnerPeriodisedValues.Add(Mapper().BuildLearnerPeriodisedValue(learnerPeriodisedValue, ukprn, periodisedValue.LearnRefNumber));
                }
            }

            learnerPeriodisedValues.Should().NotBeNull();
            learnerPeriodisedValues.Count().Should().Be(4);
            learnerPeriodisedValues.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learnerPeriodisedValues.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void ALBLearnerPeriods()
        {
            var learnerPeriods = new List<ALB_Learner_Period>();

            var periodisedValues = _fundingOutputs.Learners.Select(l => new FundModelLearnerPeriodisedValue<List<LearnerPeriodisedValue>>(ukprn, l.LearnRefNumber, l.LearnerPeriodisedValues));
            learnerPeriods.AddRange(Mapper().BuildLearnerPeriods(periodisedValues, ukprn));

            learnerPeriods.Should().NotBeNull();
            learnerPeriods.Count().Should().Be(48);
            learnerPeriods.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learnerPeriods.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void ALBLearningDelieryPeriods()
        {
            var learningDeliveryPeriodisedValues = _fundingOutputs.Learners
                .SelectMany(l => l.LearningDeliveries.Select(ld =>
                    new FundModelLearningDeliveryPeriodisedValue<List<LearningDeliveryPeriodisedValue>>(ukprn, l.LearnRefNumber, ld.AimSeqNumber, ld.LearningDeliveryPeriodisedValues)));

            var ldPeriods = Mapper().BuildLearningDeliveryPeriods(learningDeliveryPeriodisedValues, ukprn);

            ldPeriods.Should().NotBeNull();
            ldPeriods.Count().Should().Be(48);
            ldPeriods.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            ldPeriods.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
            ldPeriods.Select(l => l.Period).Distinct().Should().NotContainNulls();
        }

        [Fact]
        public void ALBLearningDelieryPeriodisedValues()
        {
            var ldPeriodised = new List<ALB_LearningDelivery_PeriodisedValue>();

            var learningDeliveryPeriodisedValues = _fundingOutputs.Learners
                .SelectMany(l => l.LearningDeliveries.Select(ld =>
                    new FundModelLearningDeliveryPeriodisedValue<List<LearningDeliveryPeriodisedValue>>(ukprn, l.LearnRefNumber, ld.AimSeqNumber, ld.LearningDeliveryPeriodisedValues)));

            foreach (var periodisedValue in learningDeliveryPeriodisedValues)
            {
                foreach (var learnerPeriodisedValue in periodisedValue.LearningDeliveryPeriodisedValue)
                {
                    ldPeriodised.Add(Mapper().BuildLearningDeliveryPeriodisedValues(learnerPeriodisedValue, periodisedValue.AimSeqNumber, ukprn, periodisedValue.LearnRefNumber));
                }
            }

            ldPeriodised.Should().NotBeNull();
            ldPeriodised.Count().Should().Be(24);
            ldPeriodised.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            ldPeriodised.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        private ALBMapper Mapper() => new ALBMapper();
    }
}
