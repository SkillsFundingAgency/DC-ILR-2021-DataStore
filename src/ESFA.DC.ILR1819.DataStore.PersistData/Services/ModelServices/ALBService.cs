using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.JobContext.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services.ModelServices
{
    public class ALBService : IModelService
    {
        private readonly IALBProviderService _providerService;
        private readonly IStoreRuleAlb _store;

        private ALBFundingOutputs _fundingModel;
        private int _ukPrn;

        public ALBService(IALBProviderService providerService, IStoreRuleAlb store)
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
