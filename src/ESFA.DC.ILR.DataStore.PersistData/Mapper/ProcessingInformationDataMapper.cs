using ESFA.DC.DateTimeProvider.Interface;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.DataStore.Model.Interface;
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

        public void MapData(IDataStoreCache cache, IDataStoreContext dataStoreContext)
        {
            PopulateDataStoreCache(cache, dataStoreContext);
        }

        private void PopulateDataStoreCache(IDataStoreCache cache, IDataStoreContext dataStoreContext)
        {
            cache.Add(BuildFileDetail(dataStoreContext));
            cache.Add(BuildProcessingData(dataStoreContext));
        }

        private FileDetail BuildFileDetail(IDataStoreContext dataStoreContext)
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
                    TotalWarningCount = dataStoreContext.ValidationTotalWarningCount
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
