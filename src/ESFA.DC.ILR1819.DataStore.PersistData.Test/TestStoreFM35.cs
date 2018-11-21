using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData.Test.Abstract;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test
{
    public class TestStoreFM35 : AbstractStoreTest<FM35Global>
    {
        public static readonly IStoreService<FM35Global> StoreService = new StoreFM35();

        public TestStoreFM35()
            : base(StoreService)
        {
        }

        [Fact]
        public async Task StoreFM35()
        {
            await StoreTestAsync(10033672, "JsonOutputs/Fm35.json", "FM35_Output");
        }

        protected override void ExecuteAssertions(FM35Global outputModel, int ukprn, SqlConnection sqlConnection)
        {
            using (SqlCommand sqlCommand = new SqlCommand($"SELECT Count(1) FROM Rulebase.FM35_LearningDelivery Where UKPRN = {ukprn} AND LearnRefNumber = '0fm3501'", sqlConnection))
            {
                Assert.Equal(outputModel.Learners.FirstOrDefault(l => l.LearnRefNumber == "0fm3501")?.LearningDeliveries.Count ?? 0, sqlCommand.ExecuteScalar());
            }
        }
    }
}
