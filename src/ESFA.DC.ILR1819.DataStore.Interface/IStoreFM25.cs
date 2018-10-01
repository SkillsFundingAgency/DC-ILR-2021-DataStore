using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IStoreFM25
    {
        Task StoreAsync(SqlConnection connection, SqlTransaction transaction, int ukPrn, FM25Global fundingOutputs, CancellationToken cancellationToken);
    }
}