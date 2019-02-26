using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.AttributeFilters;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.Dto;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData.Abstract;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services.Providers
{
    public class FM81ProviderService : AbstractProviderService<FM81Global>, IProviderService<FM81Global>
    {
        public FM81ProviderService(
            IFileService fileService,
            IJsonSerializationService jsonSerializationService,
            ILogger logger)
        : base(fileService, jsonSerializationService, logger)
        {
        }

        public Task<FM81Global> ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return ProvideAsync(dataStoreContext.FundingFM81OutputKey, dataStoreContext.Container, cancellationToken);
        }
    }
}
