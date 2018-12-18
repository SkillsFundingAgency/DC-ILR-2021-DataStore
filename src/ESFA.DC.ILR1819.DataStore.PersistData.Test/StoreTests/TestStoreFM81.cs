using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Mappers;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData.Persist;
using ESFA.DC.ILR1819.DataStore.PersistData.Test.Abstract;
using ESFA.DC.Serialization.Json;
using Moq;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test.StoreTests
{
    [Collection("StoreData Tests")]
    public class TestStoreFM81 : AbstractIlrStoreTest<FM81Global>
    {
        private static readonly int _ukprn = 10000116;
        private static readonly FM81Global _fundingOutputs = new JsonSerializationService().Deserialize<FM81Global>(File.ReadAllText(@"JsonOutputs/Fm81.json"));
        private static readonly IStoreService<FM81Global> StoreService = StoreFM81Setup();

        public TestStoreFM81()
          : base(StoreService)
        {
        }

        [Fact]
        public async Task StoreFM81()
        {
            await StoreTestAsync(_ukprn, _fundingOutputs, "FM81_Output");
        }

        protected override void ExecuteAssertions(FM81Global outputModel, int ukprn, SqlConnection sqlConnection)
        {
            using (SqlCommand sqlCommand = new SqlCommand($"SELECT Count(1) FROM Rulebase.TBL_LearningDelivery Where UKPRN = {ukprn} AND LearnRefNumber = '5fwc01'", sqlConnection))
            {
                Assert.Equal(outputModel.Learners.Where(l => l.LearnRefNumber == "5fwc01")?.Select(l => l.LearningDeliveries).Count() ?? 0, sqlCommand.ExecuteScalar());
            }
        }

        private static StoreFM81 StoreFM81Setup()
        {
            var fundingOutput =
            new TBL_global
            {
                UKPRN = _ukprn,
                TBL_Learner = new List<TBL_Learner>
                {
                    new TBL_Learner
                    {
                        LearnRefNumber = "5fwc01",
                        UKPRN = _ukprn,
                        TBL_LearningDelivery = new List<TBL_LearningDelivery>
                        {
                            new TBL_LearningDelivery
                            {
                                UKPRN = _ukprn,
                                LearnRefNumber = "5fwc01",
                                AimSeqNumber = 1,
                                TBL_LearningDelivery_Period = new List<TBL_LearningDelivery_Period>
                                {
                                    new TBL_LearningDelivery_Period
                                    {
                                        UKPRN = _ukprn,
                                        LearnRefNumber = "5fwc01",
                                        AimSeqNumber = 1,
                                        Period = 1
                                    }
                                },
                                TBL_LearningDelivery_PeriodisedValues = new List<TBL_LearningDelivery_PeriodisedValues>
                                {
                                    new TBL_LearningDelivery_PeriodisedValues
                                    {
                                        UKPRN = _ukprn,
                                        LearnRefNumber = "5fwc01",
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
            var learners = fundingOutput.TBL_Learner;
            var learningDeliveries = fundingOutput.TBL_Learner.SelectMany(ld => ld.TBL_LearningDelivery);
            var learningDeliveryPeriod = fundingOutput.TBL_Learner.SelectMany(ld => ld.TBL_LearningDelivery.SelectMany(p => p.TBL_LearningDelivery_Period));
            var learningDeliveryPeriodisedValues = fundingOutput.TBL_Learner.SelectMany(ld => ld.TBL_LearningDelivery.SelectMany(p => p.TBL_LearningDelivery_PeriodisedValues));

            var fm81MapperMock = new Mock<IFM81Mapper>();
            IBulkInsert bulkInsert = new BulkInsert();

            fm81MapperMock.Setup(fm => fm.MapGlobal(_fundingOutputs)).Returns(global);
            fm81MapperMock.Setup(fm => fm.MapLearners(_fundingOutputs)).Returns(learners);
            fm81MapperMock.Setup(fm => fm.MapLearningDeliveries(_fundingOutputs)).Returns(learningDeliveries);
            fm81MapperMock.Setup(fm => fm.MapLearningDeliveryPeriods(_fundingOutputs)).Returns(learningDeliveryPeriod);
            fm81MapperMock.Setup(fm => fm.MapLearningDeliveryPeriodisedValues(_fundingOutputs)).Returns(learningDeliveryPeriodisedValues);

            return new StoreFM81(fm81MapperMock.Object, bulkInsert);
        }
    }
}
