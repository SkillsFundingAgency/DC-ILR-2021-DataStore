using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IStoreFM81
    {
        Task StoreAsync(SqlConnection connection, SqlTransaction transaction, int ukPrn, FM81Global fundingOutputs, CancellationToken cancellationToken);
    }
}