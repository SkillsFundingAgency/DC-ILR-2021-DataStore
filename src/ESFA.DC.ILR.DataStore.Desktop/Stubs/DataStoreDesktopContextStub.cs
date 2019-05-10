using System;
using ESFA.DC.ILR.DataStore.Interface;

namespace ESFA.DC.ILR.DataStore.Desktop.Stubs
{
    public class DataStoreDesktopContextStub : IDataStoreContext
    {
        public int Ukprn { get; set; }
        public string Filename { get; set; }
        public string OriginalFilename { get; set; }
        public string Container { get; set; }
        public string CollectionYear { get; set; }
        public string ReturnCode { get; set; }
        public DateTime? SubmissionDateTimeUtc { get; set; }
        public long FileSizeInBytes { get; set; }
        public int ValidLearnRefNumbersCount { get; set; }
        public int InvalidLearnRefNumbersCount { get; set; }
        public int ValidationTotalErrorCount { get; set; }
        public int ValidationTotalWarningCount { get; set; }
        public string ValidationErrorsKey { get; set; }
        public string ValidationErrorsLookupsKey { get; set; }
        public string FundingFM81OutputKey { get; set; }
        public string FundingFM70OutputKey { get; set; }
        public string FundingFM36OutputKey { get; set; }
        public string FundingFM35OutputKey { get; set; }
        public string FundingFM25OutputKey { get; set; }
        public string FundingALBOutputKey { get; set; }
        public string ValidLearnRefNumbersKey { get; set; }
        public string IlrDatabaseConnectionString { get; set; }
        public string AppEarnHistoryDatabaseConnectionString { get; set; }
    }
}
