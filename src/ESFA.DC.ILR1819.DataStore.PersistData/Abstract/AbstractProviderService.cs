using System;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.FileService.Interface;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Abstract
{
    public abstract class AbstractProviderService<T>
    {
        private readonly IFileService _fileService;
        private readonly IJsonSerializationService _jsonSerializationService;
        private readonly ILogger _logger;

        protected AbstractProviderService(IFileService fileService, IJsonSerializationService jsonSerializationService, ILogger logger)
        {
            _fileService = fileService;
            _jsonSerializationService = jsonSerializationService;
            _logger = logger;
        }

        protected async Task<T> ProvideAsync(string fileReference, string container, CancellationToken cancellationToken)
        {
            try
            {
                using (var stream = await _fileService.OpenReadStreamAsync(fileReference, container, cancellationToken))
                {
                    return _jsonSerializationService.Deserialize<T>(stream);
                }
            }
            catch (Exception ex)
            {
                // Todo: Check behaviour
                _logger.LogError($"Failed to provide {fileReference} funding data in {container}. It will be ignored.", ex);
            }

            return default(T);
        }
    }
}
