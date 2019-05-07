﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.PersistData.Mapper;
using ESFA.DC.Serialization.Json;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test.MapperTests
{
    public class FM35MapperTests
    {
        private readonly FM35Global _fundingOutputs = new JsonSerializationService().Deserialize<FM35Global>(File.ReadAllText(@"JsonOutputs/Fm35.json"));
        private readonly int ukprn = 10033672;
        private readonly HashSet<string> learnRefNumbers = new HashSet<string> { "0Accm02", "0Accm02" };

        [Fact]
        public void FM35Global()
        {
            var global = Mapper().MapGlobals(_fundingOutputs);

            global.Should().NotBeNullOrEmpty();
            global.First().UKPRN.Should().Be(ukprn);
        }

        [Fact]
        public void FM35Learner()
        {
            var learners = Mapper().MapLearners(_fundingOutputs);

            learners.Should().NotBeNull();
            learners.Count().Should().Be(2);
            learners.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learners.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void FM35LearningDelieries()
        {
            var learningDeliveries = Mapper().MapLearningDeliveries(_fundingOutputs);

            learningDeliveries.Should().NotBeNull();
            learningDeliveries.Count().Should().Be(3);
            learningDeliveries.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learningDeliveries.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void FM35LearningDelieryPeriods()
        {
            var ldPeriods = Mapper().MapLearningDeliveryPeriods(_fundingOutputs);

            ldPeriods.Should().NotBeNull();
            ldPeriods.Count().Should().Be(36);
            ldPeriods.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            ldPeriods.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
            ldPeriods.Select(l => l.Period).Distinct().Should().NotContainNulls();
        }

        [Fact]
        public void FM35LearningDelieryPeriodisedValues()
        {
            var ldPeriodised = Mapper().MapLearningDeliveryPeriodisedValues(_fundingOutputs);

            ldPeriodised.Should().NotBeNull();
            ldPeriodised.Count().Should().Be(54);
            ldPeriodised.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            ldPeriodised.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        private FM35Mapper Mapper() => new FM35Mapper();
    }
}
