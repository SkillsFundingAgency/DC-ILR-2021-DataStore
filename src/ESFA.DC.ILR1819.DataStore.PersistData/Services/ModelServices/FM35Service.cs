using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.JobContext.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services.ModelServices
{
    public class FM35Service : IModelService
    {
        private readonly IFM35ProviderService _providerService;
        private readonly IStoreFM35 _store;

        private FM35FundingOutputs _fundingModel;
        private int _ukPrn;

        public FM35Service(IFM35ProviderService providerService, IStoreFM35 store)
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
            await _store.StoreAsync(connection, transaction, _ukPrn, _fundingModel, cancellationToken);
        }
    }
}
