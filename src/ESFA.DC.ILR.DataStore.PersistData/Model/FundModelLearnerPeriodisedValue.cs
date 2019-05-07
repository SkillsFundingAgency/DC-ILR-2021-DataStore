namespace ESFA.DC.ILR.DataStore.PersistData.Model
{
    public struct FundModelLearnerPeriodisedValue<T>
    {
        public FundModelLearnerPeriodisedValue(int ukprn, string learnRefNumber, T learnerPeriodisedValue)
        {
            Ukprn = ukprn;
            LearnRefNumber = learnRefNumber;
            LearnerPeriodisedValue = learnerPeriodisedValue;
        }

        public int Ukprn { get; }

        public string LearnRefNumber { get; }

        public T LearnerPeriodisedValue { get; }
    }
}
