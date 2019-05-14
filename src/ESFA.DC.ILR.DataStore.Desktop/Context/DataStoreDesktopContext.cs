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

        public int Ukprn
        {
            get => throw new NotImplementedException();
        }

        public string Filename
        {
            get => throw new NotImplementedException();
        }

        public string OriginalFilename
        {
            get => throw new NotImplementedException();
        }

        public string Container
        {
            get => throw new NotImplementedException();
        }

        public string CollectionYear
        {
            get => throw new NotImplementedException();
        }

        public string ReturnPeriod
        {
            get => throw new NotImplementedException();
        }

        public DateTime? SubmissionDateTimeUtc
        {
            get => throw new NotImplementedException();
        }

        public long FileSizeInBytes
        {
            get => throw new NotImplementedException();
        }

        public int ValidLearnRefNumbersCount
        {
            get => throw new NotImplementedException();
        }

        public int InvalidLearnRefNumbersCount
        {
            get => throw new NotImplementedException();
        }

        public int ValidationTotalErrorCount
        {
            get => throw new NotImplementedException();
        }

        public int ValidationTotalWarningCount
        {
            get => throw new NotImplementedException();
        }

        public string ValidationErrors
        {
            get => throw new NotImplementedException();
        }
        
        public string FundingFM81Output
        {
            get => throw new NotImplementedException();
        }

        public string FundingFM70Output
        {
            get => throw new NotImplementedException();
        }

        public string FundingFM36Output
        {
            get => throw new NotImplementedException();
        }

        public string FundingFM35Output
        {
            get => throw new NotImplementedException();
        }

        public string FundingFM25Output
        {
            get => throw new NotImplementedException();
        }

        public string FundingALBOutput
        {
            get => throw new NotImplementedException();
        }

        public string ValidLearnRefNumbers
        {
            get => throw new NotImplementedException();
        }

        public string IlrDatabaseConnectionString => _desktopContext.KeyValuePairs[ILRContextKeys.IlrDatabaseConnectionString].ToString();

        public string AppEarnHistoryDatabaseConnectionString
        {
            get => throw new NotImplementedException();
        }
    }
}
