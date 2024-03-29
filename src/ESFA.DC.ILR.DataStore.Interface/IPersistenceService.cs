﻿using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Interface
{
    public interface IPersistenceService
    {
        Task PersistValidationDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken);

        Task PersistFM25DataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken);

        Task PersistALBDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken);

        Task PersistFM35DataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken);

        Task PersistFM36DataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken);

        Task PersistFM81DataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken);

        Task PersistFM70DataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken);

        Task PersistFM36HistoryDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken);

        Task PersistValidLearnerDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken);

        Task PersistInvalidLearnerDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken);

        Task PersistProcessingInformationDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken);

        Task PersistESFSummarisationDataAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken);

        Task PersistESFLatestProviderSubmissionAsync(IDataStoreCache dataStoreCache, SqlConnection sqlConnection, SqlTransaction sqlTransaction, CancellationToken cancellationToken);
    }
}
