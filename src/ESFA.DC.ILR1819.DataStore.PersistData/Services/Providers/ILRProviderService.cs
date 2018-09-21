using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services.Providers
{
    public class ILRProviderService : IILRProviderService
    {
        private IStreamableKeyValuePersistenceService _storage;
        private IXmlSerializationService _xmlSerializationService;
        private ILogger _logger;

        public ILRProviderService(
            IStreamableKeyValuePersistenceService storage,
            IXmlSerializationService xmlSerializationService,
            ILogger logger)
        {
            _storage = storage;
            _xmlSerializationService = xmlSerializationService;
            _logger = logger;
        }

        public async Task<Message> ReadAndDeserialiseIlrAsync(string ilrFilename, CancellationToken cancellationToken)
        {
            Message message = null;

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await _storage.GetAsync(ilrFilename, ms, cancellationToken);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        return null;
                    }

                    ms.Seek(0, SeekOrigin.Begin);
                    message = _xmlSerializationService.Deserialize<Message>(ms);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to retrieve and deserialise message", ex);
            }

            return message;
        }
    }
}
