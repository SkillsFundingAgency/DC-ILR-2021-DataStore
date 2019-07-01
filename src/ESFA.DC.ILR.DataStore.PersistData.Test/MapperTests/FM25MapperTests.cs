using System.Collections.Generic;
using System.IO;
using System.Linq;
using ESFA.DC.ILR.DataStore.PersistData.Mapper;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR1920.DataStore.EF;
using ESFA.DC.Serialization.Json;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.DataStore.PersistData.Test.MapperTests
{
    public class FM25MapperTests
    {
        private readonly FM25Global _fundingOutputs = new JsonSerializationService().Deserialize<FM25Global>(File.ReadAllText(@"JsonOutputs/FM25.json"));
        private readonly int ukprn = 10033671;
        private readonly HashSet<string> learnRefNumbers = new HashSet<string> { "0Addl103", "0ContPr01", "1ContPr01" };

        [Fact]
        public void FM25Global()
        {
            var global = Mapper().BuildFM25Global(_fundingOutputs, ukprn);

            global.Should().NotBeNullOrEmpty();
            global.First().UKPRN.Should().Be(ukprn);
        }

        [Fact]
        public void FM25Learner()
        {
            var learners = new List<FM25_Learner>();

            foreach (var learner in _fundingOutputs.Learners)
            {
                learners.Add(Mapper().BuildFM25Learner(ukprn, learner));
            }

            learners.Should().NotBeNull();
            learners.Count().Should().Be(3);
            learners.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learners.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void FM25_FM35_Global()
        {
            var global = Mapper().BuildFM25_35_Global(_fundingOutputs, ukprn);

            global.Should().NotBeNullOrEmpty();
            global.First().UKPRN.Should().Be(10033671);
        }

        [Fact]
        public void FM25_FM35_LearnerPeriods()
        {
            var learnerPeriods = new List<FM25_FM35_Learner_Period>();

            foreach (var learner in _fundingOutputs.Learners)
            {
                foreach (var learnerPeriod in learner.LearnerPeriods)
                {
                    learnerPeriods.Add(Mapper().BuildFM25_35_LearnerPeriod(learnerPeriod, ukprn, learnerPeriod.LearnRefNumber));
                }
            }

            learnerPeriods.Should().NotBeNull();
            learnerPeriods.Count().Should().Be(36);
            learnerPeriods.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learnerPeriods.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        [Fact]
        public void FM25LearningDelieryPeriodisedValues()
        {
            var learnerPeriodisedValues = new List<FM25_FM35_Learner_PeriodisedValue>();

            foreach (var learner in _fundingOutputs.Learners)
            {
                foreach (var learnerPeriodisedValue in learner.LearnerPeriodisedValues)
                {
                    learnerPeriodisedValues.Add(Mapper().BuildFM25_35_LearnerPeriodisedValues(learnerPeriodisedValue, ukprn, learnerPeriodisedValue.LearnRefNumber));
                }
            }

            learnerPeriodisedValues.Should().NotBeNull();
            learnerPeriodisedValues.Count().Should().Be(3);
            learnerPeriodisedValues.Select(l => l.UKPRN).Distinct().Should().BeEquivalentTo(ukprn);
            learnerPeriodisedValues.Select(l => l.LearnRefNumber).Should().Contain(learnRefNumbers);
        }

        private FM25Mapper Mapper() => new FM25Mapper();
    }
}
