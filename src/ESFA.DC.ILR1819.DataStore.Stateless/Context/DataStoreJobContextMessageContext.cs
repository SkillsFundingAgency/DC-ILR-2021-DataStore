using System;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.JobContextManager.Model.Interface;

namespace ESFA.DC.ILR1819.DataStore.Stateless.Context
{
    public class DataStoreJobContextMessageContext : IDataStoreContext
    {
        private readonly IJobContextMessage _jobContextMessage;

        public DataStoreJobContextMessageContext(IJobContextMessage jobContextMessage)
        {
            _jobContextMessage = jobContextMessage;
        }

        public int Ukprn => int.Parse(_jobContextMessage.KeyValuePairs[JobContextMessageKey.UkPrn].ToString());

        public string Filename => _jobContextMessage.KeyValuePairs[JobContextMessageKey.Filename].ToString();

        public string OriginalFilename => _jobContextMessage.KeyValuePairs["OriginalFilename"].ToString();

        public string Container => _jobContextMessage.KeyValuePairs["Container"].ToString();

        public string CollectionYear => _jobContextMessage.KeyValuePairs[JobContextMessageKey.CollectionYear].ToString();

        public string ReturnCode => _jobContextMessage.KeyValuePairs[JobContextMessageKey.ReturnPeriod].ToString();

        public DateTime? SubmissionDateTimeUtc => _jobContextMessage.SubmissionDateTimeUtc;

        public long FileSizeInBytes => long.Parse(_jobContextMessage.KeyValuePairs[JobContextMessageKey.FileSizeInBytes].ToString());

        public int ValidLearnRefNumbersCount => int.Parse(_jobContextMessage.KeyValuePairs[JobContextMessageKey.ValidLearnRefNumbersCount].ToString());

        public int InvalidLearnRefNumbersCount => int.Parse(_jobContextMessage.KeyValuePairs[JobContextMessageKey.InvalidLearnRefNumbersCount].ToString());

        public int ValidationTotalErrorCount => int.Parse(_jobContextMessage.KeyValuePairs[JobContextMessageKey.ValidationTotalErrorCount].ToString());

        public int ValidationTotalWarningCount => int.Parse(_jobContextMessage.KeyValuePairs[JobContextMessageKey.ValidationTotalErrorCount].ToString());

        public string ValidationErrorsKey => _jobContextMessage.KeyValuePairs[JobContextMessageKey.ValidationErrors].ToString();

        public string ValidationErrorsLookupsKey => _jobContextMessage.KeyValuePairs[JobContextMessageKey.ValidationErrorLookups].ToString();

        public string FundingFM81OutputKey => _jobContextMessage.KeyValuePairs[JobContextMessageKey.FundingFm81Output].ToString();

        public string FundingFM70OutputKey => _jobContextMessage.KeyValuePairs[JobContextMessageKey.FundingFm70Output].ToString();

        public string FundingFM36OutputKey => _jobContextMessage.KeyValuePairs[JobContextMessageKey.FundingFm36Output].ToString();

        public string FundingFM35OutputKey => _jobContextMessage.KeyValuePairs[JobContextMessageKey.FundingFm35Output].ToString();

        public string FundingFM25OutputKey => _jobContextMessage.KeyValuePairs[JobContextMessageKey.FundingFm25Output].ToString();

        public string FundingALBOutputKey => _jobContextMessage.KeyValuePairs[JobContextMessageKey.FundingAlbOutput].ToString();

        public string ValidLearnRefNumbersKey => _jobContextMessage.KeyValuePairs[JobContextMessageKey.ValidLearnRefNumbers].ToString();
    }
}
