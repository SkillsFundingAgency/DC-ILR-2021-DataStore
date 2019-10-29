using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Invalid
{
    public class InvalidLearnerDestinationandProgressionClassMap : ClassMap<LearnerDestinationandProgression>
    {
        public InvalidLearnerDestinationandProgressionClassMap()
        {
            Map(m => m.LearnerDestinationandProgression_Id);
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.ULN);
        }
    }
}
