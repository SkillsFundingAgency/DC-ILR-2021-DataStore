using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Mappers;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData.Persist;
using ESFA.DC.ILR1819.DataStore.PersistData.Test.Abstract;
using ESFA.DC.Serialization.Json;
using Moq;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test
{
    [Collection("StoreData Tests")]
    public class TestStoreFM25 : AbstractStoreTest<FM25Global>
    {
        private static readonly int _ukprn = 10033671;
        private static readonly FM25Global _fundingOutputs = new JsonSerializationService().Deserialize<FM25Global>(File.ReadAllText(@"JsonOutputs/Fm25.json"));
        private static readonly IStoreService<FM25Global> StoreService = StoreFM25Setup();

        public TestStoreFM25()
            : base(StoreService)
        {
        }

        [Fact]
        public async Task StoreFM25()
        {
            await StoreTestAsync(_ukprn, _fundingOutputs, "FM25_Output");
        }

        protected override void ExecuteAssertions(FM25Global outputModel, int ukprn, SqlConnection sqlConnection)
        {
            using (SqlCommand sqlCommand = new SqlCommand($"SELECT Count(1) FROM Rulebase.FM25_Learner Where UKPRN = {ukprn}", sqlConnection))
            {
                Assert.Equal(outputModel.Learners.Count, sqlCommand.ExecuteScalar());
            }

            using (SqlCommand sqlCommand = new SqlCommand($"SELECT Count(1) FROM Rulebase.FM25_FM35_Learner_Period Where UKPRN = {ukprn}", sqlConnection))
            {
                Assert.Equal(outputModel.Learners.Where(l => l.LearnRefNumber == "0Addl103").SelectMany(l => l.LearnerPeriods).Count(), sqlCommand.ExecuteScalar());
            }

            using (SqlCommand sqlCommand = new SqlCommand($"SELECT Count(1) FROM Rulebase.FM25_FM35_Learner_PeriodisedValues Where UKPRN = {ukprn}", sqlConnection))
            {
                Assert.Equal(outputModel.Learners.Where(l => l.LearnRefNumber == "0Addl103").SelectMany(l => l.LearnerPeriodisedValues).Count(), sqlCommand.ExecuteScalar());
            }
        }

        private static StoreFM25 StoreFM25Setup()
        {
            var fundingOutput =
            new FM25_global
            {
                UKPRN = _ukprn,
                FM25_Learner = new List<FM25_Learner>
                {
                    new FM25_Learner
                    {
                        LearnRefNumber = "0Addl103",
                        UKPRN = _ukprn,
                        FM25_FM35_Learner_Period = new List<FM25_FM35_Learner_Period>
                        {
                           new FM25_FM35_Learner_Period
                           {
                               LearnRefNumber = "0Addl103",
                               UKPRN = _ukprn,
                               Period = 1,
                               LnrOnProgPay = 0.0m
                           },
                           new FM25_FM35_Learner_Period
                           {
                               LearnRefNumber = "0Addl103",
                               UKPRN = _ukprn,
                               Period = 2,
                               LnrOnProgPay = 0.0m
                           },
                           new FM25_FM35_Learner_Period
                           {
                               LearnRefNumber = "0Addl103",
                               UKPRN = _ukprn,
                               Period = 3,
                               LnrOnProgPay = 0.0m
                           },
                           new FM25_FM35_Learner_Period
                           {
                               LearnRefNumber = "0Addl103",
                               UKPRN = _ukprn,
                               Period = 4,
                               LnrOnProgPay = 0.0m
                           },
                           new FM25_FM35_Learner_Period
                           {
                               LearnRefNumber = "0Addl103",
                               UKPRN = _ukprn,
                               Period = 5,
                               LnrOnProgPay = 0.0m
                           },
                           new FM25_FM35_Learner_Period
                           {
                               LearnRefNumber = "0Addl103",
                               UKPRN = _ukprn,
                               Period = 6,
                               LnrOnProgPay = 0.0m
                           },
                           new FM25_FM35_Learner_Period
                           {
                               LearnRefNumber = "0Addl103",
                               UKPRN = _ukprn,
                               Period = 7,
                               LnrOnProgPay = 0.0m
                           },
                           new FM25_FM35_Learner_Period
                           {
                               LearnRefNumber = "0Addl103",
                               UKPRN = _ukprn,
                               Period = 8,
                               LnrOnProgPay = 0.0m
                           },
                           new FM25_FM35_Learner_Period
                           {
                               LearnRefNumber = "0Addl103",
                               UKPRN = _ukprn,
                               Period = 9,
                               LnrOnProgPay = 0.0m
                           },
                           new FM25_FM35_Learner_Period
                           {
                               LearnRefNumber = "0Addl103",
                               UKPRN = _ukprn,
                               Period = 10,
                               LnrOnProgPay = 0.0m
                           },
                           new FM25_FM35_Learner_Period
                           {
                               LearnRefNumber = "0Addl103",
                               UKPRN = _ukprn,
                               Period = 11,
                               LnrOnProgPay = 0.0m
                           },
                           new FM25_FM35_Learner_Period
                           {
                               LearnRefNumber = "0Addl103",
                               UKPRN = _ukprn,
                               Period = 12,
                               LnrOnProgPay = 0.0m
                           },
                        },
                        FM25_FM35_Learner_PeriodisedValues = new List<FM25_FM35_Learner_PeriodisedValues>
                        {
                            new FM25_FM35_Learner_PeriodisedValues
                            {
                                LearnRefNumber = "0Addl103",
                                UKPRN = _ukprn,
                                AttributeName = "Attribute1",
                                Period_1 = 0.0m,
                                Period_2 = 0.0m,
                                Period_3 = 0.0m,
                                Period_4 = 0.0m,
                                Period_5 = 0.0m,
                                Period_6 = 0.0m,
                                Period_7 = 0.0m,
                                Period_8 = 0.0m,
                                Period_9 = 0.0m,
                                Period_10 = 0.0m,
                                Period_11 = 0.0m,
                                Period_12 = 0.0m
                            }
                        }
                    },
                    new FM25_Learner
                    {
                        UKPRN = _ukprn,
                        LearnRefNumber = "0ContPr01"
                    },
                    new FM25_Learner
                    {
                        UKPRN = _ukprn,
                        LearnRefNumber = "1ContPr01"
                    }
                }
            };

            var global = fundingOutput;
            var learners = fundingOutput.FM25_Learner;
            var fm25_35global = new FM25_FM35_global { UKPRN = fundingOutput.UKPRN, RulebaseVersion = fundingOutput.RulebaseVersion };
            var fm25_35learnerPeriod = fundingOutput.FM25_Learner.SelectMany(p => p.FM25_FM35_Learner_Period);
            var fm25_35learnerPeriodisedValues = fundingOutput.FM25_Learner.SelectMany(p => p.FM25_FM35_Learner_PeriodisedValues);

            var fm25MapperMock = new Mock<IFM25Mapper>();
            IBulkInsert bulkInsert = new BulkInsert();

            fm25MapperMock.Setup(fm => fm.MapFM25Global(_fundingOutputs)).Returns(global);
            fm25MapperMock.Setup(fm => fm.MapFM25Learners(_fundingOutputs)).Returns(learners);
            fm25MapperMock.Setup(fm => fm.MapFM25_35_Global(_fundingOutputs)).Returns(fm25_35global);
            fm25MapperMock.Setup(fm => fm.MapFM25_35_LearnerPeriod(_fundingOutputs)).Returns(fm25_35learnerPeriod);
            fm25MapperMock.Setup(fm => fm.MapFM25_35_LearnerPeriodisedValues(_fundingOutputs)).Returns(fm25_35learnerPeriodisedValues);

            return new StoreFM25(fm25MapperMock.Object, bulkInsert);
        }
    }
}
