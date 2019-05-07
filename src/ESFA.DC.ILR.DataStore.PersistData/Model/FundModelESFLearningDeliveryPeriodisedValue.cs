namespace ESFA.DC.ILR1819.DataStore.PersistData.Model
{
    public struct FundModelESFLearningDeliveryPeriodisedValue<T>
    {
        public FundModelESFLearningDeliveryPeriodisedValue(int ukprn, string learnRefNumber, int aimSeqNumber, string esfDeliverableCode, T learningDeliveryPeriodisedValue)
        {
            Ukprn = ukprn;
            LearnRefNumber = learnRefNumber;
            AimSeqNumber = aimSeqNumber;
            EsfDeliverableCode = esfDeliverableCode;
            LearningDeliveryPeriodisedValue = learningDeliveryPeriodisedValue;
        }

        public int Ukprn { get; }

        public string LearnRefNumber { get; }

        public int AimSeqNumber { get; }

        public string EsfDeliverableCode { get; }

        public T LearningDeliveryPeriodisedValue { get; }
    }
}
