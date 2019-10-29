using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearningDeliveryFAMClassMap : ClassMap<LearningDeliveryFAM>
    {
        public ValidLearningDeliveryFAMClassMap()
        {
            Map(m => m.LearningDeliveryFAM_Id);
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.LearnDelFAMType);
            Map(m => m.LearnDelFAMCode);
            Map(m => m.LearnDelFAMDateFrom);
            Map(m => m.LearnDelFAMDateTo);
        }
    }
}
