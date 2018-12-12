using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IFundModelService
    {
        Task GetAndStoreFundModel(IDataStoreContext dataStoreContext, SqlTransaction transaction, CancellationToken cancellationToken);
    }
}