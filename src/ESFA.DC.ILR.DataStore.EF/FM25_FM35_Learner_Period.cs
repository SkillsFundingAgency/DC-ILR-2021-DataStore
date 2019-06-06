namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class FM25_FM35_Learner_Period
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int Period { get; set; }
        public decimal? LnrOnProgPay { get; set; }

        public virtual FM25_Learner FM25_Learner { get; set; }
        public virtual FM25_FM35_global UKPRNNavigation { get; set; }
    }
}
