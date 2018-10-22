using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
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
    public class TestStoreFM70
    {
        private readonly ITestOutputHelper _output;

        public TestStoreFM70(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task StoreFM70()
        {
            CancellationToken cancellationToken = default(CancellationToken);
            var jobContextMessage = new JobContextMessage();
            var persist = new Mock<IKeyValuePersistenceService>();
            var serialise = new Mock<ISerializationService>();

            Stopwatch stopwatch = new Stopwatch();

            int ukprn = 10033670;
            var fm70FileName = "Fm70.json";

            var fm70Output = await ReadAndDeserialiseAsync(fm70FileName, ukprn, jobContextMessage, persist, serialise);

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

                    StoreClear storeClear = new StoreClear(connection, transaction);
                    await storeClear.ClearAsync(ukprn, Path.GetFileName(fm70FileName), cancellationToken);

                    _output.WriteLine($"Clear: {stopwatch.ElapsedMilliseconds} {ukprn} {fm70FileName}");
                    stopwatch.Restart();

                    StoreFM70 store70 = new StoreFM70();
                    await store70.StoreAsync(connection, transaction, ukprn, fm70Output, cancellationToken);

                    _output.WriteLine($"Store FM70: {stopwatch.ElapsedMilliseconds}");
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
                    new SqlCommand($"SELECT Count(1) FROM Rulebase.ESF_LearningDelivery Where LearnRefNumber = '0DOB43'", connection))
                {
                    Assert.Equal(fm70Output.Learners.FirstOrDefault(l => l.LearnRefNumber == "0DOB43")?.LearningDeliveries.Count ?? 0, sqlCommand.ExecuteScalar());
                }
            }
        }

        private async Task<FM70Global> ReadAndDeserialiseAsync(
            string fm70Filename,
            int ukPrn,
            JobContextMessage jobContextMessage,
            Mock<IKeyValuePersistenceService> persist,
            Mock<ISerializationService> serialise)
        {
            var jsonSerialiser = new JsonSerializationService();
            const string keyFm70Output = "FM70_Output";
            string fm70Contents;

            Stopwatch stopwatch = new Stopwatch();
            using (StreamReader sr = new StreamReader(fm70Filename))
            {
                fm70Contents = await sr.ReadToEndAsync();
            }

            FM70Global fundingOutputs = jsonSerialiser.Deserialize<FM70Global>(fm70Contents);
            _output.WriteLine($"Deserialise FM70: {stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();

            jobContextMessage.KeyValuePairs = new Dictionary<string, object>
            {
                [JobContextMessageKey.Filename] = Path.GetFileName(fm70Filename),
                [JobContextMessageKey.FileSizeInBytes] = new FileInfo(fm70Filename).Length,
                [JobContextMessageKey.UkPrn] = ukPrn,
                [JobContextMessageKey.FundingFm70Output] = keyFm70Output
            };

            jobContextMessage.SubmissionDateTimeUtc = DateTime.UtcNow;

            persist.Setup(x => x.GetAsync(keyFm70Output, It.IsAny<CancellationToken>())).ReturnsAsync(fm70Contents);

            serialise.Setup(x => x.Deserialize<FM70Global>(fm70Contents)).Returns(fundingOutputs);

            _output.WriteLine($"Moq: {stopwatch.ElapsedMilliseconds}");

            return fundingOutputs;
        }
    }
}
