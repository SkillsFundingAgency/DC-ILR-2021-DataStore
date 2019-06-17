namespace ESFA.DC.ILR1920.DataStore.EF
{
    public partial class AEC_LearningDelivery_PeriodisedTextValue
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int AimSeqNumber { get; set; }
        public string AttributeName { get; set; }
        public string Period_1 { get; set; }
        public string Period_2 { get; set; }
        public string Period_3 { get; set; }
        public string Period_4 { get; set; }
        public string Period_5 { get; set; }
        public string Period_6 { get; set; }
        public string Period_7 { get; set; }
        public string Period_8 { get; set; }
        public string Period_9 { get; set; }
        public string Period_10 { get; set; }
        public string Period_11 { get; set; }
        public string Period_12 { get; set; }

        public virtual AEC_LearningDelivery AEC_LearningDelivery { get; set; }
    }
}
