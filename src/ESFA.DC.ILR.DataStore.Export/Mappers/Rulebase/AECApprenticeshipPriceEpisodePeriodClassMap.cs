using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class AECApprenticeshipPriceEpisodePeriodClassMap : ClassMap<AEC_ApprenticeshipPriceEpisode_Period>
    {
        public AECApprenticeshipPriceEpisodePeriodClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.PriceEpisodeIdentifier);
            Map(m => m.Period);
            Map(m => m.PriceEpisodeApplic1618FrameworkUpliftBalancing);
            Map(m => m.PriceEpisodeApplic1618FrameworkUpliftCompletionPayment);
            Map(m => m.PriceEpisodeApplic1618FrameworkUpliftOnProgPayment);
            Map(m => m.PriceEpisodeBalancePayment);
            Map(m => m.PriceEpisodeBalanceValue);
            Map(m => m.PriceEpisodeCompletionPayment);
            Map(m => m.PriceEpisodeFirstDisadvantagePayment);
            Map(m => m.PriceEpisodeFirstEmp1618Pay);
            Map(m => m.PriceEpisodeFirstProv1618Pay);
            Map(m => m.PriceEpisodeInstalmentsThisPeriod);
            Map(m => m.PriceEpisodeLevyNonPayInd);
            Map(m => m.PriceEpisodeLSFCash);
            Map(m => m.PriceEpisodeOnProgPayment);
            Map(m => m.PriceEpisodeProgFundIndMaxEmpCont);
            Map(m => m.PriceEpisodeProgFundIndMinCoInvest);
            Map(m => m.PriceEpisodeSecondDisadvantagePayment);
            Map(m => m.PriceEpisodeSecondEmp1618Pay);
            Map(m => m.PriceEpisodeSecondProv1618Pay);
            Map(m => m.PriceEpisodeSFAContribPct);
            Map(m => m.PriceEpisodeTotProgFunding);
            Map(m => m.PriceEpisodeLearnerAdditionalPayment);
        }
    }
}
