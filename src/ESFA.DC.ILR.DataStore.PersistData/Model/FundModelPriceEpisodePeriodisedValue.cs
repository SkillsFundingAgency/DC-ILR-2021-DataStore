namespace ESFA.DC.ILR1819.DataStore.PersistData.Model
{
    public struct FundModelPriceEpisodePeriodisedValue<T>
    {
        public FundModelPriceEpisodePeriodisedValue(int ukprn, string learnRefNumber, string priceEpisodeIdentifier, T priceEpisodePeriodisedValue)
        {
            Ukprn = ukprn;
            LearnRefNumber = learnRefNumber;
            PriceEpisodeIdentifier = priceEpisodeIdentifier;
            PriceEpisodePeriodisedValue = priceEpisodePeriodisedValue;
        }

        public int Ukprn { get; }

        public string LearnRefNumber { get; }

        public string PriceEpisodeIdentifier { get; }

        public T PriceEpisodePeriodisedValue { get; }
    }
}
