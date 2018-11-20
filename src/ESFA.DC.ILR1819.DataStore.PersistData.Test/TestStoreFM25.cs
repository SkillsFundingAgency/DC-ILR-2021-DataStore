using System.Data.SqlClient;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData.Test.Abstract;
using Xunit;
using Xunit.Abstractions;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test
{
    public class TestStoreFM25 : AbstractStoreTest<FM25Global>
    {
        public static readonly IStoreService<FM25Global> StoreService = new StoreFM25();

        public TestStoreFM25()
            : base(StoreService)
        {
        }

        [Fact]
        public async Task StoreFM25()
        {
            await StoreTestAsync(10033677, "Fm25.json", "FM25_Output");
        }

        protected override void ExecuteAssertions(FM25Global outputModel, int ukprn, SqlConnection sqlConnection)
        {
            using (SqlCommand sqlCommand = new SqlCommand($"SELECT Count(1) FROM Rulebase.FM25_Learner Where UKPRN = {ukprn}", sqlConnection))
            {
                Assert.Equal(outputModel.Learners.Count, sqlCommand.ExecuteScalar());
            }
        }
    }
}
