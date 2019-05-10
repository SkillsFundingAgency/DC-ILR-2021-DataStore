using System;

namespace ESFA.DC.ILR.DataStore.Interface
{
    public interface IDataStoreContext
    {
        int Ukprn { get; }

        string Filename { get; }

        string OriginalFilename { get; }

        string Container { get; }

        string CollectionYear { get; }

        string ReturnCode { get; }

        DateTime? SubmissionDateTimeUtc { get; }

        long FileSizeInBytes { get; }

        int ValidLearnRefNumbersCount { get; }

        int InvalidLearnRefNumbersCount { get; }

        int ValidationTotalErrorCount { get; }

        int ValidationTotalWarningCount { get; }

        string ValidationErrorsKey { get; }

        string ValidationErrorsLookupsKey { get; }

        string FundingFM81OutputKey { get; }

        string FundingFM70OutputKey { get; }

        string FundingFM36OutputKey { get; }

        string FundingFM35OutputKey { get; }

        string FundingFM25OutputKey { get; }

        string FundingALBOutputKey { get; }

        string ValidLearnRefNumbersKey { get; }

        string IlrDatabaseConnectionString { get; }

        string AppEarnHistoryDatabaseConnectionString { get; }
    }
}
