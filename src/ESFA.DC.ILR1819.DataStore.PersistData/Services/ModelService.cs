using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services
{
    public class ModelService<T> : IModelService
    {
        private readonly IProviderService<T> _providerService;
        private readonly IStoreService<T> _storeService;
        private readonly ILogger _logger;

        public ModelService(IProviderService<T> providerService, IStoreService<T> storeService, ILogger logger)
        {
            _providerService = providerService;
            _storeService = storeService;
            _logger = logger;
        }

        public async Task GetAndStoreModel(IDataStoreContext dataStoreContext, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var fundingModelData = await _providerService.ProvideAsync(dataStoreContext, cancellationToken);

            if (fundingModelData == null)
            {
                _logger.LogDebug($"Failed to get model so not storing");
                return;
            }

            await _storeService.StoreAsync(transaction, dataStoreContext.Ukprn, fundingModelData, cancellationToken);
        }
    }
}
