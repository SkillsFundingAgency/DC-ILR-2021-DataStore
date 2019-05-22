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

        public async Task<IDataStoreDataCache> ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            _logger.LogInfo("Starting External Data Provision Tasks");

            var messageTask = _externalDataProvider.ProvideMessageAsync(dataStoreContext, cancellationToken);
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

            var dataStoreDataCache = new DataStoreDataCache
            {
                ProcessingInformation = _dataStoreMapper.MapProcessingInformationData(dataStoreContext),
                ValidLearnerData = _dataStoreMapper.MapValidLearnerData(messageTask.Result, validLearnerTask.Result),
                InvalidLearnerData = _dataStoreMapper.MapInvalidLearnerData(messageTask.Result, validLearnerTask.Result),
                ALBData = _dataStoreMapper.MapALBData(albTask.Result),
                FM25Data = _dataStoreMapper.MapFM25Data(fm25Task.Result),
                FM35Data = _dataStoreMapper.MapFM35Data(fm35Task.Result),
                FM36Data = _dataStoreMapper.MapFM36Data(fm36Task.Result),
                FM70Data = _dataStoreMapper.MapFM70Data(fm70Task.Result),
                FM81Data = _dataStoreMapper.MapFM81Data(fm81Task.Result),
                FM36HistoryData = _dataStoreMapper.MapFM36HistoryData(fm36Task.Result, dataStoreContext),
                ValidationData = _dataStoreMapper.MapValidationData(dataStoreContext, messageTask.Result, validationErrorsTask.Result, rulesTask.Result)
            };

            _logger.LogInfo("Cache Mapping Complete");

            return dataStoreDataCache;
        }
    }
}
