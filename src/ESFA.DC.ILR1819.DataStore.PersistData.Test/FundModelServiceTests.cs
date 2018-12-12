using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData.Persist;
using ESFA.DC.ILR1819.DataStore.PersistData.Persist.Mappers;
using ESFA.DC.ILR1819.DataStore.PersistData.Services;
using ESFA.DC.ILR1819.DataStore.PersistData.Services.Providers;
using ESFA.DC.ILR1819.DataStore.Stateless.Context;
using ESFA.DC.JobContext;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Serialization.Json;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Test
{
    public class FundModelServiceTests
    {
        [Fact]
        public void GetAndStoreModel()
        {
            var fundmodelData = new FM35Global
            {
                UKPRN = 12345678,
                Learners = new List<FM35Learner>
                {
                    new FM35Learner
                    {
                        LearnRefNumber = "Learner1"
                    }
                }
            };

            var token = default(CancellationToken);

            var dataStoreContext = new Mock<IDataStoreContext>();
            var providerService = new Mock<IProviderService<FM35Global>>();
            var logger = new Mock<ILogger>();

            dataStoreContext.Setup(ds => ds.FundingFM35OutputKey).Returns("FundingFm35Output");
            providerService.Setup(ps => ps.ProvideAsync(dataStoreContext.Object, token)).ReturnsAsync(fundmodelData);

            SqlTransaction transaction = null;

            var modelService = NewService(providerService.Object, logger.Object).GetAndStoreFundModel(dataStoreContext.Object, transaction, token);

            logger.Invocations.Should().HaveCount(0);
        }

        [Fact]
        public void GetAndStoreModel_NoLearners()
        {
            var fundmodelData = new FM35Global
            {
                UKPRN = 12345678
            };

            var token = default(CancellationToken);

            var dataStoreContext = new Mock<IDataStoreContext>();
            var providerService = new Mock<IProviderService<FM35Global>>();
            var logger = new Mock<ILogger>();

            dataStoreContext.Setup(ds => ds.FundingFM35OutputKey).Returns("FundingFm35Output");
            providerService.Setup(ps => ps.ProvideAsync(dataStoreContext.Object, token)).ReturnsAsync(fundmodelData);

            SqlTransaction transaction = null;

            var modelService = NewService(providerService.Object, logger.Object).GetAndStoreFundModel(dataStoreContext.Object, transaction, token);

            logger.Invocations.Should().HaveCount(1);
            logger.Invocations.SelectMany(l => l.Arguments).Should().Contain("No Learners to Persist");
        }

        [Fact]
        public void GetAndStoreModel_NoFundModelData()
        {
            var fundmodelData = new FM35Global
            {
                UKPRN = 12345678
            };

            var token = default(CancellationToken);

            var dataStoreContext = new Mock<IDataStoreContext>();
            var providerService = new Mock<IProviderService<FM35Global>>();
            var logger = new Mock<ILogger>();

            dataStoreContext.Setup(ds => ds.FundingFM35OutputKey).Returns("FundingFm35Output");
            providerService.Setup(ps => ps.ProvideAsync(dataStoreContext.Object, token)).ReturnsAsync((FM35Global)null);

            SqlTransaction transaction = null;

            var modelService = NewService(providerService.Object, logger.Object).GetAndStoreFundModel(dataStoreContext.Object, transaction, token);

            logger.Invocations.Should().HaveCount(1);
            logger.Invocations.SelectMany(l => l.Arguments).Should().Contain("Failed to get model so not storing");
        }

        public FundModelService<FM35Global, FM35_global> NewService(IProviderService<FM35Global> providerService, ILogger logger)
        {
            return new FundModelService<FM35Global, FM35_global>(providerService, new StoreFM35(), logger);
        }
    }
}
