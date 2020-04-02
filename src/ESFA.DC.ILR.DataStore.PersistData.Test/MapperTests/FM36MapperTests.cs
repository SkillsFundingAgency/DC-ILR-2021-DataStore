using System.Collections.Generic;
using System.IO;
using System.Linq;
using ESFA.DC.ILR.DataStore.PersistData.Mapper;
using ESFA.DC.ILR.DataStore.PersistData.Model;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR2021.DataStore.EF;
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
            var global = Mapper().BuildGlobals(_fundingOutputs, ukprn);

            global.Should().NotBeEmpty();
            global.First().UKPRN.Should().Be(ukprn);
        }

        [Fact]
        public void FM36Learner()
        {
            var learners = new List<AEC_Learner>();

            foreach (var learner in _fundingOutputs.Learners)
            {
                learners.Add(Mapper().BuildLearner(learner, ukprn, learner.LearnRefNumber));
            }

            learners.Should().NotBeNull();
            learners.Count().Should().Be(1);
            learners.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learners.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void FM36LearningDeliveries()
        {
            var learningDeliveries = new List<AEC_LearningDelivery>();

            foreach (var learner in _fundingOutputs.Learners)
            {
                foreach (var learningDelivery in learner.LearningDeliveries)
                {
                    learningDeliveries.Add(Mapper().BuildLearningDelivery(learningDelivery, ukprn, learner.LearnRefNumber));
                }
            }

            learningDeliveries.Should().NotBeNull();
            learningDeliveries.Count().Should().Be(2);
            learningDeliveries.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learningDeliveries.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void FM36LearningDelieryPeriods()
        {
            var learningDeliveryPeriodisedValues = _fundingOutputs.Learners.SelectMany(l => l.LearningDeliveries.Select(ld =>
                new FundModel36LearningDeliveryPeriodisedValue(ukprn, l.LearnRefNumber, ld.AimSeqNumber, ld.LearningDeliveryPeriodisedValues, ld.LearningDeliveryPeriodisedTextValues)));

            var ldPeriods = Mapper().BuildLearningDeliveryPeriods(learningDeliveryPeriodisedValues);

            ldPeriods.Should().NotBeNull();
            ldPeriods.Count().Should().Be(24);
            ldPeriods.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            ldPeriods.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
            ldPeriods.Select(l => l.Period).Distinct().Should().NotContainNulls();
        }

        [Fact]
        public void FM36LearningDelieryPeriodisedValues()
        {
            var ldPeriodised = new List<AEC_LearningDelivery_PeriodisedValue>();

            var learningDeliveryPeriodisedValues = _fundingOutputs.Learners.SelectMany(l => l.LearningDeliveries.Select(ld =>
                new FundModel36LearningDeliveryPeriodisedValue(ukprn, l.LearnRefNumber, ld.AimSeqNumber, ld.LearningDeliveryPeriodisedValues, ld.LearningDeliveryPeriodisedTextValues)));

            foreach (var periodisedValue in learningDeliveryPeriodisedValues)
            {
                foreach (var learnerPeriodisedValue in periodisedValue.LearningDeliveryPeriodisedValue)
                {
                    ldPeriodised.Add(Mapper().BuildLearningDeliveryPeriodisedValues(learnerPeriodisedValue, ukprn, periodisedValue.AimSeqNumber, periodisedValue.LearnRefNumber));
                }
            }

            ldPeriodised.Should().NotBeNull();
            ldPeriodised.Count().Should().Be(52);
            ldPeriodised.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            ldPeriodised.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void FM36LearningDelieryPeriodisedTextValues()
        {
            var ldPeriodised = new List<AEC_LearningDelivery_PeriodisedTextValue>();

            var learningDeliveryPeriodisedValues = _fundingOutputs.Learners.SelectMany(l => l.LearningDeliveries.Select(ld =>
                new FundModel36LearningDeliveryPeriodisedValue(ukprn, l.LearnRefNumber, ld.AimSeqNumber, ld.LearningDeliveryPeriodisedValues, ld.LearningDeliveryPeriodisedTextValues)));

            foreach (var periodisedValue in learningDeliveryPeriodisedValues)
            {
                foreach (var learnerPeriodisedTextValue in periodisedValue.LearningDeliveryPeriodisedTextValue)
                {
                    ldPeriodised.Add(Mapper().BuildLearningDeliveryPeriodisedTextValues(learnerPeriodisedTextValue, ukprn, periodisedValue.AimSeqNumber, periodisedValue.LearnRefNumber));
                }
            }

            ldPeriodised.Should().NotBeNull();
            ldPeriodised.Count().Should().Be(4);
            ldPeriodised.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            ldPeriodised.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void FM36ApprenticeshipPriceEpisodes()
        {
            var priceEpisodes = new List<AEC_ApprenticeshipPriceEpisode>();

            foreach (var learner in _fundingOutputs.Learners)
            {
                foreach (var priceEpisode in learner.PriceEpisodes)
                {
                    priceEpisodes.Add(Mapper().BuildPriceEpisode(priceEpisode, ukprn, learner.LearnRefNumber));
                }
            }

            priceEpisodes.Should().NotBeNull();
            priceEpisodes.Count().Should().Be(2);
            priceEpisodes.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            priceEpisodes.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void FM36ApprenticeshipPriceEpisodePeriods()
        {
            var priceEpisodePeriodisedValues = _fundingOutputs.Learners.SelectMany(l => l.PriceEpisodes.Select(pe =>
                new FundModelPriceEpisodePeriodisedValue<List<PriceEpisodePeriodisedValues>>(ukprn, l.LearnRefNumber, pe.PriceEpisodeIdentifier, pe.PriceEpisodePeriodisedValues)));

            var pePeriods = Mapper().BuildPriceEpisodePeriods(priceEpisodePeriodisedValues);

            pePeriods.Should().NotBeNull();
            pePeriods.Count().Should().Be(24);
            pePeriods.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            pePeriods.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
            pePeriods.Select(l => l.Period).Distinct().Should().NotContainNulls();
        }

        [Fact]
        public void FM36ApprenticeshipPriceEpisodePeriodisedValues()
        {
            var pePeriodised = new List<AEC_ApprenticeshipPriceEpisode_PeriodisedValue>();

            var priceEpisodePeriodisedValues = _fundingOutputs.Learners.SelectMany(l => l.PriceEpisodes.Select(pe =>
                new FundModelPriceEpisodePeriodisedValue<List<PriceEpisodePeriodisedValues>>(ukprn, l.LearnRefNumber, pe.PriceEpisodeIdentifier, pe.PriceEpisodePeriodisedValues)));

            foreach (var periodisedValue in priceEpisodePeriodisedValues)
            {
                foreach (var priceEpisodePeriodisedValue in periodisedValue.PriceEpisodePeriodisedValue)
                {
                    pePeriodised.Add(Mapper().BuildPriceEpisodePeriodisedValue(priceEpisodePeriodisedValue, ukprn, periodisedValue.LearnRefNumber, periodisedValue.PriceEpisodeIdentifier));
                }
            }

            pePeriodised.Should().NotBeNull();
            pePeriodised.Count().Should().Be(42);
            pePeriodised.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            pePeriodised.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        private FM36Mapper Mapper() => new FM36Mapper();
    }
}
