using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.PersistData.Test.Abstract;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test
{
    public class TestStoreFM36 : AbstractStoreTest<FM36Global>
    {
        [Fact]
        public async Task StoreFM36()
        {
            await StoreTestAsync(10033670, "Fm36.json", "FM36_Output");
        }

        protected override void ExecuteAssertions(FM36Global outputModel, int ukprn, SqlConnection sqlConnection)
        {
            using (SqlCommand sqlCommand = new SqlCommand($"SELECT Count(1) FROM Rulebase.AEC_LearningDelivery Where LearnRefNumber = '3DOB01'", sqlConnection))
            {
                Assert.Equal(outputModel.Learners.FirstOrDefault(l => l.LearnRefNumber == "3DOB01")?.LearningDeliveries.Count ?? 0, sqlCommand.ExecuteScalar());
            }
        }
    }
}
