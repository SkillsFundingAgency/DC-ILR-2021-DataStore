namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class ESF_LearningDeliveryDeliverable_Period
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int AimSeqNumber { get; set; }
        public string DeliverableCode { get; set; }
        public int Period { get; set; }
        public decimal? AchievementEarnings { get; set; }
        public decimal? AdditionalProgCostEarnings { get; set; }
        public long? DeliverableVolume { get; set; }
        public decimal? ProgressionEarnings { get; set; }
        public int? ReportingVolume { get; set; }
        public decimal? StartEarnings { get; set; }

        public virtual ESF_LearningDelivery ESF_LearningDelivery { get; set; }
    }
}
