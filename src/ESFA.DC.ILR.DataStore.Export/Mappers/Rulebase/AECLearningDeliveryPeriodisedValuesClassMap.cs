using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class AECLearningDeliveryPeriodisedValuesClassMap : ClassMap<AEC_LearningDelivery_PeriodisedValue>
    {
        public AECLearningDeliveryPeriodisedValuesClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.AttributeName);
            Map(m => m.Period_1);
            Map(m => m.Period_2);
            Map(m => m.Period_3);
            Map(m => m.Period_4);
            Map(m => m.Period_5);
            Map(m => m.Period_6);
            Map(m => m.Period_7);
            Map(m => m.Period_8);
            Map(m => m.Period_9);
            Map(m => m.Period_10);
            Map(m => m.Period_11);
            Map(m => m.Period_12);
        }
    }
}
