using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ALBLearningDeliveryPeriodClassMap : ClassMap<ALB_LearningDelivery_Period>
    {
        public ALBLearningDeliveryPeriodClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.Period);
            Map(m => m.AreaUpliftOnProgPayment);
            Map(m => m.AreaUpliftBalPayment);
            Map(m => m.ALBCode);
            Map(m => m.ALBSupportPayment);
        }
    }
}
