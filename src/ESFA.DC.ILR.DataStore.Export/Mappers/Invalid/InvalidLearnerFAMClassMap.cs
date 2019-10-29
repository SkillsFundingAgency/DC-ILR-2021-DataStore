using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Invalid
{
    public class InvalidLearnerFAMClassMap : ClassMap<LearnerFAM>
    {
        public InvalidLearnerFAMClassMap()
        {
            Map(m => m.LearnerFAM_Id);
            Map(m => m.UKPRN);
            Map(m => m.Learner_Id);
            Map(m => m.LearnRefNumber);
            Map(m => m.LearnFAMType);
            Map(m => m.LearnFAMCode);
        }
    }
}
