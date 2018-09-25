using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.JobContext.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services.ModelServices
{
    public class FM25Service : IModelService
    {
        private readonly IFM25ProviderService _providerService;
        private readonly IStoreFM25 _store;

        private FM25Global _fundingModel;
        private int _ukPrn;

        public FM25Service(IFM25ProviderService providerService, IStoreFM25 store)
        {
            _providerService = providerService;
            _store = store;
        }

        public async Task<bool> GetModel(IJobContextMessage jobContextMessage, CancellationToken cancellationToken)
        {
            _ukPrn = int.Parse(jobContextMessage.KeyValuePairs[JobContextMessageKey.UkPrn].ToString());
            _fundingModel = await _providerService.ReadAndDeserialiseFileAsync(jobContextMessage, cancellationToken);

            return _fundingModel != null;
        }

        public async Task StoreModel(SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (_fundingModel == null)
            {
                return;
            }

            await _store.StoreAsync(connection, transaction, _ukPrn, _fundingModel, cancellationToken);
        }
    }
}
