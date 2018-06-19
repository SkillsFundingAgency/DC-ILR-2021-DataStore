﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationErrors.Interface;
using ESFA.DC.ILR.ValidationErrors.Interface.Models;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.JobContext;
using ESFA.DC.JobContext.Interface;
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
        //[InlineData("ILR-90000077-1819-20180516-122452-02.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 90000077, new[] { "0Accm01" })]
        //[InlineData("ILR-90000078-1819-20180518-094937-02.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 90000078, new[] { "0fm3501" })]
        //[InlineData("ILR-90000079-1819-20180518-094943-02.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 90000079, new[] { "0fm3501" })]
        //[InlineData("ILR-90000080-1819-20180518-094947-02.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 90000080, new[] { "0fm3501" })]
        //[InlineData("ILR-90000081-1819-20180518-095009-02.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 90000081, new[] { "0fm3501" })]
        //[InlineData("ILR-90000065-1819-20180518-095236-02.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 90000065, new[] { "0Accm01" })]
        //[InlineData("ILR-90000066-1819-20180518-095239-02.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 90000066, new[] { "0Accm01" })]
        //[InlineData("ILR-90000067-1819-20180518-095243-02.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 90000067, new[] { "0Accm01" })]
        //[InlineData("ILR-90000068-1819-20180518-095303-02.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 90000068, new[] { "0Accm01" })]
        //[InlineData("ILR-90000071-1819-20180518-095441-02.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 90000071, new[] { "0Accm01" })]
        //[InlineData("ILR-90000072-1819-20180518-095444-02.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 90000072, new[] { "0Accm01" })]
        //[InlineData("ILR-90000073-1819-20180518-095504-02.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 90000073, new[] { "0Accm01" })]
        //[InlineData("ILR-90000074-1819-20180521-132627-00.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 90000074, new[] { "0Accm01" })]
        //[InlineData("ILR-90000075-1819-20180521-132931-00.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 90000075, new[] { "0Accm01" })]
        //[InlineData("ILR-10006341-1819-20180118-023456-02.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 10006341, new[] { "16v224" })]
        //[InlineData("ILR-10033670-1819-20180118-023456-02.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 10033670, new[] { "16v224" })]
        //[InlineData("ILR-10033670-1819-20180118-023456-04.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 10033670, new[] { "16v224" })]
        //[InlineData("ILR-10006000-1819-20180626-144401-01.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 10006000, new[] { "ESFLearner", "NonLevy", "Levy" })]
        //[InlineData("ILR-90000064-1819-20180612-165219-02.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 90000064, new[] { "0DOB24" })]
        //[InlineData("ILR-90000004-1819-20180613-144516-03.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 90000004, new[] { "0DOB24" })]
        //[InlineData("ILR-90000064-1819-20180618-105223-02.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 90000064, new[] { "1FM09" })]
        //[InlineData("ILR-90000064-1819-20180618-133601-03.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 90000064, new[] { "control-20180618-133604.csv" })]
        //[InlineData("ILR-90000064-1819-20180618-152718-03.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 90000064, new[] { "control-20180618-152718.csv" })]
        [InlineData("ILR-90000064-1819-20180618-153725-03.xml", "ALBOutput1000.json", "9999_6_ValidationErrors.json", 90000064, new[] { "control-20180618-153730.csv" })] // File too large to check in
        //[InlineData("ILR-90000064-1819-20180521-133647-00.xml", "ALBOutput1000.json", 90000064, "0Accm01")]
        //[InlineData("ILR-90000063-1819-20180521-134854-00.xml", "ALBOutput1000.json", 90000063, "0Accm01")]
        //[InlineData("ILR-90000062-1819-20180521-135604-00.xml", "ALBOutput1000.json", 90000062, "0Accm01")]
        public async Task StoreIlr(string ilrFilename, string albDataFilename, string valErrorsFilename, int ukPrn, string[] validLearners)
        {
            CancellationToken cancellationToken = default(CancellationToken);
            var jobContextMessage = new JobContextMessage();
            var storage = new Mock<IKeyValuePersistenceService>();
            var persist = new Mock<IKeyValuePersistenceService>();
            var serialise = new Mock<ISerializationService>();
            var validationErrorsService = new Mock<IValidationErrorsService>();
            Stopwatch stopwatch = new Stopwatch();

            if (validLearners.Length == 1 && validLearners[0].EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                validLearners = ReadValidLearners(stopwatch, ilrFilename, validLearners[0]);
            }

            Message message = null;
            Task<Tuple<Message, FundingOutputs, ValidationErrorDto[]>> reandAndSerialiseTask = ReadAndDeserialiseAsync(ilrFilename, albDataFilename, valErrorsFilename, jobContextMessage, validLearners.ToList(), storage, persist, serialise, validationErrorsService);

            using (SqlConnection connection =
                new SqlConnection("data source=(local);initial catalog=ILR1819_DataStore;integrated security=True;multipleactiveresultsets=True;Connect Timeout=90"))
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
                        jobContextMessage);
                    await storeIlr.StoreAsync(message, validLearners.ToList(), cancellationToken);

                    output.WriteLine($"Store ILR: {stopwatch.ElapsedMilliseconds}");
                    stopwatch.Restart();

                    StoreRuleAlb storeRuleAlb = new StoreRuleAlb(
                        connection,
                        transaction);
                    await storeRuleAlb.StoreAsync(ukPrn, reandAndSerialiseTask.Result.Item2, cancellationToken);

                    output.WriteLine($"Store ALB: {stopwatch.ElapsedMilliseconds}");
                    stopwatch.Restart();

                    StoreValidationOutput storeValidationOutput = new StoreValidationOutput(connection, transaction, jobContextMessage, validationErrorsService.Object);
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
                    if (data[0] == ilrFilename && string.Equals(data[2], bool.TrueString, StringComparison.OrdinalIgnoreCase))
                    {
                        validLearners.Add(data[3]);
                    }
                }
            }

            output.WriteLine($"Read {validLearners.Count} Valid Learners: {stopwatch.ElapsedMilliseconds}");
            return validLearners.Distinct().ToArray();
        }

        private async Task<Tuple<Message, FundingOutputs, ValidationErrorDto[]>> ReadAndDeserialiseAsync(
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

            FundingOutputs fundingOutputs = jsonSerialiser.Deserialize<FundingOutputs>(albContents);
            output.WriteLine($"Deserialise ALB: {stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();

            ValidationErrorDto[] validationErrorDtos = jsonSerialiser.Deserialize<ValidationErrorDto[]>(valErrorsContents);
            output.WriteLine($"Deserialise Val: {stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();

            jobContextMessage.KeyValuePairs = new Dictionary<JobContextMessageKey, object>
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

            storage.Setup(x => x.GetAsync(Path.GetFileName(ilrFilename))).ReturnsAsync(ilrContents);
            //storage.Setup(x => x.GetAsync(Path.GetFileName(albFilename))).ReturnsAsync(albContents);

            persist.Setup(x => x.GetAsync(validLearnersKey)).ReturnsAsync(validLearnersSerialised);
            persist.Setup(x => x.GetAsync(keyAlbOutput)).ReturnsAsync(albContents);

            serialise.Setup(x => x.Deserialize<List<string>>(validLearnersSerialised)).Returns(validLearners);
            serialise.Setup(x => x.Deserialize<Message>(ilrContents)).Returns(message);
            serialise.Setup(x => x.Deserialize<FundingOutputs>(albContents)).Returns(fundingOutputs);

            validationErrorsService.Setup(x => x.GetValidationErrorsAsync(keyValErrors, keyValErrorsLookup))
                .ReturnsAsync(validationErrorDtos);

            output.WriteLine($"Moq: {stopwatch.ElapsedMilliseconds}");

            return new Tuple<Message, FundingOutputs, ValidationErrorDto[]>(message, fundingOutputs, validationErrorDtos);
        }
    }
}
