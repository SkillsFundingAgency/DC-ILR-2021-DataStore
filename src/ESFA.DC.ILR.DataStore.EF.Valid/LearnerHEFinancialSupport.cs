namespace ESFA.DC.ILR1920.DataStore.EF.Valid
{
    public partial class LearnerHEFinancialSupport
    {
        public int UKPRN { get; set; }
        public string LearnRefNumber { get; set; }
        public int FINTYPE { get; set; }
        public int FINAMOUNT { get; set; }

        public virtual LearnerHE LearnerHE { get; set; }
    }
}
