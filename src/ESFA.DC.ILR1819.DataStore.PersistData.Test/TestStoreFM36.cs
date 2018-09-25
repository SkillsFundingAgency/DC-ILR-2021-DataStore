using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.JobContext;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.Serialization.Interfaces;
using ESFA.DC.Serialization.Json;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test
{
    public class TestStoreFM36
    {
        private readonly ITestOutputHelper _output;

        public TestStoreFM36(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task StoreFM35()
        {
            CancellationToken cancellationToken = default(CancellationToken);
            var jobContextMessage = new JobContextMessage();
            var persist = new Mock<IKeyValuePersistenceService>();
            var serialise = new Mock<ISerializationService>();

            Stopwatch stopwatch = new Stopwatch();

            int ukprn = 10033677;
            var fm36FileName = "Fm36.json";

            var fm36Output = await ReadAndDeserialiseAsync(fm36FileName, ukprn, jobContextMessage, persist, serialise);

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
                    await storeClear.ClearAsync(ukprn, Path.GetFileName(fm36FileName), cancellationToken);

                    _output.WriteLine($"Clear: {stopwatch.ElapsedMilliseconds} {ukprn} {fm36FileName}");
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
                    new SqlCommand($"SELECT Count(1) FROM Rulebase.AEC_LearningDelivery Where LearnRefNumber = '0fm3501'", connection))
                {
                    Assert.Equal(fm36Output.Learners.FirstOrDefault(l => l.LearnRefNumber == "0fm3501")?.LearningDeliveries.Count ?? 0, sqlCommand.ExecuteScalar());
                }
            }
        }

        private async Task<FM36Global> ReadAndDeserialiseAsync(
            string fm35Filename,
            int ukPrn,
            JobContextMessage jobContextMessage,
            Mock<IKeyValuePersistenceService> persist,
            Mock<ISerializationService> serialise)
        {
            var jsonSerialiser = new JsonSerializationService();
            const string keyFm36Output = "FM36_Output";
            string fm36Contents;

            Stopwatch stopwatch = new Stopwatch();
            using (StreamReader sr = new StreamReader(fm35Filename))
            {
                fm36Contents = await sr.ReadToEndAsync();
            }

            FM36Global fundingOutputs = jsonSerialiser.Deserialize<FM36Global>(fm36Contents);
            _output.WriteLine($"Deserialise FM36: {stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();

            jobContextMessage.KeyValuePairs = new Dictionary<string, object>
            {
                [JobContextMessageKey.Filename] = Path.GetFileName(fm35Filename),
                [JobContextMessageKey.FileSizeInBytes] = new FileInfo(fm35Filename).Length,
                [JobContextMessageKey.UkPrn] = ukPrn,
                [JobContextMessageKey.FundingFm35Output] = keyFm36Output
            };

            jobContextMessage.SubmissionDateTimeUtc = DateTime.UtcNow;

            persist.Setup(x => x.GetAsync(keyFm36Output, It.IsAny<CancellationToken>())).ReturnsAsync(fm36Contents);

            serialise.Setup(x => x.Deserialize<FM36Global>(fm36Contents)).Returns(fundingOutputs);

            _output.WriteLine($"Moq: {stopwatch.ElapsedMilliseconds}");

            return fundingOutputs;
        }
    }
}
