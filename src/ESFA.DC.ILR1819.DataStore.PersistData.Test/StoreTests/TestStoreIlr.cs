﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using ESFA.DC.DateTimeProvider.Interface;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationErrors.Interface;
using ESFA.DC.ILR.ValidationErrors.Interface.Models;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Mappers;
using ESFA.DC.ILR1819.DataStore.PersistData.Builders;
using ESFA.DC.ILR1819.DataStore.PersistData.Mapper;
using ESFA.DC.ILR1819.DataStore.PersistData.Persist;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Serialization.Interfaces;
using ESFA.DC.Serialization.Json;
using ESFA.DC.Serialization.Xml;
using Microsoft.VisualBasic.FileIO;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test.StoreTests
{
    [Collection("StoreData Tests")]
    public sealed class TestStoreIlr
    {
        private const int _ukprn = 10033670;
        private readonly ITestOutputHelper output;

        public TestStoreIlr(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData("IlrFiles/ILR-10033670-1819-20180704-120055-03.xml", "JsonOutputs/ALB.json", "JsonOutputs/9999_6_ValidationErrors.json", _ukprn, new[] { "0ALB01" })]
        public async Task StoreIlr(string ilrFilename, string albDataFilename, string valErrorsFilename, int ukPrn, string[] validLearners)
        {
            CancellationToken cancellationToken = default(CancellationToken);
            var logger = new Mock<ILogger>();
            var storage = new Mock<IKeyValuePersistenceService>();
            var persist = new Mock<IKeyValuePersistenceService>();
            var serialise = new Mock<ISerializationService>();
            var validationErrorsService = new Mock<IValidationErrorsService>();
            var dateTimeProviderMock = new Mock<IDateTimeProvider>();
            dateTimeProviderMock.Setup(p => p.GetNowUtc()).Returns(new DateTime(2018, 1, 1));

            Stopwatch stopwatch = new Stopwatch();

            var validLearnersBuilder = new ValidLearnerDataMapper();
            var invalidLearnersBuilder = new InvalidLearnerDataMapper();

            if (validLearners.Length == 1 && validLearners[0].EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                validLearners = ReadValidLearners(stopwatch, ilrFilename, validLearners[0]);
            }

            Message message = null;
            Tuple<Message, ALBGlobal, ValidationErrorDto[], IDataStoreContext> readAndSerialise = await ReadAndDeserialiseAsync(ilrFilename, albDataFilename, valErrorsFilename, validLearners.ToList(), storage, persist, serialise, validationErrorsService);
            var dataStoreContext = readAndSerialise.Item4;
            message = readAndSerialise.Item1;

            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["IlrTestConnectionString"]))
                    {
                        await connection.OpenAsync();

                        output.WriteLine($"SQL Connect: {stopwatch.ElapsedMilliseconds}");
                        stopwatch.Restart();

                        StoreClear storeClear = new StoreClear();
                        await storeClear.ClearAsync(dataStoreContext, connection, cancellationToken);

                        output.WriteLine($"Clear: {stopwatch.ElapsedMilliseconds} {ukPrn} {ilrFilename}");
                        stopwatch.Restart();

                        ////StoreProcessingInformationData storeFileDetails = new StoreProcessingInformationData(dateTimeProviderMock.Object);
                        ////await storeFileDetails.StoreAsync(dataStoreContext, connection, cancellationToken);

                        output.WriteLine($"File details: {stopwatch.ElapsedMilliseconds}");
                        stopwatch.Restart();

                        ////StoreIlr storeIlr = new StoreIlr(logger.Object, validLearnersBuilder, invalidLearnersBuilder);
                        ////await storeIlr.StoreAsync(dataStoreContext, connection, message, validLearners.ToList(), cancellationToken);

                        output.WriteLine($"Store ILR: {stopwatch.ElapsedMilliseconds}");
                        stopwatch.Restart();

                        var fundingOutput =
                        new ALB_global
                        {
                            UKPRN = _ukprn,
                            ALB_Learner = new List<ALB_Learner>
                            {
                                   new ALB_Learner
                                   {
                                       LearnRefNumber = "0ALB01",
                                       UKPRN = _ukprn,
                                       ALB_Learner_Period = new List<ALB_Learner_Period>
                                       {
                                           new ALB_Learner_Period
                                           {
                                               LearnRefNumber = "0ALB01",
                                               UKPRN = _ukprn,
                                               Period = 1,
                                               ALBSeqNum = 1
                                           }
                                       },
                                       ALB_Learner_PeriodisedValues = new List<ALB_Learner_PeriodisedValues>
                                       {
                                           new ALB_Learner_PeriodisedValues
                                           {
                                               LearnRefNumber = "0ALB01",
                                               UKPRN = _ukprn,
                                               AttributeName = "ALBSeqNum",
                                               Period_1 = 1.0m,
                                               Period_2 = 1.0m,
                                               Period_3 = 1.0m,
                                               Period_4 = 1.0m,
                                               Period_5 = 1.0m,
                                               Period_6 = 1.0m,
                                               Period_7 = 1.0m,
                                               Period_8 = 1.0m,
                                               Period_9 = 1.0m,
                                               Period_10 = 1.0m,
                                               Period_11 = 1.0m,
                                               Period_12 = 1.0m,
                                           }
                                       },
                                       ALB_LearningDelivery = new List<ALB_LearningDelivery>
                                       {
                                           new ALB_LearningDelivery
                                           {
                                               UKPRN = _ukprn,
                                               LearnRefNumber = "0ALB01",
                                               AimSeqNumber = 1,
                                               ALB_LearningDelivery_Period = new List<ALB_LearningDelivery_Period>
                                               {
                                                   new ALB_LearningDelivery_Period
                                                   {
                                                       UKPRN = _ukprn,
                                                       LearnRefNumber = "0ALB01",
                                                       AimSeqNumber = 1,
                                                       Period = 1
                                                   }
                                               },
                                               ALB_LearningDelivery_PeriodisedValues = new List<ALB_LearningDelivery_PeriodisedValues>
                                               {
                                                   new ALB_LearningDelivery_PeriodisedValues
                                                   {
                                                       UKPRN = _ukprn,
                                                       LearnRefNumber = "0ALB01",
                                                       AimSeqNumber = 1,
                                                       AttributeName = "Attribute1"
                                                   }
                                               }
                                           }
                                       }
                                   }
                            }
                        };

                        var global = fundingOutput;
                        var learners = fundingOutput.ALB_Learner;
                        var learnerPeriods = fundingOutput.ALB_Learner.SelectMany(l => l.ALB_Learner_Period);
                        var learnerPeriodisedValues = fundingOutput.ALB_Learner.SelectMany(l => l.ALB_Learner_PeriodisedValues);
                        var learningDeliveries = fundingOutput.ALB_Learner.SelectMany(ld => ld.ALB_LearningDelivery);
                        var learningDeliveryPeriod = fundingOutput.ALB_Learner.SelectMany(ld => ld.ALB_LearningDelivery.SelectMany(p => p.ALB_LearningDelivery_Period));
                        var learningDeliveryPeriodisedValues = fundingOutput.ALB_Learner.SelectMany(ld => ld.ALB_LearningDelivery.SelectMany(p => p.ALB_LearningDelivery_PeriodisedValues));

                        IALBMapper albMapperMock = new ALBMapper();
                        IBulkInsert bulkInsert = new BulkInsert();

                        ////StoreALB storeRuleAlb = new StoreALB(albMapperMock, bulkInsert);
                        ////await storeRuleAlb.StoreAsync(readAndSerialise.Item2, connection, cancellationToken);

                        output.WriteLine($"Store ALB: {stopwatch.ElapsedMilliseconds}");
                        stopwatch.Restart();

                        // StoreValidationOutput storeValidationOutput = new StoreValidationOutput(null, validationErrorsService.Object);
                        // await storeValidationOutput.StoreAsync(dataStoreContext, transaction, ukPrn, message, cancellationToken);
                        output.WriteLine($"Store Val: {stopwatch.ElapsedMilliseconds}");
                        stopwatch.Restart();

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

                        using (SqlCommand sqlCommand =
                            new SqlCommand($"SELECT Count(LearnRefNumber) FROM Rulebase.ALB_Learner Where UKPRN = {ukPrn}", connection))
                        {
                            Assert.Equal(4, sqlCommand.ExecuteScalar());
                        }

                        output.WriteLine($"Assert: {stopwatch.ElapsedMilliseconds}");
                        stopwatch.Restart();
                    }

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw;
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

        private async Task<Tuple<Message, ALBGlobal, ValidationErrorDto[], IDataStoreContext>> ReadAndDeserialiseAsync(
            string ilrFilename,
            string albFilename,
            string valErrorsDtoFilename,
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

            var dataStoreContextMock = new Mock<IDataStoreContext>();

            dataStoreContextMock.SetupGet(c => c.Filename).Returns(Path.GetFileName(ilrFilename));
            dataStoreContextMock.SetupGet(c => c.OriginalFilename).Returns(Path.GetFileName(ilrFilename));
            dataStoreContextMock.SetupGet(c => c.ValidLearnRefNumbersKey).Returns(validLearnersKey);
            dataStoreContextMock.SetupGet(c => c.FileSizeInBytes).Returns(new FileInfo(ilrFilename).Length);
            dataStoreContextMock.SetupGet(c => c.Ukprn).Returns(message.HeaderEntity.SourceEntity.UKPRN);
            dataStoreContextMock.SetupGet(c => c.ValidLearnRefNumbersCount).Returns(validLearners.Count);
            dataStoreContextMock.SetupGet(c => c.InvalidLearnRefNumbersCount).Returns(message.Learner.Length - validLearners.Count);
            dataStoreContextMock.SetupGet(c => c.ValidationTotalErrorCount).Returns(10);
            dataStoreContextMock.SetupGet(c => c.ValidationTotalWarningCount).Returns(20);
            dataStoreContextMock.SetupGet(c => c.FundingALBOutputKey).Returns(keyAlbOutput);
            dataStoreContextMock.SetupGet(c => c.ValidationErrorsKey).Returns(keyValErrors);
            dataStoreContextMock.SetupGet(c => c.ValidationErrorsLookupsKey).Returns(keyValErrorsLookup);
            dataStoreContextMock.SetupGet(c => c.SubmissionDateTimeUtc).Returns(new DateTime(2018, 1, 1));

            storage.Setup(x => x.GetAsync(Path.GetFileName(ilrFilename), It.IsAny<CancellationToken>())).ReturnsAsync(ilrContents);

            // storage.Setup(x => x.GetAsync(Path.GetFileName(albFilename))).ReturnsAsync(albContents);
            persist.Setup(x => x.GetAsync(validLearnersKey, It.IsAny<CancellationToken>())).ReturnsAsync(validLearnersSerialised);
            persist.Setup(x => x.GetAsync(keyAlbOutput, It.IsAny<CancellationToken>())).ReturnsAsync(albContents);

            serialise.Setup(x => x.Deserialize<List<string>>(validLearnersSerialised)).Returns(validLearners);
            serialise.Setup(x => x.Deserialize<Message>(ilrContents)).Returns(message);
            serialise.Setup(x => x.Deserialize<ALBGlobal>(albContents)).Returns(fundingOutputs);

            validationErrorsService.Setup(x => x.GetValidationErrorsAsync(keyValErrors, keyValErrorsLookup))
                .ReturnsAsync(validationErrorDtos);

            output.WriteLine($"Moq: {stopwatch.ElapsedMilliseconds}");

            return new Tuple<Message, ALBGlobal, ValidationErrorDto[], IDataStoreContext>(message, fundingOutputs, validationErrorDtos, dataStoreContextMock.Object);
        }
    }
}
