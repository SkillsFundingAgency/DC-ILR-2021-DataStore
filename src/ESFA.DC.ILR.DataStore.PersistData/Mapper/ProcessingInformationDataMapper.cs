using ESFA.DC.DateTimeProvider.Interface;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.Model.ReferenceData;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.PersistData.Mapper
{
    public class ProcessingInformationDataMapper : IProcessingInformationDataMapper
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public ProcessingInformationDataMapper(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public void MapData(IDataStoreCache cache, ReferenceDataVersions referenceDataVersions, IDataStoreContext dataStoreContext)
        {
            PopulateDataStoreCache(cache, referenceDataVersions, dataStoreContext);
        }

        private void PopulateDataStoreCache(IDataStoreCache cache, ReferenceDataVersions referenceDataVersions, IDataStoreContext dataStoreContext)
        {
            cache.Add(BuildFileDetail(dataStoreContext, referenceDataVersions));
            cache.Add(BuildProcessingData(dataStoreContext));
        }

        private FileDetail BuildFileDetail(IDataStoreContext dataStoreContext, ReferenceDataVersions referenceDataVersions)
        {
            return new FileDetail()
                {
                    UKPRN = dataStoreContext.Ukprn,
                    Filename = dataStoreContext.OriginalFilename,
                    SubmittedTime = dataStoreContext.SubmissionDateTimeUtc,
                    FileSizeKb = dataStoreContext.FileSizeInBytes / 1024,
                    Success = true,
                    TotalLearnersSubmitted = dataStoreContext.ValidLearnRefNumbersCount + dataStoreContext.InvalidLearnRefNumbersCount,
                    TotalInvalidLearnersSubmitted = dataStoreContext.InvalidLearnRefNumbersCount,
                    TotalValidLearnersSubmitted = dataStoreContext.ValidLearnRefNumbersCount,
                    TotalErrorCount = dataStoreContext.ValidationTotalErrorCount,
                    TotalWarningCount = dataStoreContext.ValidationTotalWarningCount,
                    OrgName = referenceDataVersions.OrgName,
                    OrgVersion = referenceDataVersions.OrgVersion,
                    LarsVersion = referenceDataVersions.LarsVersion,
                    EmployersVersion = referenceDataVersions.EmployersVersion,
                    PostcodesVersion = referenceDataVersions.PostcodesVersion,
                    CampusIdentifierVersion = referenceDataVersions.CampusIdentifierVersion,
                    EasUploadDateTime = referenceDataVersions.EasUploadDateTime
            };
        }

        private ProcessingData BuildProcessingData(IDataStoreContext dataStoreContext)
        {
            return new ProcessingData()
            {
                UKPRN = dataStoreContext.Ukprn,
                ExecutionTime = dataStoreContext.SubmissionDateTimeUtc.Value.Subtract(_dateTimeProvider.GetNowUtc()).ToString(@"dd\.hh\:mm\:ss"),
                ProcessingStep = "End"
            };
        }
    }
}
