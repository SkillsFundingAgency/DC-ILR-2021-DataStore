using System;
using ESFA.DC.ILR.Constants;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Stateless.Configuration;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.JobContextManager.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Stateless.Context
{
    public class DataStoreJobContextMessageContext : IDataStoreContext
    {
        private readonly IJobContextMessage _jobContextMessage;
        private readonly PersistDataConfiguration _persistDataConfiguration;

        public DataStoreJobContextMessageContext(IJobContextMessage jobContextMessage, PersistDataConfiguration persistDataConfiguration)
        {
            _jobContextMessage = jobContextMessage;
            _persistDataConfiguration = persistDataConfiguration;
        }

        public int Ukprn => int.Parse(_jobContextMessage.KeyValuePairs[JobContextMessageKey.UkPrn].ToString());

        public string Filename => _jobContextMessage.KeyValuePairs[ILRContextKeys.Filename].ToString();

        public string OriginalFilename => _jobContextMessage.KeyValuePairs[ILRContextKeys.OriginalFilename].ToString();

        public string Container => _jobContextMessage.KeyValuePairs[ILRContextKeys.Container].ToString();

        public string CollectionYear => "1920";

        public string ReturnPeriod => _jobContextMessage.KeyValuePairs[ILRContextKeys.ReturnPeriod].ToString();

        public DateTime? SubmissionDateTimeUtc => _jobContextMessage.SubmissionDateTimeUtc;

        public long FileSizeInBytes => long.Parse(_jobContextMessage.KeyValuePairs[ILRContextKeys.FileSizeInBytes].ToString());

        public int ValidLearnRefNumbersCount => int.Parse(_jobContextMessage.KeyValuePairs[ILRContextKeys.ValidLearnRefNumbersCount].ToString());

        public int InvalidLearnRefNumbersCount => int.Parse(_jobContextMessage.KeyValuePairs[ILRContextKeys.InvalidLearnRefNumbersCount].ToString());

        public int ValidationTotalErrorCount => int.Parse(_jobContextMessage.KeyValuePairs[ILRContextKeys.ValidationTotalErrorCount].ToString());

        public int ValidationTotalWarningCount => int.Parse(_jobContextMessage.KeyValuePairs[ILRContextKeys.ValidationTotalWarningCount].ToString());

        public string ValidationErrors => _jobContextMessage.KeyValuePairs[ILRContextKeys.ValidationErrors].ToString();

        public string FundingFM81Output => _jobContextMessage.KeyValuePairs[ILRContextKeys.FundingFm81Output].ToString();

        public string FundingFM70Output => _jobContextMessage.KeyValuePairs[ILRContextKeys.FundingFm70Output].ToString();

        public string FundingFM36Output => _jobContextMessage.KeyValuePairs[ILRContextKeys.FundingFm36Output].ToString();

        public string FundingFM35Output => _jobContextMessage.KeyValuePairs[ILRContextKeys.FundingFm35Output].ToString();

        public string FundingFM25Output => _jobContextMessage.KeyValuePairs[ILRContextKeys.FundingFm25Output].ToString();

        public string FundingALBOutput => _jobContextMessage.KeyValuePairs[ILRContextKeys.FundingAlbOutput].ToString();

        public string IlrReferenceData => _jobContextMessage.KeyValuePairs[ILRContextKeys.IlrReferenceData].ToString();

        public string ValidLearnRefNumbers => _jobContextMessage.KeyValuePairs[ILRContextKeys.ValidLearnRefNumbers].ToString();

        public string IlrDatabaseConnectionString => _persistDataConfiguration.ILRDataStoreConnectionString;

        public string AppEarnHistoryDatabaseConnectionString => _persistDataConfiguration.AppEarnHistoryDataStoreConnectionString;

        public string EsfFundingDatabaseConnectionString => _persistDataConfiguration.EsfFundingDatabaseConnectionString;
    }
}
