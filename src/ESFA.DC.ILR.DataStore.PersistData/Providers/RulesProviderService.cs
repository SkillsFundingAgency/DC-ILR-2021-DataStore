using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Model.ReferenceData;
using ESFA.DC.ILR.DataStore.PersistData.Abstract;
using ESFA.DC.ILR.ReferenceDataService.Model;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR.DataStore.PersistData.Providers
{
    public class RulesProviderService : AbstractProviderService<ReferenceDataRoot>, IProviderService<List<ValidationRule>>
    {
        public RulesProviderService(
            IFileService fileService,
            IJsonSerializationService jsonSerializationService,
            ILogger logger)
            : base(fileService, jsonSerializationService, logger)
        {
        }

        public async Task<List<ValidationRule>> ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            var referenceData = await ProvideAsync(dataStoreContext.IlrReferenceData, dataStoreContext.Container, cancellationToken);

            return referenceData.MetaDatas.ValidationErrors.Select(item => new ValidationRule
            {
                RuleName = item.RuleName,
                Message = item.Message
            }).ToList();
        }
    }
}
