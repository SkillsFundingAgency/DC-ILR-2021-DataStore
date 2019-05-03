using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR1819.DataStore.Model.File;
using ESFA.DC.ILR1819.DataStore.Model.Funding;
using ESFA.DC.ILR1819.DataStore.Model.History;

namespace ESFA.DC.ILR.DataStore.Interface
{
    public interface IDataStorePersistenceService
    {
        Task ClearIlrDataAsync(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, CancellationToken cancellationToken);

        Task ClearFm36HistoryDataAsync(IDataStoreContext dataStoreContext, SqlConnection sqlConnection, CancellationToken cancellationToken);

        Task StoreProcessingInformationDataAsync(ProcessingInformationData processingInformationData, SqlConnection sqlConnection, CancellationToken cancellationToken);

        Task StoreValidHeaderDataAsync(ValidHeaderData validHeaderData, SqlConnection sqlConnection, CancellationToken cancellationToken);

        Task StoreInvalidHeaderDataAsync(InvalidHeaderData invalidHeaderData, SqlConnection sqlConnection, CancellationToken cancellationToken);

        Task StoreValidLearnerDataAsync(ValidLearnerData validLearnerData, SqlConnection sqlConnection, CancellationToken cancellationToken);

        Task StoreInvalidLearnerDataAsync(InvalidLearnerData invalidLearnerData, SqlConnection sqlConnection, CancellationToken cancellationToken);

        Task StoreValidationDataAsync(ValidationData validationData, SqlConnection sqlConnection, CancellationToken cancellationToken);

        Task StoreALBDataAsync(ALBData albData, SqlConnection sqlConnection, CancellationToken cancellationToken);

        Task StoreFM25DataAsync(FM25Data fm25Data, SqlConnection sqlConnection, CancellationToken cancellationToken);

        Task StoreFM35DataAsync(FM35Data fm35Data, SqlConnection sqlConnection, CancellationToken cancellationToken);

        Task StoreFM36DataAsync(FM36Data fm36Data, SqlConnection sqlConnection, CancellationToken cancellationToken);

        Task StoreFM70DataAsync(FM70Data fm70Data, SqlConnection sqlConnection, CancellationToken cancellationToken);

        Task StoreFM81DataAsync(FM81Data fm81Data, SqlConnection sqlConnection, CancellationToken cancellationToken);

        Task StoreFM36HistoryDataAsync(FM36HistoryData fm36HistoryData, SqlConnection sqlConnection, CancellationToken cancellationToken);
    }
}
