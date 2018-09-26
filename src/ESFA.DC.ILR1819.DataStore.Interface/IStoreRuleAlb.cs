using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IStoreRuleAlb
    {
        Task StoreAsync(SqlConnection connection, SqlTransaction transaction, int ukPrn, ALBGlobal fundingOutputs, CancellationToken cancellationToken);
    }
}
