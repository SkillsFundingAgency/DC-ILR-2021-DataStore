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
    public class ReferenceDataVersionsProviderService : AbstractProviderService<ReferenceDataRoot>, IProviderService<ReferenceDataVersions>
    {
        public ReferenceDataVersionsProviderService(
            IFileService fileService, 
            IJsonSerializationService jsonSerializationService, 
            ILogger logger) 
            : base(fileService, jsonSerializationService, logger)
        {
        }

        public async Task<ReferenceDataVersions> ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            var referenceData = await ProvideAsync(dataStoreContext.IlrReferenceData, dataStoreContext.Container, cancellationToken);

            var referenceDataVersions = referenceData.MetaDatas.ReferenceDataVersions;

            return new ReferenceDataVersions()
            {
                OrgName = referenceData.Organisations.FirstOrDefault(o => o.UKPRN == dataStoreContext.Ukprn)?.Name ?? string.Empty,
                OrgVersion = referenceDataVersions.OrganisationsVersion.Version,
                LarsVersion = referenceDataVersions.LarsVersion.Version,
                EmployersVersion = referenceDataVersions.Employers.Version,
                PostcodesVersion = referenceDataVersions.PostcodesVersion.Version,
                CampusIdentifierVersion = referenceDataVersions.CampusIdentifierVersion.Version,
                EasUploadDateTime = referenceDataVersions.EasUploadDateTime.UploadDateTime
            };
        }
    }
}
