using System.Collections.Generic;
using System.IO;
using System.Linq;
using ESFA.DC.ILR.DataStore.PersistData.Mapper;
using ESFA.DC.ILR.DataStore.PersistData.Model;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR2021.DataStore.EF;
using ESFA.DC.Serialization.Json;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.DataStore.PersistData.Test.MapperTests
{
    public class FM70MapperTests
    {
        private readonly FM70Global _fundingOutputs = new JsonSerializationService().Deserialize<FM70Global>(File.ReadAllText(@"JsonOutputs/Fm70.json"));
        private readonly int ukprn = 10001634;
        private readonly HashSet<string> learnRefNumbers = new HashSet<string> { "5DOB01", "0DOB43", "5FamNam01", "5FamNam02", "5GivNam01" };

        [Fact]
        public void FM70Global()
        {
            var global = Mapper().BuildGlobals(_fundingOutputs, ukprn);

            global.Should().NotBeEmpty();
            global.First().UKPRN.Should().Be(ukprn);
        }

        [Fact]
        public void FM70Learner()
        {
            var learners = new List<ESF_Learner>();

            foreach (var learner in _fundingOutputs.Learners)
            {
                learners.Add(Mapper().BuildLearner(ukprn, learner.LearnRefNumber));
            }

            learners.Should().NotBeNull();
            learners.Count().Should().Be(5);
            learners.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learners.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void FM70LearningDelieries()
        {
            var learningDeliveries = new List<ESF_LearningDelivery>();

            foreach (var learner in _fundingOutputs.Learners)
            {
                foreach (var learningDelivery in learner.LearningDeliveries)
                {
                    learningDeliveries.Add(Mapper().BuildLearningDelivery(learningDelivery, ukprn, learner.LearnRefNumber));
                }
            }

            learningDeliveries.Should().NotBeNull();
            learningDeliveries.Count().Should().Be(10);
            learningDeliveries.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learningDeliveries.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void FM70LearningDelieryDeiliverables()
        {
            var learningDeliveryDeliverables = new List<ESF_LearningDeliveryDeliverable>();

            foreach (var learner in _fundingOutputs.Learners)
            {
                foreach (var learningDelivery in learner.LearningDeliveries)
                {
                    foreach (var learningDeliveryDeliverable in learningDelivery.LearningDeliveryDeliverableValues)
                    {
                        learningDeliveryDeliverables.Add(Mapper().BuildLearningDeliveryDeliverable(learningDeliveryDeliverable, ukprn, learner.LearnRefNumber, learningDelivery.AimSeqNumber.Value));
                    }
                }
            }

            learningDeliveryDeliverables.Should().NotBeNull();
            learningDeliveryDeliverables.Count().Should().Be(2);
            learningDeliveryDeliverables.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learningDeliveryDeliverables.Select(l => l.LearnRefNumber).Should().Contain("0DOB43");
        }

        [Fact]
        public void FM70LearningDelieryPeriods()
        {
            var learningDeliveryPeriodisedValues = _fundingOutputs.Learners.SelectMany(l => l.LearningDeliveries.SelectMany(ld => ld.LearningDeliveryDeliverableValues.Select(ldd =>
                new FundModelESFLearningDeliveryPeriodisedValue<List<LearningDeliveryDeliverablePeriodisedValue>>(ukprn, l.LearnRefNumber, ld.AimSeqNumber.Value, ldd.DeliverableCode, ldd.LearningDeliveryDeliverablePeriodisedValues))));

            var lddPeriods = Mapper().BuildLearningDeliveryDeliverablePeriods(learningDeliveryPeriodisedValues);

            lddPeriods.Should().NotBeNull();
            lddPeriods.Count().Should().Be(24);
            lddPeriods.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            lddPeriods.Select(l => l.LearnRefNumber).Should().Contain("0DOB43");
            lddPeriods.Select(l => l.Period).Distinct().Should().NotContainNulls();
        }

        [Fact]
        public void FM70LearningDelieryPeriodisedValues()
        {
            var lddPeriodised = new List<ESF_LearningDeliveryDeliverable_PeriodisedValue>();

            var learningDeliveryPeriodisedValues = _fundingOutputs.Learners.SelectMany(l => l.LearningDeliveries.SelectMany(ld => ld.LearningDeliveryDeliverableValues.Select(ldd =>
                new FundModelESFLearningDeliveryPeriodisedValue<List<LearningDeliveryDeliverablePeriodisedValue>>(ukprn, l.LearnRefNumber, ld.AimSeqNumber.Value, ldd.DeliverableCode, ldd.LearningDeliveryDeliverablePeriodisedValues))));

            foreach (var periodisedValue in learningDeliveryPeriodisedValues)
            {
                foreach (var learnerPeriodisedValue in periodisedValue.LearningDeliveryPeriodisedValue)
                {
                    lddPeriodised.Add(Mapper().BuildLearningDeliveryDeliverablePeriodisedValue(learnerPeriodisedValue, ukprn, periodisedValue.AimSeqNumber, periodisedValue.LearnRefNumber, periodisedValue.EsfDeliverableCode));
                }
            }

            lddPeriodised.Should().NotBeNull();
            lddPeriodised.Count().Should().Be(12);
            lddPeriodised.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            lddPeriodised.Select(l => l.LearnRefNumber).Should().Contain("0DOB43");
        }

        [Fact]
        public void FM70DPOutcomes()
        {
            var dpOutcomes = new List<ESF_DPOutcome>();

            foreach (var learner in _fundingOutputs.Learners)
            {
                foreach (var dpOutcome in learner.LearnerDPOutcomes)
                {
                    dpOutcomes.Add(Mapper().BuildDPOutcome(dpOutcome, ukprn, learner.LearnRefNumber));
                }
            }

            dpOutcomes.Should().NotBeNull();
            dpOutcomes.Count().Should().Be(6);
            dpOutcomes.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            dpOutcomes.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        private FM70Mapper Mapper() => new FM70Mapper();
    }
}
