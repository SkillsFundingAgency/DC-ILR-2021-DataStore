using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.JobContextManager.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services.ModelServices
{
    public class FM81Service : IModelService
    {
        private readonly IFM81ProviderService _providerService;
        private readonly IStoreFM81 _store;

        private FM81Global _fundingModel;
        private int _ukPrn;

        public FM81Service(IFM81ProviderService providerService, IStoreFM81 store)
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
