using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Serialization.Interfaces;
using ESFA.DC.Serialization.Json;
using Moq;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test.Abstract
{
    public abstract class AbstractStoreTest<T>
    {
        private readonly IStoreService<T> _storeService;
        private readonly IStoreClear _storeClear = new StoreClear();
        private readonly IJsonSerializationService _jsonSerializationService = new JsonSerializationService();

        public async Task StoreTestAsync(int ukprn, string fileName, string outputKey)
        {
            CancellationToken cancellationToken = CancellationToken.None;
            var keyValuePersistenceServiceMock = new Mock<IKeyValuePersistenceService>();
            var serializationServiceMock = new Mock<ISerializationService>();
            var dataStoreContextMock = new Mock<IDataStoreContext>();
            dataStoreContextMock.SetupGet(c => c.Ukprn).Returns(ukprn);
            dataStoreContextMock.SetupGet(c => c.OriginalFilename).Returns(fileName);

            var outputModel = ReadAndDeserialiseAsync<T>(fileName, outputKey, keyValuePersistenceServiceMock, serializationServiceMock);

            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.AppSettings["TestConnectionString"]))
            {
                SqlTransaction transaction = null;
                try
                {
                    await connection.OpenAsync(cancellationToken);
                    transaction = connection.BeginTransaction();

                    await _storeClear.ClearAsync(dataStoreContextMock.Object, transaction, cancellationToken);

                    await _storeService.StoreAsync(connection, transaction, ukprn, outputModel, cancellationToken);

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
