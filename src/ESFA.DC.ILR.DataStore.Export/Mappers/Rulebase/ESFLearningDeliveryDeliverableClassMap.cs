using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ESFLearningDeliveryDeliverableClassMap : ClassMap<ESF_LearningDeliveryDeliverable>
    {
        public ESFLearningDeliveryDeliverableClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.DeliverableCode);
            Map(m => m.DeliverableUnitCost);
        }
    }
}
