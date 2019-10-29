using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearnerDestinationandProgressionClassMap : ClassMap<LearnerDestinationandProgression>
    {
        public ValidLearnerDestinationandProgressionClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.ULN);
        }
    }
}
