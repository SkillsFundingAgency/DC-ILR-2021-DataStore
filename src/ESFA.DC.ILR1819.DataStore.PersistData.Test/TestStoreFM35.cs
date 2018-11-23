using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.Model;
using ESFA.DC.ILR1819.DataStore.PersistData.Persist;
using ESFA.DC.ILR1819.DataStore.PersistData.Test.Abstract;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test
{
    [Collection("StoreData Tests")]
    public class TestStoreFM35 : AbstractStoreTest<IEnumerable<FM35_global>>
    {
        public static readonly IStoreService<IEnumerable<FM35_global>> StoreService = new StoreFM35();
        public static int _ukprn = 12345678;

        public static readonly IEnumerable<FM35_global> RulebaseData = new List<FM35_global>
        {
            new FM35_global
            {
                UKPRN = _ukprn,
                FM35_Learner = new List<FM35_Learner>
                {
                    new FM35_Learner
                    {
                        LearnRefNumber = "FM35_Learner",
                        UKPRN = _ukprn,
                        FM35_LearningDelivery = new List<FM35_LearningDelivery>
                        {
                            new FM35_LearningDelivery
                            {
                                UKPRN = _ukprn,
                                LearnRefNumber = "FM35_Learner",
                                AimSeqNumber = 1,
                                FM35_LearningDelivery_Period = new List<FM35_LearningDelivery_Period>
                                {
                                    new FM35_LearningDelivery_Period
                                    {
                                        UKPRN = _ukprn,
                                        LearnRefNumber = "FM35_Learner",
                                        AimSeqNumber = 1,
                                        Period = 1
                                    }
                                },
                                FM35_LearningDelivery_PeriodisedValues = new List<FM35_LearningDelivery_PeriodisedValues>
                                {
                                    new FM35_LearningDelivery_PeriodisedValues
                                    {
                                        UKPRN = _ukprn,
                                        LearnRefNumber = "FM35_Learner",
                                        AimSeqNumber = 1,
                                        AttributeName = "Attribute1"
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };

        public TestStoreFM35()
          : base(StoreService)
        {
        }

        [Fact]
        public async Task StoreFM35()
        {
            await StoreTestAsync(_ukprn, RulebaseData, "FM35_File");
        }

        protected override void ExecuteAssertions(IEnumerable<FM35_global> outputModel, int ukprn, SqlConnection sqlConnection)
        {
            using (SqlCommand sqlCommand = new SqlCommand($"SELECT Count(1) FROM Rulebase.FM35_LearningDelivery Where UKPRN = {ukprn} AND LearnRefNumber = 'FM35_Learner'", sqlConnection))
            {
                var t = outputModel.SelectMany(g => g.FM35_Learner).FirstOrDefault(l => l.LearnRefNumber == "FM35_Learner")?.FM35_LearningDelivery.Count;
                var f = sqlCommand.ExecuteScalar();

                Assert.Equal(outputModel.SelectMany(g => g.FM35_Learner).FirstOrDefault(l => l.LearnRefNumber == "FM35_Learner")?.FM35_LearningDelivery.Count ?? 0, sqlCommand.ExecuteScalar());
            }
        }
    }
}
