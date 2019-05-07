using ESFA.DC.DateTimeProvider.Interface;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.DataStore.Model.File;
using ESFA.DC.ILR1819.DataStore.EF;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Mapper
{
    public class ProcessingInformationDataMapper : IProcessingInformationDataMapper
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public ProcessingInformationDataMapper(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public ProcessingInformationData MapData(IDataStoreContext dataStoreContext)
        {
            return new ProcessingInformationData()
            {
                FileDetail = MapFileDetail(dataStoreContext),
                ProcessingData = MapProcessingData(dataStoreContext),
            };
        }

        private FileDetail MapFileDetail(IDataStoreContext dataStoreContext)
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

        private ProcessingData MapProcessingData(IDataStoreContext dataStoreContext)
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
