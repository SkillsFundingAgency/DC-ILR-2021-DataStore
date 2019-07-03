using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.ReferenceData;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR.IO.Model.Validation;
using ESFA.DC.ILR.Model;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.DataStore.PersistData.Test
{
    public class DataStoreDataProviderTests
    {
        [Fact]
        public void ProvideMessageAsync()
        {
            var mock = new Mock<IProviderService<Message>>();
            var dataStoreContextMock = new Mock<IDataStoreContext>().Object;
            var mockMessageTask = Task.FromResult(new Mock<Message>().Object);
            var cancellationToken = CancellationToken.None;

            mock.Setup(p => p.ProvideAsync(dataStoreContextMock, cancellationToken)).Returns(mockMessageTask);

            NewProvider(mock.Object).ProvideMessageAsync(dataStoreContextMock, cancellationToken).Should().Be(mockMessageTask);
        }

        [Fact]
        public void ProvideValidLearnersAsync()
        {
            var mock = new Mock<IProviderService<List<string>>>();
            var dataStoreContextMock = new Mock<IDataStoreContext>().Object;
            var task = Task.FromResult(new Mock<List<string>>().Object);
            var cancellationToken = CancellationToken.None;

            mock.Setup(p => p.ProvideAsync(dataStoreContextMock, cancellationToken)).Returns(task);

            NewProvider(validLearnerProviderService: mock.Object).ProvideValidLearnersAsync(dataStoreContextMock, cancellationToken).Should().Be(task);
        }

        [Fact]
        public void ProvideALBAsync()
        {
            var mock = new Mock<IProviderService<ALBGlobal>>();
            var dataStoreContextMock = new Mock<IDataStoreContext>().Object;
            var task = Task.FromResult(new Mock<ALBGlobal>().Object);
            var cancellationToken = CancellationToken.None;

            mock.Setup(p => p.ProvideAsync(dataStoreContextMock, cancellationToken)).Returns(task);

            NewProvider(albProviderService: mock.Object).ProvideALBAsync(dataStoreContextMock, cancellationToken).Should().Be(task);
        }

        [Fact]
        public void ProvideFM25Async()
        {
            var mock = new Mock<IProviderService<FM25Global>>();
            var dataStoreContextMock = new Mock<IDataStoreContext>().Object;
            var task = Task.FromResult(new Mock<FM25Global>().Object);
            var cancellationToken = CancellationToken.None;

            mock.Setup(p => p.ProvideAsync(dataStoreContextMock, cancellationToken)).Returns(task);

            NewProvider(fm25ProviderService: mock.Object).ProvideFM25Async(dataStoreContextMock, cancellationToken).Should().Be(task);
        }

        [Fact]
        public void ProvideFM35Async()
        {
            var mock = new Mock<IProviderService<FM35Global>>();
            var dataStoreContextMock = new Mock<IDataStoreContext>().Object;
            var task = Task.FromResult(new Mock<FM35Global>().Object);
            var cancellationToken = CancellationToken.None;

            mock.Setup(p => p.ProvideAsync(dataStoreContextMock, cancellationToken)).Returns(task);

            NewProvider(fm35ProviderService: mock.Object).ProvideFM35Async(dataStoreContextMock, cancellationToken).Should().Be(task);
        }

        [Fact]
        public void ProvideFM36Async()
        {
            var mock = new Mock<IProviderService<FM36Global>>();
            var dataStoreContextMock = new Mock<IDataStoreContext>().Object;
            var task = Task.FromResult(new Mock<FM36Global>().Object);
            var cancellationToken = CancellationToken.None;

            mock.Setup(p => p.ProvideAsync(dataStoreContextMock, cancellationToken)).Returns(task);

            NewProvider(fm36ProviderService: mock.Object).ProvideFM36Async(dataStoreContextMock, cancellationToken).Should().Be(task);
        }

        [Fact]
        public void ProvideFM70Async()
        {
            var mock = new Mock<IProviderService<FM70Global>>();
            var dataStoreContextMock = new Mock<IDataStoreContext>().Object;
            var task = Task.FromResult(new Mock<FM70Global>().Object);
            var cancellationToken = CancellationToken.None;

            mock.Setup(p => p.ProvideAsync(dataStoreContextMock, cancellationToken)).Returns(task);

            NewProvider(fm70ProviderService: mock.Object).ProvideFM70Async(dataStoreContextMock, cancellationToken).Should().Be(task);
        }

        [Fact]
        public void ProvideFM81Async()
        {
            var mock = new Mock<IProviderService<FM81Global>>();
            var dataStoreContextMock = new Mock<IDataStoreContext>().Object;
            var task = Task.FromResult(new Mock<FM81Global>().Object);
            var cancellationToken = CancellationToken.None;

            mock.Setup(p => p.ProvideAsync(dataStoreContextMock, cancellationToken)).Returns(task);

            NewProvider(fm81ProviderService: mock.Object).ProvideFM81Async(dataStoreContextMock, cancellationToken).Should().Be(task);
        }

        [Fact]
        public void ProvideValidationErrorsAsync()
        {
            var mock = new Mock<IProviderService<List<ValidationError>>>();
            var dataStoreContextMock = new Mock<IDataStoreContext>().Object;
            var task = Task.FromResult(new Mock<List<ValidationError>>().Object);
            var cancellationToken = CancellationToken.None;

            mock.Setup(p => p.ProvideAsync(dataStoreContextMock, cancellationToken)).Returns(task);

            NewProvider(validationErrorsProviderService: mock.Object).ProvideValidationErrorsAsync(dataStoreContextMock, cancellationToken).Should().Be(task);
        }

        [Fact]
        public void ProvideRulesAsync()
        {
            var mock = new Mock<IProviderService<List<ValidationRule>>>();
            var dataStoreContextMock = new Mock<IDataStoreContext>().Object;
            var task = Task.FromResult(new Mock<List<ValidationRule>>().Object);
            var cancellationToken = CancellationToken.None;

            mock.Setup(p => p.ProvideAsync(dataStoreContextMock, cancellationToken)).Returns(task);

            NewProvider(rulesProviderService: mock.Object).ProvideRulesAsync(dataStoreContextMock, cancellationToken).Should().Be(task);
        }

        private DataStoreDataProvider NewProvider(
            IProviderService<Message> ilrProviderService = null,
            IProviderService<ALBGlobal> albProviderService = null,
            IProviderService<FM25Global> fm25ProviderService = null,
            IProviderService<FM35Global> fm35ProviderService = null,
            IProviderService<FM36Global> fm36ProviderService = null,
            IProviderService<FM70Global> fm70ProviderService = null,
            IProviderService<FM81Global> fm81ProviderService = null,
            IProviderService<List<string>> validLearnerProviderService = null,
            IProviderService<List<ValidationError>> validationErrorsProviderService = null,
            IProviderService<List<ValidationRule>> rulesProviderService = null)
        {
            return new DataStoreDataProvider(
                ilrProviderService,
                albProviderService,
                fm25ProviderService,
                fm35ProviderService,
                fm36ProviderService,
                fm70ProviderService,
                fm81ProviderService,
                validLearnerProviderService,
                validationErrorsProviderService,
                rulesProviderService);
        }
    }
}
