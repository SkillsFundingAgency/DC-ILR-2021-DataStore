﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData.Persist;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Serialization.Interfaces;
using ESFA.DC.Serialization.Json;
using Moq;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test.Abstract
{
    public abstract class AbstractIlrStoreTest<T>
    {
        private readonly IStoreService<T> _storeService;
        private readonly IStoreClear _storeClear = new StoreClear();
        private readonly IJsonSerializationService _jsonSerializationService = new JsonSerializationService();

        protected AbstractIlrStoreTest(IStoreService<T> storeService)
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

            var outputModel = ReadAndDeserialiseAsync<T>(fileName, outputKey, keyValuePersistenceServiceMock, serializationServiceMock);

            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["IlrTestConnectionString"]))
                    {
                        await sqlConnection.OpenAsync();

                        await _storeClear.ClearAsync(dataStoreContextMock.Object, sqlConnection, cancellationToken);

                        await _storeService.StoreAsync(sqlConnection, outputModel, cancellationToken);

                        ExecuteAssertions(outputModel, ukprn, sqlConnection);
                    }

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task StoreTestAsync(int ukprn, T model, string fileName)
        {
            CancellationToken cancellationToken = CancellationToken.None;
            var dataStoreContextMock = new Mock<IDataStoreContext>();
            dataStoreContextMock.SetupGet(c => c.Ukprn).Returns(ukprn);
            dataStoreContextMock.SetupGet(c => c.OriginalFilename).Returns(fileName);

            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["IlrTestConnectionString"]))
                    {
                        await sqlConnection.OpenAsync();

                        await _storeClear.ClearAsync(dataStoreContextMock.Object, sqlConnection, cancellationToken);

                        await _storeService.StoreAsync(sqlConnection, model, cancellationToken);

                        ExecuteAssertions(model, ukprn, sqlConnection);
                    }

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw;
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
