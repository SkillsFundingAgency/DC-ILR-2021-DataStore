using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.PersistData.Abstract;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR.DataStore.PersistData.Providers
{
    public class FM36ProviderService : AbstractProviderService<FM36Global>, IProviderService<FM36Global>
    {
        public FM36ProviderService(
            IFileService fileService,
            IJsonSerializationService jsonSerializationService,
            ILogger logger)
            : base(fileService, jsonSerializationService, logger)
        {
        }

        public Task<FM36Global> ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return ProvideAsync(dataStoreContext.FundingFM36Output, dataStoreContext.Container, cancellationToken);
        }
    }
}
