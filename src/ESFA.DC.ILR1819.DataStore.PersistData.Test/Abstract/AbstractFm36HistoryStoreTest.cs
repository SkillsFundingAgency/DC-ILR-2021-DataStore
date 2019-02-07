using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData.Persist;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Serialization.Interfaces;
using ESFA.DC.Serialization.Json;
using Moq;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test.Abstract
{
    public abstract class AbstractFm36HistoryStoreTest
    {
        private readonly IStoreFM36HistoryService _storeService;
        private readonly IStoreFM36HistoryClear _storeClear = new StoreFM36HistoryClear();
        private readonly IJsonSerializationService _jsonSerializationService = new JsonSerializationService();

        protected AbstractFm36HistoryStoreTest(IStoreFM36HistoryService storeService)
        {
            _storeService = storeService;
        }

        public async Task StoreTestAsync(int ukprn, FM36Global model, string fileName)
        {
            CancellationToken cancellationToken = CancellationToken.None;
            var dataStoreContextMock = new Mock<IDataStoreContext>();
            dataStoreContextMock.SetupGet(c => c.Ukprn).Returns(ukprn);
            dataStoreContextMock.SetupGet(c => c.OriginalFilename).Returns(fileName);
            dataStoreContextMock.SetupGet(c => c.ReturnCode).Returns("01");
            dataStoreContextMock.SetupGet(c => c.CollectionYear).Returns("1819");

            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["Fm36HistoryTestConnectionString"]))
                    {
                        await connection.OpenAsync();

                        await _storeClear.ClearAsync(dataStoreContextMock.Object, connection, cancellationToken);
                        await _storeService.StoreAsync(dataStoreContextMock.Object, connection, model, cancellationToken);

                        ExecuteAssertions(model, ukprn, connection);
                    }

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected abstract void ExecuteAssertions(FM36Global outputModel, int ukprn, SqlConnection sqlConnection);

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
