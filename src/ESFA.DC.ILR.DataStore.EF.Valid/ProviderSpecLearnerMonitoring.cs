namespace ESFA.DC.ILR1920.DataStore.EF.Valid
{
    public partial class ProviderSpecLearnerMonitoring
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public string ProvSpecLearnMonOccur { get; set; }
        public string ProvSpecLearnMon { get; set; }

        public virtual Learner Learner { get; set; }
    }
}
