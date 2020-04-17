using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.IO.Model.Validation;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR.DataStore.PersistData.Providers
{
    using ESFA.DC.FileService.Interface;

    public class ValidationErrorsProviderService : IProviderService<List<ValidationError>>
    {
        private readonly IJsonSerializationService _jsonSerializationService;
        private readonly IFileService _fileService;

        public ValidationErrorsProviderService(
            IJsonSerializationService jsonSerializationService,
            IFileService fileService)
        {
            _jsonSerializationService = jsonSerializationService;
            _fileService = fileService;
        }

        public async Task<List<ValidationError>> ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            using (var stream = await _fileService.OpenReadStreamAsync(dataStoreContext.ValidationErrors, dataStoreContext.Container, cancellationToken))
            {
                return _jsonSerializationService.Deserialize<List<ValidationError>>(stream);
            }
        }
    }
}
