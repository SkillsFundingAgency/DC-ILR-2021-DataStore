using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services
{
    public class FundModelService<T> : IFundModelService
    {
        private readonly IProviderService<T> _providerService;
        private readonly IStoreService<T> _storeService;
        private readonly ILogger _logger;

        public FundModelService(IProviderService<T> providerService, IStoreService<T> storeService, ILogger logger)
        {
            _providerService = providerService;
            _storeService = storeService;
            _logger = logger;
        }

        public async Task GetAndStoreFundModel(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, CancellationToken cancellationToken)
        {
            var fundingModelData = await _providerService.ProvideAsync(dataStoreContext, cancellationToken);

            if (fundingModelData == null)
            {
                _logger.LogDebug($"Failed to get model so not storing");
                return;
            }

            if (fundingModelData.GetType().GetProperty("Learners").GetValue(fundingModelData) == null)
            {
                _logger.LogDebug($"No " + fundingModelData.GetType().Name + " data to Persist");
                return;
            }

            await _storeService.StoreAsync(sqlConnection, fundingModelData, cancellationToken);
        }
    }
}
