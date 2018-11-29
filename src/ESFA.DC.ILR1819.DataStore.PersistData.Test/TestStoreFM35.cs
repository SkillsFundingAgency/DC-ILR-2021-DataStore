using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
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
    public class TestStoreFM35 : AbstractStoreTest<FM35Global>
    {
        private static readonly int _ukprn = 10033672;
        private static readonly FM35Global _fundingOutputs = new JsonSerializationService().Deserialize<FM35Global>(File.ReadAllText(@"JsonOutputs/Fm35.json"));
        private static readonly IStoreService<FM35Global> StoreService = StoreFM35Setup();

        public TestStoreFM35()
          : base(StoreService)
        {
        }

        [Fact]
        public async Task StoreFM35()
        {
            await StoreTestAsync(_ukprn, _fundingOutputs, "FM35_Output");
        }

        protected override void ExecuteAssertions(FM35Global outputModel, int ukprn, SqlConnection sqlConnection)
        {
            using (SqlCommand sqlCommand = new SqlCommand($"SELECT Count(1) FROM Rulebase.FM35_LearningDelivery Where UKPRN = {ukprn} AND LearnRefNumber = '0Accm01'", sqlConnection))
            {
                Assert.Equal(outputModel.Learners.Where(l => l.LearnRefNumber == "0Accm01")?.Select(l => l.LearningDeliveries).Count() ?? 0, sqlCommand.ExecuteScalar());
            }
        }

        private static StoreFM35 StoreFM35Setup()
        {
           var fundingOutput =
           new FM35_global
           {
               UKPRN = _ukprn,
               FM35_Learner = new List<FM35_Learner>
               {
                    new FM35_Learner
                    {
                        LearnRefNumber = "0Accm01",
                        UKPRN = _ukprn,
                        FM35_LearningDelivery = new List<FM35_LearningDelivery>
                        {
                            new FM35_LearningDelivery
                            {
                                UKPRN = _ukprn,
                                LearnRefNumber = "0Accm01",
                                AimSeqNumber = 1,
                                FM35_LearningDelivery_Period = new List<FM35_LearningDelivery_Period>
                                {
                                    new FM35_LearningDelivery_Period
                                    {
                                        UKPRN = _ukprn,
                                        LearnRefNumber = "0Accm01",
                                        AimSeqNumber = 1,
                                        Period = 1
                                    }
                                },
                                FM35_LearningDelivery_PeriodisedValues = new List<FM35_LearningDelivery_PeriodisedValues>
                                {
                                    new FM35_LearningDelivery_PeriodisedValues
                                    {
                                        UKPRN = _ukprn,
                                        LearnRefNumber = "0Accm01",
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
            var learners = fundingOutput.FM35_Learner;
            var learningDeliveries = fundingOutput.FM35_Learner.SelectMany(ld => ld.FM35_LearningDelivery);
            var learningDeliveryPeriod = fundingOutput.FM35_Learner.SelectMany(ld => ld.FM35_LearningDelivery.SelectMany(p => p.FM35_LearningDelivery_Period));
            var learningDeliveryPeriodisedValues = fundingOutput.FM35_Learner.SelectMany(ld => ld.FM35_LearningDelivery.SelectMany(p => p.FM35_LearningDelivery_PeriodisedValues));

            var fm35MapperMock = new Mock<IFM35Mapper>();
            IBulkInsert bulkInsert = new BulkInsert();

            fm35MapperMock.Setup(fm => fm.MapGlobal(_fundingOutputs)).Returns(global);
            fm35MapperMock.Setup(fm => fm.MapLearners(_fundingOutputs)).Returns(learners);
            fm35MapperMock.Setup(fm => fm.MapLearningDeliveries(_fundingOutputs)).Returns(learningDeliveries);
            fm35MapperMock.Setup(fm => fm.MapLearningDeliveryPeriods(_fundingOutputs)).Returns(learningDeliveryPeriod);
            fm35MapperMock.Setup(fm => fm.MapLearningDeliveryPeriodisedValues(_fundingOutputs)).Returns(learningDeliveryPeriodisedValues);

            return new StoreFM35(fm35MapperMock.Object, bulkInsert);
        }
    }
}
