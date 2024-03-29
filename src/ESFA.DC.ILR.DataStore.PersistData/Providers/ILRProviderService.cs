﻿using System;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR.DataStore.PersistData.Providers
{
    public class ILRProviderService : IProviderService<Message>
    {
        private readonly IFileService _fileService;
        private readonly IXmlSerializationService _xmlSerializationService;
        private readonly ILogger _logger;

        public ILRProviderService(
            IFileService fileService,
            IXmlSerializationService xmlSerializationService,
            ILogger logger)
        {
            _fileService = fileService;
            _xmlSerializationService = xmlSerializationService;
            _logger = logger;
        }

        public async Task<Message> ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            _logger.LogInfo("Starting file retrieval for file" + dataStoreContext.Filename);

            try
            {
                using (var stream = await _fileService.OpenReadStreamAsync(dataStoreContext.Filename, dataStoreContext.Container, cancellationToken))
                {
                    return _xmlSerializationService.Deserialize<Message>(stream);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to retrieve and deserialise message", ex);
                throw;
            }
        }
    }
}
