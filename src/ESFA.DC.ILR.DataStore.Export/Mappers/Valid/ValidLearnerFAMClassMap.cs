using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearnerFAMClassMap : ClassMap<LearnerFAM>
    {
        public ValidLearnerFAMClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.LearnFAMType);
            Map(m => m.LearnFAMCode);
        }
    }
}
