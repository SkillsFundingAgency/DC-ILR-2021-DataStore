using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR1819.DataStore.Interface.Service
{
    public interface IValidLearnerProviderService
    {
        Task<List<string>> ReadAndDeserialiseValidLearnersAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken);
    }
}