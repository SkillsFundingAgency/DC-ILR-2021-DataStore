 using System.Data.SqlClient;
 using System.Threading;
 using System.Threading.Tasks;
 using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;

namespace ESFA.DC.ILR1819.DataStore.Interface.Service
{
    public interface IStoreFM36HistoryService
    {
        Task StoreAsync(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, FM36Global fundingOutputs, CancellationToken cancellationToken);
    }
}
