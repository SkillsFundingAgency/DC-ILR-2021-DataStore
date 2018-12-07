using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
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
    public class TestStoreFM36 : AbstractStoreTest<FM36Global>
    {
        private static readonly int _ukprn = 10033660;
        private static readonly FM36Global _fundingOutputs = new JsonSerializationService().Deserialize<FM36Global>(File.ReadAllText(@"JsonOutputs/Fm36.json"));
        private static readonly IStoreService<FM36Global> StoreService = StoreFM36Setup();

        public TestStoreFM36()
          : base(StoreService)
        {
        }

        [Fact]
        public async Task StoreFM36()
        {
            await StoreTestAsync(_ukprn, _fundingOutputs, "FM36_Output");
        }

        protected override void ExecuteAssertions(FM36Global outputModel, int ukprn, SqlConnection sqlConnection)
        {
            using (SqlCommand sqlCommand = new SqlCommand($"SELECT Count(1) FROM Rulebase.AEC_LearningDelivery Where UKPRN = {ukprn} AND LearnRefNumber = '3DOB01'", sqlConnection))
            {
                Assert.Equal(outputModel.Learners.Where(l => l.LearnRefNumber == "3DOB01")?.Select(l => l.LearningDeliveries).Count() ?? 0, sqlCommand.ExecuteScalar());
            }
        }

        private static StoreFM36 StoreFM36Setup()
        {
            var fundingOutput =
            new AEC_global
            {
                UKPRN = _ukprn,
                AEC_Learner = new List<AEC_Learner>
                {
                    new AEC_Learner
                    {
                        LearnRefNumber = "3DOB01",
                        UKPRN = _ukprn,
                        AEC_LearningDelivery = new List<AEC_LearningDelivery>
                        {
                            new AEC_LearningDelivery
                            {
                                UKPRN = _ukprn,
                                LearnRefNumber = "3DOB01",
                                AimSeqNumber = 1,
                                AEC_LearningDelivery_Period = new List<AEC_LearningDelivery_Period>
                                {
                                    new AEC_LearningDelivery_Period
                                    {
                                        UKPRN = _ukprn,
                                        LearnRefNumber = "3DOB01",
                                        AimSeqNumber = 1,
                                        Period = 1
                                    }
                                },
                                AEC_LearningDelivery_PeriodisedValues = new List<AEC_LearningDelivery_PeriodisedValues>
                                {
                                    new AEC_LearningDelivery_PeriodisedValues
                                    {
                                        UKPRN = _ukprn,
                                        LearnRefNumber = "3DOB01",
                                        AimSeqNumber = 1,
                                        AttributeName = "Attribute1"
                                    }
                                },
                                AEC_LearningDelivery_PeriodisedTextValues = new List<AEC_LearningDelivery_PeriodisedTextValues>
                                {
                                    new AEC_LearningDelivery_PeriodisedTextValues
                                    {
                                        UKPRN = _ukprn,
                                        LearnRefNumber = "3DOB01",
                                        AimSeqNumber = 1,
                                        AttributeName = "Attribute1"
                                    }
                                }
                            }
                        },
                        AEC_ApprenticeshipPriceEpisode = new List<AEC_ApprenticeshipPriceEpisode>
                        {
                            new AEC_ApprenticeshipPriceEpisode
                            {
                                UKPRN = _ukprn,
                                LearnRefNumber = "3DOB01",
                                PriceEpisodeIdentifier = "1",
                                AEC_ApprenticeshipPriceEpisode_Period = new List<AEC_ApprenticeshipPriceEpisode_Period>
                                {
                                    new AEC_ApprenticeshipPriceEpisode_Period
                                    {
                                        UKPRN = _ukprn,
                                        LearnRefNumber = "3DOB01",
                                        PriceEpisodeIdentifier = "1",
                                        Period = 1
                                    }
                                },
                                AEC_ApprenticeshipPriceEpisode_PeriodisedValues = new List<AEC_ApprenticeshipPriceEpisode_PeriodisedValues>
                                {
                                    new AEC_ApprenticeshipPriceEpisode_PeriodisedValues
                                    {
                                        UKPRN = _ukprn,
                                        LearnRefNumber = "3DOB01",
                                        PriceEpisodeIdentifier = "1",
                                        AttributeName = "Attribute1"
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var global = fundingOutput;
            var learners = fundingOutput.AEC_Learner;
            var learningDeliveries = fundingOutput.AEC_Learner.SelectMany(ld => ld.AEC_LearningDelivery);
            var learningDeliveryPeriod = fundingOutput.AEC_Learner.SelectMany(ld => ld.AEC_LearningDelivery.SelectMany(p => p.AEC_LearningDelivery_Period));
            var learningDeliveryPeriodisedValues = fundingOutput.AEC_Learner.SelectMany(ld => ld.AEC_LearningDelivery.SelectMany(p => p.AEC_LearningDelivery_PeriodisedValues));
            var learningDeliveryPeriodisedTextValues = fundingOutput.AEC_Learner.SelectMany(ld => ld.AEC_LearningDelivery.SelectMany(p => p.AEC_LearningDelivery_PeriodisedTextValues));
            var priceEpisodes = fundingOutput.AEC_Learner.SelectMany(ld => ld.AEC_ApprenticeshipPriceEpisode);
            var priceEpisodePeriod = fundingOutput.AEC_Learner.SelectMany(ld => ld.AEC_ApprenticeshipPriceEpisode.SelectMany(p => p.AEC_ApprenticeshipPriceEpisode_Period));
            var priceEpisodePeriodisedValues = fundingOutput.AEC_Learner.SelectMany(ld => ld.AEC_ApprenticeshipPriceEpisode.SelectMany(p => p.AEC_ApprenticeshipPriceEpisode_PeriodisedValues));

            var fm36MapperMock = new Mock<IFM36Mapper>();
            IBulkInsert bulkInsert = new BulkInsert();

            fm36MapperMock.Setup(fm => fm.MapGlobal(_fundingOutputs)).Returns(global);
            fm36MapperMock.Setup(fm => fm.MapLearners(_fundingOutputs)).Returns(learners);
            fm36MapperMock.Setup(fm => fm.MapLearningDeliveries(_fundingOutputs)).Returns(learningDeliveries);
            fm36MapperMock.Setup(fm => fm.MapLearningDeliveryPeriods(_fundingOutputs)).Returns(learningDeliveryPeriod);
            fm36MapperMock.Setup(fm => fm.MapLearningDeliveryPeriodisedValues(_fundingOutputs)).Returns(learningDeliveryPeriodisedValues);
            fm36MapperMock.Setup(fm => fm.MapLearningDeliveryPeriodisedTextValues(_fundingOutputs)).Returns(learningDeliveryPeriodisedTextValues);
            fm36MapperMock.Setup(fm => fm.MapPriceEpisodes(_fundingOutputs)).Returns(priceEpisodes);
            fm36MapperMock.Setup(fm => fm.MapPriceEpisodePeriods(_fundingOutputs)).Returns(priceEpisodePeriod);
            fm36MapperMock.Setup(fm => fm.MapPriceEpisodePeriodisedValues(_fundingOutputs)).Returns(priceEpisodePeriodisedValues);

            return new StoreFM36(fm36MapperMock.Object, bulkInsert);
        }
    }
}
