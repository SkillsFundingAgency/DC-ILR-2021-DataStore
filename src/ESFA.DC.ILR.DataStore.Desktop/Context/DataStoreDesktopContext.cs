using System;
using ESFA.DC.ILR.Constants;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.Desktop.Interface;

namespace ESFA.DC.ILR.DataStore.Desktop.Context
{
    public class DataStoreDesktopContext : IDataStoreContext
    {
        private readonly IDesktopContext _desktopContext;

        public DataStoreDesktopContext(IDesktopContext desktopContext)
        {
            _desktopContext = desktopContext;
        }

        public int Ukprn => 1234;

        public string Filename => _desktopContext.KeyValuePairs[ILRContextKeys.Filename].ToString();

        public string OriginalFilename => _desktopContext.KeyValuePairs[ILRContextKeys.OriginalFilename].ToString();

        public string Container => _desktopContext.KeyValuePairs[ILRContextKeys.Container].ToString();

        public string CollectionYear => _desktopContext.KeyValuePairs[ILRContextKeys.CollectionYear].ToString();

        public string ReturnPeriod => _desktopContext.KeyValuePairs[ILRContextKeys.ReturnPeriod].ToString();

        public DateTime? SubmissionDateTimeUtc => _desktopContext.DateTimeUtc;

        public long FileSizeInBytes => long.Parse(_desktopContext.KeyValuePairs[ILRContextKeys.FileSizeInBytes].ToString());

        public int ValidLearnRefNumbersCount => int.Parse(_desktopContext.KeyValuePairs[ILRContextKeys.ValidLearnRefNumbersCount].ToString());

        public int InvalidLearnRefNumbersCount => int.Parse(_desktopContext.KeyValuePairs[ILRContextKeys.InvalidLearnRefNumbersCount].ToString());

        public int ValidationTotalErrorCount => int.Parse(_desktopContext.KeyValuePairs[ILRContextKeys.ValidationTotalErrorCount].ToString());

        public int ValidationTotalWarningCount => int.Parse(_desktopContext.KeyValuePairs[ILRContextKeys.ValidationTotalWarningCount].ToString());

        public string ValidationErrors => _desktopContext.KeyValuePairs[ILRContextKeys.ValidationErrors].ToString();

        public string FundingFM81Output => _desktopContext.KeyValuePairs[ILRContextKeys.FundingFm81Output].ToString();

        public string FundingFM70Output
        {
            get => throw new NotSupportedException();
        }

        public string FundingFM36Output => _desktopContext.KeyValuePairs[ILRContextKeys.FundingFm36Output].ToString();

        public string FundingFM35Output => _desktopContext.KeyValuePairs[ILRContextKeys.FundingFm35Output].ToString();

        public string FundingFM25Output => _desktopContext.KeyValuePairs[ILRContextKeys.FundingFm25Output].ToString();

        public string FundingALBOutput => _desktopContext.KeyValuePairs[ILRContextKeys.FundingAlbOutput].ToString();

        public string IlrReferenceData => _desktopContext.KeyValuePairs[ILRContextKeys.IlrReferenceData].ToString();

        public string ValidLearnRefNumbers => _desktopContext.KeyValuePairs[ILRContextKeys.ValidLearnRefNumbers].ToString();

        public string IlrDatabaseConnectionString => _desktopContext.KeyValuePairs[ILRContextKeys.IlrDatabaseConnectionString].ToString();

        public string AppEarnHistoryDatabaseConnectionString
        {
            get => throw new NotImplementedException();
        }
    }
}
