using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
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
    public class TestStoreFM70 : AbstractStoreTest<FM70Global>
    {
        private static readonly int _ukprn = 10001634;
        private static readonly FM70Global _fundingOutputs = new JsonSerializationService().Deserialize<FM70Global>(File.ReadAllText(@"JsonOutputs/FM70.json"));
        private static readonly IStoreService<FM70Global> StoreService = StoreFM70Setup();

        public TestStoreFM70()
          : base(StoreService)
        {
        }

        [Fact]
        public async Task StoreFM70()
        {
            await StoreTestAsync(_ukprn, _fundingOutputs, "FM70_Output");
        }

        protected override void ExecuteAssertions(FM70Global outputModel, int ukprn, SqlConnection sqlConnection)
        {
            using (SqlCommand sqlCommand = new SqlCommand($"SELECT Count(1) FROM Rulebase.ESF_LearningDelivery Where UKPRN = {ukprn} AND LearnRefNumber = '5DOB01'", sqlConnection))
            {
                Assert.Equal(outputModel.Learners.Where(l => l.LearnRefNumber == "5DOB01")?.Select(l => l.LearningDeliveries).Count() ?? 0, sqlCommand.ExecuteScalar());
            }
        }

        private static StoreFM70 StoreFM70Setup()
        {
           var fundingOutput =
           new ESF_global
           {
               UKPRN = _ukprn,
               ESF_Learner = new List<ESF_Learner>
               {
                    new ESF_Learner
                    {
                        LearnRefNumber = "5DOB01",
                        UKPRN = _ukprn,
                        ESF_LearningDelivery = new List<ESF_LearningDelivery>
                        {
                            new ESF_LearningDelivery
                            {
                                UKPRN = _ukprn,
                                LearnRefNumber = "5DOB01",
                                AimSeqNumber = 1,
                                ESF_LearningDeliveryDeliverable_Period = new List<ESF_LearningDeliveryDeliverable_Period>
                                {
                                    new ESF_LearningDeliveryDeliverable_Period
                                    {
                                        UKPRN = _ukprn,
                                        LearnRefNumber = "5DOB01",
                                        AimSeqNumber = 1,
                                        DeliverableCode = "2",
                                        Period = 1
                                    }
                                },
                                ESF_LearningDeliveryDeliverable = new List<ESF_LearningDeliveryDeliverable>
                                {
                                    new ESF_LearningDeliveryDeliverable
                                    {
                                        UKPRN = _ukprn,
                                        LearnRefNumber = "5DOB01",
                                        AimSeqNumber = 1,
                                        DeliverableCode = "2",
                                        ESF_LearningDeliveryDeliverable_PeriodisedValues = new List<ESF_LearningDeliveryDeliverable_PeriodisedValues>
                                        {
                                            new ESF_LearningDeliveryDeliverable_PeriodisedValues
                                            {
                                                UKPRN = _ukprn,
                                                LearnRefNumber = "5DOB01",
                                                AimSeqNumber = 1,
                                                DeliverableCode = "2",
                                                AttributeName = "Attribute1"
                                            }
                                        }
                                    }
                                },
                            }
                        }
                    }
               }
           };

            var global = fundingOutput;
            var learners = fundingOutput.ESF_Learner;
            var learnerDPOutcomes = new List<ESF_DPOutcome> { new ESF_DPOutcome { UKPRN = _ukprn, LearnRefNumber = "5DOB01" } };
            var learningDeliveries = fundingOutput.ESF_Learner.SelectMany(ld => ld.ESF_LearningDelivery);
            var learningDeliveryDeliverables = fundingOutput.ESF_Learner.SelectMany(ld => ld.ESF_LearningDelivery.SelectMany(p => p.ESF_LearningDeliveryDeliverable));
            var learningDeliveryDeliverablePeriod = fundingOutput.ESF_Learner.SelectMany(ld => ld.ESF_LearningDelivery.SelectMany(p => p.ESF_LearningDeliveryDeliverable_Period));
            var learningDeliveryDeliverablePeriodisedValues = fundingOutput.ESF_Learner.SelectMany(ld => ld.ESF_LearningDelivery.SelectMany(p => p.ESF_LearningDeliveryDeliverable).SelectMany(p => p.ESF_LearningDeliveryDeliverable_PeriodisedValues));

            var fm70MapperMock = new Mock<IFM70Mapper>();
            IBulkInsert bulkInsert = new BulkInsert();

            fm70MapperMock.Setup(fm => fm.MapGlobal(_fundingOutputs)).Returns(global);
            fm70MapperMock.Setup(fm => fm.MapLearners(_fundingOutputs)).Returns(learners);
            fm70MapperMock.Setup(fm => fm.MapLearningDeliveries(_fundingOutputs)).Returns(learningDeliveries);
            fm70MapperMock.Setup(fm => fm.MapLearningDeliveryDeliverables(_fundingOutputs)).Returns(learningDeliveryDeliverables);
            fm70MapperMock.Setup(fm => fm.MapLearningDeliveryDeliverablePeriods(_fundingOutputs)).Returns(learningDeliveryDeliverablePeriod);
            fm70MapperMock.Setup(fm => fm.MapLearningDeliveryDeliverablePeriodisedValues(_fundingOutputs)).Returns(learningDeliveryDeliverablePeriodisedValues);

            return new StoreFM70(fm70MapperMock.Object, bulkInsert);
        }
    }
}
