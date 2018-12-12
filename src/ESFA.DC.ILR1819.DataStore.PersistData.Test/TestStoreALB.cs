using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
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
    public class TestStoreALB : AbstractStoreTest<ALBGlobal>
    {
        private static readonly int _ukprn = 10033670;
        private static readonly ALBGlobal _fundingOutputs = new JsonSerializationService().Deserialize<ALBGlobal>(File.ReadAllText(@"JsonOutputs/ALB.json"));
        private static readonly IStoreService<ALBGlobal> StoreService = StoreALBSetup();

        public TestStoreALB()
            : base(StoreService)
        {
        }

        [Fact]
        public async Task StoreALB()
        {
            await StoreTestAsync(_ukprn, _fundingOutputs, "ALB_Output");
        }

        protected override void ExecuteAssertions(ALBGlobal outputModel, int ukprn, SqlConnection sqlConnection)
        {
            using (SqlCommand sqlCommand = new SqlCommand($"SELECT Count(1) FROM Rulebase.ALB_LearningDelivery Where UKPRN = {ukprn} AND LearnRefNumber = '0ALB01'", sqlConnection))
            {
                Assert.Equal(outputModel.Learners.FirstOrDefault(l => l.LearnRefNumber == "0ALB01")?.LearningDeliveries.Count ?? 0, sqlCommand.ExecuteScalar());
            }
        }

        private static StoreALB StoreALBSetup()
        {
            var fundingOutput =
            new ALB_global
            {
                UKPRN = _ukprn,
                ALB_Learner = new List<ALB_Learner>
                {
                      new ALB_Learner
                      {
                          LearnRefNumber = "0ALB01",
                          UKPRN = _ukprn,
                          ALB_Learner_Period = new List<ALB_Learner_Period>
                          {
                              new ALB_Learner_Period
                              {
                                  LearnRefNumber = "0ALB01",
                                  UKPRN = _ukprn,
                                  Period = 1,
                                  ALBSeqNum = 1
                              }
                          },
                          ALB_Learner_PeriodisedValues = new List<ALB_Learner_PeriodisedValues>
                          {
                              new ALB_Learner_PeriodisedValues
                              {
                                  LearnRefNumber = "0ALB01",
                                  UKPRN = _ukprn,
                                  AttributeName = "ALBSeqNum",
                                  Period_1 = 1.0m,
                                  Period_2 = 1.0m,
                                  Period_3 = 1.0m,
                                  Period_4 = 1.0m,
                                  Period_5 = 1.0m,
                                  Period_6 = 1.0m,
                                  Period_7 = 1.0m,
                                  Period_8 = 1.0m,
                                  Period_9 = 1.0m,
                                  Period_10 = 1.0m,
                                  Period_11 = 1.0m,
                                  Period_12 = 1.0m,
                              }
                          },
                          ALB_LearningDelivery = new List<ALB_LearningDelivery>
                          {
                              new ALB_LearningDelivery
                              {
                                  UKPRN = _ukprn,
                                  LearnRefNumber = "0ALB01",
                                  AimSeqNumber = 1,
                                  ALB_LearningDelivery_Period = new List<ALB_LearningDelivery_Period>
                                  {
                                      new ALB_LearningDelivery_Period
                                      {
                                          UKPRN = _ukprn,
                                          LearnRefNumber = "0ALB01",
                                          AimSeqNumber = 1,
                                          Period = 1
                                      }
                                  },
                                  ALB_LearningDelivery_PeriodisedValues = new List<ALB_LearningDelivery_PeriodisedValues>
                                  {
                                      new ALB_LearningDelivery_PeriodisedValues
                                      {
                                          UKPRN = _ukprn,
                                          LearnRefNumber = "0ALB01",
                                          AimSeqNumber = 1,
                                          AttributeName = "Attribute1"
                                      }
                                  }
                              }
                          }
                      }
                }
            };

            var global = fundingOutput;
            var learners = fundingOutput.ALB_Learner;
            var learnerPeriods = fundingOutput.ALB_Learner.SelectMany(l => l.ALB_Learner_Period);
            var learnerPeriodisedValues = fundingOutput.ALB_Learner.SelectMany(l => l.ALB_Learner_PeriodisedValues);
            var learningDeliveries = fundingOutput.ALB_Learner.SelectMany(ld => ld.ALB_LearningDelivery);
            var learningDeliveryPeriod = fundingOutput.ALB_Learner.SelectMany(ld => ld.ALB_LearningDelivery.SelectMany(p => p.ALB_LearningDelivery_Period));
            var learningDeliveryPeriodisedValues = fundingOutput.ALB_Learner.SelectMany(ld => ld.ALB_LearningDelivery.SelectMany(p => p.ALB_LearningDelivery_PeriodisedValues));

            var albMapperMock = new Mock<IALBMapper>();
            IBulkInsert bulkInsert = new BulkInsert();

            albMapperMock.Setup(fm => fm.MapGlobal(_fundingOutputs)).Returns(global);
            albMapperMock.Setup(fm => fm.MapLearners(_fundingOutputs)).Returns(learners);
            albMapperMock.Setup(fm => fm.MapLearnerPeriods(_fundingOutputs)).Returns(learnerPeriods);
            albMapperMock.Setup(fm => fm.MapLearnerPeriodisedValues(_fundingOutputs)).Returns(learnerPeriodisedValues);
            albMapperMock.Setup(fm => fm.MapLearningDeliveries(_fundingOutputs)).Returns(learningDeliveries);
            albMapperMock.Setup(fm => fm.MapLearningDeliveryPeriods(_fundingOutputs)).Returns(learningDeliveryPeriod);
            albMapperMock.Setup(fm => fm.MapLearningDeliveryPeriodisedValues(_fundingOutputs)).Returns(learningDeliveryPeriodisedValues);

            return new StoreALB(albMapperMock.Object, bulkInsert);
        }
    }
}
