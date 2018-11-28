using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData.Persist;
using ESFA.DC.ILR1819.DataStore.PersistData.Test.Abstract;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test
{
    [Collection("StoreData Tests")]
    public class TestStoreALB : AbstractStoreTest<ALBGlobal>
    {
        public static readonly IStoreService<ALBGlobal> StoreService = new StoreALB();

        public TestStoreALB()
            : base(StoreService)
        {
        }

        [Fact]
        public async Task StoreALB()
        {
            await StoreTestAsync(10033670, "JsonOutputs/ALB.json", "ALB_Output");
        }

        protected override void ExecuteAssertions(ALBGlobal outputModel, int ukprn, SqlConnection sqlConnection)
        {
            using (SqlCommand sqlCommand = new SqlCommand($"SELECT Count(1) FROM Rulebase.ALB_LearningDelivery Where UKPRN = {ukprn} AND LearnRefNumber = '0ALB01'", sqlConnection))
            {
                Assert.Equal(outputModel.Learners.FirstOrDefault(l => l.LearnRefNumber == "0ALB01")?.LearningDeliveries.Count ?? 0, sqlCommand.ExecuteScalar());
            }
        }
    }
}
