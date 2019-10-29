using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Invalid
{
    public class InvalidLearningDeliveryFAMClassMap : ClassMap<LearningDeliveryFAM>
    {
        public InvalidLearningDeliveryFAMClassMap()
        {
            Map(m => m.LearningDeliveryFAM_Id);
            Map(m => m.UKPRN);
            Map(m => m.LearningDelivery_Id);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.LearnDelFAMType);
            Map(m => m.LearnDelFAMCode);
            Map(m => m.LearnDelFAMDateFrom);
            Map(m => m.LearnDelFAMDateTo);
        }
    }
}
