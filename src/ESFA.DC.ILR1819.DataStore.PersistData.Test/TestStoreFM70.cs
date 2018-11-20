using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.PersistData.Test.Abstract;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test
{
    public class TestStoreFM70 : AbstractStoreTest<FM70Global>
    {
        [Fact]
        public async Task StoreFM70()
        {
            await StoreTestAsync(10033670, "Fm70.json", "FM70_Output");
        }

        protected override void ExecuteAssertions(FM70Global outputModel, int ukprn, SqlConnection sqlConnection)
        {
            using (SqlCommand sqlCommand = new SqlCommand($"SELECT Count(1) FROM Rulebase.ESF_LearningDelivery Where LearnRefNumber = '0DOB43'", sqlConnection))
            {
                Assert.Equal(outputModel.Learners.FirstOrDefault(l => l.LearnRefNumber == "0DOB43")?.LearningDeliveries.Count ?? 0, sqlCommand.ExecuteScalar());
            }
        }
    }
}
