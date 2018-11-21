using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData.Test.Abstract;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test
{
    [Collection("StoreData Tests")]
    public class TestStoreFM81 : AbstractStoreTest<FM81Global>
    {
        public static readonly IStoreService<FM81Global> StoreService = new StoreFM81();

        public TestStoreFM81()
            : base(StoreService)
        {
        }

        [Fact]
        public async Task StoreFM81()
        {
            await StoreTestAsync(10000116, "JsonOutputs/Fm81.json", "FM81_Output");
        }

        protected override void ExecuteAssertions(FM81Global outputModel, int ukprn, SqlConnection sqlConnection)
        {
            using (SqlCommand sqlCommand = new SqlCommand($"SELECT Count(1) FROM Rulebase.TBL_LearningDelivery Where UKPRN = {ukprn} AND LearnRefNumber = '0fm8101'", sqlConnection))
            {
                Assert.Equal(outputModel.Learners.FirstOrDefault(l => l.LearnRefNumber == "0fm8101")?.LearningDeliveries.Count ?? 0, sqlCommand.ExecuteScalar());
            }
        }
    }
}
