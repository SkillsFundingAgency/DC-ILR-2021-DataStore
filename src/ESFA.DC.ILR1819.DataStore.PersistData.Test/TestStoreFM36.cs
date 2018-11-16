using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Serialization.Interfaces;
using ESFA.DC.Serialization.Json;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test
{
    public class TestStoreFM36
    {
        private const string Fm36OutputKey = "FM36_Output";

        private readonly ITestOutputHelper _output;

        public TestStoreFM36(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task StoreFM36()
        {
            CancellationToken cancellationToken = default(CancellationToken);
            var persist = new Mock<IKeyValuePersistenceService>();
            var serialise = new Mock<ISerializationService>();

            Stopwatch stopwatch = new Stopwatch();

            int ukprn = 10033670;
            var fileName = "Fm36.json";
            var outputKey = "FM36_Output";

            var dataStoreContext = BuildDataStoreContext(fileName, ukprn, outputKey);
            var fm36Output = await ReadAndDeserialiseAsync(fileName, persist, serialise);

            using (SqlConnection connection =
                new SqlConnection(ConfigurationManager.AppSettings["TestConnectionString"]))
            {
                SqlTransaction transaction = null;
                try
                {
                    stopwatch.Restart();
                    await connection.OpenAsync(cancellationToken);
                    transaction = connection.BeginTransaction();

                    _output.WriteLine($"SQL Connect: {stopwatch.ElapsedMilliseconds}");
                    stopwatch.Restart();

                    StoreClear storeClear = new StoreClear();
                    await storeClear.ClearAsync(connection, transaction, ukprn, Path.GetFileName(fileName), cancellationToken);

                    _output.WriteLine($"Clear: {stopwatch.ElapsedMilliseconds} {ukprn} {fileName}");
                    stopwatch.Restart();

                    StoreFM36 store36 = new StoreFM36();
                    await store36.StoreAsync(connection, transaction, ukprn, fm36Output, cancellationToken);

                    _output.WriteLine($"Store FM36: {stopwatch.ElapsedMilliseconds}");
                    stopwatch.Restart();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    _output.WriteLine(ex.ToString());

                    try
                    {
                        transaction?.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        _output.WriteLine(ex2.ToString());
                    }

                    Assert.True(false);
                }

                _output.WriteLine($"Commit: {stopwatch.ElapsedMilliseconds}");
                stopwatch.Restart();

                using (SqlCommand sqlCommand =
                    new SqlCommand($"SELECT Count(1) FROM Rulebase.AEC_LearningDelivery Where LearnRefNumber = '3DOB01'", connection))
                {
                    Assert.Equal(fm36Output.Learners.FirstOrDefault(l => l.LearnRefNumber == "3DOB01")?.LearningDeliveries.Count ?? 0, sqlCommand.ExecuteScalar());
                }
            }
        }

        private IDataStoreContext BuildDataStoreContext(string fileName, int ukprn, string outputKey)
        {
            var dataStoreContextMock = new Mock<IDataStoreContext>();

            dataStoreContextMock.SetupGet(c => c.Filename).Returns(Path.GetFileName(fileName));
            dataStoreContextMock.SetupGet(c => c.FileSizeInBytes).Returns(new FileInfo(fileName).Length);
            dataStoreContextMock.SetupGet(c => c.Ukprn).Returns(ukprn);
            dataStoreContextMock.SetupGet(c => c.FundingFM36OutputKey).Returns(outputKey);
            dataStoreContextMock.SetupGet(c => c.SubmissionDateTimeUtc).Returns(new DateTime(2018, 1, 1));

            return dataStoreContextMock.Object;
        }

        private async Task<FM36Global> ReadAndDeserialiseAsync(
            string fm35Filename,
            Mock<IKeyValuePersistenceService> persist,
            Mock<ISerializationService> serialise)
        {
            var jsonSerialiser = new JsonSerializationService();
            string fm36Contents;

            Stopwatch stopwatch = new Stopwatch();
            using (StreamReader sr = new StreamReader(fm35Filename))
            {
                fm36Contents = await sr.ReadToEndAsync();
            }

            FM36Global fundingOutputs = jsonSerialiser.Deserialize<FM36Global>(fm36Contents);
            _output.WriteLine($"Deserialise FM36: {stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();

            persist.Setup(x => x.GetAsync(Fm36OutputKey, It.IsAny<CancellationToken>())).ReturnsAsync(fm36Contents);

            serialise.Setup(x => x.Deserialize<FM36Global>(fm36Contents)).Returns(fundingOutputs);

            _output.WriteLine($"Moq: {stopwatch.ElapsedMilliseconds}");

            return fundingOutputs;
        }
    }
}
