using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IStoreFM70
    {
        Task StoreAsync(SqlConnection connection, SqlTransaction transaction, int ukPrn, FM70Global fundingOutputs, CancellationToken cancellationToken);
    }
}