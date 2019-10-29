using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class ESFLearningDeliveryDeliverablePeriodClassMap : ClassMap<ESF_LearningDeliveryDeliverable_Period>
    {
        public ESFLearningDeliveryDeliverablePeriodClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.DeliverableCode);
            Map(m => m.Period);
            Map(m => m.AchievementEarnings);
            Map(m => m.AdditionalProgCostEarnings);
            Map(m => m.DeliverableVolume);
            Map(m => m.ProgressionEarnings);
            Map(m => m.ReportingVolume);
            Map(m => m.StartEarnings);
        }
    }
}
