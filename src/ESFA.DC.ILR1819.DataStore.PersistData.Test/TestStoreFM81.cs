using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
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
    public class TestStoreFM81
    {
        private readonly ITestOutputHelper _output;

        public TestStoreFM81(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task StoreFM81()
        {
            CancellationToken cancellationToken = default(CancellationToken);
            var jobContextMessage = new JobContextMessage();
            var persist = new Mock<IKeyValuePersistenceService>();
            var serialise = new Mock<ISerializationService>();

            Stopwatch stopwatch = new Stopwatch();

            int ukprn = 10033677;
            var fm81FileName = "Fm81.json";

            var fm81Output = await ReadAndDeserialiseAsync(fm81FileName, ukprn, jobContextMessage, persist, serialise);

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["TestConnectionString"]))
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
                    await storeClear.ClearAsync(connection, transaction, ukprn, Path.GetFileName(fm81FileName), cancellationToken);

                    _output.WriteLine($"Clear: {stopwatch.ElapsedMilliseconds} {ukprn} {fm81FileName}");
                    stopwatch.Restart();

                    StoreFM81 storeFM81 = new StoreFM81();
                    await storeFM81.StoreAsync(connection, transaction, ukprn, fm81Output, cancellationToken);

                    _output.WriteLine($"Store FM81: {stopwatch.ElapsedMilliseconds}");
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
                    new SqlCommand($"SELECT Count(1) FROM Rulebase.TBL_LearningDelivery Where LearnRefNumber = '0fm8101'", connection))
                {
                    Assert.Equal(fm81Output.Learners.FirstOrDefault(l => l.LearnRefNumber == "0fm8101")?.LearningDeliveries.Count ?? 0, sqlCommand.ExecuteScalar());
                }
            }
        }

        private async Task<FM81Global> ReadAndDeserialiseAsync(
            string fm81Filename,
            int ukPrn,
            JobContextMessage jobContextMessage,
            Mock<IKeyValuePersistenceService> persist,
            Mock<ISerializationService> serialise)
        {
            var jsonSerialiser = new JsonSerializationService();
            const string keyFm81Output = "FM81_Output";
            string fm81Contents;

            Stopwatch stopwatch = new Stopwatch();
            using (StreamReader sr = new StreamReader(fm81Filename))
            {
                fm81Contents = await sr.ReadToEndAsync();
            }

            FM81Global fundingOutputs = jsonSerialiser.Deserialize<FM81Global>(fm81Contents);
            _output.WriteLine($"Deserialise FM81: {stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();

            jobContextMessage.KeyValuePairs = new Dictionary<string, object>
            {
                [JobContextMessageKey.Filename] = Path.GetFileName(fm81Filename),
                [JobContextMessageKey.FileSizeInBytes] = new FileInfo(fm81Filename).Length,
                [JobContextMessageKey.UkPrn] = ukPrn,
                [JobContextMessageKey.FundingFm81Output] = keyFm81Output
            };

            jobContextMessage.SubmissionDateTimeUtc = DateTime.UtcNow;

            persist.Setup(x => x.GetAsync(keyFm81Output, It.IsAny<CancellationToken>())).ReturnsAsync(fm81Contents);

            serialise.Setup(x => x.Deserialize<FM81Global>(fm81Contents)).Returns(fundingOutputs);

            _output.WriteLine($"Moq: {stopwatch.ElapsedMilliseconds}");

            return fundingOutputs;
        }
    }
}
