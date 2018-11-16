using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.AttributeFilters;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.Dto;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Service;
using ESFA.DC.ILR1819.DataStore.PersistData.Constant;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Services.Providers
{
    public class FM70ProviderService : BaseFundingModelProviderService<FM70Global>, IProviderService<FM70Global>
    {
        public FM70ProviderService(
            [KeyFilter(PersistenceStorageKeys.Redis)]
            IKeyValuePersistenceService keyValuePersistenceService,
            IJsonSerializationService jsonSerializationService,
            ILogger logger)
            : base(keyValuePersistenceService, jsonSerializationService, logger, FundModelConstants.FM70)
        {
        }

        public Task<FM70Global> ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return ReadAndDeserialiseFileAsync(dataStoreContext.FundingFM70OutputKey, cancellationToken);
        }
    }
}
