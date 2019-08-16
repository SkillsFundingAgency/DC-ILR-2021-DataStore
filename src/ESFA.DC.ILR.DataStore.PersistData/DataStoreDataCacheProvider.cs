using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.PersistData
{
    public class DataStoreDataCacheProvider : IDataStoreDataCacheProvider
    {
        private readonly IDataStoreDataProvider _externalDataProvider;
        private readonly IDataStoreMapper _dataStoreMapper;
        private readonly ILogger _logger;

        public DataStoreDataCacheProvider(IDataStoreDataProvider externalDataProvider, IDataStoreMapper dataStoreMapper, ILogger logger)
        {
            _externalDataProvider = externalDataProvider;
            _dataStoreMapper = dataStoreMapper;
            _logger = logger;
        }

        public async Task<IDataStoreCache> ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            _logger.LogInfo("Starting External Data Provision Tasks");

            var messageTask = _externalDataProvider.ProvideMessageAsync(dataStoreContext, cancellationToken);
            var looseMessageTask = _externalDataProvider.ProvideLooseMessageAsync(dataStoreContext, cancellationToken);
            var validLearnerTask = _externalDataProvider.ProvideValidLearnersAsync(dataStoreContext, cancellationToken);
            var albTask = _externalDataProvider.ProvideALBAsync(dataStoreContext, cancellationToken);
            var fm25Task = _externalDataProvider.ProvideFM25Async(dataStoreContext, cancellationToken);
            var fm35Task = _externalDataProvider.ProvideFM35Async(dataStoreContext, cancellationToken);
            var fm36Task = _externalDataProvider.ProvideFM36Async(dataStoreContext, cancellationToken);
            var fm70Task = _externalDataProvider.ProvideFM70Async(dataStoreContext, cancellationToken);
            var fm81Task = _externalDataProvider.ProvideFM81Async(dataStoreContext, cancellationToken);
            var validationErrorsTask = _externalDataProvider.ProvideValidationErrorsAsync(dataStoreContext, cancellationToken);
            var rulesTask = _externalDataProvider.ProvideRulesAsync(dataStoreContext, cancellationToken);

            var tasks = new List<Task>()
            {
                messageTask,
                looseMessageTask,
                validLearnerTask,
                albTask,
                fm25Task,
                fm35Task,
                fm36Task,
                fm70Task,
                fm81Task,
                validationErrorsTask,
                rulesTask,
            };

            await Task.WhenAll(tasks);

            _logger.LogInfo("Data Provision Finished, starting Cache Mapping");

            var cache = new DataStoreCache();

            _dataStoreMapper.MapProcessingInformationData(cache, dataStoreContext);
            _dataStoreMapper.MapValidLearnerData(cache, messageTask.Result, validLearnerTask.Result);
            _dataStoreMapper.MapInvalidLearnerData(cache, looseMessageTask.Result, validLearnerTask.Result);
            _dataStoreMapper.MapALBData(cache, albTask.Result);
            _dataStoreMapper.MapFM25Data(cache, fm25Task.Result);
            _dataStoreMapper.MapFM35Data(cache, fm35Task.Result);
            _dataStoreMapper.MapFM36Data(cache, fm36Task.Result);
            _dataStoreMapper.MapFM70Data(cache, fm70Task.Result);
            _dataStoreMapper.MapFM81Data(cache, fm81Task.Result);
            _dataStoreMapper.MapFM36HistoryData(cache, fm36Task.Result, dataStoreContext);
            _dataStoreMapper.MapValidationData(cache, dataStoreContext, messageTask.Result, validationErrorsTask.Result, rulesTask.Result);
            _dataStoreMapper.MapESFSummarisationData(cache, dataStoreContext, messageTask.Result, fm70Task.Result);

            _logger.LogInfo("Cache Mapping Complete");

            return cache;
        }
    }
}
