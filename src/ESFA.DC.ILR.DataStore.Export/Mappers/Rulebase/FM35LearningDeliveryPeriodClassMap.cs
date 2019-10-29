using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class FM35LearningDeliveryPeriodClassMap : ClassMap<FM35_LearningDelivery_Period>
    {
        public FM35LearningDeliveryPeriodClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.Period);
            Map(m => m.AchievePayment);
            Map(m => m.AchievePayPct);
            Map(m => m.AchievePayPctTrans);
            Map(m => m.BalancePayment);
            Map(m => m.BalancePaymentUncapped);
            Map(m => m.BalancePct);
            Map(m => m.BalancePctTrans);
            Map(m => m.EmpOutcomePay);
            Map(m => m.EmpOutcomePct);
            Map(m => m.EmpOutcomePctTrans);
            Map(m => m.InstPerPeriod);
            Map(m => m.LearnSuppFund);
            Map(m => m.LearnSuppFundCash);
            Map(m => m.OnProgPayment);
            Map(m => m.OnProgPaymentUncapped);
            Map(m => m.OnProgPayPct);
            Map(m => m.OnProgPayPctTrans);
            Map(m => m.TransInstPerPeriod);
        }
    }
}
