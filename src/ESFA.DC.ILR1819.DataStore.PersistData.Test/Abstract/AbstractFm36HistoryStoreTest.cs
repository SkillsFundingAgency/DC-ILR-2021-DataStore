using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData.Persist;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Serialization.Interfaces;
using ESFA.DC.Serialization.Json;
using Moq;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test.Abstract
{
    public abstract class AbstractFm36HistoryStoreTest<T>
    {
        private readonly IStoreFM36HistoryService<T> _storeService;
        private readonly IStoreFM36HistoryClear _storeClear = new StoreFM36HistoryClear();
        private readonly IJsonSerializationService _jsonSerializationService = new JsonSerializationService();

        protected AbstractFm36HistoryStoreTest(IStoreFM36HistoryService<T> storeService)
        {
            _storeService = storeService;
        }

        public async Task StoreTestAsync(int ukprn, string fileName, string outputKey)
        {
            CancellationToken cancellationToken = CancellationToken.None;
            var keyValuePersistenceServiceMock = new Mock<IKeyValuePersistenceService>();
            var serializationServiceMock = new Mock<ISerializationService>();
            var dataStoreContextMock = new Mock<IDataStoreContext>();
            dataStoreContextMock.SetupGet(c => c.Ukprn).Returns(ukprn);
            dataStoreContextMock.SetupGet(c => c.OriginalFilename).Returns(fileName);
            dataStoreContextMock.SetupGet(c => c.ReturnCode).Returns("01");
            dataStoreContextMock.SetupGet(c => c.CollectionYear).Returns("1819");

            var outputModel = ReadAndDeserialiseAsync<T>(fileName, outputKey, keyValuePersistenceServiceMock, serializationServiceMock);

            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.AppSettings["Fm36HistoryTestConnectionString"]))
            {
                SqlTransaction transaction = null;
                try
                {
                    await connection.OpenAsync(cancellationToken);
                    transaction = connection.BeginTransaction();

                    await _storeClear.ClearAsync(dataStoreContextMock.Object, transaction, cancellationToken);

                    await _storeService.StoreAsync(dataStoreContextMock.Object, transaction, outputModel, cancellationToken);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    throw;
                }

                ExecuteAssertions(outputModel, ukprn, connection);
            }
        }

        public async Task StoreTestAsync(int ukprn, T model, string fileName)
        {
            CancellationToken cancellationToken = CancellationToken.None;
            var dataStoreContextMock = new Mock<IDataStoreContext>();
            dataStoreContextMock.SetupGet(c => c.Ukprn).Returns(ukprn);
            dataStoreContextMock.SetupGet(c => c.OriginalFilename).Returns(fileName);
            dataStoreContextMock.SetupGet(c => c.ReturnCode).Returns("01");
            dataStoreContextMock.SetupGet(c => c.CollectionYear).Returns("1819");

            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.AppSettings["Fm36HistoryTestConnectionString"]))
            {
                SqlTransaction transaction = null;
                try
                {
                    await connection.OpenAsync(cancellationToken);
                    transaction = connection.BeginTransaction();

                    await _storeClear.ClearAsync(dataStoreContextMock.Object, transaction, cancellationToken);

                    await _storeService.StoreAsync(dataStoreContextMock.Object, transaction, model, cancellationToken);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    throw;
                }

                ExecuteAssertions(model, ukprn, connection);
            }
        }

        protected abstract void ExecuteAssertions(T outputModel, int ukprn, SqlConnection sqlConnection);

        private T ReadAndDeserialiseAsync<T>(
            string filename,
            string outputKey,
            Mock<IKeyValuePersistenceService> keyValuePersistenceServiceMock,
            Mock<ISerializationService> serialiseServiceMock)
        {
            string fileContent = File.ReadAllText(filename);

            T fundingOutputs = _jsonSerializationService.Deserialize<T>(fileContent);

            keyValuePersistenceServiceMock.Setup(x => x.GetAsync(outputKey, It.IsAny<CancellationToken>())).ReturnsAsync(fileContent);

            serialiseServiceMock.Setup(x => x.Deserialize<T>(fileContent)).Returns(fundingOutputs);

            return fundingOutputs;
        }
    }
}
