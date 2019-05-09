namespace ESFA.DC.ILR.DataStore.PersistData.Model
{
    public struct FundModelLearningDeliveryPeriodisedValue<T>
    {
        public FundModelLearningDeliveryPeriodisedValue(int ukprn, string learnRefNumber, int aimSeqNumber, T learningDeliveryPeriodisedValue)
        {
            Ukprn = ukprn;
            LearnRefNumber = learnRefNumber;
            AimSeqNumber = aimSeqNumber;
            LearningDeliveryPeriodisedValue = learningDeliveryPeriodisedValue;
        }

        public int Ukprn { get; }

        public string LearnRefNumber { get; }

        public int AimSeqNumber { get; }

        public T LearningDeliveryPeriodisedValue { get; }
    }
}
