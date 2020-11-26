using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR.DataStore.Interface
{
    public interface IDataStoreContext
    {
        int Ukprn { get; }

        string Filename { get; }

        string OriginalFilename { get; }

        string Container { get; }

        string CollectionYear { get; }

        string ReturnPeriod { get; }

        string CollectionPeriod { get; }

        DateTime? SubmissionDateTimeUtc { get; }

        long FileSizeInBytes { get; }

        int ValidLearnRefNumbersCount { get; }

        int InvalidLearnRefNumbersCount { get; }

        int ValidationTotalErrorCount { get; }

        int ValidationTotalWarningCount { get; }

        string ValidationErrors { get; }

        string FundingFM81Output { get; }

        string FundingFM70Output { get; }

        string FundingFM36Output { get; }

        string FundingFM35Output { get; }

        string FundingFM25Output { get; }

        string FundingALBOutput { get; }

        string IlrReferenceData { get; }

        string ValidLearnRefNumbers { get; }

        string IlrDatabaseConnectionString { get; }

        string AppEarnHistoryDatabaseConnectionString { get; }

        string EsfFundingDatabaseConnectionString { get; }

        string ExportOutputLocation { get; }

        IEnumerable<string> Tasks { get; }
    }
}
