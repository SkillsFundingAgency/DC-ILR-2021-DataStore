using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.JobContextManager.Model;
using ESFA.DC.Serialization.Interfaces;
using ESFA.DC.Serialization.Json;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test
{
    public class TestStoreFM25
    {
        private readonly ITestOutputHelper _output;

        public TestStoreFM25(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task StoreFM25()
        {
            CancellationToken cancellationToken = default(CancellationToken);
            var jobContextMessage = new JobContextMessage();
            var persist = new Mock<IKeyValuePersistenceService>();
            var serialise = new Mock<ISerializationService>();

            Stopwatch stopwatch = new Stopwatch();

            int ukprn = 10033677;
            var fm25FileName = "Fm25.json";

            var fm25Output = await ReadAndDeserialiseAsync(fm25FileName, ukprn, jobContextMessage, persist, serialise);

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
                    await storeClear.ClearAsync(connection, transaction, ukprn, Path.GetFileName(fm25FileName), cancellationToken);

                    _output.WriteLine($"Clear: {stopwatch.ElapsedMilliseconds} {ukprn} {fm25FileName}");
                    stopwatch.Restart();

                    StoreFM25 storeRuleAlb = new StoreFM25();
                    await storeRuleAlb.StoreAsync(connection, transaction, ukprn, fm25Output, cancellationToken);

                    _output.WriteLine($"Store FM25: {stopwatch.ElapsedMilliseconds}");
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
                    new SqlCommand($"SELECT Count(1) FROM Rulebase.FM25_Learner Where UKPRN = {ukprn}", connection))
                {
                    Assert.Equal(fm25Output.Learners.Count, sqlCommand.ExecuteScalar());
                }
            }
        }

        private async Task<FM25Global> ReadAndDeserialiseAsync(
            string fm25Filename,
            int ukPrn,
            JobContextMessage jobContextMessage,
            Mock<IKeyValuePersistenceService> persist,
            Mock<ISerializationService> serialise)
        {
            var jsonSerialiser = new JsonSerializationService();
            const string keyFm25Output = "FM25_Output";
            string fm25Contents;

            Stopwatch stopwatch = new Stopwatch();
            using (StreamReader sr = new StreamReader(fm25Filename))
            {
                fm25Contents = await sr.ReadToEndAsync();
            }

            FM25Global fundingOutputs = jsonSerialiser.Deserialize<FM25Global>(fm25Contents);
            _output.WriteLine($"Deserialise FM25: {stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();

            jobContextMessage.KeyValuePairs = new Dictionary<string, object>
            {
                [JobContextMessageKey.Filename] = Path.GetFileName(fm25Filename),
                [JobContextMessageKey.FileSizeInBytes] = new FileInfo(fm25Filename).Length,
                [JobContextMessageKey.UkPrn] = ukPrn,
                [JobContextMessageKey.FundingFm25Output] = keyFm25Output
            };

            jobContextMessage.SubmissionDateTimeUtc = DateTime.UtcNow;

            persist.Setup(x => x.GetAsync(keyFm25Output, It.IsAny<CancellationToken>())).ReturnsAsync(fm25Contents);

            serialise.Setup(x => x.Deserialize<FM25Global>(fm25Contents)).Returns(fundingOutputs);

            _output.WriteLine($"Moq: {stopwatch.ElapsedMilliseconds}");

            return fundingOutputs;
        }
    }
}
