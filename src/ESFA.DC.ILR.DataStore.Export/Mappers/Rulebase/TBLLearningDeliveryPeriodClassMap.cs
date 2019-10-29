using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class TBLLearningDeliveryPeriodClassMap : ClassMap<TBL_LearningDelivery_Period>
    {
        public TBLLearningDeliveryPeriodClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.Period);
            Map(m => m.AchPayment);
            Map(m => m.CoreGovContPayment);
            Map(m => m.CoreGovContUncapped);
            Map(m => m.InstPerPeriod);
            Map(m => m.LearnSuppFund);
            Map(m => m.LearnSuppFundCash);
            Map(m => m.MathEngBalPayment);
            Map(m => m.MathEngBalPct);
            Map(m => m.MathEngOnProgPayment);
            Map(m => m.MathEngOnProgPct);
            Map(m => m.SmallBusPayment);
            Map(m => m.YoungAppFirstPayment);
            Map(m => m.YoungAppPayment);
            Map(m => m.YoungAppSecondPayment);
        }
    }
}
