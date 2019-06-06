namespace ESFA.DC.ILR1920.DataStore.EF.Invalid
{
    public partial class ProviderSpecLearnerMonitoring
    {
        public int ProviderSpecLearnerMonitoring_Id { get; set; }
        public int? Learner_Id { get; set; }
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public string ProvSpecLearnMonOccur { get; set; }
        public string ProvSpecLearnMon { get; set; }
    }
}
