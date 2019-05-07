using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Model;
using ESFA.DC.ILR1819.DataStore.Model.File;
using ESFA.DC.ILR1819.DataStore.Model.Funding;
using ESFA.DC.ILR1819.DataStore.Model.History;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public class DataStorePersistenceService : IDataStorePersistenceService
    {
        private readonly IStoreClear _ilrStoreClear;
        private readonly IStoreFM36HistoryClear _fm36HistoryClear;
        private readonly IStoreService<ProcessingInformationData> _processingInformationDataStoreService;
        private readonly IStoreService<ValidHeaderData> _validHeaderDataStoreService;
        private readonly IStoreService<InvalidHeaderData> _invalidHeaderDataStoreService;
        private readonly IStoreService<ValidLearnerData> _validLearnerDataStoreService;
        private readonly IStoreService<InvalidLearnerData> _invalidLearnerDataStoreService;
        private readonly IStoreService<ValidationData> _validationDataStoreService;
        private readonly IStoreService<ALBData> _albDataStoreService;
        private readonly IStoreService<FM25Data> _fm25DataStoreService;
        private readonly IStoreService<FM35Data> _fm35DataStoreService;
        private readonly IStoreService<FM36Data> _fm36DataStoreService;
        private readonly IStoreService<FM70Data> _fm70DataStoreService;
        private readonly IStoreService<FM81Data> _fm81DataStoreService;
        private readonly IStoreService<FM36HistoryData> _fm36HistoryDataService;

        public DataStorePersistenceService(
            IStoreClear ilrStoreClear,
            IStoreFM36HistoryClear fm36HistoryClear,
            IStoreService<ProcessingInformationData> processingInformationDataStoreService,
            IStoreService<ValidHeaderData> validHeaderDataStoreService,
            IStoreService<InvalidHeaderData> invalidHeaderDataStoreService,
            IStoreService<ValidLearnerData> validLearnerDataStoreService,
            IStoreService<InvalidLearnerData> invalidLearnerDataStoreService,
            IStoreService<ValidationData> validationDataStoreService,
            IStoreService<ALBData> albDataStoreService,
            IStoreService<FM25Data> fm25DataStoreService,
            IStoreService<FM35Data> fm35DataStoreService,
            IStoreService<FM36Data> fm36DataStoreService,
            IStoreService<FM70Data> fm70DataStoreService,
            IStoreService<FM81Data> fm81DataStoreService,
            IStoreService<FM36HistoryData> fm36HistoryDataService)
        {
            _ilrStoreClear = ilrStoreClear;
            _fm36HistoryClear = fm36HistoryClear;
            _processingInformationDataStoreService = processingInformationDataStoreService;
            _validHeaderDataStoreService = validHeaderDataStoreService;
            _invalidHeaderDataStoreService = invalidHeaderDataStoreService;
            _validLearnerDataStoreService = validLearnerDataStoreService;
            _invalidLearnerDataStoreService = invalidLearnerDataStoreService;
            _validationDataStoreService = validationDataStoreService;
            _albDataStoreService = albDataStoreService;
            _fm25DataStoreService = fm25DataStoreService;
            _fm35DataStoreService = fm35DataStoreService;
            _fm36DataStoreService = fm36DataStoreService;
            _fm70DataStoreService = fm70DataStoreService;
            _fm81DataStoreService = fm81DataStoreService;
            _fm36HistoryDataService = fm36HistoryDataService;
        }

        public Task ClearIlrDataAsync(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, CancellationToken cancellationToken)
            => _ilrStoreClear.ClearAsync(dataStoreContext, sqlConnection, cancellationToken);

        public Task ClearFm36HistoryDataAsync(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, CancellationToken cancellationToken)
            => _fm36HistoryClear.ClearAsync(dataStoreContext, sqlConnection, cancellationToken);

        public Task StoreProcessingInformationDataAsync(ProcessingInformationData processingInformationData, SqlConnection sqlConnection, CancellationToken cancellationToken)
            => _processingInformationDataStoreService.StoreAsync(processingInformationData, sqlConnection, cancellationToken);

        public Task StoreValidHeaderDataAsync(ValidHeaderData validHeaderData, SqlConnection sqlConnection, CancellationToken cancellationToken)
            => _validHeaderDataStoreService.StoreAsync(validHeaderData, sqlConnection, cancellationToken);

        public Task StoreInvalidHeaderDataAsync(InvalidHeaderData invalidHeaderData, SqlConnection sqlConnection, CancellationToken cancellationToken)
            => _invalidHeaderDataStoreService.StoreAsync(invalidHeaderData, sqlConnection, cancellationToken);

        public Task StoreValidLearnerDataAsync(ValidLearnerData validLearnerData, SqlConnection sqlConnection, CancellationToken cancellationToken)
            => _validLearnerDataStoreService.StoreAsync(validLearnerData, sqlConnection, cancellationToken);

        public Task StoreInvalidLearnerDataAsync(InvalidLearnerData invalidLearnerData, SqlConnection sqlConnection, CancellationToken cancellationToken)
            => _invalidLearnerDataStoreService.StoreAsync(invalidLearnerData, sqlConnection, cancellationToken);

        public Task StoreValidationDataAsync(ValidationData validationData, SqlConnection sqlConnection, CancellationToken cancellationToken)
            => _validationDataStoreService.StoreAsync(validationData, sqlConnection, cancellationToken);

        public Task StoreALBDataAsync(ALBData albData, SqlConnection sqlConnection, CancellationToken cancellationToken)
            => _albDataStoreService.StoreAsync(albData, sqlConnection, cancellationToken);

        public Task StoreFM25DataAsync(FM25Data fm25Data, SqlConnection sqlConnection, CancellationToken cancellationToken)
            => _fm25DataStoreService.StoreAsync(fm25Data, sqlConnection, cancellationToken);

        public Task StoreFM35DataAsync(FM35Data fm35Data, SqlConnection sqlConnection, CancellationToken cancellationToken)
            => _fm35DataStoreService.StoreAsync(fm35Data, sqlConnection, cancellationToken);

        public Task StoreFM36DataAsync(FM36Data fm36Data, SqlConnection sqlConnection, CancellationToken cancellationToken)
            => _fm36DataStoreService.StoreAsync(fm36Data, sqlConnection, cancellationToken);

        public Task StoreFM70DataAsync(FM70Data fm70Data, SqlConnection sqlConnection, CancellationToken cancellationToken)
            => _fm70DataStoreService.StoreAsync(fm70Data, sqlConnection, cancellationToken);

        public Task StoreFM81DataAsync(FM81Data fm81Data, SqlConnection sqlConnection, CancellationToken cancellationToken)
            => _fm81DataStoreService.StoreAsync(fm81Data, sqlConnection, cancellationToken);

        public Task StoreFM36HistoryDataAsync(FM36HistoryData fm36HistoryData, SqlConnection sqlConnection, CancellationToken cancellationToken)
            => _fm36HistoryDataService.StoreAsync(fm36HistoryData, sqlConnection, cancellationToken);
    }
}
