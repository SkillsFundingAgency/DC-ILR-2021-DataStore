using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR.DataStore.PersistData.Providers
{
    using ESFA.DC.FileService.Interface;

    public class ValidLearnerProviderService : IProviderService<List<string>>
    {
        private readonly IJsonSerializationService _jsonSerializationService;
        private readonly IFileService _fileService;

        public ValidLearnerProviderService(
            IJsonSerializationService jsonSerializationService,
            IFileService fileService)
        {
            _jsonSerializationService = jsonSerializationService;
            _fileService = fileService;
        }

        public async Task<List<string>> ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            using (var stream = await _fileService.OpenReadStreamAsync(dataStoreContext.ValidLearnRefNumbers, dataStoreContext.Container, cancellationToken))
            {
                return _jsonSerializationService.Deserialize<List<string>>(stream);
            }
        }
    }
}
