using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationErrors.Interface;
using ESFA.DC.ILR.ValidationErrors.Interface.Models;
using ESFA.DC.ILR1819.DataStore.PersistData.Builders;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.JobContextManager.Model;
using ESFA.DC.Logging;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Serialization.Interfaces;
using ESFA.DC.Serialization.Json;
using ESFA.DC.Serialization.Xml;
using Microsoft.VisualBasic.FileIO;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test
{
    public sealed class TestStoreIlr
    {
        private readonly ITestOutputHelper output;

        public TestStoreIlr(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData("ILR-10033670-1819-20180704-120055-03.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 10033670, new[] { "3Addl103" })]
        public async Task StoreIlr(string ilrFilename, string albDataFilename, string valErrorsFilename, int ukPrn, string[] validLearners)
        {
            CancellationToken cancellationToken = default(CancellationToken);
            var jobContextMessage = new JobContextMessage();
            var storage = new Mock<IKeyValuePersistenceService>();
            var persist = new Mock<IKeyValuePersistenceService>();
            var serialise = new Mock<ISerializationService>();
            var validationErrorsService = new Mock<IValidationErrorsService>();
            Stopwatch stopwatch = new Stopwatch();

            var validLearnersBuilder = new LearnerValidDataBuilder();
            var invalidLearnersBuilder = new LearnerInvalidDataBuilder();

            if (validLearners.Length == 1 && validLearners[0].EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                validLearners = ReadValidLearners(stopwatch, ilrFilename, validLearners[0]);
            }

            Message message = null;
            Task<Tuple<Message, ALBGlobal, ValidationErrorDto[]>> reandAndSerialiseTask = ReadAndDeserialiseAsync(ilrFilename, albDataFilename, valErrorsFilename, jobContextMessage, validLearners.ToList(), storage, persist, serialise, validationErrorsService);

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["TestConnectionString"]))
            {
                SqlTransaction transaction = null;
                try
                {
                    stopwatch.Restart();
                    await connection.OpenAsync(cancellationToken);
                    transaction = connection.BeginTransaction();

                    output.WriteLine($"SQL Connect: {stopwatch.ElapsedMilliseconds}");
                    stopwatch.Restart();

                    StoreClear storeClear = new StoreClear(connection, transaction);
                    Task clearTask = storeClear.ClearAsync(ukPrn, Path.GetFileName(ilrFilename), cancellationToken);

                    await Task.WhenAll(reandAndSerialiseTask, clearTask);
                    message = reandAndSerialiseTask.Result.Item1;

                    output.WriteLine($"Clear: {stopwatch.ElapsedMilliseconds} {ukPrn} {ilrFilename}");
                    stopwatch.Restart();

                    StoreFileDetails storeFileDetails =
                        new StoreFileDetails(
                            connection,
                            transaction,
                            jobContextMessage);
                    await storeFileDetails.StoreAsync(cancellationToken);

                    output.WriteLine($"File details: {stopwatch.ElapsedMilliseconds}");
                    stopwatch.Restart();

                    StoreIlr storeIlr = new StoreIlr(
                        connection,
                        transaction,
                        jobContextMessage,
                        validLearnersBuilder,
                        invalidLearnersBuilder);
                    await storeIlr.StoreAsync(message, validLearners.ToList(), cancellationToken);

                    output.WriteLine($"Store ILR: {stopwatch.ElapsedMilliseconds}");
                    stopwatch.Restart();

                    StoreRuleAlb storeRuleAlb = new StoreRuleAlb();
                    await storeRuleAlb.StoreAsync(connection, transaction, ukPrn, reandAndSerialiseTask.Result.Item2, cancellationToken);

                    output.WriteLine($"Store ALB: {stopwatch.ElapsedMilliseconds}");
                    stopwatch.Restart();

                    StoreValidationOutput storeValidationOutput = new StoreValidationOutput(connection, transaction, null, jobContextMessage, validationErrorsService.Object);
                    await storeValidationOutput.StoreAsync(ukPrn, message, cancellationToken);

                    output.WriteLine($"Store Val: {stopwatch.ElapsedMilliseconds}");
                    stopwatch.Restart();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    output.WriteLine(ex.ToString());

                    try
                    {
                        transaction?.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        output.WriteLine(ex2.ToString());
                    }

                    Assert.True(false);
                }

                output.WriteLine($"Commit: {stopwatch.ElapsedMilliseconds}");
                stopwatch.Restart();

                using (SqlCommand sqlCommand =
                    new SqlCommand($"SELECT Count(LearnRefNumber) FROM Valid.Learner Where UKPRN = {ukPrn}", connection))
                {
                    Assert.Equal(validLearners.Length, sqlCommand.ExecuteScalar());
                }

                using (SqlCommand sqlCommand =
                    new SqlCommand(
                        $"SELECT Count(LearnRefNumber) FROM Invalid.Learner Where UKPRN = {ukPrn}",
                        connection))
                {
                    Assert.Equal(message?.Learner.Length - validLearners.Length, sqlCommand.ExecuteScalar());
                }

                output.WriteLine($"Assert: {stopwatch.ElapsedMilliseconds}");
                stopwatch.Restart();
            }
        }

        private string[] ReadValidLearners(Stopwatch stopwatch, string ilrFilename, string filename)
        {
            stopwatch.Restart();
            List<string> validLearners = new List<string>();
            using (TextFieldParser tfp = new TextFieldParser(filename))
            {
                tfp.TextFieldType = FieldType.Delimited;
                tfp.Delimiters = new[] { "," };
                tfp.ReadFields();

                while (!tfp.EndOfData)
                {
                    string[] data = tfp.ReadFields();
                    Assert.NotNull(data);
                    if (data[0] == ilrFilename && string.Equals(data[2], bool.TrueString, StringComparison.OrdinalIgnoreCase))
                    {
                        validLearners.Add(data[3]);
                    }
                }
            }

            output.WriteLine($"Read {validLearners.Count} Valid Learners: {stopwatch.ElapsedMilliseconds}");
            return validLearners.Distinct().ToArray();
        }

        private async Task<Tuple<Message, ALBGlobal, ValidationErrorDto[]>> ReadAndDeserialiseAsync(
            string ilrFilename,
            string albFilename,
            string valErrorsDtoFilename,
            JobContextMessage jobContextMessage,
            List<string> validLearners,
            Mock<IKeyValuePersistenceService> storage,
            Mock<IKeyValuePersistenceService> persist,
            Mock<ISerializationService> serialise,
            Mock<IValidationErrorsService> validationErrorsService)
        {
            var xmlSerialiser = new XmlSerializationService();
            var jsonSerialiser = new JsonSerializationService();

            const string validLearnersKey = "ValidLearners";
            const string validLearnersSerialised = "<Serialised String>";
            const string keyAlbOutput = "ALB_Output";
            const string keyValErrors = "ValErrors";
            const string keyValErrorsLookup = "ValErrorsLookup";
            string ilrContents, albContents, valErrorsContents;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (StreamReader sr = new StreamReader(ilrFilename))
            {
                ilrContents = await sr.ReadToEndAsync();
            }

            output.WriteLine($"Read ILR file: {stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();

            using (StreamReader sr = new StreamReader(albFilename))
            {
                albContents = await sr.ReadToEndAsync();
            }

            output.WriteLine($"Read ALB file: {stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();

            using (StreamReader sr = new StreamReader(valErrorsDtoFilename))
            {
                valErrorsContents = await sr.ReadToEndAsync();
            }

            output.WriteLine($"Read Val Errors file: {stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();

            Message message = xmlSerialiser.Deserialize<Message>(ilrContents);
            output.WriteLine($"Deserialise ILR: {stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();

            ALBGlobal fundingOutputs = jsonSerialiser.Deserialize<ALBGlobal>(albContents);
            output.WriteLine($"Deserialise ALB: {stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();

            ValidationErrorDto[] validationErrorDtos = jsonSerialiser.Deserialize<ValidationErrorDto[]>(valErrorsContents);
            output.WriteLine($"Deserialise Val: {stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();

            jobContextMessage.KeyValuePairs = new Dictionary<string, object>
            {
                [JobContextMessageKey.Filename] = Path.GetFileName(ilrFilename),
                [JobContextMessageKey.ValidLearnRefNumbers] = validLearnersKey,
                [JobContextMessageKey.FileSizeInBytes] = new FileInfo(ilrFilename).Length,
                [JobContextMessageKey.UkPrn] = message.HeaderEntity.SourceEntity.UKPRN,
                [JobContextMessageKey.ValidLearnRefNumbersCount] = validLearners.Count,
                [JobContextMessageKey.InvalidLearnRefNumbersCount] = message.Learner.Length - validLearners.Count,
                [JobContextMessageKey.ValidationTotalErrorCount] = 10,
                [JobContextMessageKey.ValidationTotalWarningCount] = 20,
                [JobContextMessageKey.FundingAlbOutput] = keyAlbOutput,
                [JobContextMessageKey.ValidationErrors] = keyValErrors,
                [JobContextMessageKey.ValidationErrorLookups] = keyValErrorsLookup
            };

            jobContextMessage.SubmissionDateTimeUtc = DateTime.UtcNow;

            storage.Setup(x => x.GetAsync(Path.GetFileName(ilrFilename), It.IsAny<CancellationToken>())).ReturnsAsync(ilrContents);
            //storage.Setup(x => x.GetAsync(Path.GetFileName(albFilename))).ReturnsAsync(albContents);

            persist.Setup(x => x.GetAsync(validLearnersKey, It.IsAny<CancellationToken>())).ReturnsAsync(validLearnersSerialised);
            persist.Setup(x => x.GetAsync(keyAlbOutput, It.IsAny<CancellationToken>())).ReturnsAsync(albContents);

            serialise.Setup(x => x.Deserialize<List<string>>(validLearnersSerialised)).Returns(validLearners);
            serialise.Setup(x => x.Deserialize<Message>(ilrContents)).Returns(message);
            serialise.Setup(x => x.Deserialize<ALBGlobal>(albContents)).Returns(fundingOutputs);

            validationErrorsService.Setup(x => x.GetValidationErrorsAsync(keyValErrors, keyValErrorsLookup))
                .ReturnsAsync(validationErrorDtos);

            output.WriteLine($"Moq: {stopwatch.ElapsedMilliseconds}");

            return new Tuple<Message, ALBGlobal, ValidationErrorDto[]>(message, fundingOutputs, validationErrorDtos);
        }
    }
}
