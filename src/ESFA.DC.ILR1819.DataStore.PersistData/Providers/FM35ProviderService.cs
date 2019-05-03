using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.PersistData.Abstract;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Providers
{
    public class FM35ProviderService : AbstractProviderService<FM35Global>, IProviderService<FM35Global>
    {
        public FM35ProviderService(
            IFileService fileService,
            IJsonSerializationService jsonSerializationService,
            ILogger logger)
            : base(fileService, jsonSerializationService, logger)
        {
        }

        public Task<FM35Global> ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return ProvideAsync(dataStoreContext.FundingFM35OutputKey, dataStoreContext.Container, cancellationToken);
        }
    }
}
